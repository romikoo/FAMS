using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataBase;
using Helpers;

namespace Fams
{
    public partial class frmNebartva : Form
    {
        private BindingSource _src;
        //private Boolean DataComplete = true;
        private User _user;
        private int _license;
        private string _comp_name;
        bool containsError = false;

        public frmNebartva(int license, string comp_name, ref BindingSource src, User user)
        {
            InitializeComponent();
            _src = src;
            _user = user;
            _license = license;
            _comp_name = comp_name;
            if (!_user.Nebartva) OKBtn.Enabled = false;
        }

        private void frmNebartva_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'officeDataSet.fls_LICENCE_FREQ' table. You can move, or remove it, as needed.
            this.fls_LICENCE_FREQTableAdapter.FillByLic(this.officeDataSet.fls_LICENCE_FREQ, _license);
            // TODO: This line of code loads data into the 'officeDataSet.fls_NEBARTVA' table. You can move, or remove it, as needed.

            this.fls_NEBARTVATableAdapter.FillByLicence(this.officeDataSet.fls_NEBARTVA, _license);

            registration_textBox.DataBindings.Add(new Binding("Text", _src, "registration"));



            //tu eg axalia
            if (fls_NEBARTVABindingSource.Count == 0 && _user.Nebartva)
            {
                fls_NEBARTVABindingSource.AddNew();

                numberTextBox.Text = "F";
                saxeTextBox.Text = "რადიოსიხშირული სპექტრით სარგებლობის ნებართვა";


                fls_LICENCE_FREQBindingSource.MoveFirst();
                for (int i = 0; i < fls_LICENCE_FREQBindingSource.Count; i++)
                {
                    long fr = ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).FREQ;
                    f_spectrumTextBox.Text += HelperFunctions.getHZ(fr) + "; ";
                    fls_LICENCE_FREQBindingSource.MoveNext();
                }
                f_spectrumTextBox.Text += "სიხშირული ზოლის სიგანე 25 კჰც";

                pirobebiTextBox.Text = "1. სიხშირეები გამოყენებული უნდა იყოს მხოლოდ " + _comp_name +
                    " მიერ,დამხმარე ტექნოლოგიური დანიშნულებით და არ უნდა იქნას გადაცემული სხვა პირზე. " +
                    "2. უზრუნველყოს " + _comp_name + " გადაწყვეტილების მიღებიდან 20 სამუშაო დღის ვადაში, კომისიის " +
                    "რადიოელექტრონული მოწყობილობების რეესტრში, ამავე რეესტრით გათვალისწინებული ინფორმაციის " +
                    "ელექტრონული წესით ასახვა; რადიოელექტრონული მოწყობილობების რეესტრით გათვალისწინებული " +
                    "პარამეტრების ცვლილება რეესტრში ასახული იქნას ცვლილების განხორციელებიდან 5 სამუშაო დღის ვადაში;";
            }
            //tu chanatseri ukve arsebobs
            else
            {
                if (_user.Nebartva) DeleteBtn.Visible = true;
            }




        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            try
            {
                ((OfficeDataSet.fls_NEBARTVARow)((DataRowView)fls_NEBARTVABindingSource.Current).Row).license_id = _license;
                _src.EndEdit();

                this.Validate();
                this.fls_NEBARTVABindingSource.EndEdit();
                this.fls_NEBARTVATableAdapter.Update(this.officeDataSet.fls_NEBARTVA);
                containsError = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString(), "შეცდდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                containsError = true;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.fls_NEBARTVABindingSource.CancelEdit();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ნამდვილად გნებავთ ამ ჩანაწერის წაშლა?", "გთხოვთ დაადასტუროთ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fls_NEBARTVABindingSource.RemoveCurrent();
                this.fls_NEBARTVABindingSource.EndEdit();
                this.fls_NEBARTVATableAdapter.Update(this.officeDataSet.fls_NEBARTVA);
                this.Close();
            }
        }

        private void frmNebartva_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (containsError) e.Cancel = true;
            containsError = false;
        }



    }
}
