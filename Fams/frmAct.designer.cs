namespace Fams
{
    partial class frmAct
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
            System.Windows.Forms.Label numberLabel;
            System.Windows.Forms.Label tarigiLabel;
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label receverLabel;
            System.Windows.Forms.Label remarkLabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAct));
            this.numberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.receverTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.fls_LICENCE_INFOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fls_LICENCE_INFOTableAdapter = new DataBase.OfficeDataSetTableAdapters.fls_LICENCE_INFOTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.remarkTextEdit = new System.Windows.Forms.TextBox();
            this.descriptionTextEdit = new System.Windows.Forms.TextBox();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.okBtn = new DevExpress.XtraEditors.SimpleButton();
            this.tarigiDateEdit = new DevExpress.XtraEditors.TextEdit();
            numberLabel = new System.Windows.Forms.Label();
            tarigiLabel = new System.Windows.Forms.Label();
            descriptionLabel = new System.Windows.Forms.Label();
            receverLabel = new System.Windows.Forms.Label();
            remarkLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receverTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_INFOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarigiDateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numberLabel.Location = new System.Drawing.Point(16, 19);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new System.Drawing.Size(100, 16);
            numberLabel.TabIndex = 3;
            numberLabel.Text = "აქტის ნომერი:";
            // 
            // tarigiLabel
            // 
            tarigiLabel.AutoSize = true;
            tarigiLabel.Location = new System.Drawing.Point(354, 19);
            tarigiLabel.Name = "tarigiLabel";
            tarigiLabel.Size = new System.Drawing.Size(128, 16);
            tarigiLabel.TabIndex = 5;
            tarigiLabel.Text = "გაფორმების თარიღი:";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(16, 58);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(85, 16);
            descriptionLabel.TabIndex = 7;
            descriptionLabel.Text = "აღწერილობა:";
            // 
            // receverLabel
            // 
            receverLabel.AutoSize = true;
            receverLabel.Location = new System.Drawing.Point(356, 206);
            receverLabel.Name = "receverLabel";
            receverLabel.Size = new System.Drawing.Size(58, 16);
            receverLabel.TabIndex = 9;
            receverLabel.Text = "ჩაბარდა:";
            // 
            // remarkLabel
            // 
            remarkLabel.AutoSize = true;
            remarkLabel.Location = new System.Drawing.Point(354, 58);
            remarkLabel.Name = "remarkLabel";
            remarkLabel.Size = new System.Drawing.Size(60, 16);
            remarkLabel.TabIndex = 15;
            remarkLabel.Text = "შენიშვნა:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(354, 175);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(185, 16);
            label1.TabIndex = 24;
            label1.Text = "ნებართვის/ლიცენზიის ნომერი:";
            label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numberTextEdit
            // 
            this.numberTextEdit.Location = new System.Drawing.Point(122, 18);
            this.numberTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numberTextEdit.Name = "numberTextEdit";
            this.numberTextEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.numberTextEdit.Size = new System.Drawing.Size(199, 22);
            this.numberTextEdit.TabIndex = 0;
            this.numberTextEdit.TextChanged += new System.EventHandler(this.numberTextEdit_TextChanged);
            // 
            // receverTextEdit
            // 
            this.receverTextEdit.Location = new System.Drawing.Point(416, 204);
            this.receverTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.receverTextEdit.Name = "receverTextEdit";
            this.receverTextEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.receverTextEdit.Size = new System.Drawing.Size(262, 22);
            this.receverTextEdit.TabIndex = 5;
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fls_LICENCE_INFOBindingSource
            // 
            this.fls_LICENCE_INFOBindingSource.DataMember = "fls_LICENCE_INFO";
            this.fls_LICENCE_INFOBindingSource.DataSource = this.officeDataSet;
            // 
            // fls_LICENCE_INFOTableAdapter
            // 
            this.fls_LICENCE_INFOTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.fls_LICENCE_INFOBindingSource;
            this.comboBox1.DisplayMember = "LICENCE";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(545, 172);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 24);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.ValueMember = "id";
            // 
            // remarkTextEdit
            // 
            this.remarkTextEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remarkTextEdit.Location = new System.Drawing.Point(357, 78);
            this.remarkTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.remarkTextEdit.Multiline = true;
            this.remarkTextEdit.Name = "remarkTextEdit";
            this.remarkTextEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.remarkTextEdit.Size = new System.Drawing.Size(321, 83);
            this.remarkTextEdit.TabIndex = 3;
            // 
            // descriptionTextEdit
            // 
            this.descriptionTextEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextEdit.Location = new System.Drawing.Point(19, 78);
            this.descriptionTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.descriptionTextEdit.Multiline = true;
            this.descriptionTextEdit.Name = "descriptionTextEdit";
            this.descriptionTextEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextEdit.Size = new System.Drawing.Size(302, 146);
            this.descriptionTextEdit.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(540, 250);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(138, 45);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "გაუქმება";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.okBtn.Appearance.Options.UseFont = true;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.Image")));
            this.okBtn.Location = new System.Drawing.Point(396, 250);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(138, 45);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "დადასტურება";
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // tarigiDateEdit
            // 
            this.tarigiDateEdit.Location = new System.Drawing.Point(488, 17);
            this.tarigiDateEdit.Name = "tarigiDateEdit";
            this.tarigiDateEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.tarigiDateEdit.Size = new System.Drawing.Size(190, 22);
            this.tarigiDateEdit.TabIndex = 1;
            // 
            // frmAct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(694, 309);
            this.Controls.Add(this.tarigiDateEdit);
            this.Controls.Add(label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.descriptionTextEdit);
            this.Controls.Add(this.remarkTextEdit);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(numberLabel);
            this.Controls.Add(this.numberTextEdit);
            this.Controls.Add(tarigiLabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(receverLabel);
            this.Controls.Add(this.receverTextEdit);
            this.Controls.Add(remarkLabel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "შემოწმების აქტი";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAct_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receverTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_INFOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarigiDateEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit numberTextEdit;
        private DevExpress.XtraEditors.TextEdit receverTextEdit;
        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource fls_LICENCE_INFOBindingSource;
        private DataBase.OfficeDataSetTableAdapters.fls_LICENCE_INFOTableAdapter fls_LICENCE_INFOTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox remarkTextEdit;
        private System.Windows.Forms.TextBox descriptionTextEdit;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton okBtn;
        private DevExpress.XtraEditors.TextEdit tarigiDateEdit;
    }
}