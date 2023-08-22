namespace Fams
{
    partial class frmSecured
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
            this.fls_COMPANY_INFODataGridView = new System.Windows.Forms.DataGridView();
            this.compNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fls_COMPANY_INFOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.secureDS = new DataBase.SecureDS();
            this.fls_LICENCE_INFODataGridView = new System.Windows.Forms.DataGridView();
            this.lICENCEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lICISSUDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lICEXPIRYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fls_LICENCE_INFOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fls_LICENCE_FREQDataGridView = new System.Windows.Forms.DataGridView();
            this.fREQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bandWidthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.zone_CityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fls_LICENCE_FREQBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fls_COMPANY_INFOTableAdapter = new DataBase.SecureDSTableAdapters.fls_COMPANY_INFOTableAdapter();
            this.tableAdapterManager = new DataBase.SecureDSTableAdapters.TableAdapterManager();
            this.fls_LICENCE_FREQTableAdapter = new DataBase.SecureDSTableAdapters.fls_LICENCE_FREQTableAdapter();
            this.fls_LICENCE_INFOTableAdapter = new DataBase.SecureDSTableAdapters.fls_LICENCE_INFOTableAdapter();
            this.zone_CityTableAdapter = new DataBase.SecureDSTableAdapters.Zone_CityTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fls_COMPANY_INFODataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_COMPANY_INFOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secureDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_INFODataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_INFOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_FREQDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_FREQBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fls_COMPANY_INFODataGridView
            // 
            this.fls_COMPANY_INFODataGridView.AutoGenerateColumns = false;
            this.fls_COMPANY_INFODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fls_COMPANY_INFODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compNameDataGridViewTextBoxColumn});
            this.fls_COMPANY_INFODataGridView.DataSource = this.fls_COMPANY_INFOBindingSource;
            this.fls_COMPANY_INFODataGridView.Location = new System.Drawing.Point(12, 13);
            this.fls_COMPANY_INFODataGridView.MultiSelect = false;
            this.fls_COMPANY_INFODataGridView.Name = "fls_COMPANY_INFODataGridView";
            this.fls_COMPANY_INFODataGridView.RowHeadersVisible = false;
            this.fls_COMPANY_INFODataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fls_COMPANY_INFODataGridView.Size = new System.Drawing.Size(417, 132);
            this.fls_COMPANY_INFODataGridView.TabIndex = 1;
            this.fls_COMPANY_INFODataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.fls_COMPANY_INFODataGridView_UserDeletingRow);
            // 
            // compNameDataGridViewTextBoxColumn
            // 
            this.compNameDataGridViewTextBoxColumn.DataPropertyName = "Comp_Name";
            this.compNameDataGridViewTextBoxColumn.HeaderText = "ორგანიზაცია";
            this.compNameDataGridViewTextBoxColumn.Name = "compNameDataGridViewTextBoxColumn";
            this.compNameDataGridViewTextBoxColumn.Width = 350;
            // 
            // fls_COMPANY_INFOBindingSource
            // 
            this.fls_COMPANY_INFOBindingSource.DataMember = "fls_COMPANY_INFO";
            this.fls_COMPANY_INFOBindingSource.DataSource = this.secureDS;
            this.fls_COMPANY_INFOBindingSource.CurrentChanged += new System.EventHandler(this.fls_COMPANY_INFOBindingSource_CurrentChanged);
            // 
            // secureDS
            // 
            this.secureDS.DataSetName = "SecureDS";
            this.secureDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fls_LICENCE_INFODataGridView
            // 
            this.fls_LICENCE_INFODataGridView.AutoGenerateColumns = false;
            this.fls_LICENCE_INFODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fls_LICENCE_INFODataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lICENCEDataGridViewTextBoxColumn,
            this.lICISSUDATEDataGridViewTextBoxColumn,
            this.lICEXPIRYDATEDataGridViewTextBoxColumn});
            this.fls_LICENCE_INFODataGridView.DataSource = this.fls_LICENCE_INFOBindingSource;
            this.fls_LICENCE_INFODataGridView.Location = new System.Drawing.Point(12, 151);
            this.fls_LICENCE_INFODataGridView.MultiSelect = false;
            this.fls_LICENCE_INFODataGridView.Name = "fls_LICENCE_INFODataGridView";
            this.fls_LICENCE_INFODataGridView.RowHeadersVisible = false;
            this.fls_LICENCE_INFODataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fls_LICENCE_INFODataGridView.Size = new System.Drawing.Size(417, 102);
            this.fls_LICENCE_INFODataGridView.TabIndex = 1;
            this.fls_LICENCE_INFODataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.fls_LICENCE_INFODataGridView_UserDeletingRow);
            // 
            // lICENCEDataGridViewTextBoxColumn
            // 
            this.lICENCEDataGridViewTextBoxColumn.DataPropertyName = "LICENCE";
            this.lICENCEDataGridViewTextBoxColumn.HeaderText = "ლიცენზია/ნებართვა";
            this.lICENCEDataGridViewTextBoxColumn.Name = "lICENCEDataGridViewTextBoxColumn";
            this.lICENCEDataGridViewTextBoxColumn.Width = 120;
            // 
            // lICISSUDATEDataGridViewTextBoxColumn
            // 
            this.lICISSUDATEDataGridViewTextBoxColumn.DataPropertyName = "LIC_ISSU_DATE";
            this.lICISSUDATEDataGridViewTextBoxColumn.HeaderText = "გაცემის თარიღი";
            this.lICISSUDATEDataGridViewTextBoxColumn.Name = "lICISSUDATEDataGridViewTextBoxColumn";
            this.lICISSUDATEDataGridViewTextBoxColumn.Width = 120;
            // 
            // lICEXPIRYDATEDataGridViewTextBoxColumn
            // 
            this.lICEXPIRYDATEDataGridViewTextBoxColumn.DataPropertyName = "LIC_EXPIRY_DATE";
            this.lICEXPIRYDATEDataGridViewTextBoxColumn.HeaderText = "დამთავრების თარიღი";
            this.lICEXPIRYDATEDataGridViewTextBoxColumn.Name = "lICEXPIRYDATEDataGridViewTextBoxColumn";
            this.lICEXPIRYDATEDataGridViewTextBoxColumn.Width = 150;
            // 
            // fls_LICENCE_INFOBindingSource
            // 
            this.fls_LICENCE_INFOBindingSource.DataMember = "FK_fls_LICENCE_INFO_fls_COMPANY_INFO";
            this.fls_LICENCE_INFOBindingSource.DataSource = this.fls_COMPANY_INFOBindingSource;
            this.fls_LICENCE_INFOBindingSource.CurrentChanged += new System.EventHandler(this.fls_LICENCE_INFOBindingSource_CurrentChanged);
            // 
            // fls_LICENCE_FREQDataGridView
            // 
            this.fls_LICENCE_FREQDataGridView.AutoGenerateColumns = false;
            this.fls_LICENCE_FREQDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fls_LICENCE_FREQDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fREQDataGridViewTextBoxColumn,
            this.bandWidthDataGridViewTextBoxColumn,
            this.cityidDataGridViewTextBoxColumn});
            this.fls_LICENCE_FREQDataGridView.DataSource = this.fls_LICENCE_FREQBindingSource;
            this.fls_LICENCE_FREQDataGridView.Location = new System.Drawing.Point(12, 259);
            this.fls_LICENCE_FREQDataGridView.MultiSelect = false;
            this.fls_LICENCE_FREQDataGridView.Name = "fls_LICENCE_FREQDataGridView";
            this.fls_LICENCE_FREQDataGridView.RowHeadersVisible = false;
            this.fls_LICENCE_FREQDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fls_LICENCE_FREQDataGridView.Size = new System.Drawing.Size(417, 155);
            this.fls_LICENCE_FREQDataGridView.TabIndex = 2;
            this.fls_LICENCE_FREQDataGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.fls_LICENCE_FREQDataGridView_UserDeletingRow);
            // 
            // fREQDataGridViewTextBoxColumn
            // 
            this.fREQDataGridViewTextBoxColumn.DataPropertyName = "FREQ";
            this.fREQDataGridViewTextBoxColumn.HeaderText = "სიხშირე";
            this.fREQDataGridViewTextBoxColumn.Name = "fREQDataGridViewTextBoxColumn";
            // 
            // bandWidthDataGridViewTextBoxColumn
            // 
            this.bandWidthDataGridViewTextBoxColumn.DataPropertyName = "BandWidth";
            this.bandWidthDataGridViewTextBoxColumn.HeaderText = "ზოლი";
            this.bandWidthDataGridViewTextBoxColumn.Name = "bandWidthDataGridViewTextBoxColumn";
            // 
            // cityidDataGridViewTextBoxColumn
            // 
            this.cityidDataGridViewTextBoxColumn.DataPropertyName = "city_id";
            this.cityidDataGridViewTextBoxColumn.DataSource = this.zone_CityBindingSource;
            this.cityidDataGridViewTextBoxColumn.DisplayMember = "city";
            this.cityidDataGridViewTextBoxColumn.HeaderText = "ქალაქი";
            this.cityidDataGridViewTextBoxColumn.Name = "cityidDataGridViewTextBoxColumn";
            this.cityidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cityidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cityidDataGridViewTextBoxColumn.ValueMember = "id";
            // 
            // zone_CityBindingSource
            // 
            this.zone_CityBindingSource.DataMember = "Zone_City";
            this.zone_CityBindingSource.DataSource = this.secureDS;
            // 
            // fls_LICENCE_FREQBindingSource
            // 
            this.fls_LICENCE_FREQBindingSource.DataMember = "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO";
            this.fls_LICENCE_FREQBindingSource.DataSource = this.fls_LICENCE_INFOBindingSource;
            this.fls_LICENCE_FREQBindingSource.CurrentChanged += new System.EventHandler(this.fls_LICENCE_FREQBindingSource_CurrentChanged);
            // 
            // fls_COMPANY_INFOTableAdapter
            // 
            this.fls_COMPANY_INFOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.fls_COMPANY_INFOTableAdapter = this.fls_COMPANY_INFOTableAdapter;
            this.tableAdapterManager.fls_LICENCE_FREQTableAdapter = this.fls_LICENCE_FREQTableAdapter;
            this.tableAdapterManager.fls_LICENCE_INFOTableAdapter = this.fls_LICENCE_INFOTableAdapter;
            this.tableAdapterManager.UpdateOrder = DataBase.SecureDSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.Zone_CityTableAdapter = null;
            // 
            // fls_LICENCE_FREQTableAdapter
            // 
            this.fls_LICENCE_FREQTableAdapter.ClearBeforeFill = true;
            // 
            // fls_LICENCE_INFOTableAdapter
            // 
            this.fls_LICENCE_INFOTableAdapter.ClearBeforeFill = true;
            // 
            // zone_CityTableAdapter
            // 
            this.zone_CityTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(318, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "შენახვა";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_LICENCE_FREQBindingSource, "remark", true));
            this.richTextBox1.Location = new System.Drawing.Point(75, 420);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(354, 73);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "შენიშვნა:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(12, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "ყურადღება: ყველა სიხშირე მოცემულია კილოჰერცებში!";
            // 
            // frmSecured
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 564);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fls_LICENCE_FREQDataGridView);
            this.Controls.Add(this.fls_LICENCE_INFODataGridView);
            this.Controls.Add(this.fls_COMPANY_INFODataGridView);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSecured";
            this.Opacity = 0.9;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "სპეც. სიხშირეები";
            this.Load += new System.EventHandler(this.frmSecured_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSecured_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fls_COMPANY_INFODataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_COMPANY_INFOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secureDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_INFODataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_INFOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_FREQDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zone_CityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_FREQBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView fls_COMPANY_INFODataGridView;
        private System.Windows.Forms.DataGridView fls_LICENCE_INFODataGridView;
        private System.Windows.Forms.DataGridView fls_LICENCE_FREQDataGridView;
        private DataBase.SecureDS secureDS;
        private System.Windows.Forms.BindingSource fls_COMPANY_INFOBindingSource;
        private DataBase.SecureDSTableAdapters.fls_COMPANY_INFOTableAdapter fls_COMPANY_INFOTableAdapter;
        private DataBase.SecureDSTableAdapters.TableAdapterManager tableAdapterManager;
        private DataBase.SecureDSTableAdapters.fls_LICENCE_INFOTableAdapter fls_LICENCE_INFOTableAdapter;
        private System.Windows.Forms.BindingSource fls_LICENCE_INFOBindingSource;
        private DataBase.SecureDSTableAdapters.fls_LICENCE_FREQTableAdapter fls_LICENCE_FREQTableAdapter;
        private System.Windows.Forms.BindingSource fls_LICENCE_FREQBindingSource;
        private System.Windows.Forms.BindingSource zone_CityBindingSource;
        private DataBase.SecureDSTableAdapters.Zone_CityTableAdapter zone_CityTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn compNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lICENCEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lICISSUDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lICEXPIRYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fREQDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bandWidthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn cityidDataGridViewTextBoxColumn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}