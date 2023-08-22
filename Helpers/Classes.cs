using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;

namespace Helpers
{

    #region commShare

    public class commShare
    {
        public delegate void WannaShowFreqOnMapDelegate(object sender, ShowFreqArgs e);
        public event WannaShowFreqOnMapDelegate showFreqOnMap;

        public delegate void WannaGoToFreqDelegate(object sender, GoToFreqArgs e);
        public event WannaGoToFreqDelegate GoToFreq;

        public delegate void WinStateDelegate(object sender, WinStateArgs e);
        public event WinStateDelegate WinStateChange;

        public delegate void GoToCompFreqDelegate(object sender, ShowFreqArgs e);
        public event GoToCompFreqDelegate goToCompFreqChange;

        public void fire_showFreqOnMap(object sender, ShowFreqArgs e)
        {
            if (showFreqOnMap != null)
                this.showFreqOnMap(sender, e);
        }

        public void fire_GoToFreq(object sender, GoToFreqArgs e)
        {
            if (GoToFreq != null)
                this.GoToFreq(sender, e);
        }

        public void fire_WinStateChange(object sender, WinStateArgs e)
        {
            if (WinStateChange != null)
                this.WinStateChange(sender, e);
        }

        public void fire_goToCompFreqChange(object sender, ShowFreqArgs e)
        {
            if (goToCompFreqChange != null)
                goToCompFreqChange(sender, e);
        }

    }

    public class WinStateArgs : EventArgs
    {
        private System.Windows.Forms.FormWindowState _state;
        public System.Windows.Forms.FormWindowState state
        {
            get { return _state; }
        }

        public WinStateArgs(System.Windows.Forms.FormWindowState s)
        {
            _state = s;
        }

    }

    public class ShowFreqArgs : EventArgs
    {
        private int _freqID;
        public int freqID
        {
            get { return _freqID; }
        }

        public ShowFreqArgs(int ID)
        {
            _freqID = ID;
        }

    }

    public class GoToFreqArgs : EventArgs
    {
        private int _freq;
        public int freq
        {
            get { return _freq; }
        }

        public GoToFreqArgs(int fr)
        {
            _freq = fr;
        }

    }

    #endregion


    // Collection class. 
    public class Link
    {
        public string Name 
        {
            get
            {
                return name;
            }
        }
        private string name;

        public int Band
        {
            get { return band; }
            set
            {
                band = value;
                SiteFrom.RX_F = band * 1000000; SiteFrom.RX_B = 28000; SiteFrom.TX_F = band * 1000000; SiteFrom.TX_B = 28000;
                SiteTo.RX_F = band * 1000000; SiteTo.RX_B = 28000; SiteTo.TX_F = band * 1000000; SiteTo.TX_B = 28000;
            }
        }
        private int band;

        public double Distance 
        { 
            get
            {
                return System.Math.Round(GeoCodeCalc.CalcDistance(SiteFrom.Coords.Lat, SiteFrom.Coords.Lng, SiteTo.Coords.Lat, SiteTo.Coords.Lng, GeoCodeCalcMeasurement.Kilometers), 2);
            }
        }

        public Site SiteFrom { get; set; }
        public Site SiteTo { get; set; }

        public List<Frequency> possible_freqs { get; set; }


        public Link(Site siteFrom, Site siteTo)
        {
            SiteFrom = siteFrom;    
            SiteTo = siteTo;

            Band = 7;

            name = SiteFrom.Name + "->" + SiteTo.Name;

            possible_freqs = new List<Frequency>();
        }
    }

    public class Frequency
    {
        public string Alloc_Name { get; set; }

        public long Freq { get; set; }
        public double Bandwidth { get; set; }
        public int Channel { get; set; }
        public bool Is_low_band { get; set; }
        public double Spacing { get; set; }

        public Frequency(string alloc_Name, long freq, double bandwidth, int channel, bool is_low_band)
        {
            Alloc_Name = alloc_Name;

            Freq = freq;
            Bandwidth = bandwidth;
            Channel = channel;
            Is_low_band = is_low_band;
        }

        public Frequency(string alloc_Name, long freq, double bandwidth, int channel, bool is_low_band, double spacing) : 
            this(alloc_Name, freq, bandwidth, channel, is_low_band)
        {
            Spacing = spacing;
        }

        public override string ToString()
        {
            string strRepresentation = Alloc_Name + 
                "   |   " + HelperFunctions.getHZ(Freq) + 
                "   :   " + HelperFunctions.getHZ(Bandwidth) +
                "   :   " + Channel.ToString();
            if (!Is_low_band) strRepresentation += "'ch"; else strRepresentation += "ch";
            return strRepresentation;
        }
    }

    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long RX_F { get; set; }
        public int RX_B { get; set; }
        public long TX_F { get; set; }
        public int TX_B { get; set; }

        public bool markRed { get; set; }

        public PointLatLng Coords { get; set; }


        public Site(int id, string name, string rx_f, string rx_b, string tx_f, string tx_b, PointLatLng coords) 
            : this (name, rx_f, rx_b, tx_f, tx_b, coords) 
        {
            Id = id;
        }


        public Site(string name, string rx_f, string rx_b, string tx_f, string tx_b, PointLatLng coords)
        {
            if (!(Id >= 0)) Id = -1;

            Name = name;
            try { RX_F = Convert.ToInt64(rx_f); }
            catch { }
            try { RX_B = Convert.ToInt32(rx_b); }
            catch { }
            try { TX_F = Convert.ToInt64(tx_f); }
            catch { }
            try { TX_B = Convert.ToInt32(tx_b); }
            catch { }
            Coords = coords;
        }

        public Site(string name, PointLatLng coords)
        {
            Id = -1;
            Name = name;
            Coords = coords;
        }


    }

   



}
