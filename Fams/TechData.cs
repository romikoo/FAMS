using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataBase;

namespace Fams
{
    public partial class TechData : Form
    {
        private string _tax_id;

        public TechData(string tax_id)
        {
            InitializeComponent();
            _tax_id = tax_id;
        }

        private void tECH_dataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tECH_dataBindingSource.EndEdit();
            this.tECH_dataTableAdapter.Update(this.officeDataSet.TECH_data);
        }

        private void TechData_Load(object sender, EventArgs e)
        {
            this.tECH_dataTableAdapter.Fill(this.officeDataSet.TECH_data, _tax_id);            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Tech_dataView_forPrint where id=" + ((OfficeDataSet.TECH_dataRow)((DataRowView)tECH_dataBindingSource.Current).Row).id, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            Reports.TechReport rep = new Fams.Reports.TechReport();
            rep.Database.Tables["Tech_dataView_forPrint"].SetDataSource(ds.Tables[0]);
            Reports.RepPreview preview = new Fams.Reports.RepPreview();
            preview.crystalReportViewer.ReportSource = rep;
            preview.crystalReportViewer.PrintReport();
            //preview.ShowDialog();

            this.Close();
        }

    }
}
