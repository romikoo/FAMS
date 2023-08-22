namespace ERO
{
    partial class Form1
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            this.implementationView = new Helpers.MyGridView();
            this.colid1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colFFrom1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFTo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colinUse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colband_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new Helpers.MyGridControl();
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.allocationGridView = new Helpers.MyGridView();
            this.colid2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllocation_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ero_AllocationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colFR_Band_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmain = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LicGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mainView = new Helpers.MyGridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ero_ImplementationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ero_FR_BandTableAdapter = new DataBase.OfficeDataSetTableAdapters.ero_FR_BandTableAdapter();
            this.ero_ImplementationsTableAdapter = new DataBase.OfficeDataSetTableAdapters.ero_ImplementationsTableAdapter();
            this.ero_AllocationsTableAdapter = new DataBase.OfficeDataSetTableAdapters.ero_AllocationsTableAdapter();
            this.ero_AllocationPlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ero_AllocationPlanTableAdapter = new DataBase.OfficeDataSetTableAdapters.ero_AllocationPlanTableAdapter();
            this.ero_FR_BandBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ero_LicencesTableAdapter = new DataBase.OfficeDataSetTableAdapters.ero_LicencesTableAdapter();
            this.ero_LicencesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Licence = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.implementationView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allocationGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_AllocationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LicGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_ImplementationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_AllocationPlanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_FR_BandBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_LicencesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // implementationView
            // 
            this.implementationView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.implementationView.Appearance.HeaderPanel.Options.UseFont = true;
            this.implementationView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.implementationView.Appearance.Row.Options.UseFont = true;
            this.implementationView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid1,
            this.colName,
            this.colFFrom1,
            this.colFTo1,
            this.colinUse,
            this.colNote,
            this.colband_id});
            this.implementationView.GridControl = this.gridControl;
            this.implementationView.Name = "implementationView";
            this.implementationView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.implementationView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.implementationView.OptionsView.ShowGroupPanel = false;
            this.implementationView.ViewCaption = "Implementation";
            this.implementationView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.implementationView_RowUpdated);
            this.implementationView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.implementationView_KeyDown);
            // 
            // colid1
            // 
            this.colid1.FieldName = "id";
            this.colid1.Name = "colid1";
            this.colid1.OptionsColumn.ReadOnly = true;
            this.colid1.Width = 191;
            // 
            // colName
            // 
            this.colName.ColumnEdit = this.repositoryItemComboBox1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 175;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // colFFrom1
            // 
            this.colFFrom1.FieldName = "FFrom";
            this.colFFrom1.Name = "colFFrom1";
            this.colFFrom1.OptionsColumn.FixedWidth = true;
            this.colFFrom1.Visible = true;
            this.colFFrom1.VisibleIndex = 1;
            this.colFFrom1.Width = 105;
            // 
            // colFTo1
            // 
            this.colFTo1.FieldName = "FTo";
            this.colFTo1.Name = "colFTo1";
            this.colFTo1.OptionsColumn.FixedWidth = true;
            this.colFTo1.Visible = true;
            this.colFTo1.VisibleIndex = 2;
            this.colFTo1.Width = 106;
            // 
            // colinUse
            // 
            this.colinUse.FieldName = "inUse";
            this.colinUse.Name = "colinUse";
            this.colinUse.OptionsColumn.FixedWidth = true;
            this.colinUse.Visible = true;
            this.colinUse.VisibleIndex = 3;
            this.colinUse.Width = 50;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.FixedWidth = true;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 4;
            // 
            // colband_id
            // 
            this.colband_id.FieldName = "band_id";
            this.colband_id.Name = "colband_id";
            this.colband_id.Width = 290;
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataMember = "ero_FR_Band";
            this.gridControl.DataSource = this.officeDataSet;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.implementationView;
            gridLevelNode1.RelationName = "FK_ero_Implementations_ero_FR_Band";
            gridLevelNode2.LevelTemplate = this.allocationGridView;
            gridLevelNode2.RelationName = "FK_ero_AllocationPlan_ero_FR_Band";
            gridLevelNode3.LevelTemplate = this.LicGridView;
            gridLevelNode3.RelationName = "FK_ero_licences_ero_FR_Band";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.mainView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemLookUpEdit1});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(871, 385);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.allocationGridView,
            this.LicGridView,
            this.mainView,
            this.implementationView});
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // allocationGridView
            // 
            this.allocationGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.allocationGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.allocationGridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.allocationGridView.Appearance.Row.Options.UseFont = true;
            this.allocationGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid2,
            this.colAllocation_id,
            this.colFR_Band_id,
            this.colmain});
            this.allocationGridView.GridControl = this.gridControl;
            this.allocationGridView.Name = "allocationGridView";
            this.allocationGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.allocationGridView.OptionsView.ShowGroupPanel = false;
            this.allocationGridView.ViewCaption = "Allocation";
            this.allocationGridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.allocationGridView_RowUpdated);
            this.allocationGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.allocationGridView_KeyDown);
            // 
            // colid2
            // 
            this.colid2.FieldName = "id";
            this.colid2.Name = "colid2";
            this.colid2.OptionsColumn.ReadOnly = true;
            // 
            // colAllocation_id
            // 
            this.colAllocation_id.Caption = "Allocation Name";
            this.colAllocation_id.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colAllocation_id.FieldName = "Allocation_id";
            this.colAllocation_id.Name = "colAllocation_id";
            this.colAllocation_id.Visible = true;
            this.colAllocation_id.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Font = new System.Drawing.Font("Sylfaen", 9.75F);
            this.repositoryItemLookUpEdit1.AppearanceDropDown.Options.UseFont = true;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id", "id", 31, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GName", "GName", 44, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EName", "EName", 43, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Note", "Note", 33, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.ero_AllocationsBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "GName";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "id";
            // 
            // ero_AllocationsBindingSource
            // 
            this.ero_AllocationsBindingSource.DataMember = "ero_Allocations";
            this.ero_AllocationsBindingSource.DataSource = this.officeDataSet;
            // 
            // colFR_Band_id
            // 
            this.colFR_Band_id.FieldName = "FR_Band_id";
            this.colFR_Band_id.Name = "colFR_Band_id";
            // 
            // colmain
            // 
            this.colmain.FieldName = "main";
            this.colmain.Name = "colmain";
            // 
            // LicGridView
            // 
            this.LicGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Licence});
            this.LicGridView.GridControl = this.gridControl;
            this.LicGridView.Name = "LicGridView";
            this.LicGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.LicGridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.LicGridView.OptionsView.ShowGroupPanel = false;
            this.LicGridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.LicGridView_RowUpdated);
            this.LicGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LicGridView_KeyDown);
            // 
            // mainView
            // 
            this.mainView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.mainView.Appearance.HeaderPanel.Options.UseFont = true;
            this.mainView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainView.Appearance.Row.Options.UseFont = true;
            this.mainView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colFFrom,
            this.colFTo,
            this.colDescription});
            this.mainView.GridControl = this.gridControl;
            this.mainView.Name = "mainView";
            this.mainView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.mainView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails;
            this.mainView.OptionsDetail.SmartDetailHeight = true;
            this.mainView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.mainView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.mainView.OptionsView.ShowGroupPanel = false;
            this.mainView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFFrom, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.mainView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.mainView_RowUpdated);
            this.mainView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainView_KeyDown);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.ReadOnly = true;
            // 
            // colFFrom
            // 
            this.colFFrom.FieldName = "FFrom";
            this.colFFrom.Name = "colFFrom";
            this.colFFrom.OptionsColumn.FixedWidth = true;
            this.colFFrom.Visible = true;
            this.colFFrom.VisibleIndex = 0;
            this.colFFrom.Width = 114;
            // 
            // colFTo
            // 
            this.colFTo.FieldName = "FTo";
            this.colFTo.Name = "colFTo";
            this.colFTo.OptionsColumn.FixedWidth = true;
            this.colFTo.Visible = true;
            this.colFTo.VisibleIndex = 1;
            this.colFTo.Width = 119;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            this.colDescription.Width = 759;
            // 
            // ero_ImplementationsBindingSource
            // 
            this.ero_ImplementationsBindingSource.DataMember = "ero_Implementations";
            this.ero_ImplementationsBindingSource.DataSource = this.officeDataSet;
            this.ero_ImplementationsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.ero_ImplementationsBindingSource_ListChanged);
            // 
            // ero_FR_BandTableAdapter
            // 
            this.ero_FR_BandTableAdapter.ClearBeforeFill = true;
            // 
            // ero_ImplementationsTableAdapter
            // 
            this.ero_ImplementationsTableAdapter.ClearBeforeFill = true;
            // 
            // ero_AllocationsTableAdapter
            // 
            this.ero_AllocationsTableAdapter.ClearBeforeFill = true;
            // 
            // ero_AllocationPlanBindingSource
            // 
            this.ero_AllocationPlanBindingSource.DataMember = "ero_AllocationPlan";
            this.ero_AllocationPlanBindingSource.DataSource = this.officeDataSet;
            // 
            // ero_AllocationPlanTableAdapter
            // 
            this.ero_AllocationPlanTableAdapter.ClearBeforeFill = true;
            // 
            // ero_FR_BandBindingSource
            // 
            this.ero_FR_BandBindingSource.DataMember = "ero_FR_Band";
            this.ero_FR_BandBindingSource.DataSource = this.officeDataSet;
            // 
            // ero_LicencesTableAdapter
            // 
            this.ero_LicencesTableAdapter.ClearBeforeFill = true;
            // 
            // ero_LicencesBindingSource
            // 
            this.ero_LicencesBindingSource.DataMember = "ero_Licences";
            this.ero_LicencesBindingSource.DataSource = this.officeDataSet;
            // 
            // Licence
            // 
            this.Licence.FieldName = "lic";
            this.Licence.Name = "Licence";
            this.Licence.Visible = true;
            this.Licence.VisibleIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 385);
            this.Controls.Add(this.gridControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ეროვნული გეგმა";
            ((System.ComponentModel.ISupportInitialize)(this.implementationView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allocationGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_AllocationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LicGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_ImplementationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_AllocationPlanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_FR_BandBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ero_LicencesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Helpers.MyGridControl gridControl;
        private DataBase.OfficeDataSet officeDataSet;
        private Helpers.MyGridView mainView;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colFFrom;
        private DevExpress.XtraGrid.Columns.GridColumn colFTo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DataBase.OfficeDataSetTableAdapters.ero_FR_BandTableAdapter ero_FR_BandTableAdapter;
        private Helpers.MyGridView implementationView;
        private System.Windows.Forms.BindingSource ero_ImplementationsBindingSource;
        private DataBase.OfficeDataSetTableAdapters.ero_ImplementationsTableAdapter ero_ImplementationsTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colid1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colFFrom1;
        private DevExpress.XtraGrid.Columns.GridColumn colFTo1;
        private DevExpress.XtraGrid.Columns.GridColumn colinUse;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colband_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private Helpers.MyGridView allocationGridView;
        private DevExpress.XtraGrid.Columns.GridColumn colid2;
        private DevExpress.XtraGrid.Columns.GridColumn colAllocation_id;
        private DevExpress.XtraGrid.Columns.GridColumn colFR_Band_id;
        private DevExpress.XtraGrid.Columns.GridColumn colmain;
        private System.Windows.Forms.BindingSource ero_AllocationsBindingSource;
        private DataBase.OfficeDataSetTableAdapters.ero_AllocationsTableAdapter ero_AllocationsTableAdapter;
        private System.Windows.Forms.BindingSource ero_AllocationPlanBindingSource;
        private DataBase.OfficeDataSetTableAdapters.ero_AllocationPlanTableAdapter ero_AllocationPlanTableAdapter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource ero_FR_BandBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView LicGridView;
        private DataBase.OfficeDataSetTableAdapters.ero_LicencesTableAdapter ero_LicencesTableAdapter;
        private System.Windows.Forms.BindingSource ero_LicencesBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn Licence;







    }
}

