using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBase;

namespace Fams
{
    public partial class frmLetterNew : Form
    {
        private BindingSource _src;
        private Boolean DataComplete = true;

        public frmLetterNew(ref BindingSource src)
        {
            InitializeComponent();
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ka-GE");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

            _src = src;
        }

        private void frmLetter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'officeDataSet.acc_Workflow' table. You can move, or remove it, as needed.
            this.acc_WorkflowTableAdapter.Fill(this.officeDataSet.acc_Workflow);
            // TODO: This line of code loads data into the 'officeDataSet.fls_COMPANY_INFO' table. You can move, or remove it, as needed.
            this.fls_COMPANY_INFOTableAdapter.Fill(this.officeDataSet.fls_COMPANY_INFO);
            
            numberTextBox.DataBindings.Add(new Binding("Text", _src, "number"));
            receivedDateTimePicker.DataBindings.Add(new Binding("Text", _src, "received", true, DataSourceUpdateMode.OnValidation, null, "d"));
            remTextBox.DataBindings.Add(new Binding("Text", _src, "remark"));
            comp_combo.DataBindings.Add(new Binding("SelectedValue", _src, "comp_id"));
            worklowCombo.DataBindings.Add(new Binding("SelectedValue", _src, "workflow_id"));
            isReceived.DataBindings.Add("checked",_src, "isReceived");
            isPayedCheckBox.DataBindings.Add("checked", _src, "isPayed");
            AnotationTextBox.DataBindings.Add(new Binding("Text", _src, "Annotation"));
            whosignedTextBox.DataBindings.Add(new Binding("Text", _src, "WhoSigned"));
            receiverrdTextBox.DataBindings.Add(new Binding("Text", _src, "Receivers"));
            resolutionTextBox.DataBindings.Add(new Binding("Text", _src, "Resolution"));

            if (remTextBox.Text == "") remTextBox.Text = receiverrdTextBox.Text;

            //tu es axali chanatseria
            /*if (((OfficeDataSet.acc_LettersRow)((DataRowView)_src.Current).Row).id < 0)
                ((OfficeDataSet.acc_LettersRow)((DataRowView)_src.Current).Row).received = DateTime.Now;*/
            try 
            {
                Convert.ToInt32(((OfficeDataSet.acc_LettersRow)((DataRowView)_src.Current).Row).parent_letter_id);
            }
            catch {comp_combo.Enabled = true;}
 

            numberTextBox.Focus();
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

        private void frmLetter_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DataComplete;
        }


        private void comp_combo_Leave(object sender, EventArgs e)
        {
            if (comp_combo.SelectedIndex <= 0)
            {
                comp_combo.Focus();
                comp_combo.ForeColor = Color.Red;
            }
            else comp_combo.ForeColor = Color.Black;
        }

        private void comp_combo_TextChanged(object sender, EventArgs e)
        {
            if (comp_combo.SelectedIndex <= 0)
            {
                OKBtn.Enabled = false;
                comp_combo.ForeColor = Color.Red;
            }
            else
            {
                OKBtn.Enabled = true;
                comp_combo.ForeColor = Color.Black;
            }
        }

       
      
    }
}
