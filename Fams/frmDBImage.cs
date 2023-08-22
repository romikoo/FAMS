using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using DataBase;
using Helpers;

namespace Fams
{
    public partial class frmDBImage : Form
    {
        private const string pasteFormat = "System.Drawing.Bitmap";
        private Boolean _EditImages;

        public frmDBImage(User us)
        {
            InitializeComponent();
            _EditImages = us.FreqGraph;
        }


        private void frmDBImage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'officeDataSet.fls_Monitoring_Images' table. You can move, or remove it, as needed.
            try
            {
                this.fls_Monitoring_ImagesTableAdapter.Fill(this.officeDataSet.fls_Monitoring_Images);
            }
            catch {
                DataSet ds = new DataSet();
                string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
                SqlConnection northwindConnection = new SqlConnection(connectionstring);
                string strSQL = "delete from dbo.fls_Monitoring_Images WHERE img is null";
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                this.fls_Monitoring_ImagesTableAdapter.Fill(this.officeDataSet.fls_Monitoring_Images);
            }

            freqList.SelectedIndex = 0;
            siteCombo.SelectedIndex = 0;

            PasteBtn.Visible = _EditImages;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RepSetupImages setup = new RepSetupImages();
            setup.ShowDialog();
        }

        private void PasteBtn_Click(object sender, EventArgs e)
        {
            string filetoplay = "fault.wav";

            object obj; // used to hold data to be pasted;
            this.picturePaste.Image = null;
            // Ensure that the Clipboard can support the selected format
            if (Clipboard.GetDataObject().GetDataPresent(pasteFormat))
            {
                // Set obj to the data on the clipboard, in the requested format
                obj = Clipboard.GetDataObject().GetData(pasteFormat);
                if (obj != null)
                {
                    // Attempt to paste into the PictureBox
                    //   if it fails, the PictureBox does not support this
                    //   format, so clear the image by setting Image to null.
                    try
                    {
                        picturePaste.Image = (Image)obj;
                    }
                    catch { picturePaste.Image = null; return; }

                    //-------------zapis' v bazu----------------------------------------------
                    MemoryStream ms = new MemoryStream();
                    picturePaste.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] arrImage = ms.GetBuffer();
                    ms.Close();
                    try
                    {
                        fls_Monitoring_ImagesBindingSource.AddNew();
                        ((OfficeDataSet.fls_Monitoring_ImagesRow)((DataRowView)fls_Monitoring_ImagesBindingSource.Current).Row).freq = freqList.Items[freqList.SelectedIndex].ToString();
                        ((OfficeDataSet.fls_Monitoring_ImagesRow)((DataRowView)fls_Monitoring_ImagesBindingSource.Current).Row).insDate = DateTime.Now;
                        //((OfficeDataSet.fls_Monitoring_ImagesRow)((DataRowView)fls_Monitoring_ImagesBindingSource.Current).Row).img = arrImage;
                        ((OfficeDataSet.fls_Monitoring_ImagesRow)((DataRowView)fls_Monitoring_ImagesBindingSource.Current).Row).site = siteCombo.Items[siteCombo.SelectedIndex].ToString();
                        //((DataRowView)fls_Monitoring_ImagesBindingSource.Current).Row["img"] = arrImage;

                        this.Validate();
                        this.fls_Monitoring_ImagesBindingSource.EndEdit();
                        this.fls_Monitoring_ImagesTableAdapter.Update(this.officeDataSet.fls_Monitoring_Images);

                        queriesTableAdapter1.UpdateImgGraph(arrImage);

                        //DataSet ds = new DataSet();
                        //string connectionstring = Properties.Settings.Default.OfficeConnectionString.ToString();
                        //SqlConnection northwindConnection = new SqlConnection(connectionstring);
                        //string strSQL = "UPDATE    dbo.fls_Monitoring_Images SET              img = " + arrImage + " WHERE     (id = (SELECT     MAX(id) AS Expr1    FROM          dbo.fls_Monitoring_Images))";
                        //SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                        //SqlDataAdapter da = new SqlDataAdapter(cmd);
                        //da.Fill(ds);





                        filetoplay = "ok.wav";
                    }
                    catch (SqlException sqlExc)
                    {
                        MessageBox.Show(Convert.ToString(sqlExc), "SQL Exception Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        filetoplay = "fault.wav";
                    }
                    //------------------zapisano----------------------------------------------

                    try
                    {
                        freqList.SelectedIndex += 1;
                    }
                    catch { freqList.SelectedIndex = 0; }
                }
            }

            //zakoncheno i zapisano, rabotaem s clipbord---------------------------

            if (freqList.Items[freqList.SelectedIndex].ToString() == "FM") Clipboard.SetData("System.String", "100.5 MHz");
            else Clipboard.SetData("System.String", freqList.Items[freqList.SelectedIndex].ToString() + " MHz");
            PasteBtn.Enabled = false;

            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(filetoplay);
                player.Play();
            }
            catch { }
        }

        private void freqList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PasteBtn.Text = siteCombo.Items[siteCombo.SelectedIndex] + " - " + freqList.Items[freqList.SelectedIndex].ToString() + " სიხშირის  გრაფიკის შენახვა";
            }
            catch { }
        }

        private void frmDBImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(pasteFormat)) PasteBtn.Enabled = true; else PasteBtn.Enabled = false;
        }

        private void gridEX1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                this.tmp_ImagesTableAdapter.Fill(this.officeDataSet.tmp_Images, (int)gridEX1.GetValue("id"));
            }
            catch { return;}


            try
            {
                byte[] arrPicture = ((byte[])((OfficeDataSet.tmp_ImagesRow)((DataRowView)tmp_ImagesBindingSource.Current).Row).img);

                MemoryStream ms = new MemoryStream(arrPicture);
                picturePaste.Image = Image.FromStream(ms);
                ms.Close();
            }
            catch { }
        }

        private void gridEX1_DeletingRecords(object sender, CancelEventArgs e)
        {
            if (!_EditImages) { e.Cancel = true; return; }
            if (MessageBox.Show("ნამდვილად გნებავთ ამ ჩანაწერის წაშლა?", "გთხოვთ დაადასტუროთ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
        }

        private void gridEX1_RecordsDeleted(object sender, EventArgs e)
        {
            this.fls_Monitoring_ImagesTableAdapter.Update(this.officeDataSet.fls_Monitoring_Images);
        }

        private void gridEX1_GroupsChanged(object sender, Janus.Windows.GridEX.GroupsChangedEventArgs e)
        {
            gridEX1.GroupMode = Janus.Windows.GridEX.GroupMode.Collapsed;
        }

        private void gridEX1_CellEdited(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            this.Validate();
            this.fls_Monitoring_ImagesBindingSource.EndEdit();
            this.fls_Monitoring_ImagesTableAdapter.Update(this.officeDataSet.fls_Monitoring_Images);
        }


    }
}