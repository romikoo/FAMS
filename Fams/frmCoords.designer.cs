namespace Fams
{
    partial class frmCoords
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCoords));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.zone_CityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zone_CityTableAdapter = new DataBase.OfficeDataSetTableAdapters.Zone_CityTableAdapter();
            this.zone_CityBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.zone_CityBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportBtn = new System.Windows.Forms.ToolStripButton();
            this.CloseGoogle = new System.Windows.Forms.ToolStripButton();
            this.geoLabel = new System.Windows.Forms.ToolStripLabel();
            this.zone_CityDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.special = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.queriesTableAdapter = new DataBase.OfficeDataSetTableAdapters.QueriesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityBindingNavigator)).BeginInit();
            this.zone_CityBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // zone_CityBindingSource
            // 
            this.zone_CityBindingSource.DataMember = "Zone_City";
            this.zone_CityBindingSource.DataSource = this.officeDataSet;
            // 
            // zone_CityTableAdapter
            // 
            this.zone_CityTableAdapter.ClearBeforeFill = true;
            // 
            // zone_CityBindingNavigator
            // 
            this.zone_CityBindingNavigator.AddNewItem = null;
            this.zone_CityBindingNavigator.BindingSource = this.zone_CityBindingSource;
            this.zone_CityBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.zone_CityBindingNavigator.DeleteItem = null;
            this.zone_CityBindingNavigator.Enabled = false;
            this.zone_CityBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.zone_CityBindingNavigatorSaveItem,
            this.toolStripSeparator1,
            this.ExportBtn,
            this.CloseGoogle,
            this.geoLabel});
            this.zone_CityBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.zone_CityBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.zone_CityBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.zone_CityBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.zone_CityBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.zone_CityBindingNavigator.Name = "zone_CityBindingNavigator";
            this.zone_CityBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.zone_CityBindingNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.zone_CityBindingNavigator.Size = new System.Drawing.Size(790, 25);
            this.zone_CityBindingNavigator.TabIndex = 0;
            this.zone_CityBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(58, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // zone_CityBindingNavigatorSaveItem
            // 
            this.zone_CityBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zone_CityBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("zone_CityBindingNavigatorSaveItem.Image")));
            this.zone_CityBindingNavigatorSaveItem.Name = "zone_CityBindingNavigatorSaveItem";
            this.zone_CityBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.zone_CityBindingNavigatorSaveItem.Text = "Save Data";
            this.zone_CityBindingNavigatorSaveItem.Click += new System.EventHandler(this.zone_CityBindingNavigatorSaveItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ExportBtn
            // 
            this.ExportBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ExportBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExportBtn.Image")));
            this.ExportBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(69, 22);
            this.ExportBtn.Text = "ექსპორტი...";
            this.ExportBtn.ToolTipText = "ექსპორტი რუკაზე";
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // CloseGoogle
            // 
            this.CloseGoogle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CloseGoogle.Enabled = false;
            this.CloseGoogle.Image = ((System.Drawing.Image)(resources.GetObject("CloseGoogle.Image")));
            this.CloseGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseGoogle.Name = "CloseGoogle";
            this.CloseGoogle.Size = new System.Drawing.Size(86, 22);
            this.CloseGoogle.Text = "რუკის დახურვა";
            this.CloseGoogle.Click += new System.EventHandler(this.CloseGoogle_Click);
            // 
            // geoLabel
            // 
            this.geoLabel.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.geoLabel.ForeColor = System.Drawing.Color.Green;
            this.geoLabel.Name = "geoLabel";
            this.geoLabel.Size = new System.Drawing.Size(105, 22);
            this.geoLabel.Text = "toolStripLabel1";
            this.geoLabel.Visible = false;
            // 
            // zone_CityDataGridView
            // 
            this.zone_CityDataGridView.AllowUserToAddRows = false;
            this.zone_CityDataGridView.AllowUserToDeleteRows = false;
            this.zone_CityDataGridView.AllowUserToOrderColumns = true;
            this.zone_CityDataGridView.AutoGenerateColumns = false;
            this.zone_CityDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.special});
            this.zone_CityDataGridView.DataSource = this.zone_CityBindingSource;
            this.zone_CityDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zone_CityDataGridView.Location = new System.Drawing.Point(0, 25);
            this.zone_CityDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.zone_CityDataGridView.Name = "zone_CityDataGridView";
            this.zone_CityDataGridView.ReadOnly = true;
            this.zone_CityDataGridView.Size = new System.Drawing.Size(790, 479);
            this.zone_CityDataGridView.TabIndex = 1;
            this.zone_CityDataGridView.CurrentCellChanged += new System.EventHandler(this.zone_CityDataGridView_CurrentCellChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "city";
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "სოფელი/ქალაქი/რეგიონი";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 188;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "lat";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "lat";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "lon";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "lon";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // special
            // 
            this.special.DataPropertyName = "special";
            this.special.Frozen = true;
            this.special.HeaderText = "გეო. არეალი";
            this.special.Name = "special";
            this.special.ReadOnly = true;
            // 
            // frmCoords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 504);
            this.Controls.Add(this.zone_CityDataGridView);
            this.Controls.Add(this.zone_CityBindingNavigator);
            this.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCoords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCoords";
            this.Load += new System.EventHandler(this.frmCoords_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCoords_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityBindingNavigator)).EndInit();
            this.zone_CityBindingNavigator.ResumeLayout(false);
            this.zone_CityBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource zone_CityBindingSource;
        private DataBase.OfficeDataSetTableAdapters.Zone_CityTableAdapter zone_CityTableAdapter;
        private System.Windows.Forms.BindingNavigator zone_CityBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton zone_CityBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView zone_CityDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn special;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ExportBtn;
        private System.Windows.Forms.ToolStripButton CloseGoogle;
        private DataBase.OfficeDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter;
        private System.Windows.Forms.ToolStripLabel geoLabel;
    }
}