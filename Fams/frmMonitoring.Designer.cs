namespace Fams
{
    partial class frmMonitoring
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
            this.violationView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.monitoringGridControl = new Helpers.MyGridControl();
            this.mn_MonitoringBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.operatorView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.monitoringView = new Helpers.MyGridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltarigi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colregion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collongitude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collatitude = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsafudzveli_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmizani_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.mn_COMBO_MizaniBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.collenMins = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colforCompany_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcountchannels = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcountFM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcountTV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcountStations = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltrip_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mn_MonitoringTableAdapter = new DataBase.OfficeDataSetTableAdapters.mn_MonitoringTableAdapter();
            this.mn_COMBO_MizaniTableAdapter = new DataBase.OfficeDataSetTableAdapters.mn_COMBO_MizaniTableAdapter();
            this.mn_ViolationTableAdapter = new DataBase.OfficeDataSetTableAdapters.mn_ViolationTableAdapter();
            this.sidePanel1 = new DevExpress.XtraEditors.SidePanel();
            ((System.ComponentModel.ISupportInitialize)(this.violationView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mn_MonitoringBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mn_COMBO_MizaniBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // violationView
            // 
            this.violationView.GridControl = this.monitoringGridControl;
            this.violationView.Name = "violationView";
            this.violationView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.violationView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.violationView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.violationView_RowUpdated);
            // 
            // monitoringGridControl
            // 
            this.monitoringGridControl.DataSource = this.mn_MonitoringBindingSource;
            this.monitoringGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.violationView;
            gridLevelNode1.RelationName = "FK_mn_violation_mn_Monitoring";
            gridLevelNode2.LevelTemplate = this.operatorView;
            gridLevelNode2.RelationName = "FK_mn_Operator_mn_Monitoring";
            this.monitoringGridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.monitoringGridControl.Location = new System.Drawing.Point(165, 0);
            this.monitoringGridControl.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.monitoringGridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.monitoringGridControl.MainView = this.monitoringView;
            this.monitoringGridControl.Name = "monitoringGridControl";
            this.monitoringGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.monitoringGridControl.Size = new System.Drawing.Size(848, 372);
            this.monitoringGridControl.TabIndex = 0;
            this.monitoringGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.operatorView,
            this.monitoringView,
            this.violationView});
            // 
            // mn_MonitoringBindingSource
            // 
            this.mn_MonitoringBindingSource.DataMember = "mn_Monitoring";
            this.mn_MonitoringBindingSource.DataSource = this.officeDataSet;
            this.mn_MonitoringBindingSource.Sort = "";
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operatorView
            // 
            this.operatorView.GridControl = this.monitoringGridControl;
            this.operatorView.Name = "operatorView";
            this.operatorView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // monitoringView
            // 
            this.monitoringView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.coltarigi,
            this.colcity,
            this.colregion,
            this.collongitude,
            this.collatitude,
            this.colsafudzveli_id,
            this.colmizani_id,
            this.collenMins,
            this.colforCompany_id,
            this.colcountchannels,
            this.colcountFM,
            this.colcountTV,
            this.colcountStations,
            this.colcomments,
            this.coltrip_id});
            this.monitoringView.GridControl = this.monitoringGridControl;
            this.monitoringView.Name = "monitoringView";
            this.monitoringView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.monitoringView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded;
            this.monitoringView.OptionsDetail.ShowEmbeddedDetailIndent = DevExpress.Utils.DefaultBoolean.True;
            this.monitoringView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.monitoringView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.monitoringView_RowUpdated);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            // 
            // coltarigi
            // 
            this.coltarigi.FieldName = "tarigi";
            this.coltarigi.Name = "coltarigi";
            this.coltarigi.Visible = true;
            this.coltarigi.VisibleIndex = 1;
            // 
            // colcity
            // 
            this.colcity.FieldName = "city";
            this.colcity.Name = "colcity";
            this.colcity.Visible = true;
            this.colcity.VisibleIndex = 2;
            // 
            // colregion
            // 
            this.colregion.FieldName = "region";
            this.colregion.Name = "colregion";
            this.colregion.Visible = true;
            this.colregion.VisibleIndex = 3;
            // 
            // collongitude
            // 
            this.collongitude.FieldName = "longitude";
            this.collongitude.Name = "collongitude";
            this.collongitude.Visible = true;
            this.collongitude.VisibleIndex = 4;
            // 
            // collatitude
            // 
            this.collatitude.FieldName = "latitude";
            this.collatitude.Name = "collatitude";
            this.collatitude.Visible = true;
            this.collatitude.VisibleIndex = 5;
            // 
            // colsafudzveli_id
            // 
            this.colsafudzveli_id.FieldName = "safudzveli_id";
            this.colsafudzveli_id.Name = "colsafudzveli_id";
            this.colsafudzveli_id.Visible = true;
            this.colsafudzveli_id.VisibleIndex = 6;
            // 
            // colmizani_id
            // 
            this.colmizani_id.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colmizani_id.FieldName = "mizani_id";
            this.colmizani_id.Name = "colmizani_id";
            this.colmizani_id.Visible = true;
            this.colmizani_id.VisibleIndex = 7;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.mn_COMBO_MizaniBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Name";
            this.repositoryItemLookUpEdit1.KeyMember = "id";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "-";
            this.repositoryItemLookUpEdit1.NullValuePrompt = "-";
            this.repositoryItemLookUpEdit1.ValueMember = "id";
            // 
            // mn_COMBO_MizaniBindingSource
            // 
            this.mn_COMBO_MizaniBindingSource.DataMember = "mn_COMBO_Mizani";
            this.mn_COMBO_MizaniBindingSource.DataSource = this.officeDataSet;
            // 
            // collenMins
            // 
            this.collenMins.FieldName = "lenMins";
            this.collenMins.Name = "collenMins";
            this.collenMins.Visible = true;
            this.collenMins.VisibleIndex = 8;
            // 
            // colforCompany_id
            // 
            this.colforCompany_id.FieldName = "forCompany_id";
            this.colforCompany_id.Name = "colforCompany_id";
            this.colforCompany_id.Visible = true;
            this.colforCompany_id.VisibleIndex = 9;
            // 
            // colcountchannels
            // 
            this.colcountchannels.FieldName = "countchannels";
            this.colcountchannels.Name = "colcountchannels";
            this.colcountchannels.Visible = true;
            this.colcountchannels.VisibleIndex = 10;
            // 
            // colcountFM
            // 
            this.colcountFM.FieldName = "countFM";
            this.colcountFM.Name = "colcountFM";
            this.colcountFM.Visible = true;
            this.colcountFM.VisibleIndex = 11;
            // 
            // colcountTV
            // 
            this.colcountTV.FieldName = "countTV";
            this.colcountTV.Name = "colcountTV";
            this.colcountTV.Visible = true;
            this.colcountTV.VisibleIndex = 12;
            // 
            // colcountStations
            // 
            this.colcountStations.FieldName = "countStations";
            this.colcountStations.Name = "colcountStations";
            this.colcountStations.Visible = true;
            this.colcountStations.VisibleIndex = 13;
            // 
            // colcomments
            // 
            this.colcomments.FieldName = "comments";
            this.colcomments.Name = "colcomments";
            this.colcomments.Visible = true;
            this.colcomments.VisibleIndex = 14;
            // 
            // coltrip_id
            // 
            this.coltrip_id.FieldName = "trip_id";
            this.coltrip_id.Name = "coltrip_id";
            this.coltrip_id.Visible = true;
            this.coltrip_id.VisibleIndex = 15;
            // 
            // mn_MonitoringTableAdapter
            // 
            this.mn_MonitoringTableAdapter.ClearBeforeFill = true;
            // 
            // mn_COMBO_MizaniTableAdapter
            // 
            this.mn_COMBO_MizaniTableAdapter.ClearBeforeFill = true;
            // 
            // mn_ViolationTableAdapter
            // 
            this.mn_ViolationTableAdapter.ClearBeforeFill = true;
            // 
            // sidePanel1
            // 
            this.sidePanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel1.Location = new System.Drawing.Point(0, 0);
            this.sidePanel1.Name = "sidePanel1";
            this.sidePanel1.Size = new System.Drawing.Size(165, 372);
            this.sidePanel1.TabIndex = 1;
            this.sidePanel1.Text = "sidePanel1";
            // 
            // frmMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 372);
            this.Controls.Add(this.monitoringGridControl);
            this.Controls.Add(this.sidePanel1);
            this.Name = "frmMonitoring";
            this.Text = "frmMonitoring";
            ((System.ComponentModel.ISupportInitialize)(this.violationView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mn_MonitoringBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operatorView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monitoringView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mn_COMBO_MizaniBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Helpers.MyGridControl monitoringGridControl;
        private Helpers.MyGridView monitoringView;
        private System.Windows.Forms.BindingSource mn_MonitoringBindingSource;
        private DataBase.OfficeDataSet officeDataSet;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn coltarigi;
        private DevExpress.XtraGrid.Columns.GridColumn colcity;
        private DevExpress.XtraGrid.Columns.GridColumn colregion;
        private DevExpress.XtraGrid.Columns.GridColumn collongitude;
        private DevExpress.XtraGrid.Columns.GridColumn collatitude;
        private DevExpress.XtraGrid.Columns.GridColumn colsafudzveli_id;
        private DevExpress.XtraGrid.Columns.GridColumn colmizani_id;
        private DevExpress.XtraGrid.Columns.GridColumn collenMins;
        private DevExpress.XtraGrid.Columns.GridColumn colforCompany_id;
        private DevExpress.XtraGrid.Columns.GridColumn colcountchannels;
        private DevExpress.XtraGrid.Columns.GridColumn colcountFM;
        private DevExpress.XtraGrid.Columns.GridColumn colcountTV;
        private DevExpress.XtraGrid.Columns.GridColumn colcountStations;
        private DevExpress.XtraGrid.Columns.GridColumn colcomments;
        private DevExpress.XtraGrid.Columns.GridColumn coltrip_id;
        private DataBase.OfficeDataSetTableAdapters.mn_MonitoringTableAdapter mn_MonitoringTableAdapter;
        private System.Windows.Forms.BindingSource mn_COMBO_MizaniBindingSource;
        private DataBase.OfficeDataSetTableAdapters.mn_COMBO_MizaniTableAdapter mn_COMBO_MizaniTableAdapter;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DataBase.OfficeDataSetTableAdapters.mn_ViolationTableAdapter mn_ViolationTableAdapter;
        private DevExpress.XtraGrid.Views.Grid.GridView violationView;
        private DevExpress.XtraGrid.Views.Grid.GridView operatorView;
        private DevExpress.XtraEditors.SidePanel sidePanel1;
    }
}