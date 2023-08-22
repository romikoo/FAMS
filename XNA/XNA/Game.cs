using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Net;
//using Microsoft.Xna.Framework.Storage;
using SysWinForms = System.Windows.Forms; // to avoid conflicts with namespaces
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Helpers;
using Earth;
using System.ComponentModel;



namespace XNA
{
    public class ChangeEventArgs : EventArgs
    {

    }

    

    public class myMouse
    {
        public delegate void ChangedDelegate(object sender, ChangeEventArgs e);

        public event ChangedDelegate stateChange;
        


        

        public Vector2 Position;
        public Vector2 absPosition;
        public Cursor cursor;
        public bool aboveControl;
        public bool aboveScalingPoints;

        private bool _pressed;
        public bool pressed
        {
            get { return _pressed; }
            set { _pressed = value; }
        }

        private float _scrollValue;
        public float scrollValue
        {
            get { return _scrollValue; }
            set
            {
                _scrollValue = value;
                if (value > 0) _scrollValue = 0;
                if (value < -11880) _scrollValue = -11880;
            }
        }

        private bool _drawing;
        public bool drawing
        {
            get { return _drawing; }
            set
            {
                _drawing = value;
                this.stateChange(this, null);
            }
        }

        private bool _startedDrawing;
        public bool startedDrawing
        {
            get { return _startedDrawing; }
            set
            {
                _startedDrawing = value;
                this.stateChange(this, null);
            }
        }

        private bool _commentScaling;
        public bool commentScaling
        {
            get { return _commentScaling; }
            set
            {
                _commentScaling = value;
                this.stateChange(this, null);
            }
        }

        private bool _commentDraging;
        public bool commentDraging
        {
            get { return _commentDraging; }
            set { _commentDraging = value; }
        }

        private bool _screenDraging;
        public bool screenDraging
        {
            get { return _screenDraging; }
            set
            {
                _screenDraging = value;
                this.stateChange(this, null);
            }
        }


        public myMouse()
        {
            _drawing = false;
            _startedDrawing = false;
            _commentScaling = false;
            this.aboveControl = false;

            this.stateChange += new ChangedDelegate(myMouse_stateChange);
        }

        private void myMouse_stateChange(object sender, EventArgs e)
        {
            if (_drawing || _startedDrawing)
            {
                _commentScaling = false;
                _screenDraging = false;
                _commentDraging = false;
            }
            if (_commentScaling)
            {
                _drawing = false;
                _startedDrawing = false;
                _screenDraging = false;
                _commentDraging = false;
            }
            if (_screenDraging)
            {
                _drawing = false;
                _startedDrawing = false;
                _commentScaling = false;
                _commentDraging = false;
            }

        }

    }

    public class Game : Microsoft.Xna.Framework.Game
    {

        commShare common;
        //Splash sp = new Splash();
        EarthHelpers EarthHelper;

        myMouse mice = new myMouse();
        public User user;

        Helpers.Screen screen;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera2D camera;

        SpriteFont Font;
        SpriteFont Font1;

        public Form myform;
        KeyboardState keyboardState;
        const float spriteSpeed = 4.0f;
        Vector2 mousePos;
        Rectangle world;
        Vector2 camLastState;
        Texture2D pixel;
        float fromX, fromY; //for comments drawing
        bool active = true; // form active/inactive
        ArrayList comments;
        Comment selectedComm;
        int affectedComm;
        Rectangle lu, ru, ld, rd, uc, lc, rc, dc;
        String currScalingPoint;
        Vector2 ScaleStart = Vector2.Zero;
        AllocationPlan alloc;
        frequencies frq;
        ArrayList occupiedFreqs;  //massiv narisovanix chastot
        FREQVIEW HighlightedFreq = null;
        fr_Plan HighlightedPlan = null;
        ero_Implementation HighlightedImplementation = null;
        ArrayList AllocsToDraw;
        public zone_cities zCities;
        ero ero_pl = new ero();

        bool measuringDistance = false;
        FREQVIEW fromFreq, toFreq;

        frmSearch searchForm;
        public FREQVIEW FoundFreq = null;
        frmMonGraph mon = null;
        //frmMain main = null;

        private BackgroundWorker relLinksGetter;
        private FREQVIEW prevFreq = null;
        private string relLinkDescription = "";


        float dX = 0;
        float dY = 0;

        /// <summary>
        /// Windows elements
        /// </summary>
        //private SysWinForms.Button commentsBtn;
        private SysWinForms.Button handBtn;

        private System.Windows.Forms.ContextMenuStrip MainContextMenu = new ContextMenuStrip();
        private System.Windows.Forms.ToolStripMenuItem სიხშირეToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem რედაქტირებაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem ახალიToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem გასვლაToolStripMenuItem = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem კომენტარისხატვაToolStripMenuItem = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem პუნქტებისარჩევაToolStripMenuItem = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem სიხშირისკომენტარიToolStripMenuItem = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem არხებისგანაწილებაToolStripMenuItem = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        private System.Windows.Forms.ToolStripMenuItem showAllFrequenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem გადაწყვეტილებაToolStripMenuItem = new ToolStripMenuItem();
        public System.Windows.Forms.ToolStripMenuItem ძებნაToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        public System.Windows.Forms.ToolStripMenuItem ორგანიზაციებიToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        private System.Windows.Forms.ToolStripMenuItem CoordsToolStripMenuItem = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
        public System.Windows.Forms.ToolStripMenuItem EarthToolStripMenuItem = new ToolStripMenuItem();
        public System.Windows.Forms.ToolStripMenuItem XTerraToolStripMenuItem = new ToolStripMenuItem();
        
        private HScrollBar ScrollBar = new HScrollBar();

     

        #region game methods


