namespace Fams
{
    partial class frmStationsPasswords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStationsPasswords));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer1 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1 = new DevExpress.XtraMap.ImageTilesLayer();
            DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            this.coldasajarimebeli = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.stationsExportBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuTV = new DevExpress.XtraBars.PopupMenu(this.components);
            this.exportByCitiesItem = new DevExpress.XtraBars.BarButtonItem();
            this.exportByChannelsItem = new DevExpress.XtraBars.BarButtonItem();
            this.exportByCompsItem = new DevExpress.XtraBars.BarButtonItem();
            this.exportAllTVItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenuFM = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ExportFmByCities = new DevExpress.XtraBars.BarButtonItem();
            this.ExportFmByFreqs = new DevExpress.XtraBars.BarButtonItem();
            this.ExportFmByComps = new DevExpress.XtraBars.BarButtonItem();
            this.ExportAllFmByFreqs = new DevExpress.XtraBars.BarButtonItem();
            this.relExportBtn = new DevExpress.XtraBars.BarButtonItem();
            this.printPasswordBtn = new DevExpress.XtraBars.BarButtonItem();
            this.newPasswordBtn = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.printPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComp_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshekvanili_st = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgasuliDge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.paroliani_da_uparolo_kompaniebiTableAdapter = new DataBase.OfficeDataSetTableAdapters.paroliani_da_uparolo_kompaniebiTableAdapter();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.mapControl = new DevExpress.XtraMap.MapControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuTV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).BeginInit();
            this.SuspendLayout();
            // 
            // coldasajarimebeli
            // 
            this.coldasajarimebeli.FieldName = "dasajarimebeli";
            this.coldasajarimebeli.Name = "coldasajarimebeli";
            this.coldasajarimebeli.OptionsColumn.ReadOnly = true;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.stationsExportBtn,
            this.barButtonItem3,
            this.barButtonItem2,
            this.relExportBtn,
            this.exportByCitiesItem,
            this.exportByChannelsItem,
            this.exportByCompsItem,
            this.exportAllTVItem,
            this.ExportFmByCities,
            this.ExportFmByFreqs,
            this.ExportFmByComps,
            this.ExportAllFmByFreqs,
            this.printPasswordBtn,
            this.newPasswordBtn,
            this.barButtonItem4});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(830, 144);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // stationsExportBtn
            // 
            this.stationsExportBtn.Caption = "სადგურები";
            this.stationsExportBtn.Glyph = global::Fams.Properties.Resources.transmitter;
            this.stationsExportBtn.Id = 1;
            this.stationsExportBtn.Name = "stationsExportBtn";
            this.stationsExportBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.stationsExportBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.stationsExportBtn_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.ActAsDropDown = true;
            this.barButtonItem3.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem3.Caption = "TV";
            this.barButtonItem3.DropDownControl = this.popupMenuTV;
            this.barButtonItem3.Glyph = global::Fams.Properties.Resources.tv;
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // popupMenuTV
            // 
            this.popupMenuTV.ItemLinks.Add(this.exportByCitiesItem);
            this.popupMenuTV.ItemLinks.Add(this.exportByChannelsItem);
            this.popupMenuTV.ItemLinks.Add(this.exportByCompsItem);
            this.popupMenuTV.ItemLinks.Add(this.exportAllTVItem);
            this.popupMenuTV.Name = "popupMenuTV";
            this.popupMenuTV.Ribbon = this.ribbonControl1;
            // 
            // exportByCitiesItem
            // 
            this.exportByCitiesItem.Caption = "exportByCitiesItem";
            this.exportByCitiesItem.Id = 1;
            this.exportByCitiesItem.Name = "exportByCitiesItem";
            this.exportByCitiesItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportByCitiesItem_ItemClick);
            // 
            // exportByChannelsItem
            // 
            this.exportByChannelsItem.Caption = "exportByChannelsItem";
            this.exportByChannelsItem.Id = 2;
            this.exportByChannelsItem.Name = "exportByChannelsItem";
            this.exportByChannelsItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportByChannelsItem_ItemClick);
            // 
            // exportByCompsItem
            // 
            this.exportByCompsItem.Caption = "exportByCompsItem";
            this.exportByCompsItem.Id = 3;
            this.exportByCompsItem.Name = "exportByCompsItem";
            this.exportByCompsItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportByCompsItem_ItemClick);
            // 
            // exportAllTVItem
            // 
            this.exportAllTVItem.Caption = "exportAllTVItem";
            this.exportAllTVItem.Id = 4;
            this.exportAllTVItem.Name = "exportAllTVItem";
            this.exportAllTVItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportAllTVItem_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.ActAsDropDown = true;
            this.barButtonItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem2.Caption = "FM";
            this.barButtonItem2.DropDownControl = this.popupMenuFM;
            this.barButtonItem2.Glyph = global::Fams.Properties.Resources.fm;
            this.barButtonItem2.Id = 4;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // popupMenuFM
            // 
            this.popupMenuFM.ItemLinks.Add(this.ExportFmByCities);
            this.popupMenuFM.ItemLinks.Add(this.ExportFmByFreqs);
            this.popupMenuFM.ItemLinks.Add(this.ExportFmByComps);
            this.popupMenuFM.ItemLinks.Add(this.ExportAllFmByFreqs);
            this.popupMenuFM.Name = "popupMenuFM";
            this.popupMenuFM.Ribbon = this.ribbonControl1;
            // 
            // ExportFmByCities
            // 
            this.ExportFmByCities.Caption = "ქალაქებით (Cities)";
            this.ExportFmByCities.Id = 5;
            this.ExportFmByCities.Name = "ExportFmByCities";
            this.ExportFmByCities.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportFmByCities_ItemClick);
            // 
            // ExportFmByFreqs
            // 
            this.ExportFmByFreqs.Caption = "სიხშირეებით (Freqs)";
            this.ExportFmByFreqs.Id = 6;
            this.ExportFmByFreqs.Name = "ExportFmByFreqs";
            this.ExportFmByFreqs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportFmByFreqs_ItemClick);
            // 
            // ExportFmByComps
            // 
            this.ExportFmByComps.Caption = "კომპანიებით (Comps)";
            this.ExportFmByComps.Id = 7;
            this.ExportFmByComps.Name = "ExportFmByComps";
            this.ExportFmByComps.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportFmByComps_ItemClick);
            // 
            // ExportAllFmByFreqs
            // 
            this.ExportAllFmByFreqs.Caption = "ყველა (AllFmByFreqs)";
            this.ExportAllFmByFreqs.Id = 8;
            this.ExportAllFmByFreqs.Name = "ExportAllFmByFreqs";
            this.ExportAllFmByFreqs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportAllFmByFreqs_ItemClick);
            // 
            // relExportBtn
            // 
            this.relExportBtn.Caption = "სარელეო სადგურები";
            this.relExportBtn.Glyph = global::Fams.Properties.Resources.relfixed_flip;
            this.relExportBtn.Id = 5;
            this.relExportBtn.Name = "relExportBtn";
            this.relExportBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.relExportBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.relExportBtn_ItemClick);
            // 
            // printPasswordBtn
            // 
            this.printPasswordBtn.Caption = "ამობეჭდვა";
            this.printPasswordBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("printPasswordBtn.Glyph")));
            this.printPasswordBtn.Id = 9;
            this.printPasswordBtn.Name = "printPasswordBtn";
            this.printPasswordBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.printPasswordBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.printPasswordBtn_ItemClick);
            // 
            // newPasswordBtn
            // 
            this.newPasswordBtn.Caption = "ახალი";
            this.newPasswordBtn.Glyph = ((System.Drawing.Image)(resources.GetObject("newPasswordBtn.Glyph")));
            this.newPasswordBtn.Id = 10;
            this.newPasswordBtn.Name = "newPasswordBtn";
            this.newPasswordBtn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.newPasswordBtn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.newPasswordBtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 11;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.printPageGroup});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "მენიუ";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.stationsExportBtn);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.relExportBtn);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ექსპორტი";
            // 
            // printPageGroup
            // 
            this.printPageGroup.ItemLinks.Add(this.newPasswordBtn);
            this.printPageGroup.ItemLinks.Add(this.printPasswordBtn);
            this.printPageGroup.Name = "printPageGroup";
            this.printPageGroup.Text = "პაროლი";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 477);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(830, 31);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Google Earth (*.kml)|*.kml";
            // 
            // gridControl
            // 
            this.gridControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl.DataMember = "paroliani da uparolo kompaniebi";
            this.gridControl.DataSource = this.officeDataSet;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.gridControl.MainView = this.gridView1;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(330, 333);
            this.gridControl.TabIndex = 6;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colComp_Name,
            this.colshekvanili_st,
            this.colgasuliDge,
            this.colUserName,
            this.colPassword,
            this.coldasajarimebeli});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.coldasajarimebeli;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "1";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.coldasajarimebeli;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "99";
            this.gridView1.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindDelay = 500;
            this.gridView1.OptionsFind.FindNullPrompt = "ძებნა...";
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem;
            this.gridView1.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colComp_Name
            // 
            this.colComp_Name.Caption = "ორგანიზაცია";
            this.colComp_Name.FieldName = "Comp_Name";
            this.colComp_Name.Name = "colComp_Name";
            this.colComp_Name.Visible = true;
            this.colComp_Name.VisibleIndex = 0;
            this.colComp_Name.Width = 644;
            // 
            // colshekvanili_st
            // 
            this.colshekvanili_st.Caption = "სადგურები";
            this.colshekvanili_st.FieldName = "shekvanili_st";
            this.colshekvanili_st.Name = "colshekvanili_st";
            this.colshekvanili_st.Visible = true;
            this.colshekvanili_st.VisibleIndex = 1;
            this.colshekvanili_st.Width = 180;
            // 
            // colgasuliDge
            // 
            this.colgasuliDge.Caption = "დღე";
            this.colgasuliDge.FieldName = "gasuliDge";
            this.colgasuliDge.Name = "colgasuliDge";
            this.colgasuliDge.Visible = true;
            this.colgasuliDge.VisibleIndex = 2;
            this.colgasuliDge.Width = 168;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            // 
            // colPassword
            // 
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            // 
            // paroliani_da_uparolo_kompaniebiTableAdapter
            // 
            this.paroliani_da_uparolo_kompaniebiTableAdapter.ClearBeforeFill = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 144);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.mapControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(830, 333);
            this.splitContainerControl1.SplitterPosition = 330;
            this.splitContainerControl1.TabIndex = 12;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // mapControl
            // 
            this.mapControl.CenterPoint = new DevExpress.XtraMap.GeoPoint(42D, 44D);
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            bingMapDataProvider1.BingKey = "AgWy_ZToY57N22I29FjpEc4mWNd9YSaQ103z_KXDPfWikjNULtr1ZroEl0U0RafQ";
            imageTilesLayer1.DataProvider = bingMapDataProvider1;
            this.mapControl.Layers.Add(vectorItemsLayer1);
            this.mapControl.Layers.Add(imageTilesLayer1);
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.MinZoomLevel = 3D;
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(495, 333);
            this.mapControl.TabIndex = 0;
            this.mapControl.ZoomLevel = 8D;
            // 
            // frmStationsPasswords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 508);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "frmStationsPasswords";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "აღრიცხული სადგურები";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuTV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem stationsExportBtn;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenuTV;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.PopupMenu popupMenuFM;
        private DevExpress.XtraBars.BarButtonItem relExportBtn;
        private DevExpress.XtraBars.BarButtonItem exportByCitiesItem;
        private DevExpress.XtraBars.BarButtonItem exportByChannelsItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DevExpress.XtraBars.BarButtonItem exportByCompsItem;
        private DevExpress.XtraBars.BarButtonItem exportAllTVItem;
        private DevExpress.XtraBars.BarButtonItem ExportFmByCities;
        private DevExpress.XtraBars.BarButtonItem ExportFmByFreqs;
        private DevExpress.XtraBars.BarButtonItem ExportFmByComps;
        private DevExpress.XtraBars.BarButtonItem ExportAllFmByFreqs;
        private DevExpress.XtraBars.BarButtonItem printPasswordBtn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup printPageGroup;
        private DevExpress.XtraBars.BarButtonItem newPasswordBtn;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DataBase.OfficeDataSet officeDataSet;
        private DataBase.OfficeDataSetTableAdapters.paroliani_da_uparolo_kompaniebiTableAdapter paroliani_da_uparolo_kompaniebiTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colComp_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colshekvanili_st;
        private DevExpress.XtraGrid.Columns.GridColumn colgasuliDge;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn coldasajarimebeli;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraMap.MapControl mapControl;



    }
}