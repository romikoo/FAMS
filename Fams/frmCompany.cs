using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataBase;

namespace Fams
{
    public partial class frmCompany : Form
    {
        private BindingSource _src;
        private Boolean DataComplete = true;

        public frmCompany(ref BindingSource src)
        {
            InitializeComponent();
            _src = src;
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'officeDataSet.Zone_City' table. You can move, or remove it, as needed.
            this.zone_CityTableAdapter.Fill(this.officeDataSet.Zone_City);
            this.cOMBO_CompAccountTableAdapter.Fill(this.officeDataSet.COMBO_CompAccount);
            
            
            TaxCodeText.DataBindings.Add(new Binding("Text", _src, "tax_id"));
            sentDateText.DataBindings.Add(new Binding("Text", _src, "SENT", true, DataSourceUpdateMode.OnValidation, null, "d"));
            gaveDateText.DataBindings.Add(new Binding("Text", _src, "gave", true, DataSourceUpdateMode.OnValidation, null, "d"));
            receivedEdit.DataBindings.Add(new Binding("Text", _src, "Received", true, DataSourceUpdateMode.OnValidation, null, "d"));

            comp_NameTextBox.DataBindings.Add(new Binding("Text", _src, "Comp_Name"));
            comp_indexText.DataBindings.Add(new Binding("Text", _src, "Comp_Index"));
            comp_addressText.DataBindings.Add(new Binding("Text", _src, "Comp_Address"));
            comp_phone_text.DataBindings.Add(new Binding("Text", _src, "Comp_Tel"));
            comp_faxText.DataBindings.Add(new Binding("Text", _src, "Comp_Fax"));
            comp_webText.DataBindings.Add(new Binding("Text", _src, "Comp_URL"));
            comp_mailText.DataBindings.Add(new Binding("Text", _src, "Comp_Mail"));

            nameText.DataBindings.Add(new Binding("Text", _src, "CONTACT_NAME"));
            indexText.DataBindings.Add(new Binding("Text", _src, "Comp_Cont_index"));
            addressText.DataBindings.Add(new Binding("Text", _src, "Comp_Cont_Address"));
            phoneText.DataBindings.Add(new Binding("Text", _src, "Comp_Cont_tel"));
            faxText.DataBindings.Add(new Binding("Text", _src, "Comp_Cont_fax"));
            Chief.DataBindings.Add(new Binding("Text", _src, "Comp_Chief"));
            Chief_Position.DataBindings.Add(new Binding("Text", _src, "Chief_Position"));

            CompAccountCombo.DataBindings.Add(new Binding("SelectedValue", _src, "Comp_Account"));
            Comp_CityCombo.DataBindings.Add(new Binding("SelectedValue", _src, "Comp_City"));
            Cont_CityCombo.DataBindings.Add(new Binding("SelectedValue", _src, "Comp_Cont_city"));

            remText.DataBindings.Add(new Binding("Text", _src, "remark"));

            try
            {
                has_NO_FREQCheckBox.Checked = ((OfficeDataSet.fls_COMPANY_INFORow)((DataRowView)_src.Current).Row).HAS_NO_FREQ;
            }
            catch { }

            tabControl1.SelectedTab = tabPage3;
            TaxCodeText.Focus();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            

            ((DataRowView)_src.Current)["HAS_NO_FREQ"] = has_NO_FREQCheckBox.Checked;

            try
            {
                _src.EndEdit();
                DataComplete = true;
            }
            catch (Exception ee) { DataComplete = false; MessageBox.Show(ee.ToString()); }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            _src.CancelEdit();
            DataComplete = true;
        }

        private void frmCompany_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DataComplete;
        }

        private void receivedEdit_KeyUp(object sender, KeyEventArgs e)
        {
            if ((((Janus.Windows.GridEX.EditControls.EditBox)sender).Text) == "") ((DataRowView)_src.Current).Row["Received"] = DBNull.Value;
        }

        private void sentDateText_KeyUp(object sender, KeyEventArgs e)
        {
            if ((((Janus.Windows.GridEX.EditControls.EditBox)sender).Text) == "") ((DataRowView)_src.Current).Row["SENT"] = DBNull.Value;
        }

        private void gaveDateText_KeyUp(object sender, KeyEventArgs e)
        {
            if ((((Janus.Windows.GridEX.EditControls.EditBox)sender).Text) == "") ((DataRowView)_src.Current).Row["gave"] = DBNull.Value;
        }

    }
}