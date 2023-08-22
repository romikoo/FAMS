namespace Fams
{
    partial class frmEditFreq
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
            this.zoneCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.zone_CityTableAdapter = new DataBase.OfficeDataSetTableAdapters.Zone_CityTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.powerBox = new System.Windows.Forms.TextBox();
            this.zoneBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.BandWidthTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.FREQLabel = new System.Windows.Forms.Label();
            this.FREQTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.remTextBox = new System.Windows.Forms.TextBox();
            this.reestr = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.zoneCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoneCityBindingSource
            // 
            this.zoneCityBindingSource.DataMember = "Zone_City";
            this.zoneCityBindingSource.DataSource = this.officeDataSet;
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(127, 149);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 24);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "გაუქმება";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(205, 149);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 24);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "მზადაა";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // zone_CityTableAdapter
            // 
            this.zone_CityTableAdapter.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(277, 129);
            this.tabControl1.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.powerBox);
            this.tabPage1.Controls.Add(this.zoneBox);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.BandWidthTextBox);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.FREQLabel);
            this.tabPage1.Controls.Add(this.FREQTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(269, 102);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "სიხშირე";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // powerBox
            // 
            this.powerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.powerBox.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerBox.Location = new System.Drawing.Point(205, 43);
            this.powerBox.Name = "powerBox";
            this.powerBox.Size = new System.Drawing.Size(58, 22);
            this.powerBox.TabIndex = 2;
            this.powerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.powerBox.Visible = false;
            this.powerBox.VisibleChanged += new System.EventHandler(this.powerBox_VisibleChanged);
            // 
            // zoneBox
            // 
            this.zoneBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.zoneBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.zoneBox.DataSource = this.zoneCityBindingSource;
            this.zoneBox.DisplayMember = "city";
            this.zoneBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zoneBox.FormattingEnabled = true;
            this.zoneBox.Location = new System.Drawing.Point(119, 71);
            this.zoneBox.Name = "zoneBox";
            this.zoneBox.Size = new System.Drawing.Size(144, 22);
            this.zoneBox.TabIndex = 3;
            this.zoneBox.ValueMember = "id";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 14);
            this.label17.TabIndex = 47;
            this.label17.Text = "გატარების ზოლი:";
            // 
            // BandWidthTextBox
            // 
            this.BandWidthTextBox.Location = new System.Drawing.Point(119, 43);
            this.BandWidthTextBox.Name = "BandWidthTextBox";
            this.BandWidthTextBox.Size = new System.Drawing.Size(80, 22);
            this.BandWidthTextBox.TabIndex = 1;
            this.BandWidthTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FREQTextBox_KeyDown);
            this.BandWidthTextBox.Leave += new System.EventHandler(this.FREQTextBox_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 14);
            this.label15.TabIndex = 46;
            this.label15.Text = "ქალაქი (რაიონი):";
            // 
            // FREQLabel
            // 
            this.FREQLabel.AutoSize = true;
            this.FREQLabel.Location = new System.Drawing.Point(58, 18);
            this.FREQLabel.Name = "FREQLabel";
            this.FREQLabel.Size = new System.Drawing.Size(55, 14);
            this.FREQLabel.TabIndex = 45;
            this.FREQLabel.Text = "სიხშირე:";
            // 
            // FREQTextBox
            // 
            this.FREQTextBox.Location = new System.Drawing.Point(119, 15);
            this.FREQTextBox.Name = "FREQTextBox";
            this.FREQTextBox.Size = new System.Drawing.Size(144, 22);
            this.FREQTextBox.TabIndex = 0;
            this.FREQTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FREQTextBox_KeyDown);
            this.FREQTextBox.Leave += new System.EventHandler(this.FREQTextBox_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.remTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(269, 102);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "შენიშვნა";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // remTextBox
            // 
            this.remTextBox.Location = new System.Drawing.Point(6, 6);
            this.remTextBox.Multiline = true;
            this.remTextBox.Name = "remTextBox";
            this.remTextBox.Size = new System.Drawing.Size(257, 90);
            this.remTextBox.TabIndex = 5;
            // 
            // reestr
            // 
            this.reestr.AutoSize = true;
            this.reestr.Location = new System.Drawing.Point(8, 149);
            this.reestr.Name = "reestr";
            this.reestr.Size = new System.Drawing.Size(85, 18);
            this.reestr.TabIndex = 4;
            this.reestr.Text = "რეესტრით";
            this.reestr.UseVisualStyleBackColor = true;
            this.reestr.Visible = false;
            // 
            // frmEditFreq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(287, 180);
            this.Controls.Add(this.reestr);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditFreq";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "სიხშირის დამატება/რედაქტირება";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmFreq_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFreq_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.zoneCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource zoneCityBindingSource;
        private DataBase.OfficeDataSetTableAdapters.Zone_CityTableAdapter zone_CityTableAdapter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox zoneBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox BandWidthTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label FREQLabel;
        private System.Windows.Forms.TextBox FREQTextBox;
        private System.Windows.Forms.TextBox remTextBox;
        private System.Windows.Forms.CheckBox reestr;
        private System.Windows.Forms.TextBox powerBox;
    }
}