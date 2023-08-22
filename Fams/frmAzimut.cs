using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using Helpers;

namespace Fams
{
    public partial class frmAzimut : Form
    {
        public frmAzimut()
        {
            InitializeComponent();
        }

        private void fls_AzimutBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fls_AzimutBindingSource.EndEdit();
            this.fls_AzimutTableAdapter.Update(this.officeDataSet.fls_Azimut);

        }

        private void frmAzimut_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'officeDataSet.fls_Azimut' table. You can move, or remove it, as needed.
            this.fls_AzimutTableAdapter.Fill(this.officeDataSet.fls_Azimut);

        }

        private void exportButton_Click(object sender, EventArgs e)
        {

            int length = 2;

            



            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            XmlTextWriter writer = new XmlTextWriter(saveFileDialog.FileName, System.Text.Encoding.UTF8);

            DataSet ds = new DataSet();

            progress progForm = new progress("მიმდინარეობს ინიციალიზაცია...");
            progForm.Show();
            progForm.Refresh();


            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string strSQL = "SELECT id, data, lat, lon, above_gnd, freq, lvl, azimut, remark FROM dbo.fls_Azimut order by data, lat, lon, freq; ";

            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            writer.WriteStartDocument();
            writer.WriteStartElement("kml"); writer.WriteAttributeString("xmlns", "http://earth.google.com/kml/2.0");
            writer.WriteStartElement("Document");

            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "აზიმუტები");
            writer.WriteElementString("open", "1");

            string prevFolder = ds.Tables[0].Rows[0]["data"].ToString();
            int space = 0;
            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", ds.Tables[0].Rows[0]["data"].ToString());
            writer.WriteElementString("open", "0");

            Random rnd = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            System.Drawing.Color col = System.Drawing.Color.FromArgb(rnd.Next(0, 150), rnd.Next(0, 150), rnd.Next(0, 150));
            String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(col);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //------------------------------- DELENIE NA RAZNIE KOMPANII ------------------------
                if (prevFolder != ds.Tables[0].Rows[i]["data"].ToString())
                {
                    rnd = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
                    col = System.Drawing.Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    strHtmlColor = System.Drawing.ColorTranslator.ToHtml(col);
                    
                    writer.WriteEndElement();
                    prevFolder = ds.Tables[0].Rows[i]["data"].ToString();
                    writer.WriteStartElement("Folder");
                    writer.WriteElementString("name", ds.Tables[0].Rows[i]["data"].ToString());
                    writer.WriteElementString("open", "0");
                    space = 0;
                }

                writer.WriteStartElement("Placemark");
                writer.WriteElementString("name", Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[i]["Freq"]) / 1000) + " MHz, " + ds.Tables[0].Rows[i]["lvl"].ToString() + " dBuV/m, " + ds.Tables[0].Rows[i]["azimut"].ToString() + "°");

                writer.WriteStartElement("LineString");
                writer.WriteElementString("tessellate", "1");
                double lat = Convert.ToDouble(ds.Tables[0].Rows[i]["lat"]);
                double lon = Convert.ToDouble(ds.Tables[0].Rows[i]["lon"]);
                double[] point = HelperFunctions.getPoint(lat, lon, Convert.ToInt16(ds.Tables[0].Rows[i]["azimut"]), length);

                writer.WriteElementString("coordinates", lon + ","+lat+",0\r\n"+point[1]+","+point[0]+",0");
                writer.WriteEndElement();
                //stili--------------------
                writer.WriteStartElement("Style");
                writer.WriteStartElement("LineStyle");
                writer.WriteElementString("color", strHtmlColor.Replace("#", "ff") + "");
                int lvl = Convert.ToInt16(ds.Tables[0].Rows[i]["lvl"]);
                int width = 2;
                if (lvl > 55) width = 3;
                else if (lvl > 35 && lvl <= 55) width = 2;
                else width = 1;
                writer.WriteElementString("width", width.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                //stili------------------------
                writer.WriteEndElement();
                space++;
            }
            writer.WriteEndElement();
            writer.WriteEndElement();

















            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();

            progForm.Close();

        }

        private void ExportButton2_Click(object sender, EventArgs e)
        {
            int length = 2;





            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            XmlTextWriter writer = new XmlTextWriter(saveFileDialog.FileName, System.Text.Encoding.UTF8);

            DataSet ds = new DataSet();

            progress progForm = new progress("მიმდინარეობს ინიციალიზაცია...");
            progForm.Show();
            progForm.Refresh();


            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string strSQL = "SELECT id, data, lat, lon, above_gnd, freq, lvl, azimut, remark FROM dbo.fls_Azimut order by freq, data, lat, lon; ";

            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            writer.WriteStartDocument();
            writer.WriteStartElement("kml"); writer.WriteAttributeString("xmlns", "http://earth.google.com/kml/2.0");
            writer.WriteStartElement("Document");

            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "აზიმუტები");
            writer.WriteElementString("open", "1");

            string prevFolder = ds.Tables[0].Rows[0]["data"].ToString();
            int space = 0;
            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", ds.Tables[0].Rows[0]["freq"].ToString());
            writer.WriteElementString("open", "0");

            Random rnd = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            System.Drawing.Color col = System.Drawing.Color.FromArgb(rnd.Next(0, 150), rnd.Next(0, 150), rnd.Next(0, 150));
            String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(col);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                progForm.Refresh();
                //------------------------------- DELENIE  ------------------------
                if (i>0 && prevFolder != ds.Tables[0].Rows[i]["freq"].ToString())
                {
                    rnd = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
                    col = System.Drawing.Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    strHtmlColor = System.Drawing.ColorTranslator.ToHtml(col);

                    writer.WriteEndElement();
                    prevFolder = ds.Tables[0].Rows[i]["freq"].ToString();
                    writer.WriteStartElement("Folder");
                    writer.WriteElementString("name", ds.Tables[0].Rows[i]["freq"].ToString());
                    writer.WriteElementString("open", "0");
                    space = 0;
                }

                writer.WriteStartElement("Placemark");
                writer.WriteElementString("name", Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[i]["Freq"]) / 1000) + " MHz, " + ds.Tables[0].Rows[i]["lvl"].ToString() + " dBuV/m, " + ds.Tables[0].Rows[i]["azimut"].ToString() + "°");
                writer.WriteElementString("description", ds.Tables[0].Rows[i]["remark"].ToString());
                writer.WriteStartElement("LineString");
                writer.WriteElementString("tessellate", "1");
                double lat = Convert.ToDouble(ds.Tables[0].Rows[i]["lat"]);
                double lon = Convert.ToDouble(ds.Tables[0].Rows[i]["lon"]);
                double[] point = HelperFunctions.getPoint(lat, lon, Convert.ToInt16(ds.Tables[0].Rows[i]["azimut"]), length);

                writer.WriteElementString("coordinates", lon + "," + lat + ",0\r\n" + point[1] + "," + point[0] + ",0");
                writer.WriteEndElement();
                //stili--------------------
                writer.WriteStartElement("Style");
                writer.WriteStartElement("LineStyle");
                writer.WriteElementString("color", strHtmlColor.Replace("#", "ff") + "");
                int lvl = Convert.ToInt16(ds.Tables[0].Rows[i]["lvl"]);
                int width = 2;
                if (lvl > 55) width = 3;
                else if (lvl > 35 && lvl <= 55) width = 2;
                else width = 1;
                writer.WriteElementString("width", width.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                //stili------------------------
                writer.WriteEndElement();
                space++;
            }
            writer.WriteEndElement();
            writer.WriteEndElement();

















            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();

            progForm.Close();
        }

        private void ExportButton3_Click(object sender, EventArgs e)
        {
            int length = 2;





            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            XmlTextWriter writer = new XmlTextWriter(saveFileDialog.FileName, System.Text.Encoding.UTF8);

            DataSet ds = new DataSet();

            progress progForm = new progress("მიმდინარეობს ინიციალიზაცია...");
            progForm.Show();
            progForm.Refresh();


            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string strSQL = "SELECT id, data, lat, lon, above_gnd, freq, lvl, azimut, remark, place_name FROM dbo.fls_Azimut order by place_name, data, freq; ";

            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            writer.WriteStartDocument();
            writer.WriteStartElement("kml"); writer.WriteAttributeString("xmlns", "http://earth.google.com/kml/2.0");
            writer.WriteStartElement("Document");

            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", "აზიმუტები");
            writer.WriteElementString("open", "1");

            string prevFolder = ds.Tables[0].Rows[0]["place_name"].ToString() + "," + ds.Tables[0].Rows[0]["data"].ToString();
            int space = 0;
            writer.WriteStartElement("Folder");
            writer.WriteElementString("name", prevFolder);
            writer.WriteElementString("open", "0");

            Random rnd = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
            System.Drawing.Color col = System.Drawing.Color.FromArgb(rnd.Next(0, 150), rnd.Next(0, 150), rnd.Next(0, 150));
            String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(col);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                progForm.Refresh();
                //------------------------------- DELENIE  ------------------------
                if (i > 0 && prevFolder != ds.Tables[0].Rows[i]["place_name"].ToString() + "," + ds.Tables[0].Rows[i]["data"].ToString())
                {
                    rnd = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0));
                    col = System.Drawing.Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    strHtmlColor = System.Drawing.ColorTranslator.ToHtml(col);

                    writer.WriteEndElement();
                    prevFolder = ds.Tables[0].Rows[i]["place_name"].ToString() + "," + ds.Tables[0].Rows[i]["data"].ToString();
                    writer.WriteStartElement("Folder");
                    writer.WriteElementString("name", prevFolder);
                    writer.WriteElementString("open", "0");
                    space = 0;
                }

                writer.WriteStartElement("Placemark");
                writer.WriteElementString("name", Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[i]["Freq"]) / 1000) + " MHz, " + ds.Tables[0].Rows[i]["lvl"].ToString() + " dBuV/m, " + ds.Tables[0].Rows[i]["azimut"].ToString() + "°");
                writer.WriteElementString("description", ds.Tables[0].Rows[i]["remark"].ToString());
                writer.WriteStartElement("LineString");
                writer.WriteElementString("tessellate", "1");
                double lat = Convert.ToDouble(ds.Tables[0].Rows[i]["lat"]);
                double lon = Convert.ToDouble(ds.Tables[0].Rows[i]["lon"]);
                double[] point = HelperFunctions.getPoint(lat, lon, Convert.ToInt16(ds.Tables[0].Rows[i]["azimut"]), length);

                writer.WriteElementString("coordinates", lon + "," + lat + ",0\r\n" + point[1] + "," + point[0] + ",0");
                writer.WriteEndElement();
                //stili--------------------
                writer.WriteStartElement("Style");
                writer.WriteStartElement("LineStyle");
                writer.WriteElementString("color", strHtmlColor.Replace("#", "ff") + "");
                int lvl = Convert.ToInt16(ds.Tables[0].Rows[i]["lvl"]);
                int width = 2;
                if (lvl > 55) width = 3;
                else if (lvl > 35 && lvl <= 55) width = 2;
                else width = 1;
                writer.WriteElementString("width", width.ToString());
                writer.WriteEndElement();
                writer.WriteEndElement();
                //stili------------------------
                writer.WriteEndElement();
                space++;
            }
            writer.WriteEndElement();
            writer.WriteEndElement();






            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();

            progForm.Close();
        }



    }
}
