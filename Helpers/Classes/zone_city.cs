using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Xna.Framework;
using System.Drawing;

namespace Helpers
{
    public class city
    {
        public int id;
        public string name;
        public double lat;
        public double lon;
        public bool check;
        public bool presentInLicences;
    }

    public class zone_cities
    {
        public List<city> cities = new List<city>();
        private int _total;
        public int total
        {
            get { return _total; }
        }


        public zone_cities(User us)
        {
            string sql = "SELECT  DISTINCT    Zone_City.id, Zone_City.city, Zone_City.lat, Zone_City.lon, Zone_City.special, CASE WHEN fls_LICENCE_FREQ.id IS NULL " +
                              " THEN 0 ELSE 1 END AS present " +
                              "  FROM         Zone_City LEFT OUTER JOIN " +
                              "  fls_LICENCE_FREQ ON Zone_City.id = fls_LICENCE_FREQ.city_id " +
                              " ORDER BY present DESC, Zone_City.city";

            DataSet ds, temp;
            ds = new DataSet();

            if (us.Confidential)
            {
                try
                {
                    //secured
                    temp = HelperFunctions.fill(sql, DataBase.Properties.Settings.Default.SecureConnectionString.ToString());
                    ds.Tables.Add(temp.Tables[0].Copy());
                    temp = HelperFunctions.fill(sql, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                    foreach (DataRow dr in temp.Tables[0].Rows)
                        ds.Tables[0].ImportRow(dr);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("არ გაიხსნა სპეც სიხშირეების ბაზა!", "ყურადება", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                    temp = HelperFunctions.fill(sql, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                    ds.Tables.Add(temp.Tables[0].Copy());
                }
            }
            else ds = HelperFunctions.fill(sql, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());

            _total = ds.Tables[0].Rows.Count;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                city cit = new city();
                cit.id = Convert.ToInt32(dr["id"]);
                cit.name = dr["city"].ToString().Trim();
                if (dr["lat"] == DBNull.Value) cit.lat = 0; else cit.lat = Convert.ToDouble(dr["lat"]);
                if (dr["lon"] == DBNull.Value) cit.lon = 0; else cit.lon = Convert.ToDouble(dr["lon"]);
                cit.presentInLicences = Convert.ToBoolean(dr["present"]);

                cit.check = cit.presentInLicences;

                cities.Add(cit);
            }
        }

        public bool contains(string ct)
        {
            foreach (city c in cities)
            {
                if (c.name == ct && c.check==true) return true;
            }
            return false;
        }

        public city getCity (string str)
        {

            foreach (city ct in cities)
            {
                if (ct.name == str) return ct;
            }
            return null;
        }
    }
}
