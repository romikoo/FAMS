namespace Fams
{
    partial class frmDBImage
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout gridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBImage));
            this.button1 = new System.Windows.Forms.Button();
            this.siteCombo = new System.Windows.Forms.ComboBox();
            this.freqList = new System.Windows.Forms.ListBox();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.fls_Monitoring_ImagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.PasteBtn = new System.Windows.Forms.Button();
            this.picturePaste = new System.Windows.Forms.PictureBox();
            this.fls_Monitoring_ImagesTableAdapter = new DataBase.OfficeDataSetTableAdapters.fls_Monitoring_ImagesTableAdapter();
            this.tmp_ImagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tmp_ImagesTableAdapter = new DataBase.OfficeDataSetTableAdapters.tmp_ImagesTableAdapter();
            this.queriesTableAdapter1 = new DataBase.OfficeDataSetTableAdapters.QueriesTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_Monitoring_ImagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePaste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmp_ImagesBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Image = global::Fams.Properties.Resources.print;
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 48);
            this.button1.TabIndex = 17;
            this.button1.Text = "       ბეჭდვა...";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // siteCombo
            // 
            this.siteCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siteCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.siteCombo.FormattingEnabled = true;
            this.siteCombo.Items.AddRange(new object[] {
            "RMS1",
            "RMS2",
            "RMS3",
            "RMS4",
            "MMS-K",
            "MMS-T"});
            this.siteCombo.Location = new System.Drawing.Point(85, 60);
            this.siteCombo.Name = "siteCombo";
            this.siteCombo.Size = new System.Drawing.Size(141, 24);
            this.siteCombo.TabIndex = 16;
            this.siteCombo.SelectedIndexChanged += new System.EventHandler(this.freqList_SelectedIndexChanged);
            // 
            // freqList
            // 
            this.freqList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.freqList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.freqList.FormattingEnabled = true;
            this.freqList.ItemHeight = 16;
            this.freqList.Items.AddRange(new object[] {
            "FM",
            "52.500",
            "62.000",
            "80.000",
            "88.000",
            "96.000",
            "178.000",
            "186.000",
            "194.000",
            "202.000",
            "210.000",
            "218.000",
            "226.000",
            "474.000",
            "482.000",
            "490.000",
            "498.000",
            "506.000",
            "514.000",
            "522.000",
            "530.000",
            "538.000",
            "546.000",
            "554.000",
            "562.000",
            "570.000",
            "578.000",
            "586.000",
            "594.000",
            "602.000",
            "610.000",
            "618.000",
            "626.000",
            "634.000",
            "642.000",
            "650.000",
            "658.000",
            "666.000",
            "674.000",
            "682.000",
            "690.000",
            "698.000",
            "706.000",
            "714.000",
            "722.000",
            "730.000",
            "738.000",
            "746.000",
            "754.000",
            "762.000",
            "770.000",
            "778.000",
            "786.000"});
            this.freqList.Location = new System.Drawing.Point(5, 60);
            this.freqList.Name = "freqList";
            this.freqList.Size = new System.Drawing.Size(74, 484);
            this.freqList.TabIndex = 15;
            this.freqList.SelectedIndexChanged += new System.EventHandler(this.freqList_SelectedIndexChanged);
            // 
            // gridEX1
            // 
            this.gridEX1.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEX1.DataSource = this.fls_Monitoring_ImagesBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular;
            this.gridEX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gridEX1.Location = new System.Drawing.Point(639, 91);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.ScrollBars = Janus.Windows.GridEX.ScrollBars.Vertical;
            this.gridEX1.Size = new System.Drawing.Size(323, 453);
            this.gridEX1.TabIndex = 14;
            this.gridEX1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.gridEX1.CellEdited += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gridEX1_CellEdited);
            this.gridEX1.DeletingRecords += new System.ComponentModel.CancelEventHandler(this.gridEX1_DeletingRecords);
            this.gridEX1.RecordsDeleted += new System.EventHandler(this.gridEX1_RecordsDeleted);
            this.gridEX1.GroupsChanged += new Janus.Windows.GridEX.GroupsChangedEventHandler(this.gridEX1_GroupsChanged);
            this.gridEX1.CurrentCellChanged += new System.EventHandler(this.gridEX1_CurrentCellChanged);
            // 
            // fls_Monitoring_ImagesBindingSource
            // 
            this.fls_Monitoring_ImagesBindingSource.DataMember = "fls_Monitoring_Images";
            this.fls_Monitoring_ImagesBindingSource.DataSource = this.officeDataSet;
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PasteBtn
            // 
            this.PasteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasteBtn.Font = new System.Drawing.Font("Sylfaen", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasteBtn.Location = new System.Drawing.Point(232, 6);
            this.PasteBtn.Name = "PasteBtn";
            this.PasteBtn.Size = new System.Drawing.Size(730, 78);
            this.PasteBtn.TabIndex = 13;
            this.PasteBtn.Text = "ჩასმა...";
            this.PasteBtn.UseVisualStyleBackColor = true;
            this.PasteBtn.Click += new System.EventHandler(this.PasteBtn_Click);
            // 
            // picturePaste
            // 
            this.picturePaste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePaste.BackColor = System.Drawing.SystemColors.Window;
            this.picturePaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePaste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picturePaste.Location = new System.Drawing.Point(85, 91);
            this.picturePaste.Name = "picturePaste";
            this.picturePaste.Size = new System.Drawing.Size(548, 453);
            this.picturePaste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePaste.TabIndex = 12;
            this.picturePaste.TabStop = false;
            this.picturePaste.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmDBImage_MouseMove);
            // 
            // fls_Monitoring_ImagesTableAdapter
            // 
            this.fls_Monitoring_ImagesTableAdapter.ClearBeforeFill = true;
            // 
            // tmp_ImagesBindingSource
            // 
            this.tmp_ImagesBindingSource.DataMember = "tmp_Images";
            this.tmp_ImagesBindingSource.DataSource = this.officeDataSet;
            // 
            // tmp_ImagesTableAdapter
            // 
            this.tmp_ImagesTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(240, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 59);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "რედაქტირების უფლებები შეზღუდულია";
            // 
            // frmDBImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.siteCombo);
            this.Controls.Add(this.freqList);
            this.Controls.Add(this.gridEX1);
            this.Controls.Add(this.PasteBtn);
            this.Controls.Add(this.picturePaste);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(976, 584);
            this.Name = "frmDBImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDBImage";
            this.Load += new System.EventHandler(this.frmDBImage_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmDBImage_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_Monitoring_ImagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePaste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmp_ImagesBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox siteCombo;
        private System.Windows.Forms.ListBox freqList;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private System.Windows.Forms.Button PasteBtn;
        private System.Windows.Forms.PictureBox picturePaste;
        private System.Windows.Forms.BindingSource fls_Monitoring_ImagesBindingSource;
        private DataBase.OfficeDataSetTableAdapters.fls_Monitoring_ImagesTableAdapter fls_Monitoring_ImagesTableAdapter;
        private System.Windows.Forms.BindingSource tmp_ImagesBindingSource;
        private DataBase.OfficeDataSetTableAdapters.tmp_ImagesTableAdapter tmp_ImagesTableAdapter;
        private DataBase.OfficeDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}