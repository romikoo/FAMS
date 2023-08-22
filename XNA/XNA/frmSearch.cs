using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Helpers;

namespace XNA
{
    public partial class frmSearch : Form
    {
        Game _parent;
        frequencies freqs;
        List<FREQVIEW> FoundFreqs = new List<FREQVIEW>();
        Boolean Filtered = false;

        public frmSearch(Game parent, frequencies frq)
        {
            InitializeComponent();
            _parent = parent;
            this.Height = 73;
            freqs = frq;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            coords(_parent.myform);
            this.ActiveControl = FilterText;
        }

        public void coords(Form myform)
        {
            this.Left = myform.ClientRectangle.Width + myform.Left - this.Width - 40;
            this.Top = myform.ClientRectangle.Top + myform.Top  + 60;
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            FoundFreqs.Clear();

            DataSet ds;
            if (_parent.user.Confidential) ds = HelperFunctions.fill("SELECT distinct [id],[freq],[Comp_Name],[city] ,[remark],[BandWidth] ,[reestrit],[LICENCE],[LIC_ISSU_DATE],[LIC_EXPIRY_DATE],[comp_id],[lic_id] FROM FreqVisual where comp_name like N'%" + FilterText.Text + "%' ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            else ds = HelperFunctions.fill("SELECT distinct [id],[freq],[Comp_Name],[city] ,[remark], [BandWidth] ,[reestrit],[LICENCE],[LIC_ISSU_DATE],[LIC_EXPIRY_DATE],[comp_id],[lic_id] FROM FreqVisual where comp_name like N'%" + FilterText.Text + "%' and Comp_Name NOT LIKE N'%ბანკი%' and Comp_Name NOT LIKE N'%უშიშროებ%' and Comp_Name NOT LIKE N'%გამოძი%' and Comp_Name NOT LIKE N'%თავდაცვ%' and Comp_Name NOT LIKE N'%საელჩო%' and Comp_Name NOT LIKE N'%შინაგან%'  and Comp_Name NOT LIKE N'%ფინანსთა%'  and Comp_Name NOT LIKE N'%საზღვრის%' and Comp_Name NOT LIKE N'%სასაზღვრო%'  ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                FREQVIEW fr = new FREQVIEW();
                fr.id = Convert.ToInt32(dr["id"]);
                fr.freq = Convert.ToInt32(dr["freq"]);
                fr.Comp_Name = dr["Comp_Name"].ToString();
                fr.city = dr["city"].ToString();
                fr.remark = dr["remark"].ToString();
                fr.FREQ = Convert.ToInt32(dr["FREQ"]);
                fr.BandWidth = Convert.ToInt32(dr["BandWidth"]);
                fr.reestrit = Convert.ToBoolean(dr["reestrit"]);
                fr.LICENCE = Convert.ToString(dr["LICENCE"]);
                fr.comp_id = Convert.ToInt32(dr["comp_id"]);
                fr.lic_id = Convert.ToInt32(dr["lic_id"]);

                listBox.Items.Add(HelperFunctions.getHZ(fr.freq) + " - " + fr.Comp_Name);

                FoundFreqs.Add(fr);
            }

            this.Height = 286;
            Filtered = true;
        }

        private void rX_FREQTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterBtn.Enabled = FilterText.Text == "" ? false : true;
        }

        private void FilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) FilterBtn_Click(sender, e);
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            FilterText.Text = "";
            this.Height = 73;
            this.ActiveControl = FilterText;
            Filtered = false;

            _parent.FoundFreq = null;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (FREQVIEW fr in freqs.freq)
            {
                if (fr.id == FoundFreqs[listBox.SelectedIndex].id && fr.freq == FoundFreqs[listBox.SelectedIndex].freq)
                {
                    _parent.FoundFreq = fr;
                    _parent.ScrollToFound(fr.freq);
                    break;
                }
            }
            
        }

        private void frmSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                if (Filtered) RefreshBtn_Click(sender, null);
                else Hide();
            }
        }

        private void frmSearch_VisibleChanged(object sender, EventArgs e)
        {
            _parent.ძებნაToolStripMenuItem.Checked = this.Visible;
            _parent.FoundFreq = null;
        }
    }
}