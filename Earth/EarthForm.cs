using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Earth.CustomMarkers;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Helpers;
using DataBase;



namespace Earth
{
    public partial class EarthForm : Form
    {
        private bool isCheckingCurrentLink = false;
        private bool checkAgainstSelf = Convert.ToBoolean(Properties.Settings.Default["checkAgainstSelf"]);
        private int _comp_id;
        private long _freqA, _freqB;
        private double _bandwidthA, _bandwidthB;
        private string _nameA, _nameB;
        private int _idA, _idB;

        // layers
        readonly GMapOverlay top = new GMapOverlay();
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        public GMapOverlay freqs = new GMapOverlay("freqs");
        private readonly Object _lock = new Object();

        // marker
        GMarkerGoogle currentMarker;


        // etc
        ObservableCollection<Link> links = new ObservableCollection<Link>();
        ObservableCollection<Site> xelshemshleli_sites = new ObservableCollection<Site>();
        private BackgroundWorker backgroundWorker;

        readonly Random rnd = new Random();
        GMapMarkerRect CurentRectMarker = null;
        string mobileGpsLog = string.Empty;
        bool isMouseDown = false;
        GMapMarker current = null;
        bool dragging = false;


        public EarthForm(zone_cities cts, int comp_id, int lic_id, ref BindingSource src, ref DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter adapter, OfficeDataSet.fls_LICENCE_FREQDataTable table, int Aid, int Bid, BindingSource linksSource)
            : this()
        {
            Debug.WriteLine("EarthForm()", "EarthForm");
            isCheckingCurrentLink = true;
            checkAgainstSelfBox.Visible = true;
            checkAgainstSelfBox.Checked = checkAgainstSelf;
            _comp_id = comp_id;
            _idA = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).Aid;
            _idB = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).Bid;
            _freqA = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).ATX;
            _freqB = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).BTX;
            _bandwidthA = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).ATX_B;
            _bandwidthB = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).BTX_B;
            _nameA = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).AName;
            _nameB = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).BName;
            this.Text += " - არსებული ლინკის შემოწმება: " + HelperFunctions.getHZ(_freqA) + 
                " (" + HelperFunctions.getHZ(_bandwidthA) +") | " + HelperFunctions.getHZ(_freqB) + " ("+ 
                HelperFunctions.getHZ(_bandwidthB) + ")";
            listBox3.Visible = true;
            listBox1.Visible = false;

            double ALat = (double)((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).Alat;
            double ALon = (double)((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).Alon;
            double BLat = (double)((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).Blat;
            double BLon = (double)((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)linksSource.Current).Row).Blon;

            GMarkerGoogle a = new GMarkerGoogle(new PointLatLng(ALat, ALon), GMarkerGoogleType.purple_pushpin);
            a.Tag = objects.Markers.Count + 1;
            a.ToolTipMode = MarkerTooltipMode.Always;
            a.ToolTipText = (objects.Markers.Count + 1).ToString();
            objects.Markers.Add(a);

            GMarkerGoogle b = new GMarkerGoogle(new PointLatLng(BLat, BLon), GMarkerGoogleType.purple_pushpin);
            b.Tag = objects.Markers.Count + 1;
            b.ToolTipMode = MarkerTooltipMode.Always;
            b.ToolTipText = (objects.Markers.Count + 1).ToString();
            objects.Markers.Add(b);

            FindBtn_Click(this, new EventArgs());
        }


        public EarthForm()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                // add your custom map db provider
                //GMap.NET.CacheProviders.MySQLPureImageCache ch = new GMap.NET.CacheProviders.MySQLPureImageCache();
                //ch.ConnectionString = @"server=sql2008;User Id=trolis;Persist Security Info=True;database=gmapnetcache;password=trolis;";
                //MainMap.Manager.SecondaryCache = ch;

                // set your proxy here if need
                //GMapProvider.WebProxy = new WebProxy("10.2.0.100", 8080);
                //GMapProvider.WebProxy.Credentials = new NetworkCredential("ogrenci@bilgeadam.com", "bilgeada");

                // set cache mode only if no internet avaible
                try
                {
                    System.Net.IPHostEntry e = System.Net.Dns.GetHostEntry("www.bing.com");
                }
                catch
                {
                    MainMap.Manager.Mode = AccessMode.CacheOnly;
                    MessageBox.Show("No internet connection available, going to CacheOnly mode.", "GMap.NET - Demo.WindowsForms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // config map 


#if DEBUG
                MainMap.MapProvider = GMapProviders.OpenStreetMap;
#else
                MainMap.MapProvider = GMapProviders.OpenStreetMap;
#endif
                MainMap.Position = new PointLatLng(42.51, 43.5);
                MainMap.MinZoom = 3;
                MainMap.MaxZoom = 22;
                MainMap.Zoom = 8;

                // map events
                {
                    MainMap.OnPositionChanged += new PositionChanged(MainMap_OnPositionChanged);

                    MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
                    MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);

                    MainMap.OnMapZoomChanged += new MapZoomChanged(MainMap_OnMapZoomChanged);
                    MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);

                    MainMap.OnMarkerClick += new MarkerClick(MainMap_OnMarkerClick);
                    MainMap.OnMarkerEnter += new MarkerEnter(MainMap_OnMarkerEnter);
                    MainMap.OnMarkerLeave += new MarkerLeave(MainMap_OnMarkerLeave);

                    MainMap.OnPolygonEnter += new PolygonEnter(MainMap_OnPolygonEnter);
                    MainMap.OnPolygonLeave += new PolygonLeave(MainMap_OnPolygonLeave);


                    MainMap.Manager.OnTileCacheComplete += new TileCacheComplete(OnTileCacheComplete);
                    MainMap.Manager.OnTileCacheStart += new TileCacheStart(OnTileCacheStart);
                    MainMap.Manager.OnTileCacheProgress += new TileCacheProgress(OnTileCacheProgress);
                }

                MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
                MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
                MainMap.MouseUp += new MouseEventHandler(MainMap_MouseUp);
                MainMap.MouseDoubleClick += new MouseEventHandler(MainMap_MouseDoubleClick);

                // get map types
                comboBoxMapType.ValueMember = "Name";
                comboBoxMapType.DataSource = GMapProviders.List;
                comboBoxMapType.SelectedItem = MainMap.MapProvider;

                // acccess mode
                comboBoxMode.DataSource = Enum.GetValues(typeof(AccessMode));
                comboBoxMode.SelectedItem = MainMap.Manager.Mode;


                // get cache modes
                checkBoxUseRouteCache.Checked = MainMap.Manager.UseRouteCache;


                // get zoom  
                trackBar1.Minimum = MainMap.MinZoom * 100;
                trackBar1.Maximum = MainMap.MaxZoom * 100;
                trackBar1.TickFrequency = 100;




                // add custom layers  
                {
                    MainMap.Overlays.Add(routes);
                    MainMap.Overlays.Add(objects);
                    MainMap.Overlays.Add(freqs);
                    MainMap.Overlays.Add(top);

                    objects.Markers.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Markers_CollectionChanged);
                    routes.Routes.CollectionChanged += new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Routes_CollectionChanged);
                    links.CollectionChanged +=new System.Collections.Specialized.NotifyCollectionChangedEventHandler(links_CollectionChanged);
                }

                // set current marker
                currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.arrow);
                currentMarker.IsHitTestVisible = false;
                top.Markers.Add(currentMarker);

                //MainMap.VirtualSizeEnabled = true;
                //if(false)
                {
                    

                    //RegeneratePolygon();

                    try
                    {
                        GMapOverlay overlay = DeepClone<GMapOverlay>(objects);
                        Debug.WriteLine("ISerializable status for markers: OK");

                        GMapOverlay overlay2 = DeepClone<GMapOverlay>(routes);
                        Debug.WriteLine("ISerializable status for polygons: OK");

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("ISerializable failure: " + ex.Message);

#if DEBUG
                        if (Debugger.IsAttached)
                        {
                            Debugger.Break();
                        }
#endif
                    }
                }
            }


            listBox1.Visible = !listBox3.Visible;
            DistBar.Value = Properties.Settings.Default.relFindRadius;
            InitializeBackgroundWorker(); 
        }

        public void DisableRelSearch()
        {
            SideBar.Pages.Remove(SideBar.Pages[0]);
            MainMap.Overlays.Remove(routes);
            objects.Markers.CollectionChanged -= new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Markers_CollectionChanged);
            routes.Routes.CollectionChanged -= new GMap.NET.ObjectModel.NotifyCollectionChangedEventHandler(Routes_CollectionChanged);
            links.CollectionChanged -= new System.Collections.Specialized.NotifyCollectionChangedEventHandler(links_CollectionChanged);
            MainMap.MouseDoubleClick -= new MouseEventHandler(MainMap_MouseDoubleClick);
        }

        #region backgroundWorkerStuff

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.WorkerReportsProgress = true;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
          

            double Distance_uncertain = (double)e.Argument;

            DataSet ds = new DataSet();
            string connectionstring = Properties.Settings.Default.CHAllocationsConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string connectionstring_Fams = Properties.Settings.Default.FamsConnectionString.ToString();
            SqlConnection FamsConnection = new SqlConnection(connectionstring_Fams);



            #region naxodim nujnie regioni i soxranyaem ix v otdelni massiv
            List<Point[]> regions = new List<Point[]>();
            int precision = 10000;
            foreach (Link link in links)
            {
                List<PointLatLng> tmp = new List<PointLatLng>();
                tmp.AddRange(GeoCodeCalc.RegionOfInterference(link.SiteFrom.Coords, link.SiteTo.Coords, Distance_uncertain));
                Point[] p = new Point[tmp.Count];
                for (int i = 0; i < tmp.Count; i++) p[i] = new Point(Convert.ToInt32(tmp[i].Lat * precision), Convert.ToInt32(tmp[i].Lng * precision));
                regions.Add(p);
            }
            #endregion
            //vipolnyaem rabotu dlya kajdogo linka
            foreach (Link l in links)
            {

                string strSQL = "select Count(*) as raod from PlansView where FreqBand=" + l.Band;
                SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //tu ar gvakvs gegma am diapazonisatvis vtskvitavt mushaobas
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["raod"]) == 0) continue;
                ds.Tables.Clear();

                //vibiraem vse kanali iz bazi i zapolnyaem imi massiv freqa
                List<Frequency> freqs = new List<Frequency>();

                if (isCheckingCurrentLink)
                {
                    Frequency aFREQ = new Frequency(_comp_id.ToString(), _freqA, _bandwidthA, 0, false);
                    Frequency bFREQ = new Frequency(_comp_id.ToString(), _freqB, _bandwidthB, 0, false);
                    freqs.Add(aFREQ);
                    freqs.Add(bFREQ);
                }
                
                strSQL = "select * from PlansView where FreqBand=" + l.Band;
                cmd = new SqlCommand(strSQL, northwindConnection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    freqs.Add(new Frequency(
                        ds.Tables[0].Rows[i]["Name"].ToString() + " | " + ds.Tables[0].Rows[i]["Block"].ToString() + " | " + ds.Tables[0].Rows[i]["Spacing"].ToString(),
                        Convert.ToInt64(ds.Tables[0].Rows[i]["Frequency"].ToString()),
                        Convert.ToDouble(ds.Tables[0].Rows[i]["Bandwidth"].ToString()),
                        Convert.ToInt32(ds.Tables[0].Rows[i]["CH"].ToString()),
                        Convert.ToBoolean(ds.Tables[0].Rows[i]["LowBand"].ToString())
                        ));
                }
                ds.Tables.Clear();
            
                


                //v otdelni spisok zagrujaem vse releiki
                if (!isCheckingCurrentLink) strSQL = "select * from Fixed_rel_site";
                else
                {
                    if (!checkAgainstSelfBox.Checked) strSQL = "select * from Fixed_rel_site where comp_id!=" + _comp_id;
                    else strSQL = string.Format("select * from Fixed_rel_site where id!={0} and id!={1}", _idA, _idB);
                }
                cmd = new SqlCommand(strSQL, FamsConnection);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                List<Site> sites = new List<Site>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sites.Add(new Site(
                        Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString()),
                        ds.Tables[0].Rows[i]["Name"].ToString(),
                        ds.Tables[0].Rows[i]["RX_FREQ"].ToString(),
                        ds.Tables[0].Rows[i]["RX_Band"].ToString(),
                        ds.Tables[0].Rows[i]["TX_FREQ"].ToString(),
                        ds.Tables[0].Rows[i]["TX_Band"].ToString(),
                        new PointLatLng(Convert.ToDouble(ds.Tables[0].Rows[i]["lat"].ToString()), Convert.ToDouble(ds.Tables[0].Rows[i]["lon"].ToString()))
                        ));
                }
                ds.Tables.Clear();

                


                //nachinaem poisk
                foreach (Frequency f in freqs)
                {
                    bool is_possible = true;
                    foreach (Site s in sites)
                    {
                        foreach (Point[] region in regions)
                        {
                            Regioni rg = new Regioni();
                            Point sitePoint = new Point(Convert.ToInt32(s.Coords.Lat * precision), Convert.ToInt32(s.Coords.Lng * precision));
                            if (rg.PointInPolygon(region, sitePoint))
                            {
                                //proveryaem na perekritie chastot s RX
                                long from = Convert.ToInt64(f.Freq - f.Bandwidth / 2); long to = Convert.ToInt64(f.Freq + f.Bandwidth / 2);
                                long sfrom = Convert.ToInt64(s.RX_F - s.RX_B / 2); long sto = Convert.ToInt64(s.RX_F + s.RX_B / 2);
                                if ((sfrom < from && sto > from) ||
                                    (sfrom < to && sto > to) ||
                                    (sfrom < from && sto > to) ||
                                    (sfrom > from && sto < to) ||

                                    (sfrom == from && sto > from) ||
                                    (sfrom == from && sto == to) ||
                                    (sfrom < to && sto == to) ||
                                    (sfrom == from && sto > to) ||
                                    (sfrom < from && sto == to))
                                {
                                    is_possible = false; 
                                    if (!siteInCollection(xelshemshleli_sites, s.Id))
                                    {
                                        if (isCheckingCurrentLink)
                                        {
                                            Debug.WriteLine(from + " " + to + " " + sfrom + " "+ sto + " " + _freqA + " " + _freqB);
                                            if ((f.Freq == _freqA) || (f.Freq == _freqB))
                                                s.markRed = true;
                                        }
                                        xelshemshleli_sites.Add(s);
                                    }
                                }

                                //proveryaem na perekritie chastot s TX
                                from = Convert.ToInt64(f.Freq - f.Bandwidth / 2); to = Convert.ToInt64(f.Freq + f.Bandwidth / 2);
                                sfrom = Convert.ToInt64(s.TX_F - s.TX_B / 2); sto = Convert.ToInt64(s.TX_F + s.TX_B / 2);
                                if ((sfrom < from && sto > from) ||
                                    (sfrom < to && sto > to) ||
                                    (sfrom < from && sto > to) ||
                                    (sfrom > from && sto < to) ||

                                    (sfrom == from && sto > from) ||
                                    (sfrom == from && sto == to) ||
                                    (sfrom < to && sto == to) ||
                                    (sfrom == from && sto > to) ||
                                    (sfrom < from && sto == to)) 
                                { 
                                    is_possible = false;
                                    if (!siteInCollection(xelshemshleli_sites, s.Id))
                                    {
                                        if (isCheckingCurrentLink)
                                        {
                                            Debug.WriteLine(from + " " + to + " " + sfrom + " " + sto + " " + _freqA + " " + _freqB);
                                            if ((f.Freq == _freqA) || (f.Freq == _freqB))
                                                s.markRed = true;
                                        }
                                        xelshemshleli_sites.Add(s);
                                    }
                                }
                            }

                        }


                    }

                    #region v pervuu ochered sravnivaem tekuschi link s kajdim saitom
                    /*foreach (Site s in sites)
                    {
                        //-----------------------esli sait naxoditsya v radiuse x kilometrov ot koncov linka
                        if (GeoCodeCalc.CalcDistance(l.SiteFrom.Coords.Lat, l.SiteFrom.Coords.Lng, s.Coords.Lat, s.Coords.Lng, GeoCodeCalcMeasurement.Kilometers) <= Distance_uncertain || GeoCodeCalc.CalcDistance(l.SiteTo.Coords.Lat, l.SiteTo.Coords.Lng, s.Coords.Lat, s.Coords.Lng, GeoCodeCalcMeasurement.Kilometers) <= Distance_uncertain)
                        {
                            //proveryaem na perekritie chastot s RX
                            long from = Convert.ToInt64(f.Freq - f.Bandwidth / 2); long to = Convert.ToInt64(f.Freq + f.Bandwidth / 2);
                            long sfrom = Convert.ToInt64(s.RX_F - s.RX_B / 2); long sto = Convert.ToInt64(s.RX_F + s.RX_B / 2);
                            if ((sfrom < from && sto > from) ||
                                (sfrom < to && sto > to) ||
                                (sfrom < from && sto > to) ||
                                (sfrom > from && sto < to) ||

                                (sfrom == from && sto > from) ||
                                (sfrom == from && sto == to) ||
                                (sfrom < to && sto == to) ||
                                (sfrom == from && sto > to) ||
                                (sfrom < from && sto == to)) { is_possible = false; if (!siteInCollection(xelshemshleli_sites, s.Id)) xelshemshleli_sites.Add(s); }

                            //proveryaem na perekritie chastot s TX
                            from = Convert.ToInt64(f.Freq - f.Bandwidth / 2); to = Convert.ToInt64(f.Freq + f.Bandwidth / 2);
                            sfrom = Convert.ToInt64(s.TX_F - s.TX_B / 2); sto = Convert.ToInt64(s.TX_F + s.TX_B / 2);
                            if ((sfrom < from && sto > from) ||
                                (sfrom < to && sto > to) ||
                                (sfrom < from && sto > to) ||
                                (sfrom > from && sto < to) ||

                                (sfrom == from && sto > from) ||
                                (sfrom == from && sto == to) ||
                                (sfrom < to && sto == to) ||
                                (sfrom == from && sto > to) ||
                                (sfrom < from && sto == to)) { is_possible = false; if (!siteInCollection(xelshemshleli_sites, s.Id)) xelshemshleli_sites.Add(s); }
                        }




                    }*/
                #endregion
                    
                    //tu shesadzlebelia am sixshiris gacema am linkisatvis - chavtserot igi
                    if (is_possible)
                    {
                        l.possible_freqs.Add(new Frequency(f.Alloc_Name, f.Freq, f.Bandwidth, f.Channel, f.Is_low_band));
                        if (isCheckingCurrentLink)
                            if ((f.Freq == _freqA && f.Bandwidth == _bandwidthA) || (f.Freq == _freqB && f.Bandwidth == _bandwidthB))
                            {
                                
                                MethodInvoker m = delegate()
                                {
                                    string newItem = l.Name + " | " + HelperFunctions.getHZ(f.Freq) + " | " + HelperFunctions.getHZ(f.Bandwidth) + " OK";
                                    bool present = false;
                                    for (int i = 0; i < listBox3.Items.Count; i++)
                                        if (listBox3.Items[i].ToString().Equals(newItem)) present = true;
                                    if (!present) listBox3.Items.Add(newItem);
                                };
                                try {BeginInvoke(m); }
                                catch { }
                            }
                    }
                    

                }

                backgroundWorker.ReportProgress((links.IndexOf(l) + 1) * 100 / links.Count, "vipolyaem rabotu dlya linka " + l.Name); 
            }

            
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.
                
            }
            else
            {
                // Finally, handle the case where the operation  
                // succeeded.
                FindBtn.Text = "შერჩევა";
                listBox2.Enabled = true;
                FindBtn.Enabled = true;
                SaveKmlBtn.Enabled = true;
                ClearBtn.Enabled = true;

                if (isCheckingCurrentLink && listBox3.Items.Count < 4) SaveKmlBtn_Click(sender, new EventArgs());
            }


            
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FindBtn.Text = e.ProgressPercentage + "%";
            //resultsList.Items.Add(e.UserState);
        }


        #endregion



        public void AddMarker(double lat, double lng)
        {
            AddMarker(lat, lng);
        }

        public void AddMarker(double lat, double lng, string text)
        {
            AddMarker(lat, lng, text, Color.LightGreen);
        }

        public void AddMarker(double lat, double lng, string text, Color color)
        {
            GMarkerGoogleType type = GMarkerGoogleType.green_pushpin;
            if (color.Equals(Color.Red)) type = GMarkerGoogleType.red_pushpin;
            else if (color.Equals(Color.Green)) type = GMarkerGoogleType.green_pushpin;
            else if (color.Equals(Color.Yellow)) type = GMarkerGoogleType.yellow_pushpin;
            else if (color.Equals(Color.Blue)) type = GMarkerGoogleType.blue_pushpin;

            GMarkerGoogle m = new GMarkerGoogle(new PointLatLng(lat, lng), type);
            //m.Tag = polygon.Points.Count;
            m.ToolTipMode = MarkerTooltipMode.OnMouseOver;


            object p = null;
            if (text.Equals(""))
            {
                GeoCoderStatusCode status;
                var ret = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
                if (status == GeoCoderStatusCode.G_GEO_SUCCESS && ret != null) p = ret;
                if (p != null)
                {
                    m.ToolTipText = ((Placemark)p).Address;
                }
                else
                {
                    m.ToolTipText = currentMarker.Position.ToString();
                }
            }
            else m.ToolTipText = text;

            GMapMarker marker = positionOccupied(m.Position);
            if (marker != null)
                marker.ToolTipText += "\r\n \r\n" + m.ToolTipText;
            else objects.Markers.Add(m);

            //RegeneratePolygon();
        }

        public void AddFreqsOnMap(double lat, double lng, string text, Color color)
        {
            GMarkerGoogleType type = GMarkerGoogleType.green_pushpin;
            if (color.Equals(Color.Red)) type = GMarkerGoogleType.red_pushpin;
            else if (color.Equals(Color.Green)) type = GMarkerGoogleType.green_pushpin;
            else if (color.Equals(Color.Yellow)) type = GMarkerGoogleType.yellow_pushpin;
            else if (color.Equals(Color.Blue)) type = GMarkerGoogleType.blue_pushpin;

            GMarkerGoogle m = new GMarkerGoogle(new PointLatLng(lat, lng), type);
            //m.Tag = polygon.Points.Count;
            m.ToolTipMode = MarkerTooltipMode.OnMouseOver;


            object p = null;
            if (text.Equals(""))
            {
                GeoCoderStatusCode status;
                var ret = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
                if (status == GeoCoderStatusCode.G_GEO_SUCCESS && ret != null) p = ret;
                if (p != null)
                {
                    m.ToolTipText = ((Placemark)p).Address;
                }
                else
                {
                    m.ToolTipText = currentMarker.Position.ToString();
                }
            }
            else m.ToolTipText = text;

            GMapMarker marker = positionOccupied(m.Position);
            if (marker != null)
                marker.ToolTipText += "\r\n \r\n" + m.ToolTipText;
            else freqs.Markers.Add(m);

            //RegeneratePolygon();
        }

        public T DeepClone<T>(T obj)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                formatter.Serialize(ms, obj);

                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }


        private GMapMarker positionOccupied(PointLatLng pos)
        {
            foreach (GMapMarker gm in objects.Markers)
                if (gm.Position.Equals(pos)) return gm;
            return null;
        }


        void Markers_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("Markers_CollectionChanged");



            listBox1.Items.Clear();

            List<PointLatLng> coords = new List<PointLatLng>();
            foreach (GMarkerGoogle m in objects.Markers)
            {
                listBox1.Items.Add(m.Tag + ": " + m.Position.ToString());
                coords.Add(m.Position);
            }

            if (objects.Markers.Count > 1) DrawPolyline(coords, "line");

        }

        void Routes_CollectionChanged(object sender, GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("Routes_CollectionChanged"); 

            //sperva soxranyaem vibrannie diapazoni
            List<int> bands = new List<int>();
            if  (links.Count >0) foreach (Link l in links) bands.Add(l.Band);

            //MessageBox.Show(bands.Count.ToString());
            
            if (routes.Routes.Count > 0)
            {
                links.Clear();
                for (int i = 1; i <= routes.Routes[0].Points.Count; i++)
                {
                    string linkName = i + "->" + (i - 1).ToString();
                    if (i != 1)
                    {
                        bool present = false;
                        foreach (Link l in links) if (l.Name == linkName) present = true;
                        if (!present)
                        {
                            Link lnk = new Link(new Site(i.ToString(), routes.Routes[0].Points[i-1]), new Site((i-1).ToString(), routes.Routes[0].Points[i-2]));
                            if (isCheckingCurrentLink) lnk.Band = EarthHelpers.closestBand(_freqB);
                            links.Add(lnk);
                        }
                    }

                    linkName = (i - 1).ToString() + "->" + (i).ToString();
                    if (i != 1)
                    {
                        bool present = false;
                        foreach (Link l in links) if (l.Name == linkName) present = true;
                        if (!present)
                        {
                            Link lnk = new Link(new Site((i - 1).ToString(), routes.Routes[0].Points[i - 2]), new Site(i.ToString(), routes.Routes[0].Points[i - 1]));
                            if (isCheckingCurrentLink) lnk.Band = EarthHelpers.closestBand(_freqA);
                            links.Add(lnk);
                        }
                    }


                }




            }

            

            //vozvraschaem vibrannie bans v ix linki
            for (int i = 0; i<bands.Count; i++)
                links[i].Band = bands[i];
            links_CollectionChanged(sender, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
  
            
        }

        void links_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("links_CollectionChanged");

            listBox2.Items.Clear();

            if (links.Count > 0)
            {
                FindBtn.Enabled = true;
                for (int i = 0; i < links.Count; i++)
                {
                    listBox2.Items.Add(links[i].Name + " : " + links[i].Band + "MHz" + " - " + links[i].Distance + " km.");
                }
            }
            else FindBtn.Enabled = false;

        }




        #region -- some functions --

        /*
        void RegeneratePolygon()
        {
            List<PointLatLng> polygonPoints = new List<PointLatLng>();

            foreach (GMapMarker m in objects.Markers)
            {
                if (m is GMapMarkerRect)
                {
                    m.Tag = polygonPoints.Count;
                    polygonPoints.Add(m.Position);
                }
            }

            if (polygon == null)
            {
                polygon = new GMapPolygon(polygonPoints, "polygon test");
                polygon.IsHitTestVisible = true;
                polygons.Polygons.Add(polygon);
            }
            else
            {
                polygon.Points.Clear();
                polygon.Points.AddRange(polygonPoints);

                if (polygons.Polygons.Count == 0)
                {
                    polygons.Polygons.Add(polygon);
                }
                else
                {
                    MainMap.UpdatePolygonLocalPosition(polygon);
                }
            }
        }*/



        private void DrawPolyline(List<PointLatLng> coords, string name)
        {
            routes.Routes.Clear();
            GMapRoute route = new GMapRoute(name);
            foreach (PointLatLng p in coords) route.Points.Add(p);
            routes.Routes.Add(route);
        }

        #endregion

        #region -- map events --

        void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if (item is GMapMarker && ((GMapMarker)item).Overlay != freqs)
            {
                /*GMapMarkerRect rc = item as GMapMarkerRect;
                rc.Pen.Color = Color.Red;

                CurentRectMarker = rc;*/

                current = item;
                Debug.WriteLine("OnMarkerEnter: " + item.Position);
            }
        }

        void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (item is GMapMarker)
            {
                /*CurentRectMarker = null;

                GMapMarkerRect rc = item as GMapMarkerRect;
                rc.Pen.Color = Color.Blue;*/

                if (!dragging) current = null;
                Debug.WriteLine("OnMarkerLeave: " + item.Position);
            }
        }


        void MainMap_OnPolygonEnter(GMapPolygon item)
        {
            item.Stroke.Color = Color.Red;
            Debug.WriteLine("OnPolygonEnter: " + item.Name);
        }

        void MainMap_OnPolygonLeave(GMapPolygon item)
        {
            item.Stroke.Color = Color.MidnightBlue;
            Debug.WriteLine("OnPolygonLeave: " + item.Name);
        }


        void OnTileCacheComplete()
        {
            Debug.WriteLine("OnTileCacheComplete");
            long size = 0;
            int db = 0;
            try
            {
                DirectoryInfo di = new DirectoryInfo(MainMap.CacheLocation);
                var dbs = di.GetFiles("*.gmdb", SearchOption.AllDirectories);
                foreach (var d in dbs)
                {
                    size += d.Length;
                    db++;
                }
            }
            catch
            {
            }

            if (!IsDisposed)
            {
                MethodInvoker m = delegate
                {
                    textBoxCacheSize.Text = string.Format(CultureInfo.InvariantCulture, "{0} db in {1:00} MB", db, size / (1024.0 * 1024.0));
                    textBoxCacheStatus.Text = "all tiles saved!";
                };
                Invoke(m);
            }
        }

        void OnTileCacheStart()
        {
            Debug.WriteLine("OnTileCacheStart");

            if (!IsDisposed)
            {
                MethodInvoker m = delegate
                {
                    textBoxCacheStatus.Text = "saving tiles...";
                };
                Invoke(m);
            }
        }

        void OnTileCacheProgress(int left)
        {
            if (!IsDisposed)
            {
                MethodInvoker m = delegate
                {
                    textBoxCacheStatus.Text = left + " tile to save...";
                };
                Invoke(m);
            }
        }





        void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            comboBoxMapType.SelectedItem = type;

            trackBar1.Minimum = MainMap.MinZoom * 100;
            trackBar1.Maximum = MainMap.MaxZoom * 100;


        }

        void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
                if (dragging)
                {
                    Markers_CollectionChanged(this, new GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs(GMap.NET.ObjectModel.NotifyCollectionChangedAction.Reset));
                    MainMap.Refresh();
                }
                dragging = false;
            }
        }

        // add demo circle
        void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("MainMap_MouseDoubleClick()", "EarthForm");

            /*var cc = new GMapMarkerCircle(MainMap.FromLocalToLatLng(e.X, e.Y));
            objects.Markers.Add(cc);*/

            GMarkerGoogle m = new GMarkerGoogle(MainMap.FromLocalToLatLng(e.X, e.Y), GMarkerGoogleType.green_pushpin);
            m.Tag = objects.Markers.Count + 1;
            m.ToolTipMode = MarkerTooltipMode.Always;
            m.ToolTipText = (objects.Markers.Count + 1).ToString();

            objects.Markers.Add(m);
        }

        void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;

                if (currentMarker.IsVisible && current == null)
                {
                    currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);

                    var px = MainMap.MapProvider.Projection.FromLatLngToPixel(currentMarker.Position.Lat, currentMarker.Position.Lng, (int)MainMap.Zoom);
                    var tile = MainMap.MapProvider.Projection.FromPixelToTileXY(px);

                    Debug.WriteLine("MouseDown: geo: " + currentMarker.Position + " | px: " + px + " | tile: " + tile);
                }
            }
        }

        // move current marker with left holding
        void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown)
            {
                if (CurentRectMarker == null)
                {
                    if (currentMarker.IsVisible && current == null)
                    {
                        currentMarker.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                    }
                }
                else // move rect marker
                {
                    PointLatLng pnew = MainMap.FromLocalToLatLng(e.X, e.Y);

                    int? pIndex = (int?)CurentRectMarker.Tag;
                    if (pIndex.HasValue)
                    {
                        /*if (pIndex < polygon.Points.Count)
                        {
                            polygon.Points[pIndex.Value] = pnew;
                            MainMap.UpdatePolygonLocalPosition(polygon);
                        }*/
                    }

                    if (currentMarker.IsVisible)
                    {
                        currentMarker.Position = pnew;
                    }
                    CurentRectMarker.Position = pnew;

                    if (CurentRectMarker.InnerMarker != null)
                    {
                        CurentRectMarker.InnerMarker.Position = pnew;
                    }
                }

                if (current != null && isMouseDown)
                {
                    dragging = true;
                    current.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }

                MainMap.Refresh(); // force instant invalidation
            }
        }

        // MapZoomChanged
        void MainMap_OnMapZoomChanged()
        {
            trackBar1.Value = (int)(MainMap.Zoom * 100.0);
            textBoxZoomCurrent.Text = MainMap.Zoom.ToString();
        }

        // click on some marker
        void MainMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (item is GMapMarkerRect)
                {
                    GeoCoderStatusCode status;
                    var pos = GMapProviders.GoogleMap.GetPlacemark(item.Position, out status);
                    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && pos != null)
                    {
                        GMapMarkerRect v = item as GMapMarkerRect;
                        {
                            v.ToolTipText = ((Placemark)pos).Address;
                        }
                        MainMap.Invalidate(false);
                    }
                }
                else
                {
                    if (item.Tag != null)
                    {

                    }
                }
            }
        }

        // loader start loading tiles
        void MainMap_OnTileLoadStart()
        {
            MethodInvoker m = delegate()
            {
                MenuPage.Text = "Menu: loading tiles...";
            };
            try
            {
                BeginInvoke(m);
            }
            catch
            {
            }
        }

        // loader end loading tiles
        void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            MethodInvoker m = delegate()
            {
                MenuPage.Text = "Menu, last load in " + MainMap.ElapsedMilliseconds + "ms";

                textBoxMemory.Text = string.Format(CultureInfo.InvariantCulture, "{0:0.00} MB of {1:0.00} MB", MainMap.Manager.MemoryCache.Size, MainMap.Manager.MemoryCache.Capacity);
            };
            try
            {
                BeginInvoke(m);
            }
            catch
            {
            }
        }

        // current point changed
        void MainMap_OnPositionChanged(PointLatLng point)
        {
            textBoxLatCurrent.Text = point.Lat.ToString(CultureInfo.InvariantCulture);
            textBoxLngCurrent.Text = point.Lng.ToString(CultureInfo.InvariantCulture);


        }

        // center markers on start
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (objects.Markers.Count > 0)
            {
                //MainMap.ZoomAndCenterMarkers(null);
            }
            trackBar1.Value = (int)MainMap.Zoom * 100;
            Activate();
        }
        #endregion

        #region -- ui events --

        

        // change map type
        private void comboBoxMapType_DropDownClosed(object sender, EventArgs e)
        {
            MainMap.MapProvider = comboBoxMapType.SelectedItem as GMapProvider;
        }

        // change mdoe
        private void comboBoxMode_DropDownClosed(object sender, EventArgs e)
        {
            MainMap.Manager.Mode = (AccessMode)comboBoxMode.SelectedValue;
            MainMap.ReloadMap();
        }

        // zoom
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            MainMap.Zoom = trackBar1.Value / 100.0;
        }

        

       

        // reload map
        private void button1_Click(object sender, EventArgs e)
        {
            MainMap.ReloadMap();
        }

        // cache config
        private void checkBoxUseCache_CheckedChanged(object sender, EventArgs e)
        {
            MainMap.Manager.UseRouteCache = checkBoxUseRouteCache.Checked;
            MainMap.Manager.UseGeocoderCache = checkBoxUseRouteCache.Checked;
            MainMap.Manager.UsePlacemarkCache = checkBoxUseRouteCache.Checked;
            MainMap.Manager.UseDirectionsCache = checkBoxUseRouteCache.Checked;
        }

        // clear cache
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure?", "Clear GMap.NET cache?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    MainMap.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
                    MessageBox.Show("Done. Cache is clear.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




        // export map data
        private void button9_Click(object sender, EventArgs e)
        {
            MainMap.ShowExportDialog();
        }

        // import map data
        private void button10_Click(object sender, EventArgs e)
        {
            MainMap.ShowImportDialog();
        }

        // prefetch
        private void button11_Click(object sender, EventArgs e)
        {
            RectLatLng area = MainMap.SelectedArea;
            if (!area.IsEmpty)
            {
                for (int i = (int)MainMap.Zoom; i <= MainMap.MaxZoom; i++)
                {
                    DialogResult res = MessageBox.Show("Ready ripp at Zoom = " + i + " ?", "GMap.NET", MessageBoxButtons.YesNoCancel);

                    if (res == DialogResult.Yes)
                    {
                        using (TilePrefetcher obj = new TilePrefetcher())
                        {
                            obj.Owner = this;
                            obj.ShowCompleteMessage = true;
                            obj.Start(area, i, MainMap.MapProvider, 100, 100);
                        }
                    }
                    else if (res == DialogResult.No)
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // saves current map view 
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG (*.png)|*.png";
                    sfd.FileName = "GMap.NET image";

                    Image tmpImage = MainMap.ToImage();
                    if (tmpImage != null)
                    {
                        using (tmpImage)
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                tmpImage.Save(sfd.FileName);

                                MessageBox.Show("Image saved: " + sfd.FileName, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image failed to save: " + ex.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // key-up events
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            int offset = -22;

            if (e.KeyCode == Keys.Left)
            {
                MainMap.Offset(-offset, 0);
            }
            else if (e.KeyCode == Keys.Right)
            {
                MainMap.Offset(offset, 0);
            }
            else if (e.KeyCode == Keys.Up)
            {
                MainMap.Offset(0, -offset);
            }
            else if (e.KeyCode == Keys.Down)
            {
                MainMap.Offset(0, offset);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (CurentRectMarker != null)
                {
                    objects.Markers.Remove(CurentRectMarker);

                    if (CurentRectMarker.InnerMarker != null)
                    {
                        objects.Markers.Remove(CurentRectMarker.InnerMarker);
                    }
                    CurentRectMarker = null;

                    //RegeneratePolygon();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                MainMap.Bearing = 0;


            }
        }

        // key-press events
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MainMap.Focused)
            {
                if (e.KeyChar == '+')
                {
                    MainMap.Zoom = ((int)MainMap.Zoom) + 1;
                }
                else if (e.KeyChar == '-')
                {
                    MainMap.Zoom = ((int)(MainMap.Zoom + 0.99)) - 1;
                }
                else if (e.KeyChar == 'a')
                {
                    MainMap.Bearing--;
                }
                else if (e.KeyChar == 'z')
                {
                    MainMap.Bearing++;
                }
            }
        }


        #endregion




        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("listBox2_MouseDoubleClick");

            frmLinkParams frm = new frmLinkParams(links[listBox2.SelectedIndex].Band, links[listBox2.SelectedIndex].possible_freqs, this);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //ustanavlivaem diapazon tekuschego linka i ego otvetnoi chasti
                links[listBox2.SelectedIndex].Band = frm.band;
                if (listBox2.SelectedIndex % 2 != 0) links[listBox2.SelectedIndex-1].Band = frm.band;
                else links[listBox2.SelectedIndex + 1].Band = frm.band;
                //ustanovlen



            }
            Debug.WriteLine(frm.Result);
            Debug.WriteLine(frm.band);

            links_CollectionChanged(this, new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
           
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            objects.Markers.Clear();
            freqs.Markers.Clear();
            routes.Routes.Clear();
            links.Clear();
            listBox3.Items.Clear();
            //resultsList.Items.Clear();
            xelshemshleli_sites.Clear();

            FindBtn.Enabled = false;
            SaveKmlBtn.Enabled = false;
        }

        private void FindBtn_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            freqs.Markers.Clear();
            listBox2.Enabled = false;
            FindBtn.Enabled = false;
            ClearBtn.Enabled = false;
            backgroundWorker.RunWorkerAsync(DistBar.Value / 10.0);
        }

        private void SaveKmlBtn_Click(object sender, EventArgs e)
        {
            RelRoutines.exportCalcResults(xelshemshleli_sites, links, Properties.Settings.Default.FamsConnectionString.ToString(), isCheckingCurrentLink);
            SaveKmlBtn.Enabled = true;
        }

        private bool siteInCollection(ObservableCollection<Site> sites, int id)
        {
            foreach (Site s in sites)
            {
                if (s.Id == id) return true;
            }
            return false;
        }

        private void DistBar_ValueChanged(object sender, EventArgs e)
        {
            DistLabel.Text = Convert.ToString(DistBar.Value / 10.0) + " km.";
            Properties.Settings.Default.relFindRadius = DistBar.Value;
            Properties.Settings.Default.Save();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*GMapRoute route = new GMapRoute("my");
            route.Points.AddRange(GeoCodeCalc.RegionOfInterference(objects.Markers[0].Position, objects.Markers[1].Position, DistBar.Value/10));

            routes.Routes.Add(route);*/
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            Debug.WriteLine(objects.Markers[listBox1.SelectedIndex].Position.ToString());
            frm_coords coords = new frm_coords(objects.Markers[listBox1.SelectedIndex].Position.Lat, objects.Markers[listBox1.SelectedIndex].Position.Lng);
            if (coords.ShowDialog() == DialogResult.OK)
            {
                objects.Markers[listBox1.SelectedIndex].Position = new PointLatLng(coords.Lat, coords.Lon);
                Markers_CollectionChanged(this, new GMap.NET.ObjectModel.NotifyCollectionChangedEventArgs(GMap.NET.ObjectModel.NotifyCollectionChangedAction.Reset));
                MainMap.Refresh();
            }
        }

        private void EarthForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default["checkAgainstSelf"] = checkAgainstSelfBox.Checked;
            Properties.Settings.Default.Save();
        }


        


    }

    

}
