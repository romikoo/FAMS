namespace Fams
{
    partial class frmXTerra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXTerra));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gridEX1 = new Janus.Windows.GridEX.GridEX();
            this.fmtv_terraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xTerraDataSet = new DataBase.XTerraDataSet();
            this.fmtv_terraTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_terraTableAdapter();
            this.fmtv_ant_diagBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_ant_diagTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_ant_diagTableAdapter();
            this.tableAdapterManager = new DataBase.XTerraDataSetTableAdapters.TableAdapterManager();
            this.fmtv_ant_hgtTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_ant_hgtTableAdapter();
            this.fmtv_coordTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_coordTableAdapter();
            this.fmtv_fdg_actTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_fdg_actTableAdapter();
            this.fmtv_fdg_refTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_fdg_refTableAdapter();
            this.fmtv_fdgTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_fdgTableAdapter();
            this.fmtv_ge06_plan_rmksTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_ge06_plan_rmksTableAdapter();
            this.fmtv_historyTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_historyTableAdapter();
            this.fmtv_op_prdTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_op_prdTableAdapter();
            this.fmtv_pub_histTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_pub_histTableAdapter();
            this.fmtv_rmksTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_rmksTableAdapter();
            this.fmtv_soundTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_soundTableAdapter();
            this.fmtv_statusTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_statusTableAdapter();
            this.fmtv_targetTableAdapter = new DataBase.XTerraDataSetTableAdapters.fmtv_targetTableAdapter();
            this.fmtv_ant_hgtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_coordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_fdgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_fdg_actBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_fdg_refBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_ge06_plan_rmksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_historyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_op_prdBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_pub_histBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_rmksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_soundBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_statusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fmtv_targetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_terraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTerraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_ant_diagBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_ant_hgtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_coordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_fdgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_fdg_actBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_fdg_refBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_ge06_plan_rmksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_historyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_op_prdBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_pub_histBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_rmksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_soundBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_statusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_targetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Microsoft Access DataBase|*.mdb";
            // 
            // gridEX1
            // 
            this.gridEX1.DataSource = this.fmtv_terraBindingSource;
            gridEX1_DesignTimeLayout.LayoutString = resources.GetString("gridEX1_DesignTimeLayout.LayoutString");
            this.gridEX1.DesignTimeLayout = gridEX1_DesignTimeLayout;
            this.gridEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEX1.GroupByBoxVisible = false;
            this.gridEX1.Hierarchical = true;
            this.gridEX1.Location = new System.Drawing.Point(0, 0);
            this.gridEX1.Name = "gridEX1";
            this.gridEX1.Size = new System.Drawing.Size(720, 522);
            this.gridEX1.TabIndex = 1;
            // 
            // fmtv_terraBindingSource
            // 
            this.fmtv_terraBindingSource.DataMember = "fmtv_terra";
            this.fmtv_terraBindingSource.DataSource = this.xTerraDataSet;
            // 
            // xTerraDataSet
            // 
            this.xTerraDataSet.DataSetName = "XTerraDataSet";
            this.xTerraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fmtv_terraTableAdapter
            // 
            this.fmtv_terraTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_ant_diagBindingSource
            // 
            this.fmtv_ant_diagBindingSource.DataMember = "fmtv_ant_diag";
            this.fmtv_ant_diagBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_ant_diagTableAdapter
            // 
            this.fmtv_ant_diagTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.fmtv_ant_diagTableAdapter = this.fmtv_ant_diagTableAdapter;
            this.tableAdapterManager.fmtv_ant_hgtTableAdapter = this.fmtv_ant_hgtTableAdapter;
            this.tableAdapterManager.fmtv_coordTableAdapter = this.fmtv_coordTableAdapter;
            this.tableAdapterManager.fmtv_fdg_actTableAdapter = this.fmtv_fdg_actTableAdapter;
            this.tableAdapterManager.fmtv_fdg_refTableAdapter = this.fmtv_fdg_refTableAdapter;
            this.tableAdapterManager.fmtv_fdgTableAdapter = this.fmtv_fdgTableAdapter;
            this.tableAdapterManager.fmtv_ge06_plan_rmksTableAdapter = this.fmtv_ge06_plan_rmksTableAdapter;
            this.tableAdapterManager.fmtv_historyTableAdapter = this.fmtv_historyTableAdapter;
            this.tableAdapterManager.fmtv_op_prdTableAdapter = this.fmtv_op_prdTableAdapter;
            this.tableAdapterManager.fmtv_pub_histTableAdapter = this.fmtv_pub_histTableAdapter;
            this.tableAdapterManager.fmtv_rmksTableAdapter = this.fmtv_rmksTableAdapter;
            this.tableAdapterManager.fmtv_soundTableAdapter = this.fmtv_soundTableAdapter;
            this.tableAdapterManager.fmtv_statusTableAdapter = this.fmtv_statusTableAdapter;
            this.tableAdapterManager.fmtv_targetTableAdapter = this.fmtv_targetTableAdapter;
            this.tableAdapterManager.fmtv_terraTableAdapter = this.fmtv_terraTableAdapter;
            this.tableAdapterManager.UpdateOrder = DataBase.XTerraDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // fmtv_ant_hgtTableAdapter
            // 
            this.fmtv_ant_hgtTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_coordTableAdapter
            // 
            this.fmtv_coordTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_fdg_actTableAdapter
            // 
            this.fmtv_fdg_actTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_fdg_refTableAdapter
            // 
            this.fmtv_fdg_refTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_fdgTableAdapter
            // 
            this.fmtv_fdgTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_ge06_plan_rmksTableAdapter
            // 
            this.fmtv_ge06_plan_rmksTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_historyTableAdapter
            // 
            this.fmtv_historyTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_op_prdTableAdapter
            // 
            this.fmtv_op_prdTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_pub_histTableAdapter
            // 
            this.fmtv_pub_histTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_rmksTableAdapter
            // 
            this.fmtv_rmksTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_soundTableAdapter
            // 
            this.fmtv_soundTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_statusTableAdapter
            // 
            this.fmtv_statusTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_targetTableAdapter
            // 
            this.fmtv_targetTableAdapter.ClearBeforeFill = true;
            // 
            // fmtv_ant_hgtBindingSource
            // 
            this.fmtv_ant_hgtBindingSource.DataMember = "fmtv_ant_hgt";
            this.fmtv_ant_hgtBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_coordBindingSource
            // 
            this.fmtv_coordBindingSource.DataMember = "fmtv_coord";
            this.fmtv_coordBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_fdgBindingSource
            // 
            this.fmtv_fdgBindingSource.DataMember = "fmtv_fdg";
            this.fmtv_fdgBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_fdg_actBindingSource
            // 
            this.fmtv_fdg_actBindingSource.DataMember = "fmtv_fdg_act";
            this.fmtv_fdg_actBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_fdg_refBindingSource
            // 
            this.fmtv_fdg_refBindingSource.DataMember = "fmtv_fdg_ref";
            this.fmtv_fdg_refBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_ge06_plan_rmksBindingSource
            // 
            this.fmtv_ge06_plan_rmksBindingSource.DataMember = "fmtv_ge06_plan_rmks";
            this.fmtv_ge06_plan_rmksBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_historyBindingSource
            // 
            this.fmtv_historyBindingSource.DataMember = "fmtv_history";
            this.fmtv_historyBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_op_prdBindingSource
            // 
            this.fmtv_op_prdBindingSource.DataMember = "fmtv_op_prd";
            this.fmtv_op_prdBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_pub_histBindingSource
            // 
            this.fmtv_pub_histBindingSource.DataMember = "fmtv_pub_hist";
            this.fmtv_pub_histBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_rmksBindingSource
            // 
            this.fmtv_rmksBindingSource.DataMember = "fmtv_rmks";
            this.fmtv_rmksBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_soundBindingSource
            // 
            this.fmtv_soundBindingSource.DataMember = "fmtv_sound";
            this.fmtv_soundBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_statusBindingSource
            // 
            this.fmtv_statusBindingSource.DataMember = "fmtv_status";
            this.fmtv_statusBindingSource.DataSource = this.xTerraDataSet;
            // 
            // fmtv_targetBindingSource
            // 
            this.fmtv_targetBindingSource.DataMember = "fmtv_target";
            this.fmtv_targetBindingSource.DataSource = this.xTerraDataSet;
            // 
            // frmXTerra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 522);
            this.Controls.Add(this.gridEX1);
            this.Name = "frmXTerra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XTerra";
            this.Load += new System.EventHandler(this.frmXTerra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_terraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTerraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_ant_diagBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_ant_hgtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_coordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_fdgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_fdg_actBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_fdg_refBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_ge06_plan_rmksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_historyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_op_prdBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_pub_histBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_rmksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_soundBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_statusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fmtv_targetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Janus.Windows.GridEX.GridEX gridEX1;
        private DataBase.XTerraDataSet xTerraDataSet;
        private System.Windows.Forms.BindingSource fmtv_terraBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_terraTableAdapter fmtv_terraTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_ant_diagBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_ant_diagTableAdapter fmtv_ant_diagTableAdapter;
        private DataBase.XTerraDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private DataBase.XTerraDataSetTableAdapters.fmtv_ant_hgtTableAdapter fmtv_ant_hgtTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_ant_hgtBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_coordTableAdapter fmtv_coordTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_coordBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_fdgTableAdapter fmtv_fdgTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_fdgBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_fdg_actTableAdapter fmtv_fdg_actTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_fdg_actBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_fdg_refTableAdapter fmtv_fdg_refTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_fdg_refBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_ge06_plan_rmksTableAdapter fmtv_ge06_plan_rmksTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_ge06_plan_rmksBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_historyTableAdapter fmtv_historyTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_historyBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_op_prdTableAdapter fmtv_op_prdTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_op_prdBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_pub_histTableAdapter fmtv_pub_histTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_pub_histBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_rmksTableAdapter fmtv_rmksTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_rmksBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_soundTableAdapter fmtv_soundTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_soundBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_statusTableAdapter fmtv_statusTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_statusBindingSource;
        private DataBase.XTerraDataSetTableAdapters.fmtv_targetTableAdapter fmtv_targetTableAdapter;
        private System.Windows.Forms.BindingSource fmtv_targetBindingSource;
    }
}