        public Game(User us, ref commShare comm)
        {
            //sp.Show();
            common = comm;
            common.GoToFreq += new commShare.WannaGoToFreqDelegate(gotofreq);
            common.WinStateChange += new commShare.WinStateDelegate(restoreWindow);
            EarthHelper = new EarthHelpers(this);
            System.Windows.Forms.Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            //initialize
            comments = new ArrayList();// sp.progressBar.Value++; System.Windows.Forms.Application.DoEvents();
            alloc = new AllocationPlan();// sp.progressBar.Value++; System.Windows.Forms.Application.DoEvents();
            occupiedFreqs = new ArrayList();// sp.progressBar.Value++; System.Windows.Forms.Application.DoEvents();
            AllocsToDraw = new ArrayList(); //sp.progressBar.Value++; System.Windows.Forms.Application.DoEvents();
            zCities = new zone_cities(us); //sp.progressBar.Value++; System.Windows.Forms.Application.DoEvents();
            ero_pl = new ero(); //sp.progressBar.Value++; System.Windows.Forms.Application.DoEvents();
            //inicialize complete


            this.user = us;
            frq = new frequencies(this.user);

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            myform = (Form)Form.FromHandle(this.Window.Handle);
            myform.MouseMove += new System.Windows.Forms.MouseEventHandler(myform_MouseMove);
            myform.Deactivate += new System.EventHandler(myform_Deactivate);
            myform.Activated += new System.EventHandler(myform_Activated);
            myform.Shown += new EventHandler(myform_Shown);
            myform.MouseWheel += new MouseEventHandler(myform_MouseWheel);
            myform.MouseClick += new MouseEventHandler(myform_MouseClick);
            myform.MouseDoubleClick += new MouseEventHandler(myform_MouseDoubleClick);
            myform.MouseDown += new MouseEventHandler(myform_MouseDown);
            myform.MouseUp += new MouseEventHandler(myform_MouseUp);
            myform.ClientSizeChanged += new EventHandler(myform_ClientSizeChanged);
            myform.KeyPreview = true;
            myform.KeyDown += new KeyEventHandler(myform_KeyDown);
            myform.Cursor = Cursors.Arrow;
            myform.ContextMenuStrip = this.MainContextMenu;
            //myform.Bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            myform.WindowState = FormWindowState.Maximized;
            myform.FormBorderStyle = FormBorderStyle.FixedSingle;
            MainContextMenu.ResumeLayout(false);
            myform.ResumeLayout(false);
            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = true;

            //windows elements
            /*commentsBtn = new SysWinForms.Button();
            commentsBtn.BackColor = System.Drawing.Color.DarkGray;
            commentsBtn.Location = new System.Drawing.Point(10, 10);
            commentsBtn.Width = 40;
            commentsBtn.Height = 40;
            commentsBtn.TabStop = false;
            commentsBtn.MouseEnter += new EventHandler(commentsBtn_MouseEnter);
            commentsBtn.MouseLeave += new EventHandler(commentsBtn_MouseLeave);
            commentsBtn.Click += new EventHandler(commentsBtn_Click);
            commentsBtn.Text = "Draw";
            myform.Controls.Add(commentsBtn);*/

            handBtn = new SysWinForms.Button();
            handBtn.BackColor = System.Drawing.Color.DarkGray;
            handBtn.Location = new System.Drawing.Point(50, 10);
            handBtn.Width = 40;
            handBtn.Height = 40;
            handBtn.TabStop = false;
            handBtn.MouseEnter += new EventHandler(commentsBtn_MouseEnter);
            handBtn.MouseLeave += new EventHandler(commentsBtn_MouseLeave);
            handBtn.Click += new EventHandler(handBtn_Click);
            handBtn.Text = "Save";
            myform.Controls.Add(handBtn);

            // 
            // MainContextMenu
            // 
            this.MainContextMenu.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.სიხშირეToolStripMenuItem,
            this.toolStripSeparator2,
            this.ძებნაToolStripMenuItem,
            this.toolStripSeparator4,
            this.კომენტარისხატვაToolStripMenuItem,
            this.პუნქტებისარჩევაToolStripMenuItem,
            this.სიხშირისკომენტარიToolStripMenuItem,
            this.არხებისგანაწილებაToolStripMenuItem,
            this.toolStripSeparator5,
            this.ორგანიზაციებიToolStripMenuItem,
            this.toolStripSeparator6,
            this.CoordsToolStripMenuItem,
            this.toolStripSeparator1,
            this.EarthToolStripMenuItem,
            this.XTerraToolStripMenuItem,
            this.toolStripSeparator7,
            this.გასვლაToolStripMenuItem});
            this.MainContextMenu.Name = "MainContextMenu";
            this.MainContextMenu.Size = new System.Drawing.Size(170, 70);
            this.MainContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.MainContextMenu_Opening);

            // 
            // სიხშირეToolStripMenuItem
            // 
            this.სიხშირეToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.showAllFrequenciesToolStripMenuItem,
                this.გადაწყვეტილებაToolStripMenuItem});
            this.სიხშირეToolStripMenuItem.Name = "სიხშირეToolStripMenuItem";
            this.სიხშირეToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.სიხშირეToolStripMenuItem.Text = "სიხშირე";
            // 
            // ძებნაToolStripMenuItem
            // 
            this.ძებნაToolStripMenuItem.Checked = false;
            this.ძებნაToolStripMenuItem.CheckOnClick = true;
            this.ძებნაToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            //this.ძებნაToolStripMenuItem.Image = global::Fams.Properties.Resources.Search1;
            this.ძებნაToolStripMenuItem.Name = "ძებნაToolStripMenuItem";
            this.ძებნაToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.ძებნაToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.ძებნაToolStripMenuItem.Text = "ძებნა";
            this.ძებნაToolStripMenuItem.Click += new System.EventHandler(this.ძებნაToolStripMenuItem_Click);

            this.showAllFrequenciesToolStripMenuItem.Checked = true;
            this.showAllFrequenciesToolStripMenuItem.CheckOnClick = true;
            this.showAllFrequenciesToolStripMenuItem.CheckState = CheckState.Checked;
            this.showAllFrequenciesToolStripMenuItem.Name = "showAllFrequenciesToolStripMenuItem";
            this.showAllFrequenciesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Alt;
            this.showAllFrequenciesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.showAllFrequenciesToolStripMenuItem.Text = "ყველა არსებული სიხშირე";
            this.showAllFrequenciesToolStripMenuItem.Click += new EventHandler(this.showAllFrequenciesToolStripMenuItem_Click);

            // 
            // გადაწყვეტილებაToolStripMenuItem
            // 
            this.გადაწყვეტილებაToolStripMenuItem.Name = "გადაწყვეტილებაToolStripMenuItem";
            this.გადაწყვეტილებაToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.გადაწყვეტილებაToolStripMenuItem.Text = "გადაწყვეტილება...";
            this.გადაწყვეტილებაToolStripMenuItem.Click += new System.EventHandler(this.გადაწყვეტილებაToolStripMenuItem_Click);
            // 
            // ორგანიზაციებიToolStripMenuItem
            // 
            this.ორგანიზაციებიToolStripMenuItem.Name = "ორგანიზაციებიToolStripMenuItem";
            this.ორგანიზაციებიToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ორგანიზაციებიToolStripMenuItem.Text = "ორგანიზაციები...";
            this.ორგანიზაციებიToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.ორგანიზაციებიToolStripMenuItem.Click += new System.EventHandler(this.ორგანიზაციებიToolStripMenuItem_Click);
            
            
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(185, 6);
            // 
            // CoordsToolStripMenuItem
            // 
            this.CoordsToolStripMenuItem.Visible = false;
            this.CoordsToolStripMenuItem.Name = "CoordsToolStripMenuItem";
            this.CoordsToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.CoordsToolStripMenuItem.Text = "კოორდინატები...";
            this.CoordsToolStripMenuItem.Click += new System.EventHandler(this.CoordsToolStripMenuItem_Click);
            
           
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(185, 6);
            // 
            // გასვლაToolStripMenuItem
            // 
            this.გასვლაToolStripMenuItem.Name = "გასვლაToolStripMenuItem";
            this.გასვლაToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.გასვლაToolStripMenuItem.Text = "გასვლა";
            this.გასვლაToolStripMenuItem.Click += new System.EventHandler(this.გასვლაToolStripMenuItem_Click);
            // 
            // კომენტარისხატვაToolStripMenuItem
            // 
            this.კომენტარისხატვაToolStripMenuItem.Name = "კომენტარისხატვაToolStripMenuItem";
            this.კომენტარისხატვაToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.კომენტარისხატვაToolStripMenuItem.Text = "კომენტარის ხატვა...";
            this.კომენტარისხატვაToolStripMenuItem.Enabled = false;
            // 
            // პუნქტებისარჩევაToolStripMenuItem
            // 
            this.პუნქტებისარჩევაToolStripMenuItem.Name = "პუნქტებისარჩევაToolStripMenuItem";
            this.პუნქტებისარჩევაToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.პუნქტებისარჩევაToolStripMenuItem.Text = "პუნქტების არჩევა...";
            this.პუნქტებისარჩევაToolStripMenuItem.Click += new System.EventHandler(this.პუნქტებისარჩევაToolStripMenuItem_Click);
            // 
            // სიხშირისკომენტარიToolStripMenuItem
            // 
            this.სიხშირისკომენტარიToolStripMenuItem.Checked = true;
            this.სიხშირისკომენტარიToolStripMenuItem.CheckOnClick = true;
            this.სიხშირისკომენტარიToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.სიხშირისკომენტარიToolStripMenuItem.Name = "სიხშირისკომენტარიToolStripMenuItem";
            this.სიხშირისკომენტარიToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.სიხშირისკომენტარიToolStripMenuItem.Text = "სიხშირის კომენტარი";
            // 
            // არხებისგანაწილებაToolStripMenuItem
            // 
            this.არხებისგანაწილებაToolStripMenuItem.CheckOnClick = true;
            this.არხებისგანაწილებაToolStripMenuItem.Name = "არხებისგანაწილებაToolStripMenuItem";
            this.არხებისგანაწილებაToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.არხებისგანაწილებაToolStripMenuItem.Text = "არხების განაწილება";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(185, 6);
            // 
            // EarthToolStripMenuItem
            // 
            this.EarthToolStripMenuItem.Enabled = false;
            this.EarthToolStripMenuItem.Name = "EarthToolStripMenuItem";
            this.EarthToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.EarthToolStripMenuItem.Text = "ჩვენება რუკაზე....";
            this.EarthToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.EarthToolStripMenuItem.Click +=new EventHandler(EarthToolStripMenuItem_Click);
            // 
            // XTerraToolStripMenuItem
            // 
            this.XTerraToolStripMenuItem.Visible = false;
            this.XTerraToolStripMenuItem.Name = "XTerraToolStripMenuItem";
            this.XTerraToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.XTerraToolStripMenuItem.Text = "XTerra...";
            this.XTerraToolStripMenuItem.BackColor = System.Drawing.Color.LightPink;
            this.XTerraToolStripMenuItem.Click += new EventHandler(XTerraToolStripMenuItem_Click);
           
            // 
            // ScrollBar
            // 
            this.ScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScrollBar.Name = "ScrollBar";
            this.ScrollBar.Minimum = 0;
            this.ScrollBar.Minimum = 1000;
            this.ScrollBar.LargeChange = 1000;
            this.ScrollBar.TabIndex = 1;
            this.ScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            this.ScrollBar.ValueChanged += new EventHandler(ScrollBar_ValueChanged);
            myform.Controls.Add(ScrollBar);

            handBtn.Visible = false;

            screen = new Helpers.Screen(myform.ClientRectangle.Width, myform.ClientRectangle.Height);

            if (!this.user.UserName.Equals("სტუმარი"))
                return;
            this.showAllFrequenciesToolStripMenuItem.Checked = false;
            this.showAllFrequenciesToolStripMenuItem.CheckState = CheckState.Unchecked;
        }

        protected override void Initialize()
        {
            camera = new Camera2D(this, false);
            Components.Add(camera);
            

            searchForm = new frmSearch(this, frq);


            base.Initialize();
            //sp.Close();

            relLinksGetter = new BackgroundWorker();
            relLinksGetter.DoWork += new DoWorkEventHandler(relLinksGetter_DoWork);
            relLinksGetter.RunWorkerCompleted += new RunWorkerCompletedEventHandler(relLinksGetter_RunWorkerCompleted);
            relLinksGetter.ProgressChanged += new ProgressChangedEventHandler(relLinksGetter_ProgressChanged);
            relLinksGetter.WorkerReportsProgress = true;
            relLinksGetter.WorkerSupportsCancellation = true;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("Sylfaen");
            Font1 = Content.Load<SpriteFont>("MyFont");
            pixel = Content.Load<Texture2D>("pixel");
            camera.toTopLeft();


            //load comments
            DataSet ds = HelperFunctions.fill("select * from comment order by id", DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string sh = dr["Shape"].ToString().Replace("{", "");
                sh = sh.Replace("}", "");
                string[] tmp = sh.Split(' ');
                string[] X = tmp[0].Split(':');
                string[] Y = tmp[1].Split(':');
                string[] Width = tmp[2].Split(':');
                string[] Height = tmp[3].Split(':');

                string clr = dr["Color"].ToString().Replace("{", "");
                clr = clr.Replace("}", "");
                tmp = clr.Split(' ');
                string[] R = tmp[0].Split(':');
                string[] G = tmp[1].Split(':');
                string[] B = tmp[2].Split(':');
                string[] A = tmp[3].Split(':');

                Rectangle shape = new Rectangle(Convert.ToInt32(X[1]), Convert.ToInt32(Y[1]), Convert.ToInt32(Width[1]), Convert.ToInt32(Height[1]));
                Comment cm = new Comment(new Vector2(shape.X, shape.Y), new Vector2(shape.X + shape.Width, shape.Y + shape.Height), dr["Text"].ToString(), 1f, System.Drawing.Color.FromArgb(Convert.ToInt32(A[1]), Convert.ToInt32(R[1]), Convert.ToInt32(G[1]), Convert.ToInt32(B[1])));
                cm.id = Convert.ToInt32(dr["id"]);
                comments.Add(cm);
            }

            //arrange menu
            if (!user.AddFreq) ახალიToolStripMenuItem.Enabled = false;
            if (!user.EditFreqs) რედაქტირებაToolStripMenuItem.Enabled = false;
            //if (!user.ReestritCheck) main.usageVisibleCheckBox.Visibility = Telerik.WinControls.ElementVisibility.Hidden;

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();

            UpdateKeyboard();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(new Color(52, 53, 55));

            //spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.SaveState, camera.Transform);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            //DrawRect(spriteBatch, screen.WorldArea, Color.Yellow);

            //drawComments();
            if (mice.startedDrawing) drawNewComment();
            highlightLastSelectedComment();

            displayEroAllocations(45);

            displayEroImplementations(48);

            displayFreqiencies();

            drawScale();

            processHighlightedFreq();

            processHighlightedPlan();

            processHighlightedImplementation();

            ProcessFoundFreq();

            PopupAllocationsDraw();

            if (measuringDistance) measureDistance();

            /*
            spriteBatch.DrawString(Font, "Scale: " + camera.Scale.ToString() + "\r\n" +
                 "viewport: x=" + graphics.GraphicsDevice.Viewport.X.ToString() + " height=" + graphics.GraphicsDevice.Viewport.Y.ToString() + "\r\n" +
                 "campos: x=" + camera.Position.X.ToString() + " y=" + camera.Position.Y.ToString() + "\r\n" +
                 "PosX: " + mice.Position.X + " PosY: " + mice.Position.Y + "\r\n" +
                 "absX: " + mice.absPosition.X + " absY: " + mice.absPosition.Y + "\r\n" +
                 //screen.ClientArea + "\r\n"+
                 screen.WorldArea,
                 Vector2.Zero, Color.Red,
                 0f, Vector2.Zero, 1.0f, SpriteEffects.None, camera.Scale);*/


            string currfrq = HelperFunctions.getHZ(mice.Position.X);
            Vector2 stringSize = Font.MeasureString(currfrq);
            spriteBatch.DrawString(Font, currfrq, new Vector2(myform.ClientRectangle.Width - (int)(stringSize.X * 1.5) - 15, myform.ClientRectangle.Height - (int)(stringSize.Y * 1.5) - 15), Color.Black, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);
            spriteBatch.DrawString(Font, currfrq, new Vector2(myform.ClientRectangle.Width - (int)(stringSize.X * 1.5) - 17, myform.ClientRectangle.Height - (int)(stringSize.Y * 1.5) - 17), Color.Red, 0, Vector2.Zero, 1.5f, SpriteEffects.None, 0);


            spriteBatch.End();

            base.Draw(gameTime);

        }

        #endregion



        #region Form Methods

        protected void restoreWindow(object sender, WinStateArgs e)
        {
            try
            {

                myform.BeginInvoke((Action)delegate()
                {
                    if (myform.WindowState == FormWindowState.Minimized) myform.WindowState = e.state;
                    myform.TopMost = true;
                    myform.BringToFront();
                    myform.Focus();
                    myform.TopMost = false;
                });
            }
            catch { }
        }

        private void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            //myform.Text = ScrollBar.Value.ToString() + ":" + ScrollBar.Maximum.ToString();
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            screen.Coords((int)(-e.NewValue), screen.WorldArea.Y);
            myform.Text = HelperFunctions.getHZ(e.NewValue / screen.zoom);
        }

        private void გადაწყვეტილებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decision dec = new decision();
            dec.ShowDecision(HighlightedFreq);
        }



       


        private void ორგანიზაციებიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HighlightedFreq != null && HighlightedFreq.mouseIn(mice.Position))
                common.fire_goToCompFreqChange(sender, new ShowFreqArgs(HighlightedFreq.id));
               
                
            /*
            if (HighlightedFreq != null && HighlightedFreq.mouseIn(mice.Position)) main.frqID = HighlightedFreq.id;
            else main.frqID = -1;
            main.Height = this.Window.ClientBounds.Height - 100;
            main.Width = this.Window.ClientBounds.Width - 100;
            main.ShowDialog();
            
            //process updating of visual everything
            frq = new frequencies(this.user);
            zCities = new zone_cities(this.user);*/
        }



        private void CoordsToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            frmCoords co = new frmCoords();
            co.ShowDialog();*/
        }

        private void პუნქტებისარჩევაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPickCity citiesForm = new frmPickCity(ref zCities);
            citiesForm.ShowDialog();
        }

        private void გასვლაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void ძებნაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ძებნაToolStripMenuItem.Checked == true) searchForm.Show();
            else searchForm.Hide();
        }

        private void showAllFrequenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
       

        private void EarthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            common.fire_showFreqOnMap(sender, new ShowFreqArgs(HighlightedFreq.id));
        }

        

        private void XTerraToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            frmXTerra xt = new frmXTerra();
            xt.ShowDialog();
            MainContextMenu.Items.Remove(XTerraToolStripMenuItem);
            Application.Exit();*/
        }

        private void MainContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            რედაქტირებაToolStripMenuItem.Enabled = (HighlightedFreq != null && HighlightedFreq.mouseIn(mice.Position) && user.EditFreqs) ? true : false;
            გადაწყვეტილებაToolStripMenuItem.Enabled = (HighlightedFreq != null && HighlightedFreq.mouseIn(mice.Position)) ? true : false;
            if (HighlightedFreq != null && HighlightedFreq.mouseIn(mice.Position))
            {
                EarthToolStripMenuItem.Enabled = true;
                ორგანიზაციებიToolStripMenuItem.Enabled = true;
            }
            else
            {
                EarthToolStripMenuItem.Enabled = false;
                ორგანიზაციებიToolStripMenuItem.Enabled = false;
            }

            
        }

        void myform_ClientSizeChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(myform.ClientRectangle.Width + ":" + myform.ClientRectangle.Height, " myform_ClientSizeChanged");
            try
            {
                screen.width = myform.ClientRectangle.Width;
                screen.height = myform.ClientRectangle.Height;
                if (screen.X == 0 && screen.Y == 0) screen.Coords(-150000, 220);

                ScrollBar.Minimum = 0;
                ScrollBar.Maximum = (int)(frq.maxFreq * screen.zoom);
                ScrollBar.LargeChange = (int)(frq.maxFreq / 200);

                searchForm.coords(myform);
            }
            catch { }

            if (myform.WindowState == FormWindowState.Minimized)
            {
                searchForm.TopMost = false;
                try { mon.Close(); }
                catch { }
            }
            else
            {
                try
                {
                    searchForm.TopMost = true;
                }
                catch { }
            }
        }

        /*void commentsBtn_Click(object sender, EventArgs e)
        {

            if (mice.drawing)
            {
                mice.drawing = false;
                mice.startedDrawing = false;
                commentsBtn.BackColor = System.Drawing.Color.DarkGray;
            }
            else
            {
                mice.drawing = true;
                commentsBtn.BackColor = System.Drawing.Color.DarkOrange;
            }
        }*/

        void handBtn_Click(object sender, EventArgs e)
        {
            myform.Cursor = Cursors.WaitCursor;
            SaveComments();
            myform.Cursor = Cursors.Default;
            handBtn.Visible = false;
        }

        void commentsBtn_MouseEnter(object sender, EventArgs e)
        {
            mice.aboveControl = true;
        }

        void commentsBtn_MouseLeave(object sender, EventArgs e)
        {
            mice.aboveControl = false;
        }

        void myform_Deactivate(object sender, EventArgs e)
        {
            camLastState = camera.Position;
            active = false;
        }

        void myform_Activated(object sender, EventArgs e)
        {
            camera.Position = camLastState;
            active = true;
        }

        void myform_Shown(object sender, EventArgs e)
        {
            camera.toTopLeft();
        }

        void myform_MouseWheel(object sender, MouseEventArgs e)
        {

            ArrayList zoomArray = new ArrayList();
            ArrayList zoomArrayVal = new ArrayList();
            for (int i = 1; i < 1000; i++)
            {
                zoomArray.Add(i);
                zoomArrayVal.Add(i);
            }
            for (int i = -1; i > -100; i--)
            {
                zoomArray.Add(i);
                zoomArrayVal.Add(Math.Abs(1.0000f / i / 8.0f));
            }

            int ZoomDelta = e.Delta;
            mice.scrollValue += ZoomDelta; ZoomDelta = 0;
            float scale = (float)(mice.scrollValue / 120 * 0.02f + 1);

            Rectangle ac = screen.WorldArea;
            float oldZoom = screen.zoom;

            int idx = Convert.ToInt32(mice.scrollValue / 120);
            //System.Diagnostics.Debug.WriteLine(idx, "1");
            if (idx == 0) idx = 1;
            //System.Diagnostics.Debug.WriteLine(idx, "2");
            screen.zoom = (float)Convert.ToDouble(zoomArrayVal[zoomArray.IndexOf(idx)]);
            Rectangle bc = screen.WorldArea;

            screen.Coords(ac.X / oldZoom * screen.zoom - (ac.Width / oldZoom * screen.zoom - bc.Width / oldZoom * screen.zoom) / 2 * oldZoom,
                          ac.Y / oldZoom * screen.zoom - (ac.Height / oldZoom * screen.zoom - bc.Height / oldZoom * screen.zoom) / 2 * oldZoom);



            myform_MouseMove(sender, e);
            ScrollBar.Maximum = (int)(frq.maxFreq * screen.zoom);
            ScrollBar.Value = -screen.WorldArea.X;
            ScrollBar.LargeChange = (int)(ScrollBar.Maximum / 200);
        }

        void myform_MouseMove(object sender, MouseEventArgs e)
        {
            mice.absPosition = screen.worldCoordinates(new Vector2(e.X, e.Y));
            mice.aboveScalingPoints = aboveResizePoints(new Vector2(e.X, e.Y));

            mice.Position = new Vector2((e.X - screen.WorldArea.X) / screen.zoom,
                                        (e.Y - screen.WorldArea.Y) / screen.zoom);


            if (!mice.aboveScalingPoints) mice.cursor = Cursors.Default;
            myform.Cursor = mice.cursor;


            #region popup Allocation Plan
            if (mice.Position.X > alloc.minFreq && mice.Position.X < alloc.maxFreq)
            {
                popupAllocations((int)(mice.Position.X));
            }
            else AllocsToDraw.Clear();
            #endregion


            #region Screen draging
            if (mice.screenDraging)
            {
                selectedComm = null;
                affectedComm = -1;
                int DX = Convert.ToInt32(e.X - mousePos.X) + world.X;
                int DY = Convert.ToInt32(e.Y - mousePos.Y) + world.Y;
                screen.Coords(DX, DY);
                mice.cursor = Cursors.Hand;
                ScrollBar.Value = -screen.WorldArea.X;
            }
            #endregion


            #region Comments draging
            if (mice.commentDraging)
            {
                selectedComm.shape.X = (int)(mice.absPosition.X - dX);
                selectedComm.shape.Y = (int)(mice.absPosition.Y - dY);
                comments[affectedComm] = selectedComm;
                handBtn.Visible = true;
            }
            #endregion


            #region Comment scaling
            if (mice.commentScaling)
            {
                if (currScalingPoint != "")
                {
                    int offset = 2;
                    int newWidth = selectedComm.shape.Width;
                    int newHeight = selectedComm.shape.Height;
                    int newX = selectedComm.shape.X;
                    int newY = selectedComm.shape.Y;


                    if (currScalingPoint == "lu")
                    {
                        newX = (int)mice.absPosition.X - offset;
                        newY = (int)mice.absPosition.Y - offset;
                        newWidth = selectedComm.shape.Width + selectedComm.shape.X - newX;
                        newHeight = selectedComm.shape.Height + selectedComm.shape.Y - newY;

                    }
                    else if (currScalingPoint == "ru")
                    {
                        newX = selectedComm.shape.X;
                        newY = (int)mice.absPosition.Y - offset;
                        newWidth = (int)mice.absPosition.X - selectedComm.shape.X + offset;
                        newHeight = selectedComm.shape.Height + selectedComm.shape.Y - newY;

                    }
                    else if (currScalingPoint == "ld")
                    {
                        newX = (int)mice.absPosition.X - offset;
                        newY = selectedComm.shape.Y;
                        newWidth = selectedComm.shape.Width + selectedComm.shape.X - newX;
                        newHeight = (int)mice.absPosition.Y - selectedComm.shape.Y + offset;
                    }
                    else if (currScalingPoint == "rd")
                    {
                        newX = selectedComm.shape.X;
                        newY = selectedComm.shape.Y;
                        newWidth = (int)mice.absPosition.X - selectedComm.shape.X + offset;
                        newHeight = (int)mice.absPosition.Y - selectedComm.shape.Y + offset;
                    }
                    else if (currScalingPoint == "uc")
                    {
                        newX = selectedComm.shape.X;
                        newY = (int)mice.absPosition.Y - offset;
                        newWidth = selectedComm.shape.Width;
                        newHeight = selectedComm.shape.Height + selectedComm.shape.Y - newY;
                    }
                    else if (currScalingPoint == "lc")
                    {
                        newX = (int)mice.absPosition.X - offset;
                        newY = selectedComm.shape.Y;
                        newWidth = selectedComm.shape.Width + selectedComm.shape.X - newX;
                        newHeight = selectedComm.shape.Height;
                    }
                    else if (currScalingPoint == "rc")
                    {
                        newX = selectedComm.shape.X;
                        newY = selectedComm.shape.Y;
                        newWidth = (int)mice.absPosition.X - selectedComm.shape.X + offset;
                        newHeight = selectedComm.shape.Height;
                    }
                    else if (currScalingPoint == "dc")
                    {
                        newX = selectedComm.shape.X;
                        newY = selectedComm.shape.Y;
                        newWidth = selectedComm.shape.Width;
                        newHeight = (int)mice.absPosition.Y - selectedComm.shape.Y + offset;
                    }


                    if (newWidth > 15) selectedComm.shape.Width = newWidth;
                    if (newHeight > 15) selectedComm.shape.Height = newHeight;
                    selectedComm.shape.X = newX;
                    selectedComm.shape.Y = newY;
                }
                handBtn.Visible = true;
            }
            #endregion


        }

        void myform_MouseClick(object sender, MouseEventArgs e)
        {
            Comment onComment = aboveComment(mice.absPosition);

            //deselect if not above comment
            if (onComment == null)
            {
                selectedComm = null;
                affectedComm = -1;
            }

            //measuring distance
            if (fromFreq == null && HighlightedFreq != null) fromFreq = HighlightedFreq;
            else
                if (toFreq == null && HighlightedFreq != null) toFreq = HighlightedFreq;
            if (HighlightedFreq == null)
            {
                fromFreq = null;
                toFreq = null;
            }

            //update Graph
            try { mon.Close(); }
            catch { }

        }

        void myform_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          /*  try { mon.Close(); }
            catch { }
            Comment onComment = aboveComment(mice.absPosition);

            //check if picking comment
            if (onComment != null)
            {
                if (onComment == selectedComm)
                {
                    frmEditText txtForm = new frmEditText();
                    txtForm.textBox.Text = selectedComm.text;
                    txtForm.cl = System.Drawing.Color.FromArgb(selectedComm.Xnacolor.A, selectedComm.Xnacolor.R, selectedComm.Xnacolor.G, selectedComm.Xnacolor.B);
                    txtForm.ShowDialog();
                    selectedComm.text = txtForm.textBox.Text;
                    handBtn.Visible = true;
                }
                else
                {
                    selectedComm = onComment;
                    affectedComm = comments.IndexOf(selectedComm);
                }
            }

            //else რედაქტირებაToolStripMenuItem_Click(sender, null);
            */
        }

        void myform_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Comment onComment = aboveComment(mice.absPosition);
                mice.aboveScalingPoints = aboveResizePoints(mice.absPosition);

                //draw new comment
                if (mice.drawing)
                {
                    fromX = mice.Position.X;
                    fromY = mice.Position.Y;
                    mice.startedDrawing = true;
                    return;
                }

                //set screen draging state
                if (onComment == null || selectedComm == null)
                {
                    mice.screenDraging = true;
                    mousePos = new Vector2(e.X, e.Y);
                    world = screen.WorldArea;
                    return;
                }

                //comments draging
                if (onComment != null && selectedComm == onComment && !mice.aboveScalingPoints)
                {
                    dX = mice.absPosition.X - selectedComm.shape.X;
                    dY = mice.absPosition.Y - selectedComm.shape.Y;
                    mice.commentDraging = true;
                    return;
                }

                //comment scaling
                if (onComment != null && selectedComm == onComment && mice.aboveScalingPoints)
                {
                    mice.commentScaling = true;
                    return;
                }
            }
        }

        void myform_MouseUp(object sender, MouseEventArgs e)
        {
            //draw new comment
            if (mice.drawing)
            {
                //commentsBtn_Click(null, null);

                Random rnd = new Random();
                System.Drawing.Color col = System.Drawing.Color.FromArgb(rnd.Next(100, 250), rnd.Next(100, 250), rnd.Next(100, 250));


                /*frmEditText txtForm = new frmEditText();
                txtForm.cl = col;
                txtForm.ShowDialog();
                col = txtForm.cl;


                Comment comment = new Comment(new Vector2(fromX, fromY), new Vector2(mice.Position.X, mice.Position.Y), txtForm.textBox.Text, camera.Scale, col);
                comment.id = comment.insComment();
                comments.Add(comment);
                selectedComm = comment;
                affectedComm = comments.IndexOf(selectedComm);
                mice.startedDrawing = false;
                mice.drawing = false;*/
            }

            //finish screen draging
            mice.screenDraging = false;

            //finish comment draging
            if (mice.commentDraging)
            {

                mice.commentDraging = false;
            }

            //finish scaling comment
            mice.commentScaling = false;
        }

        void myform_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        #endregion
        

        #region private methods

        private void relLinksGetter_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.relLinksGetter.CancellationPending) terminateGetterExecution(e);

            relLinkDescription = "";

            DataSet ds = HelperFunctions.fill("select * from st_rel_fixed where tx_freq_id=" + HighlightedFreq.id, DataBase.Properties.Settings.Default.OfficeConnectionString);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (HighlightedFreq.id == (int)ds.Tables[0].Rows[i]["tx_freq_id"])
                    relLinkDescription += "\r\n(TX): " + ds.Tables[0].Rows[i]["Name"];
                if (this.relLinksGetter.CancellationPending) terminateGetterExecution(e);
            }
            ds.Clear();

            ds = HelperFunctions.fill("select * from st_rel_fixed where rx_freq_id=" + HighlightedFreq.id, DataBase.Properties.Settings.Default.OfficeConnectionString);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (HighlightedFreq.id == (int)ds.Tables[0].Rows[i]["rx_freq_id"])
                    relLinkDescription += "\r\n(RX): " + ds.Tables[0].Rows[i]["Name"];
                if (this.relLinksGetter.CancellationPending) terminateGetterExecution(e);
            }


            if (relLinkDescription != "") relLinkDescription = "\r\n"  + relLinkDescription;
        }

        private void terminateGetterExecution(DoWorkEventArgs e)
        {
            e.Cancel = true;
            relLinkDescription = "";
            return;
        }

        private void relLinksGetter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
                relLinkDescription = "";
                Debug.WriteLine("BackgroundWorker Error");
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.
                Debug.WriteLine("BackgroundWorker Cancelled");
                relLinkDescription = "";
                relLinksGetter.RunWorkerAsync();
            }
            /*else
            {
                // Finally, handle the case where the operation  
                // succeeded.
                if (e.Result == null) return;
                int i = Convert.ToInt32(((List<string>)e.Result)[0].ToString());

                
                this.Invoke((MethodInvoker)delegate
                {
                    //splitContainer.Panel2Collapsed = (i==0);
                    //stationInfoPanel.Visible = (i > 0);
                });
            }*/

        }

        private void relLinksGetter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine(e.ProgressPercentage);
        }

        private void UpdateZonesAndFreqs()
        {
            //arrange zone city
            city nc = zCities.getCity(HighlightedFreq.city);
            nc.check = true;
            if (nc != null)
            {
                zone_cities tmp = new zone_cities(this.user);
                for (int i = 0; i < zCities.cities.Count; i++)
                {
                    int zCityItem = zCities.cities.IndexOf(zCities.getCity(tmp.cities[i].name));
                    tmp.cities[i].check = zCities.cities[zCityItem].check;
                }
                zCities.cities = tmp.cities;
            }
            //cities arranged

            frq = new frequencies(this.user);
        }

        protected void measureDistance()
        {
            string measurementResult = "";
            SpriteFont fn = Font;

            if (fromFreq == null) measurementResult = "აირჩიეთ პირველი სიხშირე";
            else if (toFreq == null) measurementResult = "აირჩიეთ მეორე სიხშირე";
            else
            {
                fn = Font1;
                if (fromFreq.freq > toFreq.freq)
                {
                    measurementResult = HelperFunctions.getHZ(fromFreq.freq - fromFreq.BandWidth / 2.0f - (toFreq.freq + toFreq.BandWidth / 2.0f));
                }
                else measurementResult = HelperFunctions.getHZ(toFreq.freq - toFreq.BandWidth / 2.0f - (fromFreq.freq + fromFreq.BandWidth / 2.0f));
            }

            Vector2 stringSize = fn.MeasureString(measurementResult);
            spriteBatch.DrawString(fn, measurementResult, new Vector2((int)(myform.ClientRectangle.Width / 2 - stringSize.X * 2 / 2) + 2, 102), Color.Black, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
            spriteBatch.DrawString(fn, measurementResult, new Vector2((int)(myform.ClientRectangle.Width / 2 - stringSize.X * 2 / 2), 100), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, 0);
        }

        public void ScrollToFound(int val)
        {
            ScrollBar.Value = (int)(val * screen.zoom);
            screen.Coords(-(val - screen.WorldArea.Width / 2) * screen.zoom, screen.WorldArea.Y);
        }

        protected void gotofreq(object sender, GoToFreqArgs e)
        {
            if (myform != null && myform.IsHandleCreated)
                myform.BeginInvoke((Action)delegate() { ScrollToFound(e.freq); });
        }

        protected void ProcessFoundFreq()
        {
            if (FoundFreq != null)
            {
                DrawRect(spriteBatch, FoundFreq.displayedPos, Color.LightYellow);

                if (სიხშირისკომენტარიToolStripMenuItem.Checked)
                {
                    string text = FoundFreq.Comp_Name + "\r\n" +
                               HelperFunctions.getHZ(FoundFreq.freq) + " - " + HelperFunctions.getHZ(FoundFreq.BandWidth) + "\r\n" +
                               FoundFreq.LICENCE + " : " + FoundFreq.LIC_ISSU_DATE + " - " + FoundFreq.LIC_EXPIRY_DATE + "\r\n" +
                               FoundFreq.city;
                    Vector2 stringSize = Font.MeasureString(text);

                    Rectangle rc = new Rectangle((int)(FoundFreq.freq - stringSize.X / 2 / screen.zoom), (int)(FoundFreq.displayedPos.Y - 120 / screen.zoom), (int)((stringSize.X + 20) / screen.zoom), (int)((stringSize.Y + 20) / screen.zoom));
                    if (rc.X * screen.zoom + screen.WorldArea.X <= 10) rc = new Rectangle((int)((-screen.WorldArea.X + 10) / screen.zoom), rc.Y, rc.Width, rc.Height);
                    if (rc.Y * screen.zoom + screen.WorldArea.Y <= 10) rc = new Rectangle(rc.X, (int)(FoundFreq.displayedPos.Y + 40 / screen.zoom), rc.Width, rc.Height);
                    if (rc.X + rc.Width >= screen.WorldArea.Width - screen.WorldArea.X / screen.zoom) rc = new Rectangle((int)(screen.WorldArea.Width - screen.WorldArea.X / screen.zoom - rc.Width - 10 / screen.zoom), rc.Y, rc.Width, rc.Height);


                    DrawRect(spriteBatch, rc, Color.DarkOrchid);

                    Vector2 strPos = new Vector2((int)(rc.X * screen.zoom) + screen.WorldArea.X + 10, (int)(rc.Y * screen.zoom) + screen.WorldArea.Y + 10);
                    drawString(text, spriteBatch, strPos, Color.White);
                }
            }
        }

        protected void processHighlightedPlan()
        {
            if (HighlightedPlan != null && HighlightedPlan.mouseIn(mice.Position) && myform.Focused)
            {
                DrawRect(spriteBatch, HighlightedPlan.displayedPos, Color.RoyalBlue);
                Rectangle left = new Rectangle(HighlightedPlan.displayedPos.X, (int)(-screen.WorldArea.Y / screen.zoom), 1, screen.WorldArea.Y + screen.WorldArea.Height);
                DrawRect(spriteBatch, left, Color.Red, 1);
                Rectangle right = new Rectangle(HighlightedPlan.displayedPos.X + HighlightedPlan.displayedPos.Width, (int)(-screen.WorldArea.Y / screen.zoom), 1, screen.WorldArea.Y + screen.WorldArea.Height);
                DrawRect(spriteBatch, right, Color.Red, 1);

                //draw left and right boards freqs
                float sc = 1.0f;
                string txt = HelperFunctions.getHZ(HighlightedPlan.FFrom);
                Vector2 strSize = Font1.MeasureString(txt);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                Vector2 pos = new Vector2((int)((left.X * screen.zoom + screen.WorldArea.X)) - 2, 60);
                spriteBatch.DrawString(Font1, txt, new Vector2((int)(pos.X - strSize.X), 60), Color.Red, 0, Vector2.Zero, sc, SpriteEffects.None, 0);

                txt = HelperFunctions.getHZ(HighlightedPlan.FTo);
                strSize = Font1.MeasureString(txt);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                pos = new Vector2((int)((right.X * screen.zoom + screen.WorldArea.X)) + 2, 60);
                spriteBatch.DrawString(Font1, txt, pos, Color.Red, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                //left and right boards freqs drawn

                if (true)
                {
                    txt = "ITU:";
                    int counter = 0;
                    foreach (ero_Allocation al in HighlightedPlan.allocations)
                    {
                        txt += "\r\n";
                        string tmp = al.GName.Replace("<b>", "");
                        tmp = tmp.Replace("</b>", "");
                        txt += tmp;
                        counter++;
                    }
                    /*foreach (ero_Implementation imp in HighlightedPlan.implementations)
                    {
                        txt += "\r\n";
                        string tmp = imp.Name.Replace("<b>", "");
                        tmp = tmp.Replace("</b>", "");
                        txt += tmp;
                    }*/
                    Vector2 stringSize = Font.MeasureString(txt);

                    Rectangle rc = new Rectangle((int)(mice.Position.X - stringSize.X / 2 / screen.zoom), (int)(HighlightedPlan.displayedPos.Y - (30 + stringSize.Y) / screen.zoom), (int)((stringSize.X + 20) / screen.zoom), (int)((stringSize.Y + 20) / screen.zoom));
                    if (rc.X * screen.zoom + screen.WorldArea.X <= 10) rc = new Rectangle((int)((-screen.WorldArea.X + 10) / screen.zoom), rc.Y, rc.Width, rc.Height);
                    if (rc.Y * screen.zoom + screen.WorldArea.Y <= 10) rc = new Rectangle(rc.X, (int)(HighlightedPlan.displayedPos.Y + 55 / screen.zoom), rc.Width, rc.Height);
                    if (rc.X + rc.Width >= screen.WorldArea.Width - screen.WorldArea.X / screen.zoom) rc = new Rectangle((int)(screen.WorldArea.Width - screen.WorldArea.X / screen.zoom - rc.Width - 10 / screen.zoom), rc.Y, rc.Width, rc.Height);


                    DrawRect(spriteBatch, rc, Color.RoyalBlue);

                    Vector2 strPos = new Vector2((int)(rc.X * screen.zoom) + screen.WorldArea.X + 10, (int)(rc.Y * screen.zoom) + screen.WorldArea.Y + 10);
                    drawString(txt, spriteBatch, strPos, Color.White);
                }
            }
        }

        protected void processHighlightedImplementation()
        {
            if (HighlightedImplementation != null && HighlightedImplementation.mouseIn(mice.Position) && myform.Focused)
            {
                DrawRect(spriteBatch, HighlightedImplementation.displayedPos, Color.RoyalBlue);
                Rectangle left = new Rectangle(HighlightedImplementation.displayedPos.X, (int)(-screen.WorldArea.Y / screen.zoom), 1, screen.WorldArea.Y + screen.WorldArea.Height);
                DrawRect(spriteBatch, left, Color.Red, 1);
                Rectangle right = new Rectangle(HighlightedImplementation.displayedPos.X + HighlightedImplementation.displayedPos.Width, (int)(-screen.WorldArea.Y / screen.zoom), 1, screen.WorldArea.Y + screen.WorldArea.Height);
                DrawRect(spriteBatch, right, Color.Red, 1);

                //draw left and right boards freqs
                float sc = 1.0f;
                string txt = HelperFunctions.getHZ(HighlightedImplementation.FFrom);
                Vector2 strSize = Font1.MeasureString(txt);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                Vector2 pos = new Vector2((int)((left.X * screen.zoom + screen.WorldArea.X)) - 2, 60);
                spriteBatch.DrawString(Font1, txt, new Vector2((int)(pos.X - strSize.X), 60), Color.Red, 0, Vector2.Zero, sc, SpriteEffects.None, 0);

                txt = HelperFunctions.getHZ(HighlightedImplementation.FTo);
                strSize = Font1.MeasureString(txt);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                pos = new Vector2((int)((right.X * screen.zoom + screen.WorldArea.X)) + 2, 60);
                spriteBatch.DrawString(Font1, txt, pos, Color.Red, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                //left and right boards freqs drawn
                
                if (true)
                {
                    txt = HighlightedImplementation.Name;
                    if (!HighlightedImplementation.Note.Equals("")) txt += " " + HighlightedImplementation.Note;
                    if (HighlightedImplementation.inUse) txt += ": " + "გამოყენებაში"; else txt += ": " + "პერსპექტივაში";
                    Vector2 stringSize = Font.MeasureString(txt);

                    Rectangle rc = new Rectangle((int)(mice.Position.X - stringSize.X / 2 / screen.zoom), (int)(HighlightedImplementation.displayedPos.Y - (30 + stringSize.Y) / screen.zoom), (int)((stringSize.X + 20) / screen.zoom), (int)((stringSize.Y + 20) / screen.zoom));
                    if (rc.X * screen.zoom + screen.WorldArea.X <= 10) rc = new Rectangle((int)((-screen.WorldArea.X + 10) / screen.zoom), rc.Y, rc.Width, rc.Height);
                    if (rc.Y * screen.zoom + screen.WorldArea.Y <= 10) rc = new Rectangle(rc.X, (int)(HighlightedImplementation.displayedPos.Y + 55 / screen.zoom), rc.Width, rc.Height);
                    if (rc.X + rc.Width >= screen.WorldArea.Width - screen.WorldArea.X / screen.zoom) rc = new Rectangle((int)(screen.WorldArea.Width - screen.WorldArea.X / screen.zoom - rc.Width - 10 / screen.zoom), rc.Y, rc.Width, rc.Height);


                    DrawRect(spriteBatch, rc, Color.RoyalBlue);

                    Vector2 strPos = new Vector2((int)(rc.X * screen.zoom) + screen.WorldArea.X + 10, (int)(rc.Y * screen.zoom) + screen.WorldArea.Y + 10);
                    drawString(txt, spriteBatch, strPos, Color.White);
                }
            }
        }

        protected void processHighlightedFreq()
        {
            if (HighlightedFreq != null && HighlightedFreq.mouseIn(mice.Position) && myform.Focused)
            {
                if (prevFreq != HighlightedFreq && HighlightedFreq.freq > 1000000)
                {
                    relLinkDescription = "";
                    if (relLinksGetter.IsBusy) relLinksGetter.CancelAsync();
                    else
                    {
                        relLinksGetter.RunWorkerAsync();
                        prevFreq = HighlightedFreq;
                    }
                }

                DrawRect(spriteBatch, HighlightedFreq.displayedPos, Color.Lime);
                Rectangle left = new Rectangle(HighlightedFreq.displayedPos.X, (int)(-screen.WorldArea.Y / screen.zoom), 1, screen.WorldArea.Y + screen.WorldArea.Height);
                DrawRect(spriteBatch, left, Color.Red, 1);
                Rectangle right = new Rectangle(HighlightedFreq.displayedPos.X + HighlightedFreq.displayedPos.Width, (int)(-screen.WorldArea.Y / screen.zoom), 1, screen.WorldArea.Y + screen.WorldArea.Height);
                DrawRect(spriteBatch, right, Color.Red, 1);

                //draw left and right boards freqs
                float sc = 1.0f;
                string txt = HelperFunctions.getHZ(HighlightedFreq.freq - HighlightedFreq.BandWidth / 2);
                Vector2 strSize = Font1.MeasureString(txt);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                Vector2 pos = new Vector2((int)((left.X * screen.zoom + screen.WorldArea.X)) - 2, 60);
                spriteBatch.DrawString(Font1, txt, new Vector2((int)(pos.X - strSize.X), 60), Color.Red, 0, Vector2.Zero, sc, SpriteEffects.None, 0);

                txt = HelperFunctions.getHZ(HighlightedFreq.freq + HighlightedFreq.BandWidth / 2);
                strSize = Font1.MeasureString(txt);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                pos = new Vector2((int)((right.X * screen.zoom + screen.WorldArea.X)) + 2, 60);
                spriteBatch.DrawString(Font1, txt, pos, Color.Red, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                //left and right boards freqs drawn



                if (სიხშირისკომენტარიToolStripMenuItem.Checked)
                {
                    string text = HighlightedFreq.Comp_Name + "\r\n" +
                               HelperFunctions.getHZ(HighlightedFreq.freq) + " - " + HelperFunctions.getHZ(HighlightedFreq.BandWidth) + "\r\n" +
                               HighlightedFreq.LICENCE + " : " + HighlightedFreq.LIC_ISSU_DATE + " - " + HighlightedFreq.LIC_EXPIRY_DATE + "\r\n" +
                               HighlightedFreq.city;
                    if (relLinkDescription != "")
                    {
                        text += relLinkDescription;
                    }
                    Vector2 stringSize = Font.MeasureString(text);

                    Rectangle rc = new Rectangle((int)(mice.Position.X - stringSize.X / 2 / screen.zoom), (int)(HighlightedFreq.displayedPos.Y - 40 - stringSize.Y / screen.zoom), (int)((stringSize.X + 20) / screen.zoom), (int)((stringSize.Y + 20) / screen.zoom));
                    if (rc.X * screen.zoom + screen.WorldArea.X <= 10) rc = new Rectangle((int)((-screen.WorldArea.X + 10) / screen.zoom), rc.Y, rc.Width, rc.Height);
                    if (rc.Y * screen.zoom + screen.WorldArea.Y <= 10) rc = new Rectangle(rc.X, (int)(HighlightedFreq.displayedPos.Y + 40 / screen.zoom), rc.Width, rc.Height);
                    if (rc.X + rc.Width >= screen.WorldArea.Width - screen.WorldArea.X / screen.zoom) rc = new Rectangle((int)(screen.WorldArea.Width - screen.WorldArea.X / screen.zoom - rc.Width - 10 / screen.zoom), rc.Y, rc.Width, rc.Height);

                    Color txtColor = Color.White;
                    if (HighlightedFreq.reestrit)
                    {
                        DrawRect(spriteBatch, rc, new Color(Color.Orange.R, Color.Orange.G, Color.Orange.B, 200));
                        txtColor = Color.Black;
                        //DrawRect(spriteBatch, rc, new Color(Color.Orange.R, Color.Orange.G, Color.Orange.B, 99));
                    }
                    else
                    {
                        DrawRect(spriteBatch, rc, new Color(Color.DarkViolet.R, Color.DarkViolet.G, Color.DarkViolet.B, 200));
                       //DrawRect(spriteBatch, rc, new Color(Color.DarkViolet.R, Color.DarkViolet.G, Color.DarkViolet.B, 99));
                    }


                    Vector2 strPos = new Vector2((int)(rc.X * screen.zoom) + screen.WorldArea.X + 10, (int)(rc.Y * screen.zoom) + screen.WorldArea.Y + 10);
                    drawString(text, spriteBatch, strPos, txtColor);
                }

                


            }
        }

        protected void displayEroAllocations(int hgt)
        {
            Rectangle tmpWorld = new Rectangle();
            int Yoffset = (int)(-155 / screen.zoom);
            int Height = hgt;

            foreach (fr_Plan pl in ero_pl.Plans)
            {
                tmpWorld = new Rectangle((int)(-screen.WorldArea.X), (int)(-screen.WorldArea.Y), (int)(screen.WorldArea.Width * screen.zoom), (int)(screen.WorldArea.Height * screen.zoom));
                Rectangle rect = new Rectangle((int)pl.FFrom, Yoffset, (int)(pl.FTo - pl.FFrom), (int)(Height / screen.zoom));
                Rectangle tmpRect = new Rectangle((int)(rect.X * screen.zoom), (int)(-screen.WorldArea.Y), (int)(rect.Width * screen.zoom), (int)(rect.Height));
                if (!tmpWorld.Intersects(tmpRect)) continue;

                DrawRect(spriteBatch, rect, new Color(pl.color.R, pl.color.G, pl.color.B));
                pl.displayedPos = rect;

                if (pl.mouseIn(mice.Position)) HighlightedPlan = pl;
            }

        }

        /// <summary>
        /// gamokenebis asaxva
        /// </summary>
        /// <param name="hgt">simagle</param>
        protected void displayEroImplementations(int hgt)
        {
            Rectangle tmpWorld = new Rectangle();

            foreach (fr_Plan pl in ero_pl.Plans)
            {
                int Yoffset = (int)(-85 / screen.zoom);
                foreach (ero_Implementation imp in pl.implementations)
                {
                    int Height = hgt / pl.implementations.Count;

                    tmpWorld = new Rectangle((int)(-screen.WorldArea.X), (int)(-screen.WorldArea.Y), (int)(screen.WorldArea.Width * screen.zoom), (int)(screen.WorldArea.Height * screen.zoom));
                    Rectangle rect = new Rectangle((int)imp.FFrom, Yoffset, (int)(imp.FTo - imp.FFrom), (int)(Height / screen.zoom));
                    Rectangle tmpRect = new Rectangle((int)(rect.X * screen.zoom), (int)(-screen.WorldArea.Y), (int)(rect.Width * screen.zoom), (int)(rect.Height));
                    if (!tmpWorld.Intersects(tmpRect)) continue;

                    DrawRect(spriteBatch, rect, new Color(imp.color.R, imp.color.G, imp.color.B));
                    imp.displayedPos = rect;

                    if (imp.mouseIn(mice.Position)) HighlightedImplementation = imp;

                    Yoffset = Yoffset + Convert.ToInt32(Height / screen.zoom);
                }
            }
        }

        protected void invisibleFreqPresentWarning(bool on)
        {
            if (on)
            {
                myform.Text = "- - - W A R N I N G : Invisible Frequencies!!! Please ZOOM-in... - - -";
                System.Drawing.Graphics g = myform.CreateGraphics();
                Double startingPoint = (myform.Width / 2) - (((System.Drawing.Graphics)g).MeasureString(myform.Text.Trim(), myform.Font).Width / 2);
                Double widthOfASpace = g.MeasureString(" ", myform.Font).Width;
                String tmp = "";
                Double tmpWidth = 0;
                while ((tmpWidth + widthOfASpace) < startingPoint)
                {
                    tmp += " ";
                    tmpWidth += widthOfASpace;
                }
                myform.Text = tmp + myform.Text.Trim();
            }
            else myform.Text = "Fams";
        }


        protected void displayFreqiencies_OLD()
        {
            occupiedFreqs = new ArrayList();  //massiv narisovanix chastot
            Rectangle tmpWorld = new Rectangle();
            int maxY = 0;

            bool waswarning = false;
            foreach (FREQVIEW fr in frq.freq)
            {
                
                int Yoffset = 50;
                int step = 25;
                int Height = 20;

                Rectangle rect = new Rectangle(fr.fromX, Yoffset, fr.BandWidth, (int)(Height / screen.zoom));
                Rectangle tmpRect = new Rectangle((int)(rect.X * screen.zoom), (int)(-screen.WorldArea.Y), (int)(rect.Width * screen.zoom), (int)(rect.Height));
                tmpWorld = new Rectangle((int)(-screen.WorldArea.X), (int)(-screen.WorldArea.Y), (int)(screen.WorldArea.Width * screen.zoom), (int)(screen.WorldArea.Height * screen.zoom));
                //* es iko -------------------------------
                //if (!tmpWorld.Intersects(tmpRect) || tmpRect.Width < 1) continue;
                //akamde -------------------------------
                //es gadavakete -------------------------------
                if (!tmpWorld.Intersects(tmpRect)) continue;
                if (tmpRect.Width < 1)
                {
                    waswarning = true;
                    continue;
                }
                //akamde -------------------------------
                if (!zCities.contains(fr.city)) continue;


                List<Rectangle> Xcrossing = new List<Rectangle>();
                for (int i = 0; i < occupiedFreqs.Count; i++)
                {
                    Rectangle checkingFreq = ((FREQVIEW)occupiedFreqs[i]).displayedPos;
                    Rectangle currentYchanged = new Rectangle(rect.X, checkingFreq.Y, rect.Width, rect.Height);
                    if (currentYchanged.Intersects(checkingFreq))
                        Xcrossing.Add(((FREQVIEW)occupiedFreqs[i]).displayedPos);
                }

                int[] Yarray = new int[Xcrossing.Count];
                int m = 0;
                foreach (Rectangle r in Xcrossing)
                {
                    Yarray[m] = r.Y;
                    m++;
                }
                //Array.Sort(Yarray);

                for (int i = 0; i < Yarray.Length + 1; i++)
                {
                    Yoffset = 50 + (int)(step * i / screen.zoom);
                    if (Array.IndexOf(Yarray, Yoffset) == -1) break;
                }
                rect = new Rectangle(rect.X, Yoffset, rect.Width, rect.Height);



                fr.displayedPos = rect;
                if (fr.mouseIn(mice.Position)) HighlightedFreq = fr;
                DrawRect(spriteBatch, fr.displayedPos, new Color(fr.color.R, fr.color.G, fr.color.B));
                occupiedFreqs.Add(fr);

                //display text if possible
                float sc = 0.8f;
                Vector2 strSize = Font.MeasureString(fr.Comp_Name);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                Vector2 pos = new Vector2((int)((rect.X * screen.zoom + screen.WorldArea.X)), (int)((rect.Y * screen.zoom + screen.WorldArea.Y)));
                Rectangle textRectangle = new Rectangle(rect.X, rect.Y, (int)(strSize.X / screen.zoom), (int)(strSize.Y / screen.zoom));
                if (rect.Contains(textRectangle))
                    if (fr.Comp_Name.Contains("არქივი")) spriteBatch.DrawString(Font, fr.Comp_Name, new Vector2((int)(pos.X + (rect.Width * screen.zoom - strSize.X) / 2), pos.Y), Color.Black, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                    else spriteBatch.DrawString(Font, fr.Comp_Name, new Vector2((int)(pos.X + (rect.Width * screen.zoom - strSize.X) / 2), pos.Y), Color.White, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                //text processing done

                if (maxY < (rect.Y + rect.Height) * screen.zoom) maxY = (int)((rect.Y + rect.Height) * screen.zoom);
            }
            screen.minY = (int)(maxY - screen.WorldArea.Height * screen.zoom);
            invisibleFreqPresentWarning(waswarning);
        }

        protected void displayFreqiencies()
        {
            this.occupiedFreqs = new ArrayList();
            Microsoft.Xna.Framework.Rectangle rectangle1 = new Microsoft.Xna.Framework.Rectangle();
            int num1 = 0;
            bool on = false;
            foreach (FREQVIEW freqview in this.frq.freq)
            {
                if (freqview.currentlyActive || this.showAllFrequenciesToolStripMenuItem.Checked)
                {
                    int y = 50;
                    int num2 = 25;
                    int num3 = 20;
                    Rectangle rectangle2 = new Rectangle(freqview.fromX, y, freqview.BandWidth, (int)((double)num3 / (double)this.screen.zoom));
                    Rectangle rectangle3 = new Rectangle((int)((double)rectangle2.X * (double)this.screen.zoom), -this.screen.WorldArea.Y, (int)((double)rectangle2.Width * (double)this.screen.zoom), rectangle2.Height);
                    if (new Microsoft.Xna.Framework.Rectangle(-this.screen.WorldArea.X, -this.screen.WorldArea.Y, (int)((double)this.screen.WorldArea.Width * (double)this.screen.zoom), (int)((double)this.screen.WorldArea.Height * (double)this.screen.zoom)).Intersects(rectangle3))
                    {
                        if (rectangle3.Width < 1)
                            on = true;
                        else if (this.zCities.contains(freqview.city))
                        {
                            List<Rectangle> list = new List<Rectangle>();
                            for (int index = 0; index < this.occupiedFreqs.Count; ++index)
                            {
                                Rectangle rectangle4 = ((FREQVIEW)this.occupiedFreqs[index]).displayedPos;
                                if (new Microsoft.Xna.Framework.Rectangle(rectangle2.X, rectangle4.Y, rectangle2.Width, rectangle2.Height).Intersects(rectangle4))
                                    list.Add(((FREQVIEW)this.occupiedFreqs[index]).displayedPos);
                            }
                            int[] array = new int[list.Count];
                            int index1 = 0;
                            foreach (Rectangle rectangle4 in list)
                            {
                                array[index1] = rectangle4.Y;
                                ++index1;
                            }
                            for (int index2 = 0; index2 < array.Length + 1; ++index2)
                            {
                                y = 50 + (int)((double)(num2 * index2) / (double)this.screen.zoom);
                                if (Array.IndexOf<int>(array, y) == -1)
                                    break;
                            }
                            rectangle2 = new Rectangle(rectangle2.X, y, rectangle2.Width, rectangle2.Height);
                            freqview.displayedPos = rectangle2;
                            if (freqview.mouseIn(this.mice.Position))
                                this.HighlightedFreq = freqview;
                            this.DrawRect(this.spriteBatch, freqview.displayedPos, new Color((int)freqview.color.R, (int)freqview.color.G, (int)freqview.color.B));
                            this.occupiedFreqs.Add((object)freqview);
                            float scale = 0.8f;
                            Vector2 vector2_1 = this.Font.MeasureString(freqview.Comp_Name);
                            vector2_1 = new Vector2((float)(int)((double)vector2_1.X * (double)scale), (float)(int)((double)vector2_1.Y * (double)scale));
                            Vector2 vector2_2 = new Vector2((float)(int)((double)rectangle2.X * (double)this.screen.zoom + (double)this.screen.WorldArea.X), (float)(int)((double)rectangle2.Y * (double)this.screen.zoom + (double)this.screen.WorldArea.Y));
                            Rectangle rectangle5 = new Rectangle(rectangle2.X, rectangle2.Y, (int)((double)vector2_1.X / (double)this.screen.zoom), (int)((double)vector2_1.Y / (double)this.screen.zoom));
                            if (rectangle2.Contains(rectangle5))
                            {
                                if (freqview.Comp_Name.Contains("არქივი"))
                                    this.spriteBatch.DrawString(this.Font, freqview.Comp_Name, new Vector2((float)(int)((double)vector2_2.X + ((double)rectangle2.Width * (double)this.screen.zoom - (double)vector2_1.X) / 2.0), vector2_2.Y), Color.Black, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
                                else
                                    this.spriteBatch.DrawString(this.Font, freqview.Comp_Name, new Vector2((float)(int)((double)vector2_2.X + ((double)rectangle2.Width * (double)this.screen.zoom - (double)vector2_1.X) / 2.0), vector2_2.Y), Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
                            }
                            if ((double)num1 < (double)(rectangle2.Y + rectangle2.Height) * (double)this.screen.zoom)
                                num1 = (int)((double)(rectangle2.Y + rectangle2.Height) * (double)this.screen.zoom);
                        }
                    }
                }
            }
            this.screen.minY = (int)((double)num1 - (double)this.screen.WorldArea.Height * (double)this.screen.zoom);
            this.invisibleFreqPresentWarning(on);
        }

        protected void popupAllocations(int tofind)
        {
            AllocsToDraw = new ArrayList();

            if (არხებისგანაწილებაToolStripMenuItem.Checked)
            {

                foreach (Plan pl in alloc.plans)
                {
                    foreach (Block bl in pl.block)
                    {
                        foreach (Freq fr in bl.freq)
                        {
                            if (tofind > fr.Frequency - pl.bandwidth * 1000 / 2 && tofind < fr.Frequency + pl.bandwidth * 1000 / 2)
                            {
                                ArrayList m = new ArrayList();
                                m.Add(pl); m.Add(bl); m.Add(fr);
                                AllocsToDraw.Add(m);

                            }

                        }
                    }
                }
            }


        }

        protected void PopupAllocationsDraw()
        {

            int height = (int)(20 / screen.zoom);
            int fromY = (int)(mice.Position.Y * screen.zoom);

            foreach (ArrayList al in AllocsToDraw)
            {
                Plan pl = (Plan)al[0];
                Block bl = (Block)al[1];
                Freq fr = (Freq)al[2];

                Rectangle rect = new Rectangle((int)(fr.Frequency - pl.bandwidth / 2f * 1000f), (int)((fromY) / screen.zoom), pl.bandwidth * 1000, height);
                
                if (pl.special) DrawRect(spriteBatch, rect, new Color(204, 255, 0, 150));
                else DrawRect(spriteBatch, rect, new Color(255, 255, 255, 150));

                //display text if possible
                float sc = 1.0f;
                string CH = "";
                if (fr.LowBand) CH = fr.CH.ToString(); else CH = fr.CH + "'";
                string txt = pl.name.ToString() + ", " + HelperFunctions.getHZ(pl.freqBand * 1000000) + ", " + HelperFunctions.getHZ(pl.bandwidth * 1000) + ", (" + HelperFunctions.getHZ(bl.spacing * 1000) + " Tx-Rx), " + bl.name + ", ch" + CH;
                Vector2 strSize = Font1.MeasureString(txt);
                strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                Vector2 pos = new Vector2((int)((rect.X * screen.zoom + screen.WorldArea.X)), (int)((rect.Y * screen.zoom + screen.WorldArea.Y)));
                Rectangle textRectangle = new Rectangle(rect.X, rect.Y, (int)(strSize.X / screen.zoom), (int)(strSize.Y / screen.zoom));
                if (rect.Contains(textRectangle))
                    spriteBatch.DrawString(Font1, txt, new Vector2((int)(pos.X + (rect.Width * screen.zoom - strSize.X) / 2), pos.Y), Color.Black, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                else
                {
                    txt = HelperFunctions.getHZ(fr.Frequency - pl.bandwidth / 2 * 1000) + " - " + HelperFunctions.getHZ(fr.Frequency + pl.bandwidth / 2 * 1000);
                    strSize = Font1.MeasureString(txt);
                    strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                    pos = new Vector2((int)((rect.X * screen.zoom + screen.WorldArea.X)), (int)((rect.Y * screen.zoom + screen.WorldArea.Y)));
                    textRectangle = new Rectangle(rect.X, rect.Y, (int)(strSize.X / screen.zoom), (int)(strSize.Y / screen.zoom));
                    if (rect.Contains(textRectangle))
                        spriteBatch.DrawString(Font1, txt, new Vector2((int)(pos.X + (rect.Width * screen.zoom - strSize.X) / 2), pos.Y), Color.Black, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                    else
                    {
                        txt = HelperFunctions.getHZ(fr.Frequency);
                        strSize = Font1.MeasureString(txt);
                        strSize = new Vector2((int)(strSize.X * sc), (int)(strSize.Y * sc));
                        pos = new Vector2((int)((rect.X * screen.zoom + screen.WorldArea.X)), (int)((rect.Y * screen.zoom + screen.WorldArea.Y)));
                        textRectangle = new Rectangle(rect.X, rect.Y, (int)(strSize.X / screen.zoom), (int)(strSize.Y / screen.zoom));
                        if (rect.Contains(textRectangle))
                            spriteBatch.DrawString(Font1, txt, new Vector2((int)(pos.X + (rect.Width * screen.zoom - strSize.X) / 2), pos.Y), Color.Black, 0, Vector2.Zero, sc, SpriteEffects.None, 0);
                    }
                }
                //text processing done

                fromY += 25;
            }

        }

        protected void UpdateKeyboard()
        {

            if (active)
            {
   
                keyboardState = Keyboard.GetState();    
#if DEBUG       
                /// <summary> Move sprite using Keyboard Arrow Keys </summary>
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left))
                    camera.Position = new Vector2(camera.Position.X - spriteSpeed, camera.Position.Y);
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right))
                    camera.Position = new Vector2(camera.Position.X + spriteSpeed, camera.Position.Y);
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Up))
                    camera.Position = new Vector2(camera.Position.X, camera.Position.Y - spriteSpeed);
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Down))
                    camera.Position = new Vector2(camera.Position.X, camera.Position.Y + spriteSpeed);
                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space))
                    camera.toTopLeft();


                if (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Delete))
                {
                    if (MessageBox.Show("ნამდვილად გნებავთ წაშლა?", "Confirmation", MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        selectedComm.Delete();
                        comments.Remove(selectedComm);
                        selectedComm = null;
                        affectedComm = -1;
                    }
                }

#endif                

                measuringDistance = (keyboardState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)) ? true : false;
                if (!measuringDistance)
                {
                    fromFreq = null;
                    toFreq = null;
                }

            }

        }

        protected void drawScale()
        {
            Color cl = Color.LightGray;


            Rectangle prevMetka1 = new Rectangle();
            Rectangle prevMetka2 = new Rectangle();
            Rectangle prevText2 = new Rectangle();

            for (int i = 0; i < screen.WorldArea.Width; i += 1)
            {
                int height = 12;
                float val = (i * screen.zoom - screen.WorldArea.X) / screen.zoom;
                if (Math.Floor(val) / 10 == (int)(val / 10))
                {
                    Rectangle metka = new Rectangle((int)(i * screen.zoom), 0, 1, height);
                    if (!prevMetka1.Intersects(metka))
                    {
                        int wrapsize = 2;
                        spriteBatch.Draw(pixel, metka, cl);
                        prevMetka1 = metka;
                        prevMetka1.Inflate(wrapsize, wrapsize);
                    }
                }

                height = 25;
                if (Math.Floor(val) / 100 == (int)(val / 100))
                {
                    Rectangle metka = new Rectangle((int)(i * screen.zoom), 0, 1, height);

                    if (!prevMetka2.Intersects(metka))
                    {
                        int wrapsize = 10;
                        spriteBatch.Draw(pixel, metka, cl);
                        string txt = (HelperFunctions.getHZ((int)((i * screen.zoom - screen.WorldArea.X) / screen.zoom))).ToString();
                        Vector2 str = Font.MeasureString(txt);
                        int off = 10;
                        Rectangle currTextRect = new Rectangle((int)(i * screen.zoom) - (int)str.X / 2 - off, 30 - off, (int)str.X + off, (int)str.Y + off);
                        if (!currTextRect.Intersects(prevText2))
                        {
                            drawString(txt, spriteBatch, new Vector2((int)(i * screen.zoom) - currTextRect.Width / 3, 30), cl);
                            prevText2 = currTextRect;
                        }
                        prevMetka2 = metka;
                        prevMetka2.Inflate(wrapsize, wrapsize);

                    }
                }
            }



        }

        protected void drawString(object Text, SpriteBatch sprite, Vector2 position, Color color)
        {
            spriteBatch.DrawString(Font, Text.ToString(), position, color,
                0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }

        protected void drawNewComment()
        {
            DrawRect(spriteBatch, new Rectangle((int)fromX, (int)fromY, (int)(mice.Position.X - fromX), (int)(mice.Position.Y - fromY)), Color.Red, 1);
        }

        protected void drawComments()
        {
            foreach (Comment cm in comments)
            {
                DrawRect(spriteBatch, cm.shape, cm.Xnacolor);
                Vector2 stringSize = Font.MeasureString(cm.text);
                //spriteBatch.DrawString(Font, cm.text, new Vector2((cm.shape.X + cm.shape.Width / 2 - stringSize.X / 2) * screen.zoom, (cm.shape.Y + cm.shape.Height / 2 - stringSize.Y / 2) * screen.zoom), Color.White);
            }
        }

        protected void highlightLastSelectedComment()
        {
            if (selectedComm != null)
            {
                DrawRect(spriteBatch, selectedComm.shape, Color.Red, 2);

                Color dotColor = Color.Red;
                int rectWidth = (int)(4 / Math.Pow(camera.Scale, 2));
                int rectHeight = (int)(4 / Math.Pow(camera.Scale, 2));
                lu = new Rectangle(selectedComm.shape.X, selectedComm.shape.Y, rectWidth, rectHeight);
                ru = new Rectangle(selectedComm.shape.X + selectedComm.shape.Width - rectWidth, selectedComm.shape.Y, rectWidth, rectHeight);
                ld = new Rectangle(selectedComm.shape.X, selectedComm.shape.Y + selectedComm.shape.Height - rectHeight, rectWidth, rectHeight);
                rd = new Rectangle(selectedComm.shape.X + selectedComm.shape.Width - rectWidth, selectedComm.shape.Y + selectedComm.shape.Height - rectHeight, rectWidth, rectHeight);

                uc = new Rectangle(selectedComm.shape.X + selectedComm.shape.Width / 2 - rectWidth / 2, selectedComm.shape.Y, rectWidth, rectHeight);
                lc = new Rectangle(selectedComm.shape.X, selectedComm.shape.Y + selectedComm.shape.Height / 2 - rectHeight / 2, rectWidth, rectHeight);
                rc = new Rectangle(selectedComm.shape.X + selectedComm.shape.Width - rectWidth, selectedComm.shape.Y + selectedComm.shape.Height / 2 - rectHeight / 2, rectWidth, rectHeight);
                dc = new Rectangle(selectedComm.shape.X + selectedComm.shape.Width / 2 - rectWidth / 2, selectedComm.shape.Y + selectedComm.shape.Height - rectHeight, rectWidth, rectHeight);


                DrawRect(spriteBatch, lu, dotColor);
                DrawRect(spriteBatch, ru, dotColor);
                DrawRect(spriteBatch, ld, dotColor);
                DrawRect(spriteBatch, rd, dotColor);

                DrawRect(spriteBatch, uc, dotColor);
                DrawRect(spriteBatch, lc, dotColor);
                DrawRect(spriteBatch, rc, dotColor);
                DrawRect(spriteBatch, dc, dotColor);
            }

        }

        protected void DrawRect(SpriteBatch sprite, Rectangle rect, Color color, int thikness)
        {
            // | left
            //DrawLine(sprite, new Vector2(rect.X * screen.zoom, rect.Y * screen.zoom), new Vector2(rect.X * screen.zoom, (rect.Y + rect.Height) * screen.zoom), color, thikness);
            sprite.Draw(pixel, new Rectangle((int)(rect.X * screen.zoom) + screen.WorldArea.X, (int)(rect.Y * screen.zoom) + screen.WorldArea.Y, thikness, (int)(rect.Height * screen.zoom)), color);
            // - top
            //DrawLine(sprite, new Vector2(rect.X * screen.zoom, rect.Y * screen.zoom), new Vector2((rect.X + rect.Width) * screen.zoom, rect.Y * screen.zoom), color, thikness);
            sprite.Draw(pixel, new Rectangle((int)(rect.X * screen.zoom) + screen.WorldArea.X, (int)(rect.Y * screen.zoom) + screen.WorldArea.Y, (int)(rect.Width * screen.zoom), thikness), color);
            // - bottom
            //DrawLine(sprite, new Vector2(rect.X * screen.zoom, (rect.Y + rect.Height) * screen.zoom),
            //new Vector2((rect.X + rect.Width) * screen.zoom, (rect.Y + rect.Height) * screen.zoom), color, thikness);
            sprite.Draw(pixel, new Rectangle((int)(rect.X * screen.zoom) + screen.WorldArea.X, (int)(rect.Bottom * screen.zoom) - thikness + screen.WorldArea.Y, (int)(rect.Width * screen.zoom), thikness), color);
            // | right
            //DrawLine(sprite, new Vector2((rect.X + rect.Width) * screen.zoom, rect.Y * screen.zoom),
            //new Vector2((rect.X + rect.Width) * screen.zoom, (rect.Y + rect.Height) * screen.zoom), color, thikness);
            sprite.Draw(pixel, new Rectangle((int)(rect.Right * screen.zoom) - thikness + screen.WorldArea.X, (int)(rect.Y * screen.zoom) + screen.WorldArea.Y, thikness, (int)(rect.Height * screen.zoom)), color);
            //myform.Text = "x: " + rect.X + " y: " + rect.Y + " width: " + rect.Width + " height: " +rect.Height;
            
        }

        protected void DrawRect(SpriteBatch sprite, Rectangle rect, Color color)
        {
            /*sprite.Draw(pixel, new Vector2((int)(rect.X * screen.zoom) + screen.WorldArea.X, (int)(rect.Y * screen.zoom) + screen.WorldArea.Y),
                        new Rectangle((int)(rect.X * screen.zoom), (int)(rect.Y * screen.zoom), (int)(rect.Width * screen.zoom), (int)(rect.Height * screen.zoom)),
                        color, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);*/
            sprite.Draw(pixel, new Rectangle((int)(rect.X * screen.zoom) + screen.WorldArea.X, (int)(rect.Y * screen.zoom) + screen.WorldArea.Y, (int)(rect.Width * screen.zoom), (int)(rect.Height * screen.zoom)), color);
        }

        protected bool mouseIn(Vector2 position, Rectangle shape)
        {
            if (position.X > shape.X && position.X < shape.X + shape.Width && position.Y > shape.Y && position.Y < shape.Y + shape.Height) return true;
            else return false;
        }

        protected bool aboveResizePoints(Vector2 ms)
        {
            Vector2 pointer = camera.worldCoordinates(ms);
            if (mouseIn(pointer, lu))
            {
                this.currScalingPoint = "lu";
                mice.cursor = Cursors.SizeNWSE;
                mice.aboveScalingPoints = true;
                return true;
            }
            else if (mouseIn(pointer, ru))
            {
                this.currScalingPoint = "ru";
                mice.cursor = Cursors.SizeNESW;
                mice.aboveScalingPoints = true;
                return true;
            }
            else if (mouseIn(pointer, ld))
            {
                this.currScalingPoint = "ld";
                mice.cursor = Cursors.SizeNESW;
                mice.aboveScalingPoints = true;
                return true;
            }
            else if (mouseIn(pointer, rd))
            {
                this.currScalingPoint = "rd";
                mice.cursor = Cursors.SizeNWSE;
                mice.aboveScalingPoints = true;
                return true;
            }
            else if (mouseIn(pointer, uc))
            {
                this.currScalingPoint = "uc";
                mice.cursor = Cursors.SizeNS;
                mice.aboveScalingPoints = true;
                return true;
            }
            else if (mouseIn(pointer, lc))
            {
                this.currScalingPoint = "lc";
                mice.cursor = Cursors.SizeWE;
                mice.aboveScalingPoints = true;
                return true;
            }
            else if (mouseIn(pointer, rc))
            {
                this.currScalingPoint = "rc";
                mice.cursor = Cursors.SizeWE;
                mice.aboveScalingPoints = true;
                return true;
            }
            else if (mouseIn(pointer, dc))
            {
                this.currScalingPoint = "dc";
                mice.cursor = Cursors.SizeNS;
                mice.aboveScalingPoints = true;
                return true;
            }
            return false;
        }

        protected Comment aboveComment(Vector2 ms)
        {
            for (int i = comments.Count; i > 0; i--)
            {
                Comment cm = (Comment)comments[i - 1];
                if (cm.mouseIn(mice.Position))
                {
                    mice.cursor = Cursors.SizeAll;
                    return cm;
                }
            }
            mice.cursor = Cursors.Default;
            return null;
        }

        protected void SaveComments()
        {
            int i = 0;
            foreach (Comment cm in comments)
            {
                HelperFunctions.ExecuteNonQuery("update Comment set shape='" + cm.shape + "', color='" + cm.Xnacolor + "', text=N'" + cm.text + "' where id=" + cm.id, DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());
                i++;
            }
        }



        #endregion



    }
}
