namespace Fams
{
    partial class frmCalcResults
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
            this.gridControl = new Helpers.MyGridControl();
            this.gridView = new Helpers.MyGridView();
            this.stationColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.powerColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.regionColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KgColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.priceColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bwthColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.freqColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PfColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KqColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KpColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.KsColumn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColumnP15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.printButton = new System.Windows.Forms.Button();
            this.mobCheckBox = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.gridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(838, 325);
            this.gridControl.TabIndex = 0;
            this.gridControl.ToolTipController = this.toolTipController1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.stationColumn,
            this.powerColumn,
            this.regionColumn,
            this.KgColumn,
            this.priceColumn,
            this.bwthColumn,
            this.freqColumn,
            this.PfColumn,
            this.KqColumn,
            this.KpColumn,
            this.KsColumn,
            this.ColumnP1,
            this.ColumnP2,
            this.ColumnP3,
            this.ColumnP4,
            this.ColumnP5,
            this.ColumnP6,
            this.ColumnP7,
            this.ColumnP8,
            this.ColumnP9,
            this.ColumnP10,
            this.ColumnP11,
            this.ColumnP12,
            this.ColumnP13,
            this.ColumnP14,
            this.ColumnP15});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowFooter = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            // 
            // stationColumn
            // 
            this.stationColumn.Caption = "სადგური";
            this.stationColumn.FieldName = "station";
            this.stationColumn.MinWidth = 170;
            this.stationColumn.Name = "stationColumn";
            this.stationColumn.Visible = true;
            this.stationColumn.VisibleIndex = 0;
            this.stationColumn.Width = 170;
            // 
            // powerColumn
            // 
            this.powerColumn.Caption = "სიმძლავრე";
            this.powerColumn.FieldName = "power";
            this.powerColumn.MinWidth = 80;
            this.powerColumn.Name = "powerColumn";
            this.powerColumn.Visible = true;
            this.powerColumn.VisibleIndex = 4;
            this.powerColumn.Width = 80;
            // 
            // regionColumn
            // 
            this.regionColumn.Caption = "რეგიონი";
            this.regionColumn.FieldName = "region";
            this.regionColumn.MinWidth = 150;
            this.regionColumn.Name = "regionColumn";
            this.regionColumn.Visible = true;
            this.regionColumn.VisibleIndex = 1;
            this.regionColumn.Width = 150;
            // 
            // KgColumn
            // 
            this.KgColumn.Caption = "Kg";
            this.KgColumn.FieldName = "Kg";
            this.KgColumn.MaxWidth = 35;
            this.KgColumn.MinWidth = 35;
            this.KgColumn.Name = "KgColumn";
            this.KgColumn.Visible = true;
            this.KgColumn.VisibleIndex = 5;
            this.KgColumn.Width = 35;
            // 
            // priceColumn
            // 
            this.priceColumn.Caption = "ფასი";
            this.priceColumn.FieldName = "price";
            this.priceColumn.MinWidth = 90;
            this.priceColumn.Name = "priceColumn";
            this.priceColumn.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "price", "{0:0.##}")});
            this.priceColumn.Visible = true;
            this.priceColumn.VisibleIndex = 10;
            this.priceColumn.Width = 90;
            // 
            // bwthColumn
            // 
            this.bwthColumn.Caption = "ზოლი";
            this.bwthColumn.FieldName = "bandwidth";
            this.bwthColumn.MinWidth = 80;
            this.bwthColumn.Name = "bwthColumn";
            this.bwthColumn.Visible = true;
            this.bwthColumn.VisibleIndex = 3;
            this.bwthColumn.Width = 80;
            // 
            // freqColumn
            // 
            this.freqColumn.Caption = "სიხშირე";
            this.freqColumn.FieldName = "frequency";
            this.freqColumn.MinWidth = 100;
            this.freqColumn.Name = "freqColumn";
            this.freqColumn.Visible = true;
            this.freqColumn.VisibleIndex = 2;
            this.freqColumn.Width = 100;
            // 
            // PfColumn
            // 
            this.PfColumn.Caption = "Pf";
            this.PfColumn.FieldName = "Pf";
            this.PfColumn.MaxWidth = 50;
            this.PfColumn.MinWidth = 50;
            this.PfColumn.Name = "PfColumn";
            this.PfColumn.Visible = true;
            this.PfColumn.VisibleIndex = 6;
            this.PfColumn.Width = 50;
            // 
            // KqColumn
            // 
            this.KqColumn.Caption = "Kq";
            this.KqColumn.FieldName = "Kq";
            this.KqColumn.MaxWidth = 35;
            this.KqColumn.MinWidth = 35;
            this.KqColumn.Name = "KqColumn";
            this.KqColumn.Visible = true;
            this.KqColumn.VisibleIndex = 7;
            this.KqColumn.Width = 35;
            // 
            // KpColumn
            // 
            this.KpColumn.Caption = "Kp";
            this.KpColumn.FieldName = "Kp";
            this.KpColumn.MaxWidth = 35;
            this.KpColumn.MinWidth = 35;
            this.KpColumn.Name = "KpColumn";
            this.KpColumn.Visible = true;
            this.KpColumn.VisibleIndex = 8;
            this.KpColumn.Width = 35;
            // 
            // KsColumn
            // 
            this.KsColumn.Caption = "Ks";
            this.KsColumn.FieldName = "Ks";
            this.KsColumn.MaxWidth = 35;
            this.KsColumn.MinWidth = 35;
            this.KsColumn.Name = "KsColumn";
            this.KsColumn.Visible = true;
            this.KsColumn.VisibleIndex = 9;
            this.KsColumn.Width = 35;
            // 
            // ColumnP1
            // 
            this.ColumnP1.Caption = "1st";
            this.ColumnP1.FieldName = "p1";
            this.ColumnP1.MinWidth = 65;
            this.ColumnP1.Name = "ColumnP1";
            this.ColumnP1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p1", "{0:0.##}")});
            this.ColumnP1.Visible = true;
            this.ColumnP1.VisibleIndex = 11;
            this.ColumnP1.Width = 104;
            // 
            // ColumnP2
            // 
            this.ColumnP2.Caption = "2nd";
            this.ColumnP2.FieldName = "p2";
            this.ColumnP2.MinWidth = 65;
            this.ColumnP2.Name = "ColumnP2";
            this.ColumnP2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p2", "{0:0.##}")});
            this.ColumnP2.Visible = true;
            this.ColumnP2.VisibleIndex = 12;
            this.ColumnP2.Width = 65;
            // 
            // ColumnP3
            // 
            this.ColumnP3.Caption = "3rd";
            this.ColumnP3.FieldName = "p3";
            this.ColumnP3.MinWidth = 65;
            this.ColumnP3.Name = "ColumnP3";
            this.ColumnP3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p3", "{0:0.##}")});
            this.ColumnP3.Visible = true;
            this.ColumnP3.VisibleIndex = 13;
            this.ColumnP3.Width = 65;
            // 
            // ColumnP4
            // 
            this.ColumnP4.Caption = "4th";
            this.ColumnP4.FieldName = "p4";
            this.ColumnP4.MinWidth = 65;
            this.ColumnP4.Name = "ColumnP4";
            this.ColumnP4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p4", "{0:0.##}")});
            this.ColumnP4.Visible = true;
            this.ColumnP4.VisibleIndex = 14;
            this.ColumnP4.Width = 65;
            // 
            // ColumnP5
            // 
            this.ColumnP5.Caption = "5th";
            this.ColumnP5.FieldName = "p5";
            this.ColumnP5.MinWidth = 65;
            this.ColumnP5.Name = "ColumnP5";
            this.ColumnP5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p5", "{0:0.##}")});
            this.ColumnP5.Visible = true;
            this.ColumnP5.VisibleIndex = 15;
            this.ColumnP5.Width = 65;
            // 
            // ColumnP6
            // 
            this.ColumnP6.Caption = "6th";
            this.ColumnP6.FieldName = "p6";
            this.ColumnP6.MinWidth = 65;
            this.ColumnP6.Name = "ColumnP6";
            this.ColumnP6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p6", "{0:0.##}")});
            this.ColumnP6.Visible = true;
            this.ColumnP6.VisibleIndex = 16;
            this.ColumnP6.Width = 65;
            // 
            // ColumnP7
            // 
            this.ColumnP7.Caption = "7th";
            this.ColumnP7.FieldName = "p7";
            this.ColumnP7.MinWidth = 65;
            this.ColumnP7.Name = "ColumnP7";
            this.ColumnP7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p7", "{0:0.##}")});
            this.ColumnP7.Visible = true;
            this.ColumnP7.VisibleIndex = 17;
            this.ColumnP7.Width = 65;
            // 
            // ColumnP8
            // 
            this.ColumnP8.Caption = "8th";
            this.ColumnP8.FieldName = "p8";
            this.ColumnP8.MinWidth = 65;
            this.ColumnP8.Name = "ColumnP8";
            this.ColumnP8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p8", "{0:0.##}")});
            this.ColumnP8.Visible = true;
            this.ColumnP8.VisibleIndex = 18;
            this.ColumnP8.Width = 65;
            // 
            // ColumnP9
            // 
            this.ColumnP9.Caption = "9th";
            this.ColumnP9.FieldName = "p9";
            this.ColumnP9.MinWidth = 65;
            this.ColumnP9.Name = "ColumnP9";
            this.ColumnP9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p9", "{0:0.##}")});
            this.ColumnP9.Visible = true;
            this.ColumnP9.VisibleIndex = 19;
            this.ColumnP9.Width = 65;
            // 
            // ColumnP10
            // 
            this.ColumnP10.Caption = "10th";
            this.ColumnP10.FieldName = "p10";
            this.ColumnP10.MinWidth = 65;
            this.ColumnP10.Name = "ColumnP10";
            this.ColumnP10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p10", "{0:0.##}")});
            this.ColumnP10.Visible = true;
            this.ColumnP10.VisibleIndex = 20;
            this.ColumnP10.Width = 65;
            // 
            // ColumnP11
            // 
            this.ColumnP11.Caption = "11th";
            this.ColumnP11.FieldName = "p11";
            this.ColumnP11.MinWidth = 65;
            this.ColumnP11.Name = "ColumnP11";
            this.ColumnP11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p11", "{0:0.##}")});
            this.ColumnP11.Visible = true;
            this.ColumnP11.VisibleIndex = 21;
            this.ColumnP11.Width = 65;
            // 
            // ColumnP12
            // 
            this.ColumnP12.Caption = "12th";
            this.ColumnP12.FieldName = "p12";
            this.ColumnP12.MinWidth = 65;
            this.ColumnP12.Name = "ColumnP12";
            this.ColumnP12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p12", "{0:0.##}")});
            this.ColumnP12.Visible = true;
            this.ColumnP12.VisibleIndex = 22;
            this.ColumnP12.Width = 65;
            // 
            // ColumnP13
            // 
            this.ColumnP13.Caption = "13th";
            this.ColumnP13.FieldName = "p13";
            this.ColumnP13.MinWidth = 65;
            this.ColumnP13.Name = "ColumnP13";
            this.ColumnP13.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p13", "{0:0.##}")});
            this.ColumnP13.Visible = true;
            this.ColumnP13.VisibleIndex = 23;
            this.ColumnP13.Width = 65;
            // 
            // ColumnP14
            // 
            this.ColumnP14.Caption = "14th";
            this.ColumnP14.FieldName = "p14";
            this.ColumnP14.MinWidth = 65;
            this.ColumnP14.Name = "ColumnP14";
            this.ColumnP14.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p14", "{0:0.##}")});
            this.ColumnP14.Visible = true;
            this.ColumnP14.VisibleIndex = 24;
            this.ColumnP14.Width = 65;
            // 
            // ColumnP15
            // 
            this.ColumnP15.Caption = "15th";
            this.ColumnP15.FieldName = "p15";
            this.ColumnP15.MinWidth = 65;
            this.ColumnP15.Name = "ColumnP15";
            this.ColumnP15.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "p15", "{0:0.##}")});
            this.ColumnP15.Visible = true;
            this.ColumnP15.VisibleIndex = 25;
            this.ColumnP15.Width = 65;
            // 
            // toolTipController1
            // 
            this.toolTipController1.GetActiveObjectInfo += new DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventHandler(this.toolTipController1_GetActiveObjectInfo);
            // 
            // printButton
            // 
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printButton.Image = global::Fams.Properties.Resources.print;
            this.printButton.Location = new System.Drawing.Point(754, 334);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 42);
            this.printButton.TabIndex = 1;
            this.printButton.Text = "ბეჭდვა...";
            this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // mobCheckBox
            // 
            this.mobCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mobCheckBox.AutoSize = true;
            this.mobCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.mobCheckBox.Location = new System.Drawing.Point(312, 343);
            this.mobCheckBox.Name = "mobCheckBox";
            this.mobCheckBox.Size = new System.Drawing.Size(151, 24);
            this.mobCheckBox.TabIndex = 11;
            this.mobCheckBox.Text = "არასტაციონარული";
            this.mobCheckBox.UseVisualStyleBackColor = true;
            this.mobCheckBox.CheckedChanged += new System.EventHandler(this.mobCheckBox_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 345);
            this.dateTimePicker1.MaxDate = new System.DateTime(2038, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker1.TabIndex = 10;
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dateTimePicker1.DropDown += new System.EventHandler(this.dateTimePicker1_DropDown);
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(116, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "-დან";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(218, 347);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "წელი";
            // 
            // spinEdit1
            // 
            this.spinEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinEdit1.EditValue = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(173, 345);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Properties.IsFloatValue = false;
            this.spinEdit1.Properties.Mask.EditMask = "N00";
            this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit1.Size = new System.Drawing.Size(39, 20);
            this.spinEdit1.TabIndex = 7;
            this.spinEdit1.EditValueChanged += new System.EventHandler(this.spinEdit1_ValueChanged);
            // 
            // frmCalcResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(838, 385);
            this.Controls.Add(this.mobCheckBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.spinEdit1);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.gridControl);
            this.Name = "frmCalcResults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "კალკულაცია";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Helpers.MyGridControl gridControl;
        private Helpers.MyGridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn stationColumn;
        private DevExpress.XtraGrid.Columns.GridColumn powerColumn;
        private DevExpress.XtraGrid.Columns.GridColumn regionColumn;
        private DevExpress.XtraGrid.Columns.GridColumn KgColumn;
        private DevExpress.XtraGrid.Columns.GridColumn priceColumn;
        private DevExpress.XtraGrid.Columns.GridColumn bwthColumn;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.Columns.GridColumn freqColumn;
        private DevExpress.XtraGrid.Columns.GridColumn PfColumn;
        private DevExpress.XtraGrid.Columns.GridColumn KqColumn;
        private DevExpress.XtraGrid.Columns.GridColumn KpColumn;
        private DevExpress.XtraGrid.Columns.GridColumn KsColumn;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.CheckBox mobCheckBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP1;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP2;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP3;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP4;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP5;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP6;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP7;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP8;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP9;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP10;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP11;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP12;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP13;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP14;
        private DevExpress.XtraGrid.Columns.GridColumn ColumnP15;
    }
}