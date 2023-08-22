using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Earth;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using Helpers;
using System.Data.SqlClient;

namespace Earth
{
    public enum FreqState { indate, outdate, ending, unknown };

    public class EarthHelpers
    {
        public EarthForm form;
        object parent;

        #region Public Functions

        public EarthHelpers(object parent)
        {
            Debug.WriteLine("EarthHelpers created.", "EarthHelpers");
            this.parent = parent;
        }

        public static int closestBand(long freq)
        {
            string strSQL = "select * from PlansView";
            string connectionstring = Properties.Settings.Default.CHAllocationsConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            long diff = long.MaxValue; int band=-1;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                long difference = Math.Abs((long)Convert.ToInt64(ds.Tables[0].Rows[i]["Frequency"].ToString()) - freq);
                if (difference < diff) { diff = difference; band = Convert.ToInt32(ds.Tables[0].Rows[i]["FreqBand"].ToString()); }
            }

            return band;
        }

      

        /// <summary>
        /// Opens Map
        /// </summary>
        public void showMap(bool forSearch)
        {
            Debug.WriteLine("showMap()", "EarthHelpers");
            if (form == null || form.IsDisposed) createFormWindow();
            if (!forSearch) form.DisableRelSearch();
            form.Show();
        }

        /// <summary>
        /// Closes Map
        /// </summary>
        public void closeMap()
        {
            Debug.WriteLine("closeMap()", "EarthHelpers");
            form.Close();
        }

        public void showFreq(int id)
        {
            Debug.WriteLine("showFreq(long freq)", "EarthHelpers");
            showMap(false);
            DataSet ds = HelperFunctions.fill(
                "SELECT     dbo.fls_LICENCE_FREQ.id, dbo.fls_LICENCE_FREQ.FREQ, dbo.fls_LICENCE_FREQ.BandWidth, dbo.fls_LICENCE_FREQ.power, dbo.fls_LICENCE_FREQ.remark, "+
                      "dbo.fls_LICENCE_FREQ.reestrit, dbo.fls_LICENCE_FREQ.licence_id, dbo.fls_LICENCE_FREQ.city_id, dbo.fls_LICENCE_FREQ.function_getCityName, "+
                      "dbo.Zone_City.lat, dbo.Zone_City.lon, dbo.fls_COMPANY_INFO.Comp_Name, dbo.fls_LICENCE_INFO.LIC_EXPIRY_DATE " +
                "FROM         dbo.fls_LICENCE_FREQ INNER JOIN "+
                                      "dbo.Zone_City ON dbo.fls_LICENCE_FREQ.city_id = dbo.Zone_City.id INNER JOIN "+
                                      "dbo.fls_LICENCE_INFO ON dbo.fls_LICENCE_FREQ.licence_id = dbo.fls_LICENCE_INFO.id INNER JOIN "+
                                      "dbo.fls_COMPANY_INFO ON dbo.fls_LICENCE_INFO.comp_id = dbo.fls_COMPANY_INFO.id "+
                "WHERE     (FREQ + BandWidth / 2 >= " +
                          "(SELECT     FREQ " +
                            "FROM          dbo.fls_LICENCE_FREQ AS fls_LICENCE_FREQ_3 " +
                            "WHERE      (id = " + id.ToString() + ")) - " +
                          "(SELECT     BandWidth " +
                            "FROM          dbo.fls_LICENCE_FREQ AS fls_LICENCE_FREQ_1 " +
                            "WHERE      (id = " + id.ToString() + ")) / 2) AND (FREQ - BandWidth / 2 <= " +
                          "(SELECT     FREQ " +
                            "FROM          dbo.fls_LICENCE_FREQ AS fls_LICENCE_FREQ_4 " +
                            "WHERE      (id = " + id.ToString() + ")) + " +
                          "(SELECT     BandWidth " +
                            "FROM          dbo.fls_LICENCE_FREQ AS fls_LICENCE_FREQ_2 " +
                            "WHERE      (id = " + id.ToString() + ")) / 2)", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Color color;
                try{ color = HelperFunctions.FreqStateColor(Convert.ToDateTime(dr["LIC_EXPIRY_DATE"]));}
                catch{color = Color.Blue;}

                form.AddMarker(Convert.ToDouble(dr["lat"]), Convert.ToDouble(dr["lon"]), 
                    dr["Comp_Name"].ToString() + "\n\r" +
                    HelperFunctions.getHZ(Convert.ToDouble(dr["FREQ"].ToString())) + "; "+
                    HelperFunctions.getHZ(Convert.ToDouble(dr["BandWidth"].ToString())) + "; " +
                    dr["function_getCityName"].ToString(), color);
                /*Freq freq = new Freq();
                freq.id = Convert.ToInt32(drFreq["id"]);
                freq.CH = Convert.ToInt32(drFreq["CH"]);
                freq.Frequency = Convert.ToInt32(drFreq["Frequency"]);
                freq.LowBand = Convert.ToBoolean(drFreq["LowBand"]);

                freqs.Add(freq);
                if (_minFreq > freq.Frequency || _minFreq == -1) _minFreq = freq.Frequency;
                if (_maxFreq < freq.Frequency || _maxFreq == -1) _maxFreq = freq.Frequency;*/
            }
        }


        




        #endregion




        #region private FormMethods

        private void createFormWindow()
        {
            Debug.WriteLine("createFormWindow()", "EarthHelpers");
            form = new EarthForm();
            form.Disposed += new EventHandler(form_Disposed);
        }


        private void form_Disposed(object sender, EventArgs e)
        {/*
            Debug.WriteLine("form_Disposed()", "EarthHelpers");
            if (parent.GetType().Equals(typeof(Fams.Game)))
                ((Fams.Game)parent).EarthToolStripMenuItem.Checked = false;*/
        }

        #endregion
    }
}
