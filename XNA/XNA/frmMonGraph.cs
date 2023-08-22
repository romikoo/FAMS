using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Helpers;
using DataBase;

namespace XNA
{
    


    public partial class frmMonGraph : Form
    {
        //GeoCodeCalc GeoCodeCalc;

        List<monImage> Images = new List<monImage>();
        int w, h, l, t;


        public frmMonGraph(string freq, string city, int dis)
        {
            InitializeComponent();

            w = this.Width;
            h = this.Height;

            DataSet ds = HelperFunctions.fill("select * from zone_city where city = N'" + city + "'", DataBase.Properties.Settings.Default.OfficeConnectionString);
            double lat = Convert.ToDouble(ds.Tables[0].Rows[0]["lat"]);
            double lon = Convert.ToDouble(ds.Tables[0].Rows[0]["lon"]);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Clear();
                ds = HelperFunctions.fill("select * from monGraph where freq='" + freq + "'", DataBase.Properties.Settings.Default.OfficeConnectionString);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    monImage mImage = new monImage();

                    mImage.id = Convert.ToInt32(dr["id"]);
                    mImage.freq = dr["freq"].ToString();
                    mImage.monDate = dr["monDate"].ToString();
                    mImage.monTime = dr["monTime"].ToString();
                    mImage.lat = Convert.ToDouble(dr["lat"]);
                    mImage.lon = Convert.ToDouble(dr["lon"]);
                    mImage.distance = (int)GeoCodeCalc.CalcDistance(mImage.lat, mImage.lon, lat, lon, GeoCodeCalcMeasurement.Kilometers);

                    if (mImage.distance <= dis)
                    {
                        
                        
                        Images.Add(mImage);
                    }
                }
                if (Images.Count == 0) Hide();
                else this.Show();
            }
            else
            {
                MessageBox.Show("There is no city with name " + city);
                Close();
            }

            
        }

        private void frmMonGraph_Load(object sender, EventArgs e)
        {
            for (int i = 0; i<Images.Count; i++)
            {
                listBox.Items.Add(Images[i].monDate + " : " + Images[i].distance + "km");
            }




            this.Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - this.Height - 55;
            this.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
            l = this.Left;
            t = this.Top;

            listBox.SelectedIndex = 0;
            listBox1_SelectedIndexChanged(sender, e);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Images[listBox.SelectedIndex].img == null)
            {
                DataSet dsImg = HelperFunctions.fill("select * from fls_Monitoring_Images where id=" + Images[listBox.SelectedIndex].id, DataBase.Properties.Settings.Default.OfficeConnectionString);
                Images[listBox.SelectedIndex].img = (byte[])dsImg.Tables[0].Rows[0]["img"];
            }

            MemoryStream ms = new MemoryStream(Images[listBox.SelectedIndex].img);
            picturePaste.Image = Image.FromStream(ms);
            ms.Close();
        }

        private void picturePaste_DoubleClick(object sender, EventArgs e)
        {
            if (this.Width > w)
            {
                this.Width = w;
                this.Height = h;

                this.Left = l;
                this.Top = t;
            }
            else
            {
                int offset = 100;

                this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width - 100;
                this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height - 100;

                this.Left = offset / 2;
                this.Top = offset / 2;
            }
        }
    }

    public class monImage
    {
        public int id;
        public string freq;
        public string monDate;
        public string monTime;
        public double lat;
        public double lon;
        public byte[] img;

        public int distance;
    }
}
