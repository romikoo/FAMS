using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fams
{
    public partial class frmPickLicence : Form
    {
        public int licence_id { get; set; }

        public frmPickLicence(int comp_id)
        {
            InitializeComponent();

            // TODO: This line of code loads data into the 'officeDataSet.fls_LICENCE_INFO' table. You can move, or remove it, as needed.
            this.fls_LICENCE_INFOTableAdapter.FillByComp(this.officeDataSet.fls_LICENCE_INFO, comp_id);
            foreach (DataRowView dr in flsLICENCEINFOBindingSource)
            {
                //listBox1.Items.Add(dr["LICENCE"]);
            }
        }

        private void gridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                licence_id = Convert.ToInt32(e.Row.Cells["id"].Value);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch { this.DialogResult = System.Windows.Forms.DialogResult.Cancel; }
        }


        private void gridEX1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                e.SuppressKeyPress = true;
                return;
            }
            base.OnKeyDown(e);
        }





    }
}
