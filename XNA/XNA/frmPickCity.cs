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
    public partial class frmPickCity : Form
    {
        private zone_cities _cities;

        public frmPickCity(ref zone_cities lst)
        {
            InitializeComponent();
            _cities = lst;
            foreach (city ct in lst.cities)
            {
                checkList.Items.Add(ct.name);
                checkList.SetItemChecked(checkList.Items.Count - 1, ct.check);
            }
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            for (int i=0; i< checkList.Items.Count; i++)
            {
                if (_cities.cities[i].presentInLicences)
                {
                    checkList.SetItemChecked(i, true);
                    _cities.cities[i].check = true;
                }
            }
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (_cities.cities[i].presentInLicences)
                {
                    checkList.SetItemChecked(i, false);
                    _cities.cities[i].check = false;
                }
            }
        }

        private void checkList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            _cities.cities[e.Index].check = (e.CurrentValue == CheckState.Checked) ? false : true;

        }

        private void btnCheckAllUnused_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (!_cities.cities[i].presentInLicences)
                {
                    checkList.SetItemChecked(i, true);
                    _cities.cities[i].check = true;
                }
            }
        }

        private void btnUncheckAllUnused_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (!_cities.cities[i].presentInLicences)
                {
                    checkList.SetItemChecked(i, false);
                    _cities.cities[i].check = false;
                }
            }
        }
    }
}