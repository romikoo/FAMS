using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Data.SqlClient;
using DataBase;
using Helpers;

namespace Fams
{
    public partial class frmXTerra : Form
    {
        public frmXTerra()
        {
            InitializeComponent();
        }

        private void changeValue(string connectionStringName, string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = newValue;
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }



        private void insert_to_db()
        {
            //get country to insert to
            fmtv_terraBindingSource.MoveFirst();
            string ctry = ((XTerraDataSet.fmtv_terraRow)((DataRowView)fmtv_terraBindingSource.Current).Row).ctry.ToString();

            //delete everything for this country
            HelperFunctions.ExecuteNonQuery("delete from fls_company_info where comp_name=N'x_" + ctry + "'", DataBase.Properties.Settings.Default.OfficeConnectionString);

            //add current country
            HelperFunctions.ExecuteNonQuery("insert into fls_company_info (comp_name) values (N'x_" + ctry + "')", DataBase.Properties.Settings.Default.OfficeConnectionString);

            //get current inserted id
            DataSet ds = HelperFunctions.fill("select id from fls_company_info where comp_name=N'x_" + ctry + "'", DataBase.Properties.Settings.Default.OfficeConnectionString);
            int comp_id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            Debug.WriteLine(comp_id.ToString(), " - esaa damatebuli kompaniis id");

            //insert TV and FM licences in current "company"
            HelperFunctions.ExecuteNonQuery("insert into fls_licence_info (LICENCE, comp_id) " +
                    "values (N'x_TV', " + comp_id.ToString() + ")", DataBase.Properties.Settings.Default.OfficeConnectionString);
            HelperFunctions.ExecuteNonQuery("insert into fls_licence_info (LICENCE, comp_id) " +
                    "values (N'x_FM', " + comp_id.ToString() + ")", DataBase.Properties.Settings.Default.OfficeConnectionString);

            //get inserted TV licence id
            ds = HelperFunctions.fill("select id from fls_licence_info where LICENCE=N'x_TV' and comp_id=" + comp_id.ToString(), DataBase.Properties.Settings.Default.OfficeConnectionString);
            int tv_lic_id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            Debug.WriteLine(tv_lic_id.ToString(), " - esaa damatebuli tv licence id");

            //get inserted FM licence id
            ds = HelperFunctions.fill("select id from fls_licence_info where LICENCE=N'x_FM' and comp_id=" + comp_id.ToString(), DataBase.Properties.Settings.Default.OfficeConnectionString);
            int fm_lic_id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            Debug.WriteLine(fm_lic_id.ToString(), " - esaa damatebuli fm licence id");


            //zapolnyaem zone
            DataSet ds1 = new DataSet();
            string connectionstring1 = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection northwindConnection1 = new SqlConnection(connectionstring1);
            string strSQL1 = "select * from Zone";
            SqlCommand cmd1 = new SqlCommand(strSQL1, northwindConnection1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);



            foreach (DataRowView dr in fmtv_terraBindingSource)
            {
                string zon = "";

                Point p = new Point(Convert.ToInt32(Convert.ToDouble(dr["long_dec"]) * 10000), Convert.ToInt32(Convert.ToDouble(dr["lat_dec"]) * 10000));
                if (p.X > 1000000 || p.Y > 1000000) continue;
                //MessageBox.Show(p.X.ToString() + " - " + p.Y.ToString());
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    
                    string str = ds1.Tables[0].Rows[i]["Coords"].ToString();
                    string[] s = str.Split(new string[] { ")(" }, StringSplitOptions.RemoveEmptyEntries);

                    Regioni rg = new Regioni();
                    Point[] pt = new Point[s.GetLength(0)];
                    for (int j = 0; j < s.GetLength(0); j++)
                    {
                        s[j] = s[j].Replace("(", "");
                        s[j] = s[j].Replace(")", "");
                        string[] tmp = s[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        pt[j] = new Point(Convert.ToInt32(Convert.ToDouble(tmp[0]) * 10000), Convert.ToInt32(Convert.ToDouble(tmp[1]) * 10000));
                    }
                    if (rg.PointInPolygon(pt, p))
                    {
                        zon = ds1.Tables[0].Rows[i]["Name"].ToString();
                        //Debug.WriteLine(p.ToString() + ":" + zon, "-city");
                        break;
                    }
                    else zon = "";
                }
                Debug.Write("-");
                if (zon == "") continue;
                Debug.WriteLine(p.ToString() + ":" + zon, "-city");



                int lic;
                if (Convert.ToInt32(dr["bdwdth"]) == 8000) lic = tv_lic_id;
                else lic = fm_lic_id;
                
                /*string mystr = "select count(*) as raod from fls_licence_freq where freq=" + Convert.ToInt32(dr["freq_assgn"]) * 1000 + " and bandwidth=" + dr["bdwdth"] + " and power=" + Convert.ToInt32(dr["erp_kw"]) * 1000 + " and function_getCityName=N'" + zon + "' and licence_id=" + lic;
                Debug.WriteLine(mystr);
                DataSet tempuri = HelperFunctions.fill(mystr, Properties.Settings.Default.OfficeConnectionString.ToString());
                
                if (tempuri != null && Convert.ToInt32(tempuri.Tables[0].Rows[0][0]) == 0)*/
                    HelperFunctions.ExecuteNonQuery("insert into fls_licence_freq (freq, bandwidth, power, reestrit, licence_id, remark, city_id) " +
                        " values (" + Convert.ToInt32(dr["freq_assgn"]) * 1000 + ", " + dr["bdwdth"] + ", " + Convert.ToInt32(dr["erp_kw"]) * 1000 + ", 0, " + lic + ", '" + dr["tv_chan"] + " - " + dr["lat_dec"] + ":" + dr["long_dec"] + "; " + zon + "', dbo.getCityIDByName(dbo.closestCity(" + dr["lat_dec"] + ", " + dr["long_dec"] + "))); ", DataBase.Properties.Settings.Default.OfficeConnectionString);
                

            }
        }

