namespace Earth
{
   partial class EarthForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if(disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SideBar = new Telerik.WinControls.UI.RadPageView();
            this.MenuPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button12 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxMapType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DistLabel = new System.Windows.Forms.Label();
            this.SaveKmlBtn = new System.Windows.Forms.Button();
            this.FindBtn = new System.Windows.Forms.Button();
            this.DistBar = new System.Windows.Forms.TrackBar();
            this.CachePage = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxCacheSize = new System.Windows.Forms.TextBox();
            this.textBoxCacheStatus = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.textBoxMemory = new System.Windows.Forms.TextBox();
            this.checkBoxUseRouteCache = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.InfoPage = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxZoomCurrent = new System.Windows.Forms.TextBox();
            this.textBoxrouteCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxLngCurrent = new System.Windows.Forms.TextBox();
            this.textBoxMarkerCount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLatCurrent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkAgainstSelfBox = new System.Windows.Forms.CheckBox();
            this.MainMap = new Earth.Map();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SideBar)).BeginInit();
            this.SideBar.SuspendLayout();
            this.MenuPage.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DistBar)).BeginInit();
            this.CachePage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.InfoPage.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.MainMap);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 653);
            this.panel2.TabIndex = 41;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.BackColor = System.Drawing.Color.Gray;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(9, 515);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 1700;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 117);
            this.trackBar1.TabIndex = 29;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 12;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.SideBar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(702, 653);
            this.panel4.TabIndex = 44;
            // 
            // SideBar
            // 
            this.SideBar.Controls.Add(this.MenuPage);
            this.SideBar.Controls.Add(this.CachePage);
            this.SideBar.Controls.Add(this.InfoPage);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.SideBar.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SideBar.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            this.SideBar.Location = new System.Drawing.Point(439, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.SelectedPage = this.MenuPage;
            this.SideBar.Size = new System.Drawing.Size(263, 653);
            this.SideBar.TabIndex = 1;
            this.SideBar.Text = "radPageView1";
            this.SideBar.ViewMode = Telerik.WinControls.UI.PageViewMode.Stack;
            // 
            // MenuPage
            // 
            this.MenuPage.Controls.Add(this.tableLayoutPanel4);
            this.MenuPage.Description = null;
            this.MenuPage.ItemSize = new System.Drawing.SizeF(261F, 24F);
            this.MenuPage.Location = new System.Drawing.Point(5, 29);
            this.MenuPage.Name = "MenuPage";
            this.MenuPage.Size = new System.Drawing.Size(253, 545);
            this.MenuPage.Text = "Menu";
            this.MenuPage.Title = "Menu";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(253, 545);
            this.tableLayoutPanel4.TabIndex = 38;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox5, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.02326F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.54263F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.75194F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.29457F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(251, 543);
            this.tableLayoutPanel5.TabIndex = 30;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button12);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.comboBoxMode);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.comboBoxMapType);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 92);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "რუკის ბირთვი";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(171, 17);
            this.button12.Margin = new System.Windows.Forms.Padding(2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(69, 24);
            this.button12.TabIndex = 39;
            this.button12.Text = "შენახვა....";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(132, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 14);
            this.label8.TabIndex = 38;
            this.label8.Text = "რეჟიმი";
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Location = new System.Drawing.Point(8, 46);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(123, 22);
            this.comboBoxMode.TabIndex = 37;
            this.comboBoxMode.DropDownClosed += new System.EventHandler(this.comboBoxMode_DropDownClosed);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(132, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 14);
            this.label7.TabIndex = 31;
            this.label7.Text = "რუკა";
            // 
            // comboBoxMapType
            // 
            this.comboBoxMapType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMapType.FormattingEnabled = true;
            this.comboBoxMapType.Location = new System.Drawing.Point(8, 19);
            this.comboBoxMapType.Name = "comboBoxMapType";
            this.comboBoxMapType.Size = new System.Drawing.Size(123, 22);
            this.comboBoxMapType.TabIndex = 9;
            this.comboBoxMapType.DropDownClosed += new System.EventHandler(this.comboBoxMapType_DropDownClosed);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 105);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "სარელეო საიტები";
            // 
            // listBox3
            // 
            this.listBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox3.ForeColor = System.Drawing.Color.Green;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(3, 18);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(239, 84);
            this.listBox3.TabIndex = 1;
            this.listBox3.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(3, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(239, 84);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Controls.Add(this.ClearBtn);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 172);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ლინკები";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(3, 18);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(239, 116);
            this.listBox2.TabIndex = 0;
            this.listBox2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDoubleClick);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(3, 140);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(239, 23);
            this.ClearBtn.TabIndex = 1;
            this.ClearBtn.Text = "ლინკების წაშლა";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkAgainstSelfBox);
            this.groupBox3.Controls.Add(this.DistLabel);
            this.groupBox3.Controls.Add(this.SaveKmlBtn);
            this.groupBox3.Controls.Add(this.FindBtn);
            this.groupBox3.Controls.Add(this.DistBar);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 150);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "შერჩევა";
            // 
            // DistLabel
            // 
            this.DistLabel.AutoSize = true;
            this.DistLabel.Location = new System.Drawing.Point(98, 28);
            this.DistLabel.Name = "DistLabel";
            this.DistLabel.Size = new System.Drawing.Size(40, 14);
            this.DistLabel.TabIndex = 4;
            this.DistLabel.Text = "10 km.";
            // 
            // SaveKmlBtn
            // 
            this.SaveKmlBtn.Enabled = false;
            this.SaveKmlBtn.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveKmlBtn.Location = new System.Drawing.Point(9, 96);
            this.SaveKmlBtn.Name = "SaveKmlBtn";
            this.SaveKmlBtn.Size = new System.Drawing.Size(221, 45);
            this.SaveKmlBtn.TabIndex = 2;
            this.SaveKmlBtn.Text = "KML...";
            this.SaveKmlBtn.UseVisualStyleBackColor = true;
            this.SaveKmlBtn.Click += new System.EventHandler(this.SaveKmlBtn_Click);
            // 
            // FindBtn
            // 
            this.FindBtn.Enabled = false;
            this.FindBtn.Location = new System.Drawing.Point(155, 12);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(75, 47);
            this.FindBtn.TabIndex = 0;
            this.FindBtn.Text = "შერჩევა";
            this.FindBtn.UseVisualStyleBackColor = true;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // DistBar
            // 
            this.DistBar.AutoSize = false;
            this.DistBar.LargeChange = 10;
            this.DistBar.Location = new System.Drawing.Point(9, 21);
            this.DistBar.Maximum = 250;
            this.DistBar.Minimum = 1;
            this.DistBar.Name = "DistBar";
            this.DistBar.Size = new System.Drawing.Size(92, 38);
            this.DistBar.TabIndex = 3;
            this.DistBar.Value = 100;
            this.DistBar.ValueChanged += new System.EventHandler(this.DistBar_ValueChanged);
            // 
            // CachePage
            // 
            this.CachePage.Controls.Add(this.tableLayoutPanel1);
            this.CachePage.Description = null;
            this.CachePage.ItemSize = new System.Drawing.SizeF(261F, 24F);
            this.CachePage.Location = new System.Drawing.Point(5, 29);
            this.CachePage.Name = "CachePage";
            this.CachePage.Size = new System.Drawing.Size(233, 539);
            this.CachePage.Text = "Cache";
            this.CachePage.Title = "Cache";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxCacheSize, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.textBoxCacheStatus, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.button10, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMemory, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseRouteCache, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.button9, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button11, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label13, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 539);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // textBoxCacheSize
            // 
            this.textBoxCacheSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCacheSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCacheSize.Location = new System.Drawing.Point(18, 217);
            this.textBoxCacheSize.Name = "textBoxCacheSize";
            this.textBoxCacheSize.ReadOnly = true;
            this.textBoxCacheSize.Size = new System.Drawing.Size(197, 28);
            this.textBoxCacheSize.TabIndex = 49;
            this.textBoxCacheSize.Text = "...";
            // 
            // textBoxCacheStatus
            // 
            this.textBoxCacheStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxCacheStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCacheStatus.Location = new System.Drawing.Point(18, 281);
            this.textBoxCacheStatus.Name = "textBoxCacheStatus";
            this.textBoxCacheStatus.ReadOnly = true;
            this.textBoxCacheStatus.Size = new System.Drawing.Size(197, 28);
            this.textBoxCacheStatus.TabIndex = 46;
            this.textBoxCacheStatus.Text = "...";
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.Location = new System.Drawing.Point(18, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(197, 20);
            this.button10.TabIndex = 5;
            this.button10.Text = "Import";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBoxMemory
            // 
            this.textBoxMemory.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMemory.Location = new System.Drawing.Point(18, 153);
            this.textBoxMemory.Name = "textBoxMemory";
            this.textBoxMemory.ReadOnly = true;
            this.textBoxMemory.Size = new System.Drawing.Size(197, 28);
            this.textBoxMemory.TabIndex = 39;
            this.textBoxMemory.Text = "...";
            // 
            // checkBoxUseRouteCache
            // 
            this.checkBoxUseRouteCache.AutoSize = true;
            this.checkBoxUseRouteCache.Checked = true;
            this.checkBoxUseRouteCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseRouteCache.Location = new System.Drawing.Point(18, 331);
            this.checkBoxUseRouteCache.Name = "checkBoxUseRouteCache";
            this.checkBoxUseRouteCache.Size = new System.Drawing.Size(150, 18);
            this.checkBoxUseRouteCache.TabIndex = 2;
            this.checkBoxUseRouteCache.Text = "cache routing/geocodig/etc";
            this.checkBoxUseRouteCache.UseVisualStyleBackColor = true;
            this.checkBoxUseRouteCache.CheckedChanged += new System.EventHandler(this.checkBoxUseCache_CheckedChanged);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.Location = new System.Drawing.Point(18, 45);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(197, 20);
            this.button9.TabIndex = 4;
            this.button9.Text = "Export";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Top;
            this.button11.Location = new System.Drawing.Point(18, 71);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(197, 20);
            this.button11.TabIndex = 38;
            this.button11.Text = "Prefetch selected area";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 14);
            this.label10.TabIndex = 40;
            this.label10.Text = "memory cache usage:";
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(18, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 20);
            this.button2.TabIndex = 43;
            this.button2.Text = "Clear tiles in local cache";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 14);
            this.label13.TabIndex = 44;
            this.label13.Text = "local cache status:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 200);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 14);
            this.label14.TabIndex = 47;
            this.label14.Text = "local cache size:";
            // 
            // InfoPage
            // 
            this.InfoPage.Controls.Add(this.tableLayoutPanel2);
            this.InfoPage.Description = null;
            this.InfoPage.ItemSize = new System.Drawing.SizeF(261F, 24F);
            this.InfoPage.Location = new System.Drawing.Point(5, 29);
            this.InfoPage.Name = "InfoPage";
            this.InfoPage.Size = new System.Drawing.Size(233, 539);
            this.InfoPage.Text = "Info";
            this.InfoPage.Title = "Info";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxZoomCurrent, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBoxrouteCount, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.label12, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.label9, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.textBoxLngCurrent, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.textBoxMarkerCount, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label11, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxLatCurrent, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 13;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(233, 539);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // textBoxZoomCurrent
            // 
            this.textBoxZoomCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxZoomCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxZoomCurrent.Location = new System.Drawing.Point(18, 145);
            this.textBoxZoomCurrent.Name = "textBoxZoomCurrent";
            this.textBoxZoomCurrent.ReadOnly = true;
            this.textBoxZoomCurrent.Size = new System.Drawing.Size(197, 28);
            this.textBoxZoomCurrent.TabIndex = 8;
            this.textBoxZoomCurrent.Text = "...";
            // 
            // textBoxrouteCount
            // 
            this.textBoxrouteCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxrouteCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxrouteCount.Location = new System.Drawing.Point(18, 241);
            this.textBoxrouteCount.Name = "textBoxrouteCount";
            this.textBoxrouteCount.ReadOnly = true;
            this.textBoxrouteCount.Size = new System.Drawing.Size(197, 28);
            this.textBoxrouteCount.TabIndex = 12;
            this.textBoxrouteCount.Text = "...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "routes:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "zoom:";
            // 
            // textBoxLngCurrent
            // 
            this.textBoxLngCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLngCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLngCurrent.Location = new System.Drawing.Point(18, 81);
            this.textBoxLngCurrent.Name = "textBoxLngCurrent";
            this.textBoxLngCurrent.ReadOnly = true;
            this.textBoxLngCurrent.Size = new System.Drawing.Size(197, 28);
            this.textBoxLngCurrent.TabIndex = 5;
            this.textBoxLngCurrent.Text = "...";
            // 
            // textBoxMarkerCount
            // 
            this.textBoxMarkerCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMarkerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMarkerCount.Location = new System.Drawing.Point(18, 193);
            this.textBoxMarkerCount.Name = "textBoxMarkerCount";
            this.textBoxMarkerCount.ReadOnly = true;
            this.textBoxMarkerCount.Size = new System.Drawing.Size(197, 28);
            this.textBoxMarkerCount.TabIndex = 10;
            this.textBoxMarkerCount.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 11;
            this.label11.Text = "markers:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "lng:";
            // 
            // textBoxLatCurrent
            // 
            this.textBoxLatCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLatCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLatCurrent.Location = new System.Drawing.Point(18, 33);
            this.textBoxLatCurrent.Name = "textBoxLatCurrent";
            this.textBoxLatCurrent.ReadOnly = true;
            this.textBoxLatCurrent.Size = new System.Drawing.Size(197, 28);
            this.textBoxLatCurrent.TabIndex = 4;
            this.textBoxLatCurrent.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "lat:";
            // 
            // checkAgainstSelfBox
            // 
            this.checkAgainstSelfBox.AutoSize = true;
            this.checkAgainstSelfBox.Location = new System.Drawing.Point(9, 72);
            this.checkAgainstSelfBox.Name = "checkAgainstSelfBox";
            this.checkAgainstSelfBox.Size = new System.Drawing.Size(225, 18);
            this.checkAgainstSelfBox.TabIndex = 5;
            this.checkAgainstSelfBox.Text = "შეადარე იმავე კომპანიის სადგურებს";
            this.checkAgainstSelfBox.UseVisualStyleBackColor = true;
            this.checkAgainstSelfBox.Visible = false;
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 0);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 17;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(439, 653);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 0D;
            // 
            // EarthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(702, 653);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(554, 110);
            this.Name = "EarthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "რუკა";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EarthForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SideBar)).EndInit();
            this.SideBar.ResumeLayout(false);
            this.MenuPage.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DistBar)).EndInit();
            this.CachePage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.InfoPage.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TrackBar trackBar1;
      private System.Windows.Forms.CheckBox checkBoxUseRouteCache;
      private System.Windows.Forms.Button button9;
      private System.Windows.Forms.Button button10;
      private System.Windows.Forms.Button button11;
      internal Map MainMap;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Panel panel4;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.TextBox textBoxLngCurrent;
      private System.Windows.Forms.TextBox textBoxLatCurrent;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.TextBox textBoxZoomCurrent;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.TextBox textBoxMemory;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.TextBox textBoxrouteCount;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.TextBox textBoxMarkerCount;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
      private System.Windows.Forms.GroupBox groupBox5;
      private System.Windows.Forms.Button button12;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.ComboBox comboBoxMode;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.ComboBox comboBoxMapType;
      private System.Windows.Forms.TextBox textBoxCacheStatus;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.TextBox textBoxCacheSize;
      private Telerik.WinControls.UI.RadPageView SideBar;
      private Telerik.WinControls.UI.RadPageViewPage MenuPage;
      private Telerik.WinControls.UI.RadPageViewPage CachePage;
      private Telerik.WinControls.UI.RadPageViewPage InfoPage;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ListBox listBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ListBox listBox2;
      private System.Windows.Forms.Button ClearBtn;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button FindBtn;
      private System.Windows.Forms.Button SaveKmlBtn;
      private System.Windows.Forms.TrackBar DistBar;
      private System.Windows.Forms.Label DistLabel;
      private System.Windows.Forms.ListBox listBox3;
      private System.Windows.Forms.CheckBox checkAgainstSelfBox;
   }
}

