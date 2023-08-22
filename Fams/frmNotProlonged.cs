using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Threading;
using Helpers;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace Fams
{
    public partial class frmNotProlonged : ShapedForm
    {
        public frmNotProlonged()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = this.ci;
            Thread.CurrentThread.CurrentUICulture = this.ci;
            this.notProlongedTableAdapter.Fill(this.officeDataSet.__notProlonged);
            this.dateTimePicker1.Value = DateTime.Now.AddMonths(-6);
            this.dateTimePicker1_ValueChanged((object)this, (EventArgs)null);
            this.colFREQ.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatter();
            this.colFREQ.DisplayFormat.FormatType = FormatType.Custom;
            this.colBandWidth.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatter();
            this.colBandWidth.DisplayFormat.FormatType = FormatType.Custom;
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.notProlongedBindingSource.Filter = string.Format("Expiry > '{0}-{1}-{2} 00:00:00'", (object)this.dateTimePicker1.Value.Year, (object)this.dateTimePicker1.Value.Month, (object)this.dateTimePicker1.Value.Day);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (!this.myGridControl1.IsPrintingAvailable)
            {
                int num = (int)MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
            }
            else
                this.myGridControl1.ShowPrintPreview();
        }

        private void myGridView1_EndGrouping(object sender, EventArgs e)
        {
            (sender as GridView).ExpandAllGroups();
        }
    }
}
