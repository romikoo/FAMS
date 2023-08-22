using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using DataBase;


namespace Fams
{
    public partial class RepSetupImages : Form
    {
        public RepSetupImages()
        {
            InitializeComponent();
        }

        private void RepSetupImages_Load(object sender, EventArgs e)
        {
            date1.Text = calendar1.SelectionRange.Start.Date.ToString();
            date2.Text = calendar2.SelectionRange.Start.Date.ToString();
            repFreqList.SelectedIndex = 0;
            repSiteList.SelectedIndex = 0;
        }

        private void Configure_rep_job()
        {
            DataSet dsPictures = new DataSet();;

            progress progForm = new progress("მიმდინარეობს ინიციალიზაცია...");
            progForm.Show();
            progForm.Refresh();

            string frq = "";
            for (int i = 0; i < repFreqList.Items.Count; i++)
            {
                if (repFreqList.GetSelected(i) && frq=="") frq = frq + "freq='" + repFreqList.Items[i].ToString() + "'";
                else if (repFreqList.GetSelected(i)) frq = frq + " or freq='" + repFreqList.Items[i].ToString() + "'";
            }
            if (frq!="") frq = "("+frq+")";

            string site = "";
            for (int i = 0; i < repSiteList.Items.Count; i++)
            {
                if (repSiteList.GetSelected(i) && site == "") site = site + "site='" + repSiteList.Items[i].ToString() + "'";
                else if (repSiteList.GetSelected(i)) site = site + " or site='" + repSiteList.Items[i].ToString() + "'";
            }
            if (site != "") site = "(" + site + ")";

            string addstr = "";
            if (frq != "" && site != "") addstr = "and " + frq + " and " + site;
            else if (frq != "") addstr = " and " + frq;
            else if (site != "") addstr = " and " + site;

            addstr += " order by insDate, site, freq";

            try
            {
                string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
                SqlConnection northwindConnection = new SqlConnection(connectionstring);
                string strSQL = "select * from fls_monitoring_images where insDate between '" + date1.Text + "' and '" + date2.Text + "' " + addstr;
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsPictures);
            }
            catch { MessageBox.Show("არ გაიხსნა ძირითადი ბაზა!"); progForm.Close(); }
            Reports.RepPreview preview = new Reports.RepPreview();
            try
            {
                Reports.DBImage DBImageRep = new Reports.DBImage();
                DBImageRep.SetDataSource(dsPictures.Tables[0]);
                preview.crystalReportViewer.ReportSource = DBImageRep;
            }
            catch { MessageBox.Show("რეპორტის ინიციალიზაცია ვერ მოხერხდა!"); progForm.Close(); }
            progForm.Close();
            preview.ShowDialog();
        }

        private void calendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            date1.Text = calendar1.SelectionRange.Start.Date.ToString();
        }

        private void calendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            date2.Text = calendar2.SelectionRange.Start.Date.ToString();
        }

        private void date1_Leave(object sender, EventArgs e)
        {
            try
            {
                date1.Text = Convert.ToDateTime(date1.Text).ToString();
            }
            catch
            {
                PrintBtn.Enabled = false;
                date1.Focus();
                try
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("fault.wav");
                    player.Play();
                }
                catch { }
            }
        }

        private void date1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDateTime(date1.Text);
                Convert.ToDateTime(date2.Text);
                if (repFreqList.SelectedItems.Count<1) Convert.ToInt32("wer");
                if (repSiteList.SelectedItems.Count < 1) Convert.ToInt32("wer");
                PrintBtn.Enabled = true;
            }
            catch { PrintBtn.Enabled = false; }
        }

        private void date2_Leave(object sender, EventArgs e)
        {
            try
            {
                date2.Text = Convert.ToDateTime(date2.Text).ToString();
            }
            catch
            {
                PrintBtn.Enabled = false;
                date2.Focus();
                try
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("fault.wav");
                    player.Play();
                }
                catch { }
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Configure_rep_job();
            }
            catch { MessageBox.Show("თქვენს კომპიუტერზე არ არის დაინსტალირებული პროგრამისათვის აუცილებელი კომპონენტი,\r\nკერძოდ Crystal Reports. გთხოვთ მიმართოთ პასუხისმგებელ პირს დახმარებისათვის.", "შეცდომა!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            this.Close();
        }
       
    }
}