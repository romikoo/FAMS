using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;

namespace Fams
{
    public partial class frmCoords : Form
    {
        private Process myProcess = new Process();
        string oldREGISTERValue = "";
        string GuiFont = "";
        string PrimaryFont = "";
        string SecondaryFont = "";
        string OldCachePath = "";

        Color cl;

        DataSet ds;
        string connectionstring;
        SqlConnection northwindConnection;
        string strSQL;
        SqlCommand cmd;
        SqlDataAdapter da;

        public frmCoords()
        {
            InitializeComponent();
            cl = zone_CityBindingNavigator.BackColor;
        }

        private void zone_CityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.zone_CityBindingSource.EndEdit();
            this.zone_CityTableAdapter.Update(this.officeDataSet.Zone_City);

        }

        private void frmCoords_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'officeDataSet.Zone_City' table. You can move, or remove it, as needed.
            this.zone_CityTableAdapter.Fill(this.officeDataSet.Zone_City);

            ds = new DataSet();
            connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            northwindConnection = new SqlConnection(connectionstring);
            strSQL = "select * from Zone";
            cmd = new SqlCommand(strSQL, northwindConnection);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);


        }

        private void frmCoords_FormClosing(object sender, FormClosingEventArgs e)
        {
            zone_CityBindingNavigatorSaveItem_Click(sender, (EventArgs)e);
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            ExportBtn.Enabled = false;

            SqlCommand cmd = new SqlCommand("select * from Zone", northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Zone");
            cmd = new SqlCommand("select * from Zone_City order by city", northwindConnection);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Zone_City");

            SortedDictionary<string, System.Collections.ArrayList> znhash = new SortedDictionary<string, System.Collections.ArrayList>();
            foreach (DataRow dr in ds.Tables["Zone"].Rows)
            {
                string str = dr["Coords"].ToString();
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



                System.Collections.ArrayList arr = new System.Collections.ArrayList();

                foreach (DataRow cityRow in ds.Tables["Zone_City"].Rows)
                {
                    Point p = new Point(Convert.ToInt32(Convert.ToDouble(cityRow["lon"]) * 10000), Convert.ToInt32(Convert.ToDouble(cityRow["lat"]) * 10000));
                    if (rg.PointInPolygon(pt, p))
                    {
                        Punkt pk = new Punkt();
                        pk.city = cityRow["city"].ToString();
                        pk.lat = Convert.ToDouble(cityRow["lat"]);
                        pk.lon = Convert.ToDouble(cityRow["lon"]);
                        arr.Add(pk);
                    }
                }
                znhash.Add(dr["Name"].ToString(), arr);
            }


            XmlTextWriter writer = new XmlTextWriter("Google/myplaces.kml", System.Text.Encoding.UTF8);

            writer.WriteStartDocument();
            writer.WriteStartElement("kml"); writer.WriteAttributeString("xmlns", "http://earth.google.com/kml/2.0");
            writer.WriteStartElement("Document");
            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "My Places");
            writer.WriteElementString("open", "1");


            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "ზონები");
            writer.WriteElementString("open", "0");
            writer.WriteElementString("visibility", "0");

            foreach (string myKey in znhash.Keys)
            {
                writer.WriteStartElement("Folder");
                writer.WriteElementString("name", myKey);
                writer.WriteElementString("open", "0");
                writer.WriteElementString("visibility", "0");


                System.Collections.ArrayList punktebi = znhash[myKey];
                if (punktebi.Count > 0)
                {
                    foreach (Punkt pk in punktebi)
                    {
                        writer.WriteStartElement("Placemark");
                        //writer.WriteAttributeString("id", ((DataRowView)zone_CityBindingSource.Current).Row["id"].ToString());
                        writer.WriteElementString("name", pk.city.ToString());
                        writer.WriteElementString("visibility", "0");
                        writer.WriteStartElement("LookAt");
                        writer.WriteElementString("longitude", pk.lon.ToString());
                        writer.WriteElementString("latitude", pk.lat.ToString());
                        writer.WriteElementString("range", "27000");
                        writer.WriteElementString("tilt", "0");
                        writer.WriteElementString("heading", "0");
                        writer.WriteEndElement();
                        writer.WriteElementString("styleUrl", "root://styleMaps#default+nicon=0x307+hicon=0x317");
                        writer.WriteStartElement("Point");
                        writer.WriteElementString("coordinates", pk.lon.ToString() + "," + pk.lat.ToString());
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();

            try
            {
                RegistryKey rootKey = Microsoft.Win32.Registry.CurrentUser;
                RegistryKey Key = rootKey.OpenSubKey("Software\\Google\\Google Earth Plus", true);
                oldREGISTERValue = Key.GetValue("KMLPath").ToString();
                OldCachePath = Key.GetValue("CachePath").ToString();
                Key.SetValue("KMLPath", Application.StartupPath + "\\Google");
                Key.SetValue("CachePath", Application.StartupPath + "\\Google");
                Key = rootKey.OpenSubKey("Software\\Google\\Google Earth Plus\\Render", true);
                GuiFont = Key.GetValue("GuiFontFamily").ToString();
                Key.SetValue("GuiFontFamily", "Sylfaen");
                PrimaryFont = Key.GetValue("PrimaryFontFamily").ToString();
                Key.SetValue("PrimaryFontFamily", "Sylfaen");
                SecondaryFont = Key.GetValue("SecondaryFontFamily").ToString();
                Key.SetValue("SecondaryFontFamily", "Sylfaen");
            }
            catch (Exception ee) { MessageBox.Show("Cannot set GoogleEarth path - " + ee.ToString()); }

            try
            {
                RegistryKey rootKey = Microsoft.Win32.Registry.CurrentUser;
                RegistryKey Key = rootKey.OpenSubKey("Software\\Google\\Google Earth Plus\\autoupdate", false);
                myProcess.StartInfo.FileName = Key.GetValue("AppPath").ToString() + "/GoogleEarth.exe";
                myProcess.Start();
            }
            catch (Exception ee) { MessageBox.Show("Cannot start GoogleEarth path - " + myProcess.StartInfo.FileName + "\n\r" + ee.ToString()); }

            CloseGoogle.Enabled = true;
        }

        private void CloseGoogle_Click(object sender, EventArgs e)
        {
            CloseGoogle.Enabled = false;

            try
            {
                myProcess.Kill();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Cannot terminate GoogleEarth application - " + ee.ToString());
            }

            try
            {
                RegistryKey rootKey = Microsoft.Win32.Registry.CurrentUser;
                RegistryKey Key = rootKey.OpenSubKey("Software\\Google\\Google Earth Plus", true);
                Key.SetValue("KMLPath", oldREGISTERValue);
                Key.SetValue("CachePath", OldCachePath);
                Key = rootKey.OpenSubKey("Software\\Google\\Google Earth Plus\\Render", true);
                Key.SetValue("GuiFontFamily", "Arial"/*GuiFont*/);
                Key.SetValue("PrimaryFontFamily", "Arial"/*PrimaryFont*/);
                Key.SetValue("SecondaryFontFamily", "Arial Unicode MS"/*SecondaryFont*/);
            }
            catch (Exception ee) { MessageBox.Show("Cannot restore old GoogleEarth path - " + ee.ToString()); }


            /*
            DialogResult result;
            result = MessageBox.Show("გნებავთ შეცვლილი სადგურების შენახვა?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(Application.StartupPath + "\\Google\\myplaces.kml");
                XmlNodeList xmlnode = xmldoc.GetElementsByTagName("Placemark");

                string strSQL = "";
                for (int i = 0; i < xmlnode.Count; i++)
                {
                    XmlAttributeCollection xmlattrc = xmlnode[i].Attributes;
                    //if (xmlattrc.Count > 0) continue;
                    string s = "";
                    string[] ss;
                    int id = -1;
                    decimal longitute = -1;
                    decimal latitude = -1;

                    try
                    {
                        XmlNodeList lst = xmlnode[i].ChildNodes;
                        //s = xmlnode[i].ChildNodes.Count Item(5).InnerText;
                        foreach (XmlNode nd in lst)
                        {
                            if (nd.Name == "Point") { s = nd.InnerText; break; }
                        }
                        ss = s.Split(',');
                        id = Convert.ToInt32(xmlattrc[0].Value);
                        longitute = Convert.ToDecimal(ss[0]);
                        latitude = Convert.ToDecimal(ss[1]);
                        strSQL += ("update zone_city set lat=" + latitude.ToString() + ", lon=" + longitute.ToString() + " where id=" + id.ToString() + ";");
                        queriesTableAdapter.UpdateCoordinates((decimal)latitude, (decimal)longitute, id);
                        //MessageBox.Show(id.ToString());
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(xmlattrc[0].Name + " - " + xmlattrc[0].Value + " " + s + "\n\r " + id.ToString() + " E:" + longitute + " N:" + latitude + "\n\r " + ee.ToString());
                    }

                }
                this.zone_CityTableAdapter.Fill(this.officeDataSet.Zone_City);
            }*/

            ExportBtn.Enabled = true;
        }

        private void zone_CityDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Point p = new Point(Convert.ToInt32(Convert.ToDouble(zone_CityDataGridView.CurrentRow.Cells[3].Value) * 10000), Convert.ToInt32(Convert.ToDouble(zone_CityDataGridView.CurrentRow.Cells[2].Value) * 10000));
                //MessageBox.Show(p.X.ToString() + " - " + p.Y.ToString());
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string str = ds.Tables[0].Rows[i]["Coords"].ToString();
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
                        geoLabel.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                        geoLabel.Visible = true;
                        break;
                    }
                    else geoLabel.Visible = false;
                }
            }
            catch { }




            DataSet ds1 = new DataSet();
            string connectionstring1 = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection northwindConnection1 = new SqlConnection(connectionstring1);
            string strSQL1 = "SELECT     count(*) as raod FROM fls_LICENCE_FREQ where function_getCityName=N'" + zone_CityDataGridView.CurrentRow.Cells[1].Value.ToString() + "'";

            SqlCommand cmd1 = new SqlCommand(strSQL1, northwindConnection1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            da1.Fill(ds1);


            if (Convert.ToBoolean(ds1.Tables[0].Rows[0][0])) zone_CityBindingNavigator.BackColor = Color.Red;
            else zone_CityBindingNavigator.BackColor = cl;

        }
    }
}