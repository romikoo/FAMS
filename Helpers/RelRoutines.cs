using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Xml;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.IO;
using System.Web;

namespace Helpers
{
    public class RelRoutines
    {
        public static int sul_releika_monishvnashi(int comp_id, string connectionstring)
        {
            string strSQL = "select count(*) as raod from st_rel_fixed where comp_id=" + comp_id.ToString();
            return sul_releika_monishvnashi(strSQL, connectionstring);
        }

        public static int sul_releika_monishvnashi(System.Collections.ArrayList items, string connectionstring)
        {
            
            if (items.Count == 0) return 0;

            DataSet ds = new DataSet();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string strSQL = "select count(*) as raod from st_rel_fixed where comp_id=";

            for (int k = 0; k < items.Count; k++)
            {
                if (k > 0) strSQL += " or comp_id=";
                try
                {
                    DataRow row = items[k] as DataRow;
                    strSQL += row["id"].ToString();
                }
                catch { return 0; }
                
            }
            //MessageBox.Show(strSQL);
            return sul_releika_monishvnashi(strSQL, connectionstring);
        }

        private static int sul_releika_monishvnashi(string strSQL, string connectionstring)
        {
            DataSet ds = new DataSet();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Debug.WriteLine(strSQL);
            return Convert.ToInt32(ds.Tables[0].Rows[0]["raod"].ToString());
        }





        public static void export_stations(System.Collections.ArrayList items, string connectionstring)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

            string server_uri = "http://www.gncc.ge/1/";

            string pathToImages = "http://geo.gncc.ge/fr/Images";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Google Earth file (*.kml)|*.kml";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;


            DataSet ds = new DataSet();

            /*progress progForm = new progress("მიმდინარეობს ინიციალიზაცია...");
            progForm.Show();
            progForm.Refresh();*/

            SqlConnection northwindConnection = new SqlConnection(connectionstring);


            XmlTextWriter writer = new XmlTextWriter(saveFileDialog.FileName, System.Text.Encoding.UTF8);


            writer.WriteStartDocument(true);
            writer.WriteStartElement("kml");
            writer.WriteStartElement("Document");

            //writer.WriteString("<Style id=\"sn_hide\"><LabelStyle><scale>0</scale></LabelStyle></Style><Style id=\"sh_style\"><LabelStyle><scale>1.1</scale></LabelStyle></Style><StyleMap id=\"msn_hide\"><Pair><key>normal</key><styleUrl>#sn_hide</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sh_style</styleUrl></Pair></StyleMap>");


            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "სარელეო სადგურები");
            writer.WriteElementString("open", "1");


