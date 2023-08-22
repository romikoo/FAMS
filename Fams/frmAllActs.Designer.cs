namespace Fams
{
    partial class frmAllActs
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.myMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colnumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltarigi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colremark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrecever = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComp_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLICENCE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.allActsTableAdapter = new DataBase.OfficeDataSetTableAdapters.AllActsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.myMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.myMenuStrip;
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataMember = "AllActs";
            this.gridControl.DataSource = this.officeDataSet;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.gridControl.Size = new System.Drawing.Size(874, 511);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // myMenuStrip
            // 
            this.myMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printContextMenuItem});
            this.myMenuStrip.Name = "ContextMenuStrip";
            this.myMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // printContextMenuItem
            // 
            this.printContextMenuItem.Image = global::Fams.Properties.Resources.print;
            this.printContextMenuItem.Name = "printContextMenuItem";
            this.printContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printContextMenuItem.Text = "ბეჭდვა...";
            this.printContextMenuItem.Click += new System.EventHandler(this.printContextMenuItem_Click);
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colnumber,
            this.coltarigi,
            this.coldescription,
            this.colremark,
            this.colrecever,
            this.colComp_Name,
            this.colLICENCE});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.coltarigi, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colnumber
            // 
            this.colnumber.Caption = "აქტის ნომერი";
            this.colnumber.FieldName = "number";
            this.colnumber.Name = "colnumber";
            this.colnumber.Visible = true;
            this.colnumber.VisibleIndex = 0;
            this.colnumber.Width = 70;
            // 
            // coltarigi
            // 
            this.coltarigi.Caption = "გაფორმების თარიღი";
            this.coltarigi.FieldName = "tarigi";
            this.coltarigi.Name = "coltarigi";
            this.coltarigi.Visible = true;
            this.coltarigi.VisibleIndex = 1;
            this.coltarigi.Width = 112;
            // 
            // coldescription
            // 
            this.coldescription.AppearanceCell.Options.UseTextOptions = true;
            this.coldescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.coldescription.Caption = "აღწერა";
            this.coldescription.ColumnEdit = this.repositoryItemMemoEdit1;
            this.coldescription.FieldName = "description";
            this.coldescription.Name = "coldescription";
            this.coldescription.Visible = true;
            this.coldescription.VisibleIndex = 2;
            this.coldescription.Width = 192;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colremark
            // 
            this.colremark.Caption = "შენიშვნა";
            this.colremark.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colremark.FieldName = "remark";
            this.colremark.Name = "colremark";
            this.colremark.Visible = true;
            this.colremark.VisibleIndex = 3;
            this.colremark.Width = 128;
            // 
            // colrecever
            // 
            this.colrecever.Caption = "ჩაიბარა";
            this.colrecever.FieldName = "recever";
            this.colrecever.Name = "colrecever";
            this.colrecever.Visible = true;
            this.colrecever.VisibleIndex = 4;
            this.colrecever.Width = 70;
            // 
            // colComp_Name
            // 
            this.colComp_Name.Caption = "ორგანიზაცია";
            this.colComp_Name.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colComp_Name.FieldName = "Comp_Name";
            this.colComp_Name.Name = "colComp_Name";
            this.colComp_Name.Visible = true;
            this.colComp_Name.VisibleIndex = 5;
            this.colComp_Name.Width = 181;
            // 
            // colLICENCE
            // 
            this.colLICENCE.Caption = "ლიცენზიის ნომერი";
            this.colLICENCE.FieldName = "LICENCE";
            this.colLICENCE.Name = "colLICENCE";
            this.colLICENCE.Visible = true;
            this.colLICENCE.VisibleIndex = 6;
            this.colLICENCE.Width = 100;
            // 
            // allActsTableAdapter
            // 
            this.allActsTableAdapter.ClearBeforeFill = true;
            // 
            // frmAllActs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 511);
            this.Controls.Add(this.gridControl);
            this.MinimizeBox = false;
            this.Name = "frmAllActs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "შემოწმების აქტების ნუსხა";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.myMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DataBase.OfficeDataSet officeDataSet;
        private DevExpress.XtraGrid.Columns.GridColumn colnumber;
        private DevExpress.XtraGrid.Columns.GridColumn coltarigi;
        private DevExpress.XtraGrid.Columns.GridColumn coldescription;
        private DevExpress.XtraGrid.Columns.GridColumn colremark;
        private DevExpress.XtraGrid.Columns.GridColumn colrecever;
        private DevExpress.XtraGrid.Columns.GridColumn colComp_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colLICENCE;
        private DataBase.OfficeDataSetTableAdapters.AllActsTableAdapter allActsTableAdapter;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.ContextMenuStrip myMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem printContextMenuItem;
    }
}