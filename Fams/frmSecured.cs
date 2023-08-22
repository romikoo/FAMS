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
    public partial class frmSecured : Form
    {
        public frmSecured()
        {
            InitializeComponent();
        }


        private void frmSecured_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'secureDS.Zone_City' table. You can move, or remove it, as needed.
            this.zone_CityTableAdapter.Fill(this.secureDS.Zone_City);
            // TODO: This line of code loads data into the 'secureDS.fls_COMPANY_INFO' table. You can move, or remove it, as needed.
            this.fls_COMPANY_INFOTableAdapter.Fill(this.secureDS.fls_COMPANY_INFO);
            // TODO: This line of code loads data into the 'secureDS.fls_LICENCE_INFO' table. You can move, or remove it, as needed.
            this.fls_LICENCE_INFOTableAdapter.Fill(this.secureDS.fls_LICENCE_INFO);
            // TODO: This line of code loads data into the 'secureDS.fls_LICENCE_FREQ' table. You can move, or remove it, as needed.
            this.fls_LICENCE_FREQTableAdapter.Fill(this.secureDS.fls_LICENCE_FREQ);
        }

        private void fls_COMPANY_INFOBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (secureDS.HasChanges()) button1.Enabled = true;
            try
            {
                this.fls_COMPANY_INFOBindingSource.EndEdit();
                this.fls_COMPANY_INFOTableAdapter.Update(this.secureDS.fls_COMPANY_INFO);
            }
            catch { }
        }

        private void fls_LICENCE_INFOBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (secureDS.HasChanges()) button1.Enabled = true;
            try
            {
                this.fls_LICENCE_INFOBindingSource.EndEdit();
                this.fls_LICENCE_INFOTableAdapter.Update(this.secureDS.fls_LICENCE_INFO);
            }
            catch { }
        }

        private void fls_LICENCE_FREQBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (secureDS.HasChanges()) button1.Enabled = true;
            try
            {
                this.fls_LICENCE_FREQBindingSource.EndEdit();
                this.fls_LICENCE_FREQTableAdapter.Update(this.secureDS.fls_LICENCE_FREQ);
            }
            catch { }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();

            this.fls_LICENCE_FREQBindingSource.EndEdit();
            this.fls_LICENCE_FREQTableAdapter.Update(this.secureDS.fls_LICENCE_FREQ);

            this.fls_LICENCE_INFOBindingSource.EndEdit();
            this.fls_LICENCE_INFOTableAdapter.Update(this.secureDS.fls_LICENCE_INFO);

            this.fls_COMPANY_INFOBindingSource.EndEdit();
            this.fls_COMPANY_INFOTableAdapter.Update(this.secureDS.fls_COMPANY_INFO);

            button1.Enabled = false;
        }

        private void frmSecured_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (secureDS.HasChanges())
            {
                if (MessageBox.Show("შევინახო შეტანილი ცვლილებები?", "დაადასტურეთ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    button1_Click(sender, null);
                }
            }
        }

        private void fls_COMPANY_INFODataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("წაშლის შედეგად წაიშლება ეს ორგანიზაცი, მასში შემავალი ყველა ლიცენზია /ნებართვა და უკლებლივ ყველა სიხშირე, წავშალოთ?", "დაადასტურეთ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                e.Cancel = true;
        }

        private void fls_LICENCE_INFODataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("წაშლის შედეგად წაიშლება ყველა ლიცენზია /ნებართვა და უკლებლივ ყველა სიხშირე, წავშალოთ?", "დაადასტურეთ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No)
                e.Cancel = true;
        }

        private void fls_LICENCE_FREQDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("გნებავთ ამ სიხშირის წაშლა?", "დაადასტურეთ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }


    }
}
