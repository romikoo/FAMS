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



namespace Earth
{
    public partial class miniEarthForm : Form
    {
        // layers
        readonly GMapOverlay top = new GMapOverlay();
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        internal readonly GMapOverlay routes = new GMapOverlay("routes");
        private readonly Object _lock = new Object();

        // marker
        GMarkerGoogle currentMarker;


        // etc
        ObservableCollection<Link> links = new ObservableCollection<Link>();
        ObservableCollection<Site> xelshemshleli_sites = new ObservableCollection<Site>();

        readonly Random rnd = new Random();
        GMapMarkerRect CurentRectMarker = null;
        string mobileGpsLog = string.Empty;
        bool isMouseDown = false;
        GMapMarker current = null;

        public double ReturnLat { get; set; }
        public double ReturnLon { get; set; } 


        public miniEarthForm()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

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
                MainMap.MapProvider = GMapProviders.GoogleHybridMap;
#else
                MainMap.MapProvider = GMapProviders.OpenStreetMap;
#endif
                MainMap.Position = new PointLatLng(42.51, 43.5);
                MainMap.MinZoom = 3;
                MainMap.MaxZoom = 22;
                MainMap.Zoom = 8;

                // map events
                {
                    MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
                    MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);

                    MainMap.Manager.OnTileCacheComplete += new TileCacheComplete(OnTileCacheComplete);
                    MainMap.Manager.OnTileCacheStart += new TileCacheStart(OnTileCacheStart);
                    MainMap.Manager.OnTileCacheProgress += new TileCacheProgress(OnTileCacheProgress);
                }

                MainMap.MouseMove += new MouseEventHandler(MainMap_MouseMove);
                MainMap.MouseDown += new MouseEventHandler(MainMap_MouseDown);
                MainMap.MouseDoubleClick += new MouseEventHandler(MainMap_MouseDoubleClick);










                // add custom layers  
                {
                    MainMap.Overlays.Add(routes);
                    MainMap.Overlays.Add(objects);
                    MainMap.Overlays.Add(top);

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



        }




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


      







        #region -- map events --



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
                    
                };
                Invoke(m);
            }
        }







        void MainMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GMarkerGoogle m = new GMarkerGoogle(MainMap.FromLocalToLatLng(e.X, e.Y), GMarkerGoogleType.green_pushpin);
            m.Tag = objects.Markers.Count + 1;
            m.ToolTipMode = MarkerTooltipMode.Always;
            m.ToolTipText = (objects.Markers.Count + 1).ToString();

            
            ReturnLat = MainMap.FromLocalToLatLng(e.X, e.Y).Lat;
            ReturnLon = MainMap.FromLocalToLatLng(e.X, e.Y).Lng;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
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
                    current.Position = MainMap.FromLocalToLatLng(e.X, e.Y);
                }

                MainMap.Refresh(); // force instant invalidation
            }
        }



        // loader start loading tiles
        void MainMap_OnTileLoadStart()
        {
            MethodInvoker m = delegate()
            {
                
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

            };
            try
            {
                BeginInvoke(m);
            }
            catch
            {
            }
        }

       

        // center markers on start
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (objects.Markers.Count > 0)
            {
                //MainMap.ZoomAndCenterMarkers(null);
            }
            Activate();
        }
        #endregion

        private void MainMap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }





    }

    

}
