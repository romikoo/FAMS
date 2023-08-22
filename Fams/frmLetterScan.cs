using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataBase;
using Helpers;

namespace Fams
{
    public partial class frmLetterScan : Form
    {
        private int _letter_id;

        public frmLetterScan(int letter_id, User usr)
        {
            InitializeComponent();

            _letter_id = letter_id;

            if (!usr.Nebartva)
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = false;
                browseBtn.Enabled = false;
            }
        }

        private void acc_Letters_scanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.acc_Letters_scanBindingSource.EndEdit();
            this.acc_Letters_scanTableAdapter.Update(this.officeDataSet.acc_Letters_scan);

        }

        private void frmLetterScan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'officeDataSet.acc_Letters_scan' table. You can move, or remove it, as needed.
            this.acc_Letters_scanTableAdapter.FillByLetter(this.officeDataSet.acc_Letters_scan, _letter_id);
            updateImage();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                acc_Letters_scanBindingSource.AddNew();

                Image img = Image.FromFile(openFileDialog.FileName);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arrImage = ms.GetBuffer();
                ((OfficeDataSet.acc_Letters_scanRow)((DataRowView)acc_Letters_scanBindingSource.Current).Row).img = arrImage;
                ms.Close();
                updateImage();

                ((OfficeDataSet.acc_Letters_scanRow)((DataRowView)acc_Letters_scanBindingSource.Current).Row).letter_id = _letter_id;
                acc_Letters_scanBindingSource.EndEdit();
                acc_Letters_scanTableAdapter.Update(this.officeDataSet.acc_Letters_scan);
            }
        }


        private bool updateImage()
        {
            try
            {
                byte[] arrPicture = ((byte[])((OfficeDataSet.acc_Letters_scanRow)((DataRowView)acc_Letters_scanBindingSource.Current).Row).img);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(arrPicture);
                picture.Image = Image.FromStream(ms);
                ms.Close();
            }
            catch { picture.Image = null; return false; }


            return true;
        }

        private void printImageBtn_Click(object sender, EventArgs e)
        {
            /*try
            {
                System.Drawing.Printing.PrintDocument tmpDoc = new System.Drawing.Printing.PrintDocument();
                tmpDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(Tmpdoc_Print);
                PrintPreviewDialog tmpPpd = new PrintPreviewDialog();
                tmpPpd.Document = tmpDoc;
                tmpPpd.ShowDialog();
            }
            catch { }*/



            DataSet ds = new DataSet();
            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from acc_Letters_scan where letter_id=" + _letter_id.ToString(), conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            

            Reports.letterReport rep = new Fams.Reports.letterReport();
            rep.Database.Tables["acc_Letters_scan"].SetDataSource(ds.Tables[0]);
            Reports.RepPreview preview = new Fams.Reports.RepPreview();
            preview.crystalReportViewer.ReportSource = rep;
            //preview.crystalReportViewer.PrintReport();
            preview.ShowDialog();

        }

        private void acc_Letters_scanBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            updateImage();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("ნამდვილად გნებავთ ამ ჩანაწერის წაშლა?", "გთხოვთ დაადასტუროთ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            acc_Letters_scanTableAdapter.Update(this.officeDataSet.acc_Letters_scan);
        }
    }
}
