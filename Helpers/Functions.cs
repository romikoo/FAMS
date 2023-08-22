using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics;



namespace Helpers
{
    public class Functions
    {
        

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
            catch { Debug.WriteLine(strSQL, "=ERROR EXECUTING QUERY"); }
            return null;
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

        public static long FreqForDB(string txt)
        {
            TextBox t = new TextBox();
            t.Text = txt;
            return FreqForDB(t);
        }

        public static Color FreqStateColor(DateTime date)
        {
            TimeSpan ts = date - DateTime.Now;
            if (date == null) return Color.Blue;
            else if (ts.Days > 0 && ts.Days < 31) return Color.Yellow;
            else if (ts.Days > 31) return Color.Green;
            else if (ts.Days <= 0) return Color.Red;
            return Color.LightGray;
        }

        public static void bringWindowToFront(Form form, FormWindowState state = FormWindowState.Normal)
        {
            System.Diagnostics.Debug.WriteLine("bringWindowToFront: " + form.Name);

            if (form.WindowState == FormWindowState.Minimized) form.WindowState = state;
            //form.Show();
            form.TopMost = true;
            form.BringToFront();
            form.Focus();
            form.TopMost = false;

        }
    }
}
