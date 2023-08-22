using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Xna.Framework;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace Helpers
{
    public static class HelperFunctions
    {
        public static System.Drawing.Image getImage(string s)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(s);
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return (Image)(new Bitmap(img, new Size(32, 32)));
        }

        public static DataSet fill(string strSQL, string connection)
        {
            try
            {
                //Debug.WriteLine(strSQL);
                DataSet ds = new DataSet();
                string connectionstring = connection;
                SqlConnection northwindConnection = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                cmd.CommandTimeout = 100;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ee)
            {
                Debug.WriteLine(strSQL, "ERROR EXECUTING QUERY"); 
                Debug.WriteLine(ee.InnerException.ToString() +"\n"+ strSQL, "=ERROR EXECUTING QUERY"); 
            }
            return null;
        }

        public static bool ExecuteNonQuery(string strSQL, string connection)
        {
            Debug.WriteLine(strSQL, "+ExecuteNonQuery");
            try
            {
                DataSet ds = new DataSet();
                string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
                SqlConnection northwindConnection = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                //cmd.CommandTimeout = 1000;
                northwindConnection.Open();
                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception ee)
            {
                Debug.WriteLine(ee.Message, " - error in ExecuteNonQuery");
                return false;
            }
        }

        public static string ConvertToFreq(string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace(',', '.');


            //esli soderjitsya opredelenie togo chto eto
            string[] vozmojni = new string[9] { "k", "K", "კ", "m", "M", "მ", "g", "G", "გ" };
            for (int i = 0; i < vozmojni.Length; i++)
            {
                if (str.Contains(vozmojni[i]))
                {
                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    provider.NumberGroupSeparator = ",";
                    provider.NumberGroupSizes = new int[] { 3 };


                    int pos = str.IndexOf(vozmojni[i]);
                    string[] tmp = str.Split(Convert.ToChar(vozmojni[i]));
                    try
                    {
                        int mnojitel = 1;
                        if (i <= 2) mnojitel = 1;
                        else
                            if (i > 2 && i <= 5) mnojitel = 1000;
                            else
                                if (i > 5 && i <= 8) mnojitel = 1000000;
                        return getHZ(Convert.ToDouble(tmp[0], provider) * mnojitel);
                    }
                    catch (Exception ee) { Debug.WriteLine(ee.Message +"\n"+ee.StackTrace); return "არასწორია"; }
                }
            }

            //esli ne soderjitsya nikakix bukv, togda
            try
            {
                return getHZ(Convert.ToDouble(str));
            }
            catch { return "არასწორია"; }
        }

        public static string getHZ(double frequency)
        {

            /*
           if (frequency < 1000)
           {
               return Math.Round(frequency, 3) + " kHz";
           }
           else if (frequency >= 1000 && frequency < 1000000)
           {
               return Math.Round(frequency / 1000, 3) + " MHz";
           }
           else if (frequency >= 1000000)
           {
               return frequency / 1000000 + " GHz";
           }
           return frequency.ToString();
            */

            if (frequency < 27500)
            {
                return Math.Round(frequency, 2) + " kHz";
            }
            else if (frequency >= 27500 && frequency < 10000000)
            {
                return Math.Round(frequency / 1000, 3) + " MHz";
            }
            else if (frequency >= 10000000)
            {
                return Math.Round(frequency / 1000000, 5) + " GHz";
            }
            return frequency.ToString();
        }

        public static long FreqForDB(object sender)
        {
            string str = ((TextBox)sender).Text;
            string[] tmp = str.Split(' ');
            try
            {
                if (tmp[1].StartsWith("k")) return Convert.ToInt64(tmp[0]);
                else
                    if (tmp[1].StartsWith("M")) return Convert.ToInt64(Convert.ToDouble(tmp[0]) * 1000);
                    else
                        if (tmp[1].StartsWith("G")) return Convert.ToInt64(Convert.ToDouble(tmp[0]) * 1000000);
                return 0;
            }
            catch { return 0; }
        }

        public static string ToDegreeNotation(decimal angle)
        {
            int deg = (int)angle;
            decimal minutesAndSeconds = Math.Abs(angle - deg) * 60;
            int minutes = (int)minutesAndSeconds;
            int seconds = (int)(Math.Abs(minutesAndSeconds - minutes) * 60);

            if (deg < 0) deg = 0;
            if (minutes < 0) minutes = 0;
            if (seconds < 0) minutes = 0;
            string ideg = deg.ToString();
            string iminutes = minutes.ToString();
            string iseconds = seconds.ToString();
            if (deg < 10) ideg = "0" + deg.ToString();
            if (minutes < 10) iminutes = "0" + minutes.ToString();
            if (seconds < 10) iseconds = "0" + seconds.ToString();

            return ideg + iminutes + iseconds;
        }

        public static void catchKey(object sender, KeyEventArgs e)
        {/*
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event");*/


            if (e.KeyValue >= 65 && e.KeyValue <= 90 && e.KeyData != (Keys.Control | Keys.V))
            {
                string str = ((TextBox)sender).Text;
                ((TextBox)sender).Text = ConvertToFreq(str + e.KeyData);
                e.SuppressKeyPress = true;
            }

        }

        public static System.Drawing.Color FreqStateColor(DateTime date)
        {
            TimeSpan ts = date - DateTime.Now;
            Debug.WriteLine(date.ToString() + " : " + ts.ToString());
            if (date == null) return System.Drawing.Color.Blue;
            else if (ts.Days > 0 && ts.Days < 31) return System.Drawing.Color.Yellow;
            else if (ts.Days > 31) return System.Drawing.Color.Green;
            else if (ts.Days <= 0) return System.Drawing.Color.Red;
            return System.Drawing.Color.LightGray;
        }

        public static double[] getPoint(double x, double y, int azimut, int length)
        {
            int alfa = 0;

            if (azimut >= 0 && azimut <= 90) alfa = azimut;
            else if (azimut > 90 && azimut <= 180) alfa = 180 - azimut;
            else if (azimut > 180 && azimut <= 270) alfa = azimut - 180;
            else if (azimut > 270 && azimut <= 360) alfa = 360 - azimut;

            double bc = Math.Cos(DegreeToRadian(alfa)) * length;
            double ab = Math.Sin(DegreeToRadian(alfa)) * length * 1.4;

            if (azimut >= 0 && azimut <= 90)
            {
                x = x + bc; y = y + ab;
                //x = x + bc; y = y - ab;
            }
            else if (azimut > 90 && azimut <= 180)
            {
                x = x - bc; y = y + ab;
                //x = x + bc; y = y + ab;
            }
            else if (azimut > 180 && azimut <= 270)
            {
                x = x - bc; y = y - ab;
                //x = x - bc; y = y + ab;
            }
            else if (azimut > 270 && azimut <= 360)
            {
                x = x + bc; y = y - ab;
                //x = x - bc; y = y - ab;
            }
            else
            {
                MessageBox.Show("აზიმუტი აღემატება 360 გრადუსს!!!", "შეცდომა!");
                Application.Exit();
            }


            return new double[] { x, y };
        }

        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
    }
}
