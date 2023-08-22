namespace Fams
{
    partial class frmPickLicence
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPickLicence));
            this.flsLICENCEINFOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.fls_LICENCE_INFOTableAdapter = new DataBase.OfficeDataSetTableAdapters.fls_LICENCE_INFOTableAdapter();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.flsLICENCEINFOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // flsLICENCEINFOBindingSource
            // 
            this.flsLICENCEINFOBindingSource.DataMember = "fls_LICENCE_INFO";
            this.flsLICENCEINFOBindingSource.DataSource = this.officeDataSet;
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fls_LICENCE_INFOTableAdapter
            // 
            this.fls_LICENCE_INFOTableAdapter.ClearBeforeFill = true;
            // 
            // gridEX1
            // 
            this.gridEX1.AllowCardSizing = false;
            this.gridEX1.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEX1.DataSource = this.flsLICENCEINFOBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Location = new System.Drawing.Point(12, 12);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(375, 251);
            this.gridEX1.TabIndex = 1;
            this.gridEX1.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.gridEX1_RowDoubleClick);
            this.gridEX1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridEX1_KeyUp);
            // 
            // frmPickLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 275);
            this.Controls.Add(this.gridEX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPickLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  აირჩიეთ ლიცენზია";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridEX1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.flsLICENCEINFOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource flsLICENCEINFOBindingSource;
        private DataBase.OfficeDataSetTableAdapters.fls_LICENCE_INFOTableAdapter fls_LICENCE_INFOTableAdapter;
        private Janus.Windows.GridEX.GridEX gridEX1;
    }
}