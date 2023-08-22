using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBase;
using Helpers;

namespace Fams
{
    public partial class frmEditFreq : Form
    {
        private BindingSource _src;
        private Boolean DataComplete = true;
        private User _user;
        private bool _isForLetter = false;

        /// <summary>
        /// konstruktori
        /// </summary>
        /// <param name="src"></param>
        /// <param name="user"></param>
        /// <param name="isForLetter">tserilisatvis tua unda ikos TRUE</param>
        public frmEditFreq(ref BindingSource src, User user, bool isForLetter) : this(ref src, user, 0)
        {
            _isForLetter = true;
        }

        public frmEditFreq(ref BindingSource src, User user, int isFromGnccDB = 0)
        {
            InitializeComponent();

            _src = src;
            _user = user;
            ActiveControl = FREQTextBox;
            if (isFromGnccDB == 0) return;
            FREQTextBox.Enabled = false;
            BandWidthTextBox.Enabled = false;
            reestr.Enabled = false;
            ActiveControl = zoneBox;
        }

        private void frmFreq_Load(object sender, EventArgs e)
        {
            this.zone_CityTableAdapter.Fill(this.officeDataSet.Zone_City);
            if (!_isForLetter) reestr.Visible = _user.ReestritCheck;


            try
            {
                string txt;
                if (_isForLetter) txt = HelperFunctions.getHZ(Convert.ToDouble(((OfficeDataSet.acc_FREQRow)((DataRowView)_src.Current).Row).FREQ.ToString()));
                else txt = HelperFunctions.getHZ(Convert.ToDouble(((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).FREQ.ToString()));
                FREQTextBox.Text = txt;
            }
            catch { }
            try
            {
                string txt;
                if (_isForLetter) txt = HelperFunctions.getHZ(Convert.ToDouble(((OfficeDataSet.acc_FREQRow)((DataRowView)_src.Current).Row).BandWidth.ToString()));
                else txt = HelperFunctions.getHZ(Convert.ToDouble(((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).BandWidth.ToString()));
                BandWidthTextBox.Text = txt;
            }
            catch { }


            zoneBox.DataBindings.Add(new Binding("SelectedValue", _src, "city_id"));
            remTextBox.DataBindings.Add(new Binding("Text", _src, "remark"));
            if (!_isForLetter)
            {
                try
                {
                    reestr.Checked = ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).reestrit;
                }
                catch { }
            }

            tabControl1.SelectedTab = tabPage1;
            FREQTextBox.Focus();

            checkToShowPowerBox();
        }

        private void checkToShowPowerBox()
        {
            DataSet ds = HelperFunctions.fill("select * from Channels where Center=" + HelperFunctions.FreqForDB(FREQTextBox), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            if (ds.Tables[0].Rows.Count > 0) powerBox.Visible = true;
            else if (HelperFunctions.FreqForDB(FREQTextBox) >= 88000 && HelperFunctions.FreqForDB(FREQTextBox) <= 108000) powerBox.Visible = true;
            else powerBox.Visible = false;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (!_isForLetter)
            {
                try
                {
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).FREQ = HelperFunctions.FreqForDB(FREQTextBox);
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).BandWidth = Convert.ToInt32(HelperFunctions.FreqForDB(BandWidthTextBox));
                    ((DataRowView)_src.Current)["reestrit"] = reestr.Checked;
                    _src.EndEdit();
                    DataComplete = true;
                }
                catch { DataComplete = false; }
            }
            else
            {
                try
                {
                    ((OfficeDataSet.acc_FREQRow)((DataRowView)_src.Current).Row).FREQ = HelperFunctions.FreqForDB(FREQTextBox);
                    ((OfficeDataSet.acc_FREQRow)((DataRowView)_src.Current).Row).BandWidth = Convert.ToInt32(HelperFunctions.FreqForDB(BandWidthTextBox));
                    _src.EndEdit();
                    DataComplete = true;
                }
                catch { DataComplete = false; }
            }
            this.Dispose();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            _src.CancelEdit();
            DataComplete = true;
        }

        private void frmFreq_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DataComplete;
        }

        private void FREQTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            HelperFunctions.catchKey(sender, e);
        }

        private void FREQTextBox_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = HelperFunctions.ConvertToFreq(((TextBox)sender).Text);
            checkToShowPowerBox();
        }

        private void powerBox_VisibleChanged(object sender, EventArgs e)
        {
            if (powerBox.Visible)
            {
                if (powerBox.DataBindings.Count == 0) powerBox.DataBindings.Add(new Binding("Text", _src, "power"));
            }
            else powerBox.DataBindings.Clear();
        }
    }
}