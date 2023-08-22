namespace Fams
{
    partial class frmAdministrator
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
            this.permissionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.privilegiesDataSet = new DataBase.PrivilegiesDataSet();
            this.cardView = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditFreqs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleteFreqs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditLicence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeleteLicence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditComp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDelComp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditFreqLic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditFreqComp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReestritCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddFreq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfidential = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreqGraph = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNebartva = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdminStationsAdd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdminStationsEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdminStationsDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.permissionsTableAdapter = new DataBase.PrivilegiesDataSetTableAdapters.PermissionsTableAdapter();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.usersGridControl = new DevExpress.XtraGrid.GridControl();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.usersTableAdapter = new DataBase.PrivilegiesDataSetTableAdapters.UsersTableAdapter();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.privilegiesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.permissionsBindingSource;
            this.gridControl.Location = new System.Drawing.Point(12, 40);
            this.gridControl.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.cardView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(641, 337);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView});
            // 
            // permissionsBindingSource
            // 
            this.permissionsBindingSource.DataMember = "Permissions";
            this.permissionsBindingSource.DataSource = this.privilegiesDataSet;
            this.permissionsBindingSource.Sort = "";
            // 
            // privilegiesDataSet
            // 
            this.privilegiesDataSet.DataSetName = "PrivilegiesDataSet";
            this.privilegiesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cardView
            // 
            this.cardView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTypeID,
            this.colEditFreqs,
            this.colDeleteFreqs,
            this.colEditLicence,
            this.colDeleteLicence,
            this.colEditComp,
            this.colDelComp,
            this.colEditFreqLic,
            this.colEditFreqComp,
            this.colReestritCheck,
            this.colAddFreq,
            this.colConfidential,
            this.colFreqGraph,
            this.colNebartva,
            this.colAdminStationsAdd,
            this.colAdminStationsEdit,
            this.colAdminStationsDelete});
            this.cardView.FocusedCardTopFieldIndex = 0;
            this.cardView.GridControl = this.gridControl;
            this.cardView.Name = "cardView";
            this.cardView.OptionsBehavior.ReadOnly = true;
            this.cardView.OptionsView.ShowQuickCustomizeButton = false;
            this.cardView.CustomDrawCardCaption += new DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventHandler(this.cardView_CustomDrawCardCaption);
            // 
            // colTypeID
            // 
            this.colTypeID.FieldName = "TypeID";
            this.colTypeID.Name = "colTypeID";
            this.colTypeID.Width = 106;
            // 
            // colEditFreqs
            // 
            this.colEditFreqs.FieldName = "EditFreqs";
            this.colEditFreqs.Name = "colEditFreqs";
            this.colEditFreqs.Visible = true;
            this.colEditFreqs.VisibleIndex = 0;
            this.colEditFreqs.Width = 43;
            // 
            // colDeleteFreqs
            // 
            this.colDeleteFreqs.FieldName = "DeleteFreqs";
            this.colDeleteFreqs.Name = "colDeleteFreqs";
            this.colDeleteFreqs.Visible = true;
            this.colDeleteFreqs.VisibleIndex = 1;
            this.colDeleteFreqs.Width = 43;
            // 
            // colEditLicence
            // 
            this.colEditLicence.FieldName = "EditLicence";
            this.colEditLicence.Name = "colEditLicence";
            this.colEditLicence.Visible = true;
            this.colEditLicence.VisibleIndex = 2;
            this.colEditLicence.Width = 43;
            // 
            // colDeleteLicence
            // 
            this.colDeleteLicence.FieldName = "DeleteLicence";
            this.colDeleteLicence.Name = "colDeleteLicence";
            this.colDeleteLicence.Visible = true;
            this.colDeleteLicence.VisibleIndex = 3;
            this.colDeleteLicence.Width = 43;
            // 
            // colEditComp
            // 
            this.colEditComp.FieldName = "EditComp";
            this.colEditComp.Name = "colEditComp";
            this.colEditComp.Visible = true;
            this.colEditComp.VisibleIndex = 4;
            this.colEditComp.Width = 43;
            // 
            // colDelComp
            // 
            this.colDelComp.FieldName = "DelComp";
            this.colDelComp.Name = "colDelComp";
            this.colDelComp.Visible = true;
            this.colDelComp.VisibleIndex = 5;
            this.colDelComp.Width = 43;
            // 
            // colEditFreqLic
            // 
            this.colEditFreqLic.FieldName = "EditFreqLic";
            this.colEditFreqLic.Name = "colEditFreqLic";
            this.colEditFreqLic.Visible = true;
            this.colEditFreqLic.VisibleIndex = 6;
            this.colEditFreqLic.Width = 43;
            // 
            // colEditFreqComp
            // 
            this.colEditFreqComp.FieldName = "EditFreqComp";
            this.colEditFreqComp.Name = "colEditFreqComp";
            this.colEditFreqComp.Visible = true;
            this.colEditFreqComp.VisibleIndex = 7;
            this.colEditFreqComp.Width = 43;
            // 
            // colReestritCheck
            // 
            this.colReestritCheck.FieldName = "ReestritCheck";
            this.colReestritCheck.Name = "colReestritCheck";
            this.colReestritCheck.Visible = true;
            this.colReestritCheck.VisibleIndex = 8;
            this.colReestritCheck.Width = 43;
            // 
            // colAddFreq
            // 
            this.colAddFreq.FieldName = "AddFreq";
            this.colAddFreq.Name = "colAddFreq";
            this.colAddFreq.Visible = true;
            this.colAddFreq.VisibleIndex = 9;
            this.colAddFreq.Width = 43;
            // 
            // colConfidential
            // 
            this.colConfidential.FieldName = "Confidential";
            this.colConfidential.Name = "colConfidential";
            this.colConfidential.Visible = true;
            this.colConfidential.VisibleIndex = 10;
            this.colConfidential.Width = 43;
            // 
            // colFreqGraph
            // 
            this.colFreqGraph.FieldName = "FreqGraph";
            this.colFreqGraph.Name = "colFreqGraph";
            this.colFreqGraph.Visible = true;
            this.colFreqGraph.VisibleIndex = 11;
            this.colFreqGraph.Width = 43;
            // 
            // colNebartva
            // 
            this.colNebartva.FieldName = "Nebartva";
            this.colNebartva.Name = "colNebartva";
            this.colNebartva.Visible = true;
            this.colNebartva.VisibleIndex = 12;
            this.colNebartva.Width = 43;
            // 
            // colAdminStationsAdd
            // 
            this.colAdminStationsAdd.FieldName = "AdminStationsAdd";
            this.colAdminStationsAdd.Name = "colAdminStationsAdd";
            this.colAdminStationsAdd.Visible = true;
            this.colAdminStationsAdd.VisibleIndex = 13;
            this.colAdminStationsAdd.Width = 43;
            // 
            // colAdminStationsEdit
            // 
            this.colAdminStationsEdit.FieldName = "AdminStationsEdit";
            this.colAdminStationsEdit.Name = "colAdminStationsEdit";
            this.colAdminStationsEdit.Visible = true;
            this.colAdminStationsEdit.VisibleIndex = 14;
            this.colAdminStationsEdit.Width = 43;
            // 
            // colAdminStationsDelete
            // 
            this.colAdminStationsDelete.FieldName = "AdminStationsDelete";
            this.colAdminStationsDelete.Name = "colAdminStationsDelete";
            this.colAdminStationsDelete.Visible = true;
            this.colAdminStationsDelete.VisibleIndex = 15;
            this.colAdminStationsDelete.Width = 48;
            // 
            // permissionsTableAdapter
            // 
            this.permissionsTableAdapter.ClearBeforeFill = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelControl1.Location = new System.Drawing.Point(12, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 25);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Roles";
            // 
            // usersGridControl
            // 
            this.usersGridControl.DataSource = this.usersBindingSource;
            this.usersGridControl.Location = new System.Drawing.Point(136, 400);
            this.usersGridControl.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.usersGridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.usersGridControl.MainView = this.gridView;
            this.usersGridControl.Name = "usersGridControl";
            this.usersGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1});
            this.usersGridControl.Size = new System.Drawing.Size(517, 171);
            this.usersGridControl.TabIndex = 2;
            this.usersGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.privilegiesDataSet;
            this.usersBindingSource.Sort = "";
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colTypeID1,
            this.colPassword});
            this.gridView.GridControl = this.usersGridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_RowUpdated);
            this.gridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView_KeyDown);
            // 
            // colUserName
            // 
            this.colUserName.Caption = "მომხმარებელი";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            this.colUserName.Width = 532;
            // 
            // colTypeID1
            // 
            this.colTypeID1.Caption = "როლი";
            this.colTypeID1.FieldName = "TypeID";
            this.colTypeID1.Name = "colTypeID1";
            this.colTypeID1.Visible = true;
            this.colTypeID1.VisibleIndex = 2;
            this.colTypeID1.Width = 232;
            // 
            // colPassword
            // 
            this.colPassword.Caption = "პაროლი";
            this.colPassword.ColumnEdit = this.repositoryItemTextEdit1;
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.Visible = true;
            this.colPassword.VisibleIndex = 1;
            this.colPassword.Width = 228;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.UseSystemPasswordChar = true;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelControl2.Location = new System.Drawing.Point(12, 400);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 25);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Users";
            // 
            // frmAdministrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(670, 583);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.usersGridControl);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl);
            this.Name = "frmAdministrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ადმინისტრირება";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.privilegiesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private System.Windows.Forms.BindingSource permissionsBindingSource;
        private DataBase.PrivilegiesDataSet privilegiesDataSet;
        private DataBase.PrivilegiesDataSetTableAdapters.PermissionsTableAdapter permissionsTableAdapter;
        private DevExpress.XtraGrid.Views.Card.CardView cardView;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEditFreqs;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteFreqs;
        private DevExpress.XtraGrid.Columns.GridColumn colEditLicence;
        private DevExpress.XtraGrid.Columns.GridColumn colDeleteLicence;
        private DevExpress.XtraGrid.Columns.GridColumn colEditComp;
        private DevExpress.XtraGrid.Columns.GridColumn colDelComp;
        private DevExpress.XtraGrid.Columns.GridColumn colEditFreqLic;
        private DevExpress.XtraGrid.Columns.GridColumn colEditFreqComp;
        private DevExpress.XtraGrid.Columns.GridColumn colReestritCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colAddFreq;
        private DevExpress.XtraGrid.Columns.GridColumn colConfidential;
        private DevExpress.XtraGrid.Columns.GridColumn colFreqGraph;
        private DevExpress.XtraGrid.Columns.GridColumn colNebartva;
        private DevExpress.XtraGrid.Columns.GridColumn colAdminStationsAdd;
        private DevExpress.XtraGrid.Columns.GridColumn colAdminStationsEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colAdminStationsDelete;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl usersGridControl;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeID1;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DataBase.PrivilegiesDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}