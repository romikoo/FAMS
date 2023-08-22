using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;

namespace Fams
{

    public partial class frmAct : Form
    {
        private BindingSource _src;
        private Boolean DataComplete = true;

        public frmAct(ref BindingSource src)
        {
            InitializeComponent();

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ka-GE");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

            _src = src;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            fls_LICENCE_INFOTableAdapter.FillByComp(officeDataSet.fls_LICENCE_INFO, ((OfficeDataSet.fls_verificationActRow)((DataRowView)_src.Current).Row).comp_id);

            numberTextEdit.DataBindings.Add(new Binding("Text", _src, "number"));
            tarigiDateEdit.DataBindings.Add(new Binding("Text", _src, "tarigi", true, DataSourceUpdateMode.OnValidation, null, "d"));
            if (((OfficeDataSet.fls_verificationActRow)((DataRowView)_src.Current).Row).id < 0)
                tarigiDateEdit.Text = Convert.ToString(DateTime.Now.ToShortDateString());
            descriptionTextEdit.DataBindings.Add(new Binding("Text", _src, "description"));
            remarkTextEdit.DataBindings.Add(new Binding("Text", _src, "remark"));
            receverTextEdit.DataBindings.Add(new Binding("Text", _src, "recever"));
            comboBox1.DataBindings.Add(new Binding("SelectedValue", _src, "lic_id"));

            numberTextEdit.Focus();
            numberTextEdit_TextChanged(sender, e);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(tarigiDateEdit.Text);
            //return;

            //try
            //{
                _src.EndEdit();
                DataComplete = true;
            //}
            //catch { DataComplete = false; }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            _src.CancelEdit();
            DataComplete = true;
        }

        private void frmAct_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !DataComplete;
        }

        private void numberTextEdit_TextChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = numberTextEdit.Text.Trim() != "" &&
                tarigiDateEdit.Text.Trim() != "";

            
        }



    }
}