        private void frmXTerra_Load(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine(openFileDialog.FileName.ToString());
                changeValue("Fams.Properties.Settings.XTerraDBConnectionString",
                    "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + openFileDialog.FileName);

                this.fmtv_terraTableAdapter.Fill(this.xTerraDataSet.fmtv_terra);
                this.fmtv_ant_diagTableAdapter.Fill(this.xTerraDataSet.fmtv_ant_diag);
                this.fmtv_ant_hgtTableAdapter.Fill(this.xTerraDataSet.fmtv_ant_hgt);
                this.fmtv_targetTableAdapter.Fill(this.xTerraDataSet.fmtv_target);
                this.fmtv_statusTableAdapter.Fill(this.xTerraDataSet.fmtv_status);
                this.fmtv_soundTableAdapter.Fill(this.xTerraDataSet.fmtv_sound);
                this.fmtv_rmksTableAdapter.Fill(this.xTerraDataSet.fmtv_rmks);
                this.fmtv_pub_histTableAdapter.Fill(this.xTerraDataSet.fmtv_pub_hist);
                this.fmtv_op_prdTableAdapter.Fill(this.xTerraDataSet.fmtv_op_prd);
                this.fmtv_historyTableAdapter.Fill(this.xTerraDataSet.fmtv_history);
                this.fmtv_ge06_plan_rmksTableAdapter.Fill(this.xTerraDataSet.fmtv_ge06_plan_rmks);
                this.fmtv_fdg_refTableAdapter.Fill(this.xTerraDataSet.fmtv_fdg_ref);
                this.fmtv_fdg_actTableAdapter.Fill(this.xTerraDataSet.fmtv_fdg_act);
                this.fmtv_fdgTableAdapter.Fill(this.xTerraDataSet.fmtv_fdg);
                this.fmtv_coordTableAdapter.Fill(this.xTerraDataSet.fmtv_coord);

                insert_to_db();
            }
        }


    }
}
