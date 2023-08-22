using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using DataBase;
using System.Data.SqlClient;

namespace Fams
{
    public partial class frmRelFreqAllocValidity : Form
    {
        private int _comp_id;
        private long _freqA, _freqB;
        private double _bandwidthA, _bandwidthB;
        private string _nameA, _nameB;

        private BackgroundWorker backgroundWorker;
        List<Frequency> allocation = new List<Frequency>();

        List<Frequency> allowed_A = new List<Frequency>();
        List<Frequency> notAllowed_A = new List<Frequency>();
        List<Frequency> allowed_B = new List<Frequency>();
        List<Frequency> notAllowed_B = new List<Frequency>();
        int? aSelectedIndex;
        int? bSelectedIndex;
        private BindingSource _src;
        int _lic_id = -1;
        private DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter _adapter;
        private OfficeDataSet.fls_LICENCE_FREQDataTable _table;
        zone_cities cts;
        private BindingSource _linksSource;
        int _Aid, _Bid;


        public frmRelFreqAllocValidity(zone_cities cts, int comp_id, int lic_id, ref BindingSource src, ref DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter adapter, OfficeDataSet.fls_LICENCE_FREQDataTable table, int Aid, int Bid, BindingSource linksSource)
        {
            InitializeComponent();

            _src = src;
            _adapter = adapter;
            _lic_id = lic_id;
            _table = table;
            _Aid = Aid;
            _Bid = Bid;
            _linksSource = linksSource;
            this.cts = cts;

            _comp_id = comp_id;
            _freqA = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).ATX;
            _freqB = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).BTX;
            _bandwidthA = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).ATX_B;
            _bandwidthB = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).BTX_B;
            _nameA = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).AName;
            _nameB = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).BName;

            AText.Text = _nameA;
            BText.Text = _nameB;
            Alabel.Text = HelperFunctions.getHZ(_freqA) + ": " + HelperFunctions.getHZ(_bandwidthA);
            Blabel.Text = HelperFunctions.getHZ(_freqB) + ": " + HelperFunctions.getHZ(_bandwidthB);



            InitializeBackgroundWorker();
            backgroundWorker.RunWorkerAsync(15);
        }


        #region backgroundWorker

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.WorkerReportsProgress = true;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet ds = new DataSet();
            string connectionstring = DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string connectionstring_Fams = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection FamsConnection = new SqlConnection(connectionstring_Fams);

            string strSQL = "select * from PlansView";
            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd = new SqlCommand(strSQL, northwindConnection);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                allocation.Add(new Frequency(
                    ds.Tables[0].Rows[i]["Name"].ToString() + "_" + ds.Tables[0].Rows[i]["Block"].ToString() + "_" + ds.Tables[0].Rows[i]["Spacing"].ToString(),
                    Convert.ToInt64(ds.Tables[0].Rows[i]["Frequency"].ToString()),
                    Convert.ToDouble(ds.Tables[0].Rows[i]["Bandwidth"].ToString()),
                    Convert.ToInt32(ds.Tables[0].Rows[i]["CH"].ToString()),
                    Convert.ToBoolean(ds.Tables[0].Rows[i]["LowBand"].ToString())
                    ));
            }
            ds.Tables.Clear();

            #region fill listboxes

            //-----------------------A--------------------------------------
            
            foreach (Frequency f in allocation)
            {
                if (freqInRange(f, _freqA, _bandwidthA) == 1)
                {
                    Frequency ff = new Frequency("+ " + f.Alloc_Name, f.Freq, f.Bandwidth, f.Channel, f.Is_low_band);
                    allowed_A.Add(ff);
                }
                else if (freqInRange(f, _freqA, _bandwidthA) == 2)
                {
                    Frequency ff = new Frequency("- " + f.Alloc_Name, f.Freq, f.Bandwidth, f.Channel, f.Is_low_band);
                    notAllowed_A.Add(ff);
                }
            }

            foreach (Frequency ff in allowed_A)
                this.BeginInvoke((Action)delegate()
                {
                    ABox.Items.Add(ff.ToString());
                });

            foreach (Frequency ff in notAllowed_A)
                this.BeginInvoke((Action)delegate()
                {
                    ABox.Items.Add(ff.ToString());
                });

            //-----------------------B--------------------------------------
            
            foreach (Frequency f in allocation)
            {
                if (freqInRange(f, _freqB, _bandwidthB) == 1)
                {
                    Frequency ff = new Frequency("+ " + f.Alloc_Name, f.Freq, f.Bandwidth, f.Channel, f.Is_low_band);
                    allowed_B.Add(ff);
                }
                else if (freqInRange(f, _freqB, _bandwidthB) == 2)
                {
                    Frequency ff = new Frequency("- " + f.Alloc_Name, f.Freq, f.Bandwidth, f.Channel, f.Is_low_band);
                    notAllowed_B.Add(ff);
                }
            }

            foreach (Frequency ff in allowed_B)
                this.BeginInvoke((Action)delegate()
                {
                    BBox.Items.Add(ff.ToString());
                });

            foreach (Frequency ff in notAllowed_B)
                this.BeginInvoke((Action)delegate()
                {
                    BBox.Items.Add(ff.ToString());
                });

            #endregion

            
            #region select correct channels

            string A_AllocName="";
            for (int i=0; i<allowed_A.Count; i++)
                if (_freqA == allowed_A[i].Freq && _bandwidthA == allowed_A[i].Bandwidth)
                {
                    aSelectedIndex = i;
                    this.BeginInvoke((Action)delegate()
                    {
                        ABox.SelectedIndex = i;
                    });
                    A_AllocName = allowed_A[i].Alloc_Name;
                    break;
                }

            string B_AllocName="";
            for (int i = 0; i < allowed_B.Count; i++)
                if (_freqB == allowed_B[i].Freq && _bandwidthB == allowed_B[i].Bandwidth)
                {
                    bSelectedIndex = i;
                    this.BeginInvoke((Action)delegate()
                    {
                        BBox.SelectedIndex = i;
                    });
                    B_AllocName = allowed_B[i].Alloc_Name;
                    break;
                }


            if (A_AllocName != "" && B_AllocName != "" && A_AllocName.Equals(B_AllocName))
            {
                this.BeginInvoke((Action)delegate()
                {
                    this.Text += " - " + A_AllocName;
                    okBtn.BackColor = Color.LightGreen;
                });
            }
            else this.BeginInvoke((Action)delegate() { okBtn.BackColor = Color.Pink; });
            #endregion
        
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.

            }
            else
            {
                // Finally, handle the case where the operation  
                // succeeded.

            }



        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        #endregion

        private int freqInRange(Frequency f, long frq, double bandwidth)
        {
            double ffrom = frq - bandwidth / 2;
            double fto = frq + bandwidth / 2;
            double allocFreqFrom = f.Freq - f.Bandwidth / 2;
            double allocFreqTo = f.Freq + f.Bandwidth / 2;

            if (ffrom >= allocFreqFrom && fto <= allocFreqTo) return 1; //an zustadaa an jdeba sazgvrebshi

            if ((ffrom <= allocFreqFrom && fto >= allocFreqFrom) ||
                (ffrom <= allocFreqTo && fto >= allocFreqTo)) return 2; //kvets saxgvrebs
            else return 0;  //sazgvrebs garetaa
        }

        private void Box_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            try
            {
                if (e.Index != ((ListBox)sender).SelectedIndex)
                {
                    if (((ListBox)sender).Items[e.Index].ToString().FirstOrDefault() == '+') e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds);
                    else e.Graphics.FillRectangle(Brushes.LightPink, e.Bounds);
                    e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, Brushes.Black, new System.Drawing.PointF(e.Bounds.X, e.Bounds.Y));
                }
                else
                    using (Brush textBrush = new SolidBrush(e.ForeColor))
                    {
                        e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, textBrush, e.Bounds.Location);
                    }
            }
            catch { }
        }

        private void Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ListBox)sender).Refresh();
            
            if (ABox.SelectedIndex != aSelectedIndex && ABox.SelectedIndex < allowed_A.Count) 
                a_saveBtn.Enabled = ABox.SelectedIndex >= 0;
            else a_saveBtn.Enabled = false;

            if (BBox.SelectedIndex != bSelectedIndex && BBox.SelectedIndex < allowed_B.Count) 
                b_saveBtn.Enabled = BBox.SelectedIndex >= 0;
            else b_saveBtn.Enabled = false;
        }



        private int SaveFreq(long f, int bwth, int city_id)
        {
            //ne vipolnyaem vibor licenzii, poskolku mi ee peredaem pri sozdanii formi
            #region vibor licenzii dlya zapisi
            if (_lic_id < 0)
            {
                frmPickLicence lic = new frmPickLicence(_comp_id);
                if (lic.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) _lic_id = lic.licence_id;
                else
                {
                    lic.Dispose();
                    MessageBox.Show("Execution stopped");
                    return -1;
                }
            }

            #endregion


            int id = -1;

            //sperva proveryaem net li uje takoi chastoti v baze
            DataSet ds = Helpers.Functions.fill(string.Format("select count(*) as raod from  dbo.fls_LICENCE_FREQ where FREQ={0} and Bandwidth={1} and city_id={2} and licence_id={3}", new object[] { f, bwth, city_id, _lic_id }), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            //esli takoi chastoti net to dobavlyaem ee
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["raod"].ToString()) == 0)
            {
                _src.AddNew();
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).FREQ = f;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).BandWidth = bwth;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).city_id = city_id;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).licence_id = _lic_id;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).reestrit = false;
                _src.EndEdit();
                _adapter.Update(_table);
                id = ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).id;

            }
            //tu egeti arsebobs - vedzebt mis id-s
            else
            {
                ds = Helpers.Functions.fill(string.Format("select id from  dbo.fls_LICENCE_FREQ where FREQ={0} and Bandwidth={1} and city_id={2} and licence_id={3}", new object[] { f, bwth, city_id, _lic_id }), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            return id;
        }

        private void a_saveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("გსურთ არჩეული სიხშირის შეცვლა მონაცემთა ბაზაში?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //vtsert pirvel sixshires A punktshi rogorc TX da meorestvis rogorc RX
                _linksSource.Position = this._linksSource.Find("Aid", _Aid);
                string City = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).ATX_city.Trim();
                int city_id = -1;
                foreach (city ct in cts.cities)
                    if (City.Equals(ct.name))
                    {
                        city_id = ct.id;
                        break;
                    }
                int? TX = SaveFreq(allowed_A[ABox.SelectedIndex].Freq, (Int32)(allowed_A[ABox.SelectedIndex].Bandwidth), city_id);
                if (TX < 0) return;

                _linksSource.Position = this._linksSource.Find("Bid", _Bid);
                City = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BRX_city.Trim();
                city_id = -1;
                foreach (city ct in cts.cities)
                    if (City.Equals(ct.name))
                    {
                        city_id = ct.id;
                        break;
                    }
                int? RX = SaveFreq(allowed_A[ABox.SelectedIndex].Freq, (Int32)(allowed_A[ABox.SelectedIndex].Bandwidth), city_id);
                if (RX < 0) return;

                string stx = string.Format("update st_rel_fixed set TX_FREQ_id={0} where id={1}", TX, _Aid); System.Diagnostics.Debug.WriteLine(stx);
                HelperFunctions.ExecuteNonQuery(stx, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                string srx = string.Format("update st_rel_fixed set RX_FREQ_id={0} where id={1}", RX, _Bid); System.Diagnostics.Debug.WriteLine(srx);
                HelperFunctions.ExecuteNonQuery(srx, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());

                cancelBtn.Enabled = false;
                okBtn.Enabled = true;
            }

            
        }

        private void b_saveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("გსურთ არჩეული სიხშირის შეცვლა მონაცემთა ბაზაში?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //vtsert pirvel sixshires A punktshi rogorc TX da meorestvis rogorc RX
                _linksSource.Position = this._linksSource.Find("Bid", _Bid);
                string City = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BTX_city.Trim();
                int city_id = -1;
                foreach (city ct in cts.cities)
                    if (City.Equals(ct.name))
                    {
                        city_id = ct.id;
                        break;
                    }
                int? TX = SaveFreq(allowed_B[BBox.SelectedIndex].Freq, (Int32)(allowed_B[BBox.SelectedIndex].Bandwidth), city_id);
                if (TX < 0) return;

                _linksSource.Position = this._linksSource.Find("Aid", _Aid);
                City = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).ARX_city.Trim();
                city_id = -1;
                foreach (city ct in cts.cities)
                    if (City.Equals(ct.name))
                    {
                        city_id = ct.id;
                        break;
                    }
                int? RX = SaveFreq(allowed_B[BBox.SelectedIndex].Freq, (Int32)(allowed_B[BBox.SelectedIndex].Bandwidth), city_id);
                if (RX < 0) return;

                string stx = string.Format("update st_rel_fixed set TX_FREQ_id={0} where id={1}", TX, _Bid); System.Diagnostics.Debug.WriteLine(stx);
                HelperFunctions.ExecuteNonQuery(stx, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                string srx = string.Format("update st_rel_fixed set RX_FREQ_id={0} where id={1}", RX, _Aid); System.Diagnostics.Debug.WriteLine(srx);
                HelperFunctions.ExecuteNonQuery(srx, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());

                cancelBtn.Enabled = false;
                okBtn.Enabled = true;
            }

            
        }


    }




}
