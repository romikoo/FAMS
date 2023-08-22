using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XNA;
using Helpers;
using System.Threading;
using DevExpress.XtraEditors;
using System.Deployment.Application;
using ERO;


namespace Fams
{
    public partial class FormMenu : DevExpress.XtraEditors.XtraForm
    {

#if DEBUG
        User user = new User("რომან ქურდაძე");
#else
        User user;// = new User("სტუმარი");
#endif


        frmMain main;
        frmOrgs orgs;
        Game _game;
        commShare common = new commShare();

        Earth.EarthHelpers earth;
        Earth.EarthHelpers earthFreq;


        public FormMenu()
        {
            InitializeComponent();

            if (ApplicationDeployment.IsNetworkDeployed)
                this.tileItem1.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4);
            this.tileItem1.Elements[2].Text = RetrieveLinkerTimestamp().ToString();
            

            this.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Left;
            this.Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2;
            this.Width = System.Windows.Forms.Screen.GetBounds(this).Width;

            common.showFreqOnMap += new commShare.WannaShowFreqOnMapDelegate(callEarthForFreq);
        }

        public Version AssemblyVersion
        {
            get
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
        }

        private void exitItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Application.Exit();
        }

        private void itemXNA_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (user == null) authorizeItem_ItemClick(null, null);

            if (user != null)
            {
                Thread theThread = new Thread(StartGame);
                theThread.Start();
            }
        }

        public void StartGame()
        {


            if (_game != null)
            {
                common.fire_WinStateChange(null, new WinStateArgs(FormWindowState.Maximized));
                return;
            }

            showWait();

            this.BeginInvoke((Action)delegate() { this.Enabled = false; });
            _game = new Game(user, ref common);
            _game.myform.Resize += new EventHandler(gameWindowResized);
            this.BeginInvoke((Action)delegate() { this.Enabled = true; });
            hideWait();
            _game.Run();

            try
            {
                _game.Dispose();
                _game = null;
            }
            catch { }

            try
            {
                this.BeginInvoke((Action)delegate() { Helpers.Functions.bringWindowToFront(this, FormWindowState.Normal); });
            }
            catch { }
        }

        protected void showWait(string caption = "იტვირთება                                        .", string description = "გთხოვთ დაელოდოთ...                         .")
        {
            if (user == null) authorizeItem_ItemClick(null, null);

            if (user != null)
            {
                System.Diagnostics.Debug.WriteLine("showWait");
                splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Helpers.WaitForm1), true, true);
                splashScreenManager1.ShowWaitForm();
                splashScreenManager1.SetWaitFormCaption(caption);
                splashScreenManager1.SetWaitFormDescription(description);
            }
        }

        protected void hideWait()
        {
            System.Diagnostics.Debug.WriteLine("hideWait");
            try
            {
                splashScreenManager1.CloseWaitForm();
                splashScreenManager1.Dispose();
            }
            catch { }
        }

        protected void gameWindowResized(object sender, EventArgs e)
        {
            if (_game.myform.WindowState == FormWindowState.Minimized)
                this.BeginInvoke((Action)delegate() { Helpers.Functions.bringWindowToFront(this); });
        }

        private void callEarthForFreq(object sender, ShowFreqArgs e)
        {
            if (earthFreq != null) earthFreq.closeMap();

            earthFreq = new Earth.EarthHelpers(this);
            earthFreq.showFreq(e.freqID);
            earthFreq.form.FormClosed += new FormClosedEventHandler(EarthFreqFormClosed);
        }

        private void EarthFreqFormClosed(object sender, FormClosedEventArgs e)
        {
            earthFreq = null;
        }


        private void authorizeItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmLogin login = new frmLogin();

            login.ShowDialog();


            if (login.user != null)
            {
                user = login.user;
                authorizeItem.Text = user.UserName;
                //orgsItem.Visible = user.ReestritCheck;
                if (this.user.UserName == "ანა დაბრუნდაშვილი" || this.user.UserName == "ნოდარ ასპანიძე" || this.user.UserName == "რომან ქურდაძე")
                    this.DBFreqItem.Visible = true;
                if (_game != null)
                {
                    _game.Exit();
                    _game = null;
                    itemXNA_ItemClick(sender, null);
                }

                if (main != null)
                {
                    main.Close();
                    mainItem_ItemClick(sender, null);
                }

            }

        }

        private void mainItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (main != null) Helpers.Functions.bringWindowToFront(main);
            else
            {
                showWait();
                if (user != null)
                {
                    main = new frmMain(user, ref common);
                    main.FormClosed += new FormClosedEventHandler(mainFormClosed);
                    main.Show();
                }
                hideWait();
            }
        }


        private void mainFormClosed(object sender, FormClosedEventArgs e)
        {
            main = null;
        }

        private void microwaveItem_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (earth != null) Helpers.Functions.bringWindowToFront(earth.form, FormWindowState.Maximized);
            else
            {
                showWait();
                if (user != null)
                {
                    earth = new Earth.EarthHelpers(this);
                    earth.showMap(true);
                    earth.form.FormClosed += new FormClosedEventHandler(EarthFormClosed);
                }
                hideWait();
            }
        }

        private void EarthFormClosed(object sender, FormClosedEventArgs e)
        {
            earth = null;
        }

        private void azimutItem_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!user.EditFreqs || !user.EditLicence) return;

            showWait();
            if (user == null)
            {
                hideWait(); return;
            }

            frmAzimut az = new frmAzimut();
            hideWait();
            az.ShowDialog();

        }

        private void securedItem_ItemClick(object sender, TileItemEventArgs e)
        {
            showWait();
            if (user != null && user.Confidential)
            {
                frmSecured frm = new frmSecured();
                hideWait();
                frm.ShowDialog();
            }
            else hideWait();
        }

        private void shekvaniliItem_ItemClick(object sender, TileItemEventArgs e)
        {
            showWait();
            if (user != null)
            {
                frmStationsPasswords frm = new frmStationsPasswords(user);
                hideWait();
                frm.ShowDialog();
            }
            else hideWait();
        }

        private void orgsItem_ItemClick(object sender, TileItemEventArgs e)
        {
            if (orgs != null) Helpers.Functions.bringWindowToFront(orgs);
            else
            {
                showWait();
                if (user != null)
                {
                    orgs = new frmOrgs(user, ref common);
                    orgs.FormClosed += new FormClosedEventHandler(orgsFormClosed);
                    orgs.Show();
                }
                hideWait();
            }
            
        }

        private void orgsFormClosed(object sender, FormClosedEventArgs e)
        {
            orgs.Dispose();
            orgs = null;
        }

        private void docmasterItem_ItemClick(object sender, TileItemEventArgs e)
        {
            showWait();
            if (user != null && user.Nebartva)
            {
                frmDocmaster f = new frmDocmaster(user);
                hideWait();
                f.ShowDialog();
            }
            else hideWait();
           

        }

        private void minButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void eroTileItem_ItemClick(object sender, TileItemEventArgs e)
        {
            showWait();
            if (user != null && user.AddFreq)
            {
                ERO.Form1 f = new Form1();
                hideWait();
                f.ShowDialog();
            }
            else hideWait();
        }










        private DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.ToLocalTime();
            return dt;
        }

        private void preferencesItem_ItemClick(object sender, TileItemEventArgs e)
        {
            frmAdministrator f = new frmAdministrator(user);
            f.ShowDialog();
        }

        private void monitItem_ItemClick(object sender, TileItemEventArgs e)
        {
            showWait();
            if (user != null && user.FreqGraph)
            {
                frmDBImage f = new frmDBImage(user);
                hideWait();
                f.ShowDialog();
            }
            else hideWait();
        }

        private void DBFreqItem_ItemClick(object sender, TileItemEventArgs e)
        {
            showWait();
            if (this.user != null && this.user.FreqGraph)
            {
                frmDBfreq frmDbfreq = new frmDBfreq(user);
                hideWait();
                frmDbfreq.Show();
            }
            else hideWait();
        }


    }
}
