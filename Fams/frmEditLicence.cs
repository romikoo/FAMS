using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fams
{
    public partial class frmEditLicence : Form
    {
        private BindingSource _src;
        private Boolean DataComplete=true;

        public frmEditLicence(ref BindingSource src)
        {
            InitializeComponent();
            _src=src;
        }

        private void frmLicence_Load(object sender, EventArgs e)
        {
            LicText.DataBindings.Add(new Binding("Text", _src, "LICENCE"));
            IssueText.DataBindings.Add(new Binding("Text", _src, "LIC_ISSU_DATE", true, DataSourceUpdateMode.OnValidation, null, "d"));
            endText.DataBindings.Add(new Binding("Text", _src, "LIC_EXPIRY_DATE", true, DataSourceUpdateMode.OnValidation, null, "d"));
            remText.DataBindings.Add(new Binding("Text", _src, "COMMENTS"));

            tabControl1.SelectedTab = tabPage1;
            LicText.Focus();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _src.EndEdit();
                DataComplete = true;
            }
            catch { DataComplete = false; }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            _src.CancelEdit();
            DataComplete = true;
        }

        private void frmLicence_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DataComplete;
        }

        private void IssueText_KeyUp(object sender, KeyEventArgs e)
        {
            if ((((System.Windows.Forms.TextBox)sender).Text) == "") ((DataRowView)_src.Current).Row["LIC_ISSU_DATE"] = DBNull.Value;
        }

        private void endText_KeyUp(object sender, KeyEventArgs e)
        {
            if ((((System.Windows.Forms.TextBox)sender).Text) == "") ((DataRowView)_src.Current).Row["LIC_EXPIRY_DATE"] = DBNull.Value;
        }

    }
}