using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Helpers;
using DevExpress.Utils;
using System.Globalization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using DataBase;
using System.Diagnostics;

namespace Fams
{
    public partial class frmDBfreq : Form
    {
        private List<dbRes> dbResNums = new List<dbRes>();
        private List<dbFreq> dbFrequencies = new List<dbFreq>();
        private List<string> myResNums = new List<string>();
        private User _user;
        private List<string> clipboard = new List<string>();

        public frmDBfreq(User us)
        {
            this._user = us;
            CultureInfo cultureInfo = new CultureInfo("ka-GE");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            this.InitializeComponent();
            this.colFREQ.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatterHZ();
            this.colFREQ.DisplayFormat.FormatType = FormatType.Custom;
            this.col_freq_FREQ.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatter();
            this.col_freq_FREQ.DisplayFormat.FormatType = FormatType.Custom;
            this.colBandWidth.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatterHZ();
            this.colBandWidth.DisplayFormat.FormatType = FormatType.Custom;
            this.col_freq_BandWidth.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatter();
            this.col_freq_BandWidth.DisplayFormat.FormatType = FormatType.Custom;
            this.vCompaniesComparisonTableAdapter.Fill(this.officeDataSet.vCompaniesComparison);
        }

        private void myGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                dbResNums.Clear();
                string TaxCode = ((OfficeDataSet.vCompaniesComparisonRow)((DataRowView)vCompaniesComparisonBindingSource.Current).Row).TaxCode.ToString();
                vLicenseFreqsTableAdapter.FillByTax(this.officeDataSet.vLicenseFreqs, TaxCode);
                addLicenceBtn.Enabled = this.vLicenseFreqsBindingSource.Count > 0;
                Text = TaxCode + " - " + ((OfficeDataSet.vCompaniesComparisonRow)((DataRowView)vCompaniesComparisonBindingSource.Current).Row).Comp_Name.ToString();
                fls_LICENCE_INFOTableAdapter.FillByComp(officeDataSet.fls_LICENCE_INFO, int.Parse(((OfficeDataSet.vCompaniesComparisonRow)((DataRowView)vCompaniesComparisonBindingSource.Current).Row).id.ToString()));
                GridView gridView1 = (GridView)freqGridView;
                int num = fls_LICENCE_INFOBindingSource.Find("LICENCE", gridView1.GetFocusedRowCellValue(colLicNum));
                fls_LICENCE_INFOBindingSource.Position = num < 0 ? fls_LICENCE_INFOBindingSource.Find("LICENCE", gridView1.GetFocusedRowCellValue(colResNum)) : num;
                for (int rowHandle = 0; rowHandle < gridView1.DataRowCount; ++rowHandle)
                    dbResNums.Add(new dbRes(gridView1.GetRowCellValue(rowHandle, colResNum).ToString(), gridView1.GetRowCellValue(rowHandle, colLicNum).ToString(), gridView1.GetRowCellValue(rowHandle, colResDate).ToString(), gridView1.GetRowCellValue(rowHandle, colEndDate).ToString()));
                GridView gridView2 = (GridView)myLicGridView;
                myResNums.Clear();
                for (int rowHandle = 0; rowHandle < gridView2.DataRowCount; ++rowHandle)
                    myResNums.Add(gridView2.GetRowCellValue(rowHandle, colLICENCE).ToString());
            }
            catch
            {
                this.Text = "";
                this.fls_LICENCE_INFOTableAdapter.FillByComp(this.officeDataSet.fls_LICENCE_INFO, -1);
            }
        }

        private void freqGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.dbDecisionBtn.Enabled = this.freqGridView.RowCount > 0;
            GridView gridView = sender as GridView;
            int num = this.fls_LICENCE_INFOBindingSource.Find("LICENCE", gridView.GetFocusedRowCellValue(this.colLicNum));
            this.fls_LICENCE_INFOBindingSource.Position = num < 0 ? this.fls_LICENCE_INFOBindingSource.Find("LICENCE", gridView.GetFocusedRowCellValue(this.colResNum)) : num;
            this.vFreqsTableAdapter.Fill(this.officeDataSet.vFreqs, gridView.GetFocusedRowCellValue(this.colTax).ToString(), gridView.GetFocusedRowCellValue(this.colOrg).ToString(), gridView.GetFocusedRowCellValue(this.colResNum).ToString(), gridView.GetFocusedRowCellValue(this.colLicNum).ToString());
            this.dbFrequencies.Clear();
            for (int rowHandle = 0; rowHandle < this.vFreqsGridView.DataRowCount; ++rowHandle)
                this.dbFrequencies.Add(new dbFreq(this.vFreqsGridView.GetRowCellValue(rowHandle, this.colFREQ).ToString(), this.vFreqsGridView.GetRowCellValue(rowHandle, this.colBandWidth).ToString(), this.vFreqsGridView.GetRowCellValue(rowHandle, this.colcity).ToString()));
        }

        private void myLicGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                this.fls_LICENCE_FREQTableAdapter.FillByLic(this.officeDataSet.fls_LICENCE_FREQ, int.Parse(((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).id.ToString()));
            }
            catch
            {
                this.fls_LICENCE_FREQTableAdapter.FillByLic(this.officeDataSet.fls_LICENCE_FREQ, -1);
            }
            GridView gridView = sender as GridView;
            this.decisionBtn.Enabled = this.myLicGridView.RowCount > 0 && gridView.GetFocusedRowCellValue(this.colLIC_ISSU_DATE).ToString() != "" && gridView.GetFocusedRowCellValue(this.colLIC_EXPIRY_DATE).ToString() != "";
            addFreqBtn.Enabled = this.vFreqsBindingSource.Count > 0;
            reestritBtn.Enabled = Convert.ToBoolean(fls_LICENCE_FREQBindingSource.Count);
        }

        private void freqGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Column.FieldName == "ResNum")
            {
                bool flag = true;
                foreach (string str in this.myResNums)
                {
                    if (gridView.GetRowCellValue(e.RowHandle, this.colResNum).ToString() == str)
                        flag = false;
                }
                e.Appearance.BackColor = flag ? Color.Pink : Color.LightGreen;
            }
            if (!(e.Column.FieldName == "LicNum"))
                return;
            bool flag1 = false;
            foreach (string str in this.myResNums)
            {
                if (gridView.GetRowCellValue(e.RowHandle, this.colLicNum).ToString() == str)
                    flag1 = true;
            }
            if (!flag1)
                return;
            e.Appearance.BackColor = Color.LightGreen;
        }

        private void decisionBtn_Click(object sender, EventArgs e)
        {
            CultureInfo cultureInfo1 = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo1;
            Thread.CurrentThread.CurrentUICulture = cultureInfo1;
            new decision().ShowDecision(new FREQVIEW()
            {
                LICENCE = ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).LICENCE.ToString(),
                LIC_ISSU_DATE = ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).LIC_ISSU_DATE.ToString(),
                LIC_EXPIRY_DATE = ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).LIC_EXPIRY_DATE.ToString()
            });
            CultureInfo cultureInfo2 = new CultureInfo("ka-GE");
            Thread.CurrentThread.CurrentCulture = cultureInfo2;
            Thread.CurrentThread.CurrentUICulture = cultureInfo2;
        }

        private void dbDecisionBtn_Click(object sender, EventArgs e)
        {
            CultureInfo cultureInfo1 = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = cultureInfo1;
            Thread.CurrentThread.CurrentUICulture = cultureInfo1;
            new decision().ShowDecision(new FREQVIEW()
            {
                LICENCE = ((OfficeDataSet.vLicenseFreqsRow)((DataRowView)this.vLicenseFreqsBindingSource.Current).Row).ResNum.ToString(),
                LIC_ISSU_DATE = ((OfficeDataSet.vLicenseFreqsRow)((DataRowView)this.vLicenseFreqsBindingSource.Current).Row).ResDate.ToString(),
                LIC_EXPIRY_DATE = ((OfficeDataSet.vLicenseFreqsRow)((DataRowView)this.vLicenseFreqsBindingSource.Current).Row).EndDate.ToString()
            });
            CultureInfo cultureInfo2 = new CultureInfo("ka-GE");
            Thread.CurrentThread.CurrentCulture = cultureInfo2;
            Thread.CurrentThread.CurrentUICulture = cultureInfo2;
        }

        private void myLicGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.Column.FieldName == "LIC_ISSU_DATE")
            {
                foreach (dbRes dbRes in this.dbResNums)
                {
                    if (gridView.GetRowCellValue(e.RowHandle, this.colLICENCE).ToString() == dbRes._colResNum || gridView.GetRowCellValue(e.RowHandle, this.colLICENCE).ToString() == dbRes._colLicNum)
                        e.Appearance.BackColor = !(gridView.GetRowCellValue(e.RowHandle, this.colLIC_ISSU_DATE).ToString() != dbRes._colResDate) ? Color.LightGreen : Color.Pink;
                }
            }
            if (!(e.Column.FieldName == "LIC_EXPIRY_DATE"))
                return;
            foreach (dbRes dbRes in this.dbResNums)
            {
                if (gridView.GetRowCellValue(e.RowHandle, this.colLICENCE).ToString() == dbRes._colResNum || gridView.GetRowCellValue(e.RowHandle, this.colLICENCE).ToString() == dbRes._colLicNum)
                    e.Appearance.BackColor = !(gridView.GetRowCellValue(e.RowHandle, this.colLIC_EXPIRY_DATE).ToString() != dbRes._colEndDate) ? Color.LightGreen : Color.Pink;
            }
        }

        private void myFreqGridView_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (!(e.Column.FieldName == "FREQ"))
                return;
            bool flag = false;
            foreach (dbFreq dbFreq in this.dbFrequencies)
            {
                if (int.Parse(gridView.GetRowCellValue(e.RowHandle, this.col_freq_FREQ).ToString()) == dbFreq.FREQ && int.Parse(gridView.GetRowCellValue(e.RowHandle, this.colBandWidth).ToString()) == dbFreq.BandWidth && gridView.GetRowCellValue(e.RowHandle, this.colfunction_getCityName).ToString() == dbFreq.city)
                    flag = true;
            }
            e.Appearance.BackColor = flag ? Color.LightGreen : Color.Pink;
        }

        private void freqCheckedBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("გნებავთ ამ სიხშირის აღნიშვნა როგორც შესრულებული?", "ინფორმაცია", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            GridView gridView1 = (GridView)this.vFreqsGridView;
            int[] selectedRows = gridView1.GetSelectedRows();
            for (int index = 0; index < Enumerable.Count<int>((IEnumerable<int>)selectedRows); ++index)
            {
                HelperFunctions.ExecuteNonQuery(string.Format("INSERT INTO [Fams].[dbo].[_FreqsFromGnccDB_IDs] ([vFreqID]) VALUES ('{0}')", gridView1.GetRowCellValue(selectedRows[index], this.colvFreqID)), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                Application.DoEvents();
            }
            GridView gridView2 = (GridView)this.freqGridView;
            int focusedRowHandle1 = gridView2.FocusedRowHandle;
            this.vLicenseFreqsTableAdapter.FillByTax(this.officeDataSet.vLicenseFreqs, ((OfficeDataSet.vCompaniesComparisonRow)((DataRowView)this.vCompaniesComparisonBindingSource.Current).Row).TaxCode.ToString());
            gridView2.FocusedRowHandle = focusedRowHandle1;
            if (this.freqGridView.RowCount != 0)
                return;
            GridView gridView3 = (GridView)this.myGridView;
            int focusedRowHandle2 = gridView3.FocusedRowHandle;
            this.vCompaniesComparisonTableAdapter.Fill(this.officeDataSet.vCompaniesComparison);
            gridView3.FocusedRowHandle = focusedRowHandle2;
        }

        private void myLicGridView_DoubleClick(object sender, EventArgs e)
        {
            if (this._user.EditFreqLic)
            {
                GridView gridView = sender as GridView;
                this.fls_LICENCE_INFOBindingSource.Position = this.fls_LICENCE_INFOBindingSource.Find("id", (object)Convert.ToInt32(gridView.GetDataRow(gridView.FocusedRowHandle)["id"]));
                if (new frmEditLicence(ref this.fls_LICENCE_INFOBindingSource).ShowDialog() != DialogResult.OK)
                    return;
                this.fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.fls_LICENCE_INFO);
            }
            else
            {
                int num = (int)MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void addLicenceBtn_Click(object sender, EventArgs e)
        {
            if (this._user.EditFreqLic)
            {
                GridView gridView1 = (GridView)this.myGridView;
                int num = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["id"]);
                this.fls_LICENCE_INFOBindingSource.AddNew();
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).comp_id = num;
                GridView gridView2 = (GridView)this.freqGridView;
                string str = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, this.colResNum).ToString();
                if (str == "GD" || str == "")
                    str = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, this.colLicNum).ToString();
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).LICENCE = str;
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).LIC_ISSU_DATE = Convert.ToDateTime(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, this.colResDate).ToString());
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).LIC_EXPIRY_DATE = Convert.ToDateTime(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, this.colEndDate).ToString());
                if (new frmEditLicence(ref this.fls_LICENCE_INFOBindingSource).ShowDialog() != DialogResult.OK)
                    return;
                this.fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.fls_LICENCE_INFO);
                int focusedRowHandle = this.freqGridView.FocusedRowHandle;
                this.myGridView_FocusedRowChanged((object)this.myGridView, (FocusedRowChangedEventArgs)null);
                this.freqGridView.FocusedRowHandle = focusedRowHandle;
            }
            else
            {
                int num1 = (int)MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void addFreqBtn_Click(object sender, EventArgs e)
        {
            if (this._user.AddFreq)
            {
                GridView gridView1 = (GridView)this.myLicGridView;
                int num1 = Convert.ToInt32(gridView1.GetDataRow(gridView1.FocusedRowHandle)["id"]);
                this.fls_LICENCE_FREQBindingSource.AddNew();
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)this.fls_LICENCE_FREQBindingSource.Current).Row).licence_id = num1;
                string str = "საქართველო";
                frmEditFreq frmEditFreq;
                try
                {
                    int num2 = int.Parse((((OfficeDataSet.vFreqsRow)((DataRowView)this.vFreqsBindingSource.Current).Row).FREQ / 1000L).ToString());
                    int num3 = int.Parse((((OfficeDataSet.vFreqsRow)((DataRowView)this.vFreqsBindingSource.Current).Row).BandWidth / 1000L).ToString());
                    str = ((OfficeDataSet.vFreqsRow)((DataRowView)this.vFreqsBindingSource.Current).Row).city;
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)this.fls_LICENCE_FREQBindingSource.Current).Row).FREQ = (long)num2;
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)this.fls_LICENCE_FREQBindingSource.Current).Row).BandWidth = num3;
                    frmEditFreq = new frmEditFreq(ref this.fls_LICENCE_FREQBindingSource, this._user, 1);
                }
                catch
                {
                    frmEditFreq = new frmEditFreq(ref this.fls_LICENCE_FREQBindingSource, this._user, 0);
                }
                try
                {
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)this.fls_LICENCE_FREQBindingSource.Current).Row).city_id = int.Parse(HelperFunctions.fill(string.Format("select dbo.getZone(N'{0}')", (object)str), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString()).Tables[0].Rows[0][0].ToString());
                }
                catch
                {
                }
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)this.fls_LICENCE_FREQBindingSource.Current).Row).reestrit = true;
                if (frmEditFreq.ShowDialog() != DialogResult.OK)
                    return;
                this.fls_LICENCE_FREQTableAdapter.Update(this.officeDataSet.fls_LICENCE_FREQ);
                try
                {
                    GridView gridView2 = (GridView)this.vFreqsGridView;
                    gridView2.FocusedRowHandle = gridView2.FocusedRowHandle + 1;
                }
                catch
                {
                }
            }
            else
            {
                int num = (int)MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void vFreqsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.addFreqBtn.Enabled = this.vFreqsGridView.SelectedRowsCount == 1;
        }

        private void cancelLicBtn_Click(object sender, EventArgs e)
        {
            if (this._user.EditLicence)
            {
                GridView gridView = (GridView)this.myLicGridView;
                Convert.ToInt32(gridView.GetDataRow(gridView.FocusedRowHandle)["id"]);
                if (MessageBox.Show("გნებავთ ამ ლიცენზიის გაუქმება/აღდგენა?", "ინფორმაცია", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                bool flag = false;
                try
                {
                    flag = ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).isCanceled;
                }
                catch
                {
                }
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)this.fls_LICENCE_INFOBindingSource.Current).Row).isCanceled = !flag;
                this.fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.fls_LICENCE_INFO);
            }
            else
            {
                int num = (int)MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void myLicGridView_RowCountChanged(object sender, EventArgs e)
        {
            this.cancelLicBtn.Enabled = (sender as GridView).RowCount > 0;
        }

        private void freqGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 3)
            {
                clipboard.Clear();
                GridView view = sender as GridView;

                clipboard.Add(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[0]).ToString());
                clipboard.Add(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[2]).ToString());
                clipboard.Add(view.GetRowCellValue(view.FocusedRowHandle, view.Columns[4]).ToString());

                Clipboard.SetData("myFormat", clipboard);
            }
        }


        private void myLicGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22 && Clipboard.ContainsData("myFormat"))
            {
                GridView view = sender as GridView;
                List<string> result = (List<string>)Clipboard.GetData("myFormat");
                int focusedRow = view.FocusedRowHandle;
                int id = Convert.ToInt32(view.GetRowCellValue(focusedRow, colid1));
                fls_LICENCE_INFOBindingSource.Position = this.fls_LICENCE_INFOBindingSource.Find("id", id);

                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LICENCE = result[0];
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LIC_ISSU_DATE = Convert.ToDateTime(result[1]);
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LIC_EXPIRY_DATE = Convert.ToDateTime(result[2]);
                fls_LICENCE_INFOBindingSource.EndEdit();
                fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.fls_LICENCE_INFO);

                view.FocusedRowHandle = focusedRow;
            }
            e.Handled = true;
        }

        private void reestritBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("გნებავთ ამ სიხშირეების აღნიშვნა როგორც რეესტრით შეტანილი?", "ინფორმაცია", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            GridView view = myFreqGridView;
            Debug.WriteLine(fls_LICENCE_FREQBindingSource.Count);
            for (int i = 0; i < fls_LICENCE_FREQBindingSource.Count; i++)
            {
                fls_LICENCE_FREQBindingSource.Position = i;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).reestrit = true;
                fls_LICENCE_FREQTableAdapter.Update(officeDataSet.fls_LICENCE_FREQ);
            }
        }

        private void myGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myGridView_FocusedRowChanged(sender, null);
        }

    }

    public class dbFreq
    {
        public int FREQ = -1;
        public int BandWidth = -1;
        public string city;

        public dbFreq(string F, string B, string c)
        {
            try
            {
                this.FREQ = int.Parse(F) / 1000;
                this.BandWidth = int.Parse(B) / 1000;
            }
            catch
            {
            }
            this.city = c;
        }
    }

    public class dbRes
    {
        public string _colResNum;
        public string _colLicNum;
        public string _colResDate;
        public string _colEndDate;

        public dbRes(string cResNum, string cLicNum, string cResDate, string cEndDate)
        {
            this._colResNum = cResNum;
            this._colLicNum = cLicNum;
            this._colResDate = cResDate;
            this._colEndDate = cEndDate;
        }
    }
}
