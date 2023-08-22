using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helpers;
using System.Diagnostics;


namespace Earth
{
    public partial class frmLinkParams : Form
    {
        public DialogResult Result { get; set; }
        public int band { get; set; }

        List<string> couples = new List<string>();
        List<string> singles = new List<string>();

        private EarthForm parent;
       

        public frmLinkParams(int band, List<Frequency> possible_freqs, EarthForm form)
        {
            InitializeComponent();
            parent = form;
            for (int i=0; i<comboBox1.Items.Count; i++)
            {
                if (Convert.ToString(comboBox1.Items[i]) == band.ToString()){
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }

            /*
            foreach (Frequency f in possible_freqs)
            {
                string toadd = "";
                if (!f.Is_low_band) toadd = "'";
                possible_freqs_list.Items.Add(Functions.getHZ(f.Freq) + " : " + Functions.getHZ(f.Bandwidth) + " : " + f.Channel + toadd + "ch      |      " + f.Alloc_Name);
            }*/


            List<string> lst = new List<string>();
            foreach (Frequency f in possible_freqs) lst.Add(f.Alloc_Name);
            List<string> allocs = new List<string>();
            foreach (string s in lst) if (!allocs.Contains(s)) allocs.Add(s);
            foreach (string s in allocs)
            {
                List<Frequency> lowband = new List<Frequency>();
                List<Frequency> highband = new List<Frequency>();
                foreach (Frequency f in possible_freqs) if (f.Alloc_Name == s) if (f.Is_low_band) lowband.Add(f); else highband.Add(f);
                int lb = -1;
                foreach (Frequency l in lowband) if (l.Channel > lb) lb = l.Channel;   
                int hb = -1;
                foreach (Frequency h in highband) if (h.Channel > hb) hb = h.Channel;

                int max = -1;
                if (lb > hb) max = lb; else max = hb;
                Frequency[] low = new Frequency[max];
                Frequency[] high = new Frequency[max];
                for (int i = 0; i < max; i++)
                {
                    foreach (Frequency l in lowband) if (l.Channel == i+1) low[i] = l;
                    foreach (Frequency h in highband) if (h.Channel == i+1) high[i] = h;
                }
                for (int i = 0; i < max; i++)
                {
                    if (low[i] != null && high[i] == null)
                        singles.Add(Functions.getHZ(low[i].Freq) + " : " + Functions.getHZ(low[i].Bandwidth) + " : " + low[i].Channel + "ch      |      " + s);
                    else
                        if (low[i] == null && high[i] != null)
                            singles.Add(Functions.getHZ(high[i].Freq) + " : " + Functions.getHZ(high[i].Bandwidth) + " : " + high[i].Channel + "'ch      |      " + s);
                        else
                            if (low[i] != null && high[i] != null)
                                couples.Add(Functions.getHZ(low[i].Freq) + " : " + Functions.getHZ(high[i].Freq) + " : " + Functions.getHZ(low[i].Bandwidth) + " : " + low[i].Channel + "ch, " + high[i].Channel + "'ch      |      " + s);
                }


            }

            if (couples.Count > 0) couplRadio.Checked = true;
            else singleRadio.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            band = Convert.ToInt32(comboBox1.Text);
            Result = DialogResult.OK;
        }

        private void couplRadio_CheckedChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("couplRadio_CheckedChanged");
            possible_freqs_list.Items.Clear();
            if (couplRadio.Checked)
            {
                foreach (string s in couples) possible_freqs_list.Items.Add(s);
                possible_freqs_list.DoubleClick +=new EventHandler(possible_freqs_list_DoubleClick);
            }
            else
            {
                foreach (string s in singles) possible_freqs_list.Items.Add(s);
                possible_freqs_list.DoubleClick -= new EventHandler(possible_freqs_list_DoubleClick);
            }
        }

        private void possible_freqs_list_DoubleClick(object sender, EventArgs e)
        {
            if (possible_freqs_list.SelectedIndex < 0) return;
            string str = possible_freqs_list.Items[possible_freqs_list.SelectedIndex].ToString();
            string[] tmp = str.Split('|');
            string[] tmp2 = tmp[0].Split(':');
            long frq1 = Functions.FreqForDB(tmp2[0]);
            long frq2 = Functions.FreqForDB(tmp2[1]);
            long bandwidth = Functions.FreqForDB(tmp2[2]);

            parent.freqs.Markers.Clear();
            showCalculatedFreqPair(frq1, frq2, bandwidth);
        }

        public void showCalculatedFreqPair(long frq1, long frq2, long bandwidth)
        {
            DataSet ds = Helpers.Functions.fill(
                "SELECT     dbo.fls_LICENCE_FREQ.id, dbo.fls_LICENCE_FREQ.FREQ, dbo.fls_LICENCE_FREQ.BandWidth, dbo.fls_LICENCE_FREQ.power, dbo.fls_LICENCE_FREQ.remark, " +
                      "dbo.fls_LICENCE_FREQ.reestrit, dbo.fls_LICENCE_FREQ.licence_id, dbo.fls_LICENCE_FREQ.city_id, dbo.fls_LICENCE_FREQ.function_getCityName, " +
                      "dbo.Zone_City.lat, dbo.Zone_City.lon, dbo.fls_COMPANY_INFO.Comp_Name, dbo.fls_LICENCE_INFO.LIC_EXPIRY_DATE " +
                "FROM         dbo.fls_LICENCE_FREQ INNER JOIN " +
                                      "dbo.Zone_City ON dbo.fls_LICENCE_FREQ.city_id = dbo.Zone_City.id INNER JOIN " +
                                      "dbo.fls_LICENCE_INFO ON dbo.fls_LICENCE_FREQ.licence_id = dbo.fls_LICENCE_INFO.id INNER JOIN " +
                                      "dbo.fls_COMPANY_INFO ON dbo.fls_LICENCE_INFO.comp_id = dbo.fls_COMPANY_INFO.id " +
                "WHERE     ((FREQ + BandWidth / 2 >= " + Convert.ToString(frq1 - bandwidth / 2) +
                          ") AND (FREQ - BandWidth / 2 <= " + Convert.ToString(frq1 + bandwidth / 2) +
                          ")) OR " +
                          "((FREQ + BandWidth / 2 >= " + Convert.ToString(frq2 - bandwidth / 2) +
                          ") AND (FREQ - BandWidth / 2 <= " + Convert.ToString(frq2 + bandwidth / 2) +
                          "))", Properties.Settings.Default.FamsConnectionString.ToString());

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Color color;
                try { color = Functions.FreqStateColor(Convert.ToDateTime(dr["LIC_EXPIRY_DATE"])); }
                catch { color = Color.Blue; }

                parent.AddFreqsOnMap(Convert.ToDouble(dr["lat"]), Convert.ToDouble(dr["lon"]),
                    dr["Comp_Name"].ToString() + "\n\r" +
                    Helpers.Functions.getHZ(Convert.ToDouble(dr["FREQ"].ToString())) + "; " +
                    Helpers.Functions.getHZ(Convert.ToDouble(dr["BandWidth"].ToString())) + "; " +
                    dr["function_getCityName"].ToString(), color);
                //Debug.WriteLine("addmarker");
            }
        }
      
    }
}