            for (int k = 0; k < items.Count; k++)
            {
                DataRow row = items[k] as DataRow;
                //MessageBox.Show(gridEX1.SelectedItems[k].GetRow().Cells["id"].Value.ToString());
                string strSQL = "select id, Comp_Name from fls_company_info where id=" + row["id"].ToString();
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                string compania = row["id"].ToString();// gridEX1.GetValue("id").ToString();
                string comp_name = row["Comp_Name"].ToString();// gridEX1.GetValue("id").ToString();

                ds.Tables.Clear();
                ds.Clear();

               

                //___________________________________________________________________________________________ Radiolink ____________________________________________
                strSQL = "select * from Fixed_Rel_site where comp_id=" + compania;
                cmd = new SqlCommand(strSQL, northwindConnection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                writer.WriteStartElement("Folder");
                writer.WriteElementString("name", comp_name);
                writer.WriteElementString("open", "0");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    writer.WriteStartElement("Placemark");
                    writer.WriteElementString("name", ds.Tables[0].Rows[i]["Name"].ToString());
                    string uri_params = "";
                    for (int n = 0; n < ds.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds.Tables[0].Columns[n].ColumnName + "=" + ds.Tables[0].Rows[i][n].ToString(); }
                    writer.WriteStartElement("description");
                    writer.WriteString("<iframe style='border 0px none;' width='520px'height='360px' frameborder='0' src='" + server_uri + "fixed_rel_site.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                    writer.WriteEndElement();
                    


                    writer.WriteElementString("styleUrl", "root://styleMaps#default+nicon=0x307+hicon=0x317");
                    writer.WriteStartElement("Style");
                    writer.WriteStartElement("IconStyle");
                    writer.WriteStartElement("Icon");
                    writer.WriteElementString("href", pathToImages + "/Tx/relfixed.png");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();


                    //writer.WriteString("<styleUrl>#sn_hide</styleUrl>");
                    writer.WriteStartElement("Point");
                    writer.WriteElementString("extrude", "1");
                    writer.WriteElementString("altitudeMode", "relativeToGround");
                    writer.WriteElementString("coordinates", ds.Tables[0].Rows[i]["lon"].ToString() + "," + ds.Tables[0].Rows[i]["lat"].ToString() + "," + ds.Tables[0].Rows[i]["ant_height"].ToString());
                    writer.WriteEndElement();



                    writer.WriteEndElement();
                }
                
                ds.Tables.Clear();
                ds.Clear();
                //____________________________________________________________________  L I N K S _________________________________________________________________________________
                strSQL = "select * from Fixed_rel_links where comp_id=" + compania;
                cmd = new SqlCommand(strSQL, northwindConnection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                writer.WriteStartElement("Folder");
                writer.WriteElementString("name", "__Radio Links__");
                writer.WriteElementString("open", "0"); 
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    writer.WriteStartElement("Placemark");
                    writer.WriteElementString("name", ds.Tables[0].Rows[i]["AName"].ToString() + " | " + ds.Tables[0].Rows[i]["BName"].ToString());
                    string uri_params = "";
                    for (int n = 0; n < ds.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds.Tables[0].Columns[n].ColumnName + "=" + ds.Tables[0].Rows[i][n].ToString(); }
                    writer.WriteStartElement("description");
                    writer.WriteString("<iframe style='border 0px none;' width='540px'height='380px' frameborder='0' src='" + server_uri + "fixed_rel_link.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                    writer.WriteEndElement();
                    
                    writer.WriteStartElement("Style");

                    writer.WriteStartElement("LineStyle");
                    writer.WriteElementString("color", LinkColor(Convert.ToInt32(ds.Tables[0].Rows[i]["ATX"].ToString())));
                    writer.WriteElementString("width", LinkWidth(Convert.ToInt32(ds.Tables[0].Rows[i]["ATX_B"].ToString())).ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("PolyStyle");
                    writer.WriteElementString("color", "7f0055ff");
                    writer.WriteEndElement();

                    writer.WriteEndElement();


                    writer.WriteStartElement("LineString");
                    writer.WriteElementString("extrude", "0");
                    writer.WriteElementString("altitudeMode", "relativeToGround");
                    writer.WriteStartElement("coordinates");
                    writer.WriteString(ds.Tables[0].Rows[i]["Alon"].ToString() + "," + ds.Tables[0].Rows[i]["Alat"].ToString() + "," + ds.Tables[0].Rows[i]["Aant_height"].ToString() + " ");
                    writer.WriteString(ds.Tables[0].Rows[i]["Blon"].ToString() + "," + ds.Tables[0].Rows[i]["Blat"].ToString() + "," + ds.Tables[0].Rows[i]["Bant_height"].ToString() + " ");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                ds.Clear();
                //_____________________________________________________________________________________________________________________________________________________


            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();

         




            writer.Close();

            //progForm.Close();


            ci = new System.Globalization.CultureInfo("ka-GE");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        }

        public static void export_stations(int lic_id, string connectionstring)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

            string server_uri = "http://www.gncc.ge/1/";

            string pathToImages = "http://geo.gncc.ge/fr/Images";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Google Earth file (*.kml)|*.kml";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;


            DataSet ds = new DataSet();

            /*progress progForm = new progress("მიმდინარეობს ინიციალიზაცია...");
            progForm.Show();
            progForm.Refresh();*/

            SqlConnection northwindConnection = new SqlConnection(connectionstring);


            XmlTextWriter writer = new XmlTextWriter(saveFileDialog.FileName, System.Text.Encoding.UTF8);


            writer.WriteStartDocument(true);
            writer.WriteStartElement("kml");
            writer.WriteStartElement("Document");

            //writer.WriteString("<Style id=\"sn_hide\"><LabelStyle><scale>0</scale></LabelStyle></Style><Style id=\"sh_style\"><LabelStyle><scale>1.1</scale></LabelStyle></Style><StyleMap id=\"msn_hide\"><Pair><key>normal</key><styleUrl>#sn_hide</styleUrl></Pair><Pair><key>highlight</key><styleUrl>#sh_style</styleUrl></Pair></StyleMap>");


            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "სარელეო სადგურები");
            writer.WriteElementString("open", "1");


           
                //MessageBox.Show(gridEX1.SelectedItems[k].GetRow().Cells["id"].Value.ToString());
                string strSQL = "select id, Comp_Name from fls_company_info where id=(select comp_id from fls_LICENCE_INFO where id=" + lic_id + ")";
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

               
                ds.Tables.Clear();
                ds.Clear();



                //___________________________________________________________________________________________ Radiolink ____________________________________________
                strSQL = string.Format("select * from Fixed_Rel_site where lic_id={0}", lic_id);
                cmd = new SqlCommand(strSQL, northwindConnection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                writer.WriteStartElement("Folder");
                writer.WriteElementString("name", "");
                writer.WriteElementString("open", "0");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    writer.WriteStartElement("Placemark");
                    writer.WriteElementString("name", ds.Tables[0].Rows[i]["Name"].ToString());
                    string uri_params = "";
                    for (int n = 0; n < ds.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds.Tables[0].Columns[n].ColumnName + "=" + ds.Tables[0].Rows[i][n].ToString(); }
                    writer.WriteStartElement("description");
                    writer.WriteString("<iframe style='border 0px none;' width='520px'height='360px' frameborder='0' src='" + server_uri + "fixed_rel_site.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                    writer.WriteEndElement();



                    writer.WriteElementString("styleUrl", "root://styleMaps#default+nicon=0x307+hicon=0x317");
                    writer.WriteStartElement("Style");
                    writer.WriteStartElement("IconStyle");
                    writer.WriteStartElement("Icon");
                    writer.WriteElementString("href", pathToImages + "/Tx/relfixed.png");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();


                    //writer.WriteString("<styleUrl>#sn_hide</styleUrl>");
                    writer.WriteStartElement("Point");
                    writer.WriteElementString("extrude", "1");
                    writer.WriteElementString("altitudeMode", "relativeToGround");
                    writer.WriteElementString("coordinates", ds.Tables[0].Rows[i]["lon"].ToString() + "," + ds.Tables[0].Rows[i]["lat"].ToString() + "," + ds.Tables[0].Rows[i]["ant_height"].ToString());
                    writer.WriteEndElement();



                    writer.WriteEndElement();
                }

                ds.Tables.Clear();
                ds.Clear();
                //____________________________________________________________________  L I N K S _________________________________________________________________________________
                strSQL =  string.Format("select * from Fixed_rel_links where Alic_id={0} or Blic_id={0}", lic_id);
                cmd = new SqlCommand(strSQL, northwindConnection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                writer.WriteStartElement("Folder");
                writer.WriteElementString("name", "__Radio Links__");
                writer.WriteElementString("open", "0");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    writer.WriteStartElement("Placemark");
                    writer.WriteElementString("name", ds.Tables[0].Rows[i]["AName"].ToString() + " | " + ds.Tables[0].Rows[i]["BName"].ToString());
                    string uri_params = "";
                    for (int n = 0; n < ds.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds.Tables[0].Columns[n].ColumnName + "=" + ds.Tables[0].Rows[i][n].ToString(); }
                    writer.WriteStartElement("description");
                    writer.WriteString("<iframe style='border 0px none;' width='540px'height='380px' frameborder='0' src='" + server_uri + "fixed_rel_link.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                    writer.WriteEndElement();

                    writer.WriteStartElement("Style");

                    writer.WriteStartElement("LineStyle");
                    writer.WriteElementString("color", LinkColor(Convert.ToInt32(ds.Tables[0].Rows[i]["ATX"].ToString())));
                    writer.WriteElementString("width", LinkWidth(Convert.ToInt32(ds.Tables[0].Rows[i]["ATX_B"].ToString())).ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("PolyStyle");
                    writer.WriteElementString("color", "7f0055ff");
                    writer.WriteEndElement();

                    writer.WriteEndElement();


                    writer.WriteStartElement("LineString");
                    writer.WriteElementString("extrude", "0");
                    writer.WriteElementString("altitudeMode", "relativeToGround");
                    writer.WriteStartElement("coordinates");
                    writer.WriteString(ds.Tables[0].Rows[i]["Alon"].ToString() + "," + ds.Tables[0].Rows[i]["Alat"].ToString() + "," + ds.Tables[0].Rows[i]["Aant_height"].ToString() + " ");
                    writer.WriteString(ds.Tables[0].Rows[i]["Blon"].ToString() + "," + ds.Tables[0].Rows[i]["Blat"].ToString() + "," + ds.Tables[0].Rows[i]["Bant_height"].ToString() + " ");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
                ds.Clear();
                //_____________________________________________________________________________________________________________________________________________________


           
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();






            writer.Close();

            //progForm.Close();


            ci = new System.Globalization.CultureInfo("ka-GE");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        }


        public static void exportCalcResults(ObservableCollection<Site> xelshemshleli_sites, ObservableCollection<Link> links, string connectionstring, bool noQuestion=false)
        {
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;


            string server_uri = "http://www.gncc.ge/1/";

            //string pathToImages = "http://geo.gncc.ge/fr/Images";
            string pathToImages = "http://www.gncc.ge/1/images";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Google Earth file (*.kml)|*.kml";
            if (noQuestion)
            {
                saveFileDialog.FileName = "temp.kml";
                saveFileDialog.OverwritePrompt = false;
                saveFileDialog.CreatePrompt = false;
            }
            else if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            
            DataSet ds = new DataSet();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);

            XmlTextWriter writer = new XmlTextWriter(saveFileDialog.FileName, System.Text.Encoding.UTF8);

        //http://maps.google.com/mapfiles/kml/pushpin/grn-pushpin.png

            
            writer.WriteStartDocument(true);
            writer.WriteStartElement("kml");
            writer.WriteStartElement("Document");


            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "სარელეო სადგურები");
            writer.WriteElementString("open", "1");



            
            
            string toadd = string.Empty;
            if (xelshemshleli_sites.Count > 0)
            {

                #region naxodim vse saiti kotorie uchastvuut v linkax

                for (int k = 0; k < xelshemshleli_sites.Count; k++)
                {
                    if (k > 0) toadd += " or ";
                    toadd += " Aid=" + xelshemshleli_sites[k].Id + " or Bid=" + xelshemshleli_sites[k].Id;
                }
                Debug.WriteLine(toadd);
                DataSet ds2 = new DataSet();
                string strSQL2 = "select * from Fixed_Rel_links where " + toadd;
                SqlCommand cmd2 = new SqlCommand(strSQL2, northwindConnection);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(ds2);

                List<int> lst = new List<int>();
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    lst.Add(Convert.ToInt32(ds2.Tables[0].Rows[i]["Aid"].ToString()));
                    lst.Add(Convert.ToInt32(ds2.Tables[0].Rows[i]["Bid"].ToString()));
                }
                for (int k = 0; k < xelshemshleli_sites.Count; k++) lst.Add(xelshemshleli_sites[k].Id);
                Debug.WriteLine(lst.Count + " amdenia sul");
                List<int> unique_items = new List<int>();
                foreach (int id in lst)
                {
                    if (!unique_items.Contains(id)) unique_items.Add(id);
                }
                Debug.WriteLine(unique_items.Count + " unique_items");
                toadd = string.Empty;
                for (int k = 0; k < unique_items.Count; k++)
                {
                    if (k > 0) toadd += " or ";
                    toadd += " id=" + unique_items[k];
                }
                string strSQL = "select * from Fixed_Rel_site where " + toadd;
                Debug.WriteLine(strSQL);
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);



                #endregion


                #region Site

                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {

                    writer.WriteStartElement("Folder");
                    writer.WriteElementString("name", ds.Tables[0].Rows[k]["Comp_Name"].ToString());
                    writer.WriteElementString("open", "0");

                    writer.WriteStartElement("Placemark");
                    writer.WriteElementString("name", ds.Tables[0].Rows[k]["Name"].ToString());
                    string uri_params = "";
                    for (int n = 0; n < ds.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds.Tables[0].Columns[n].ColumnName + "=" + ds.Tables[0].Rows[k][n].ToString(); }
                    writer.WriteStartElement("description");
                    writer.WriteString("<iframe style='border 0px none;' width='520px'height='360px' frameborder='0' src='" + server_uri + "fixed_rel_site.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                    writer.WriteEndElement();



                    writer.WriteElementString("styleUrl", "root://styleMaps#default+nicon=0x307+hicon=0x317");
                    writer.WriteStartElement("Style");
                    writer.WriteStartElement("IconStyle");
                    writer.WriteStartElement("Icon");
                    writer.WriteElementString("href", pathToImages + "/Tx/relfixed.png");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();


                    writer.WriteStartElement("Point");
                    writer.WriteElementString("extrude", "1");
                    writer.WriteElementString("altitudeMode", "relativeToGround");
                    writer.WriteElementString("coordinates", ds.Tables[0].Rows[k]["lon"].ToString() + "," + ds.Tables[0].Rows[k]["lat"].ToString() + "," + ds.Tables[0].Rows[k]["ant_height"].ToString());
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndElement();



                }
                ds.Tables.Clear();
                ds.Clear();
                #endregion


                #region arsebuli linkebis dasma

                toadd = string.Empty;
                for (int k = 0; k < xelshemshleli_sites.Count; k++)
                {
                    if (k > 0) toadd += " or ";
                    toadd += " Aid=" + xelshemshleli_sites[k].Id + " or Bid=" + xelshemshleli_sites[k].Id;
                }

                DataSet ds1 = new DataSet();
                string strSQL1 = "select * from Fixed_Rel_links where " + toadd;
                SqlCommand cmd1 = new SqlCommand(strSQL1, northwindConnection);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1);

                writer.WriteStartElement("Folder");
                writer.WriteElementString("name", "__Radio Links__");
                writer.WriteElementString("open", "0");
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    writer.WriteStartElement("Placemark");
                    writer.WriteElementString("name", ds1.Tables[0].Rows[i]["AName"].ToString() + " | " + ds1.Tables[0].Rows[i]["BName"].ToString());
                    string uri_params = "";
                    for (int n = 0; n < ds1.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds1.Tables[0].Columns[n].ColumnName + "=" + ds1.Tables[0].Rows[i][n].ToString(); }
                    writer.WriteStartElement("description");
                    writer.WriteString("<iframe style='border 0px none;' width='540px'height='380px' frameborder='0' src='" + server_uri + "fixed_rel_link.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                    writer.WriteEndElement();

                    writer.WriteStartElement("Style");


                    writer.WriteStartElement("LineStyle");
                    bool toDrawRed = false;
                    for (int k = 0; k < xelshemshleli_sites.Count; k++)
                    {
                        if ((xelshemshleli_sites[k].Id == Convert.ToInt32(ds1.Tables[0].Rows[i]["Aid"].ToString()) ||
                            xelshemshleli_sites[k].Id == Convert.ToInt32(ds1.Tables[0].Rows[i]["Bid"].ToString())) &&
                            xelshemshleli_sites[k].markRed)
                            toDrawRed = true;
                    }
                    if (toDrawRed) writer.WriteElementString("color", Properties.Settings.Default.searchLinkColor);
                    else writer.WriteElementString("color", LinkColor(Convert.ToInt32(ds1.Tables[0].Rows[i]["ATX"].ToString())));
                    writer.WriteElementString("width", LinkWidth(Convert.ToInt32(ds1.Tables[0].Rows[i]["ATX_B"].ToString())).ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("PolyStyle");
                    writer.WriteElementString("color", "7f0055ff");
                    writer.WriteEndElement();

                    writer.WriteEndElement();


                    writer.WriteStartElement("LineString");
                    writer.WriteElementString("extrude", "0");
                    writer.WriteElementString("altitudeMode", "relativeToGround");
                    writer.WriteStartElement("coordinates");
                    writer.WriteString(ds1.Tables[0].Rows[i]["Alon"].ToString() + "," + ds1.Tables[0].Rows[i]["Alat"].ToString() + "," + ds1.Tables[0].Rows[i]["Aant_height"].ToString() + " ");
                    writer.WriteString(ds1.Tables[0].Rows[i]["Blon"].ToString() + "," + ds1.Tables[0].Rows[i]["Blat"].ToString() + "," + ds1.Tables[0].Rows[i]["Bant_height"].ToString() + " ");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                ds1.Clear();




                #endregion

            }

            //_______________________________________________________________ possible ____________________________________________
            for (int i = 0; i < links.Count; i++)
            {
                //-------------------------------------------------tsertilebis dasma-------------------------------------------------
                writer.WriteStartElement("Placemark");
                writer.WriteElementString("name", links[i].Name);
                string uri_params = "";
                //for (int n = 0; n < ds.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds.Tables[0].Columns[n].ColumnName + "=" + ds.Tables[0].Rows[0][n].ToString(); }
                writer.WriteStartElement("description");
                writer.WriteString("<iframe style='border 0px none;' width='520px'height='360px' frameborder='0' src='" + server_uri + "fixed_rel_site.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                writer.WriteEndElement();



                writer.WriteElementString("styleUrl", "root://styleMaps#default+nicon=0x307+hicon=0x317");
                writer.WriteStartElement("Style");
                writer.WriteStartElement("IconStyle");
                writer.WriteStartElement("Icon");
                writer.WriteElementString("href", "http://maps.google.com/mapfiles/kml/pushpin/grn-pushpin.png");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();


                writer.WriteStartElement("Point");
                writer.WriteElementString("extrude", "1");
                writer.WriteElementString("altitudeMode", "relativeToGround");
                writer.WriteElementString("coordinates", links[i].SiteFrom.Coords.Lng + "," + links[i].SiteFrom.Coords.Lat + "," + 100);
                writer.WriteEndElement();

                writer.WriteEndElement();





                //-------------------------------------------------linkebis dasma (kalkulaciis) -------------------------------------------------
                writer.WriteStartElement("Placemark");
                writer.WriteElementString("name", links[i].Name);
                //string uri_params = "";
                //for (int n = 0; n < ds.Tables[0].Columns.Count; n++) { if (n > 0) uri_params += "&"; uri_params += ds.Tables[0].Columns[n].ColumnName + "=" + ds.Tables[0].Rows[i][n].ToString(); }
                writer.WriteStartElement("description");
                writer.WriteString("<iframe style='border 0px none;' width='540px'height='380px' frameborder='0' src='" + server_uri + "fixed_rel_link.php?" + HttpUtility.UrlEncode(uri_params) + "'/>");
                writer.WriteEndElement();

                writer.WriteStartElement("Style");

                writer.WriteStartElement("LineStyle");
                writer.WriteElementString("color", Properties.Settings.Default.searchLinkColor);
                //writer.WriteElementString("color", LinkColor(Convert.ToInt32(links[i].SiteFrom.TX_F)));
                writer.WriteElementString("width", LinkWidth(Convert.ToInt32(links[i].SiteFrom.TX_B)).ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("PolyStyle");
                writer.WriteElementString("color", "7f0055ff");
                writer.WriteEndElement();

                writer.WriteEndElement();


                writer.WriteStartElement("LineString");
                writer.WriteElementString("extrude", "0");
                writer.WriteElementString("altitudeMode", "relativeToGround");
                writer.WriteStartElement("coordinates");
                writer.WriteString(links[i].SiteFrom.Coords.Lng + "," + links[i].SiteFrom.Coords.Lat + "," + 100 + " ");
                writer.WriteString(links[i].SiteTo.Coords.Lng + "," + links[i].SiteTo.Coords.Lat + "," + 100 + " ");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();

            }



            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();






            writer.Close();


            ﻿
            try
            {
                System.Diagnostics.Process.Start(saveFileDialog.FileName);
            }
            catch { }

            ci = new System.Globalization.CultureInfo("ka-GE");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
        }


        private static string LinkColor(int freq)
        {
            if (freq <= 3000000) return "7fff0000";
            else if (freq > 3000000 && freq <= 5000000) return "7fff6600";
            else if (freq > 5000000 && freq <= 6600000) return "7fffff00";
            else if (freq > 6600000 && freq <= 7700000) return "7f99ff00";
            else if (freq > 7700000 && freq <= 8300000) return "7f00ff00";
            else if (freq > 10000000 && freq <= 12000000) return "7f00ffcc";
            else if (freq > 12000000 && freq <= 13400000) return "7f00ccff";
            else if (freq > 13400000 && freq <= 16000000) return "7f0099ff";
            else if (freq > 16000000 && freq <= 20000000) return "7f0033ff";
            else if (freq > 20000000 && freq <= 24000000) return "7f6600ff";
            else if (freq > 24000000 && freq <= 26600000) return "7f9900ff";
            else if (freq > 26600000 && freq <= 31000000) return "7fcc00ff";
            else if (freq > 31000000 && freq <= 40000000) return "7fff00ff";
            else return "7fff66cc";
        }

        private static int LinkWidth(int bandwidth)
        {
            if (bandwidth <= 4000) return 1;
            else if (bandwidth > 4000 && bandwidth <= 7000) return 2;
            else if (bandwidth > 7000 && bandwidth <= 14000) return 3;
            else if (bandwidth > 14000 && bandwidth <= 30000) return 4;

            else return 5;
        }

    }
}
