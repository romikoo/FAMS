namespace Fams
{
    partial class frmNotProlonged
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
            this.radTitleBar1 = new Telerik.WinControls.UI.RadTitleBar();
            this.roundRectShapeTitle = new Telerik.WinControls.RoundRectShape(this.components);
            this.myGridControl1 = new Helpers.MyGridControl();
            this.notProlongedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.myGridView1 = new Helpers.MyGridView();
            this.colComp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collicName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIssue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFREQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBandWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.notProlongedTableAdapter = new DataBase.OfficeDataSetTableAdapters.__notProlongedTableAdapter();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.printButton = new Telerik.WinControls.UI.RadButton();
            this.radTitleBar1.BeginInit();
            this.myGridControl1.BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.notProlongedBindingSource).BeginInit();
            this.officeDataSet.BeginInit();
            this.myGridView1.BeginInit();
            this.printButton.BeginInit();
            this.SuspendLayout();
            this.radTitleBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radTitleBar1.Location = new System.Drawing.Point(1, 1);
            this.radTitleBar1.Name = "radTitleBar1";
            this.radTitleBar1.RootElement.ApplyShapeToControl = true;
            this.radTitleBar1.RootElement.Shape = (Telerik.WinControls.ElementShape)this.roundRectShapeTitle;
            this.radTitleBar1.Size = new System.Drawing.Size(891, 23);
            this.radTitleBar1.TabIndex = 0;
            this.radTitleBar1.TabStop = false;
            this.radTitleBar1.Text = "არ გაგრძელებული სიხშირეები";
            this.radTitleBar1.ThemeName = "Office2013Dark";
            this.roundRectShapeTitle.BottomLeftRounded = false;
            this.roundRectShapeTitle.BottomRightRounded = false;
            this.myGridControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.myGridControl1.DataSource = (object)this.notProlongedBindingSource;
            this.myGridControl1.Font = new System.Drawing.Font("Sylfaen", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)204);
            this.myGridControl1.Location = new System.Drawing.Point(12, 64);
            this.myGridControl1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.myGridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.myGridControl1.MainView = (DevExpress.XtraGrid.Views.Base.BaseView)this.myGridView1;
            this.myGridControl1.Name = "myGridControl1";
            this.myGridControl1.Size = new System.Drawing.Size(869, 448);
            this.myGridControl1.TabIndex = 1;
            this.myGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[1]
      {
        (DevExpress.XtraGrid.Views.Base.BaseView) this.myGridView1
      });
            this.notProlongedBindingSource.DataMember = "__notProlonged";
            this.notProlongedBindingSource.DataSource = (object)this.officeDataSet;
            this.notProlongedBindingSource.Filter = "";
            this.notProlongedBindingSource.Sort = "";
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.myGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[7]
      {
        this.colComp,
        this.collicName,
        this.colIssue,
        this.colExpiry,
        this.colFREQ,
        this.colBandWidth,
        this.colcity
      });
            this.myGridView1.GridControl = (DevExpress.XtraGrid.GridControl)this.myGridControl1;
            this.myGridView1.GroupCount = 2;
            this.myGridView1.Name = "myGridView1";
            this.myGridView1.OptionsBehavior.Editable = false;
            this.myGridView1.OptionsBehavior.ReadOnly = true;
            this.myGridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.myGridView1.OptionsView.ShowFooter = true;
            this.myGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[3]
      {
        new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colcity, DevExpress.Data.ColumnSortOrder.Ascending),
        new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colComp, DevExpress.Data.ColumnSortOrder.Ascending),
        new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFREQ, DevExpress.Data.ColumnSortOrder.Ascending)
      });
            this.myGridView1.EndGrouping += new System.EventHandler(this.myGridView1_EndGrouping);
            this.colComp.Caption = "ორგანიზაცია";
            this.colComp.FieldName = "Comp";
            this.colComp.Name = "colComp";
            this.colComp.Visible = true;
            this.colComp.VisibleIndex = 0;
            this.collicName.Caption = "ლიცენზია";
            this.collicName.FieldName = "licName";
            this.collicName.Name = "collicName";
            this.collicName.Visible = true;
            this.collicName.VisibleIndex = 0;
            this.colIssue.Caption = "გაცემა";
            this.colIssue.FieldName = "Issue";
            this.colIssue.Name = "colIssue";
            this.colIssue.Visible = true;
            this.colIssue.VisibleIndex = 1;
            this.colExpiry.Caption = "ამოწურვა";
            this.colExpiry.FieldName = "Expiry";
            this.colExpiry.Name = "colExpiry";
            this.colExpiry.Visible = true;
            this.colExpiry.VisibleIndex = 2;
            this.colFREQ.Caption = "სიხშირე";
            this.colFREQ.FieldName = "FREQ";
            this.colFREQ.Name = "colFREQ";
            this.colFREQ.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[1]
      {
        (DevExpress.XtraGrid.GridSummaryItem) new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "FREQ", "{0}")
      });
            this.colFREQ.Visible = true;
            this.colFREQ.VisibleIndex = 3;
            this.colBandWidth.Caption = "ზოლი";
            this.colBandWidth.FieldName = "BandWidth";
            this.colBandWidth.Name = "colBandWidth";
            this.colBandWidth.Visible = true;
            this.colBandWidth.VisibleIndex = 4;
            this.colcity.Caption = "ქალაქი";
            this.colcity.FieldName = "city";
            this.colcity.Name = "colcity";
            this.colcity.Visible = true;
            this.colcity.VisibleIndex = 6;
            this.notProlongedTableAdapter.ClearBeforeFill = true;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)204);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 35);
            this.dateTimePicker1.MaxDate = new System.DateTime(2038, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 23);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)204);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(168, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "-დან";
            this.printButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.printButton.Image = global::Fams.Properties.Resources.print;
            this.printButton.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.printButton.Location = new System.Drawing.Point(852, 30);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(29, 28);
            this.printButton.TabIndex = 8;
            this.printButton.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(893, 524);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.myGridControl1);
            this.Controls.Add(this.radTitleBar1);
            this.Name = "frmNotProlonged";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "არ გაგრძელებული სიხშირეები";
            this.radTitleBar1.EndInit();
            this.myGridControl1.EndInit();
            ((System.ComponentModel.ISupportInitialize)this.notProlongedBindingSource).EndInit();
            this.officeDataSet.EndInit();
            this.myGridView1.EndInit();
            this.printButton.EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ka-GE");
        private Telerik.WinControls.UI.RadTitleBar radTitleBar1;
        private Telerik.WinControls.RoundRectShape roundRectShapeTitle;
        private Helpers.MyGridControl myGridControl1;
        private System.Windows.Forms.BindingSource notProlongedBindingSource;
        private DataBase.OfficeDataSet officeDataSet;
        private Helpers.MyGridView myGridView1;
        private DataBase.OfficeDataSetTableAdapters.__notProlongedTableAdapter notProlongedTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colComp;
        private DevExpress.XtraGrid.Columns.GridColumn collicName;
        private DevExpress.XtraGrid.Columns.GridColumn colIssue;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiry;
        private DevExpress.XtraGrid.Columns.GridColumn colFREQ;
        private DevExpress.XtraGrid.Columns.GridColumn colBandWidth;
        private DevExpress.XtraGrid.Columns.GridColumn colcity;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton printButton;
    }
}