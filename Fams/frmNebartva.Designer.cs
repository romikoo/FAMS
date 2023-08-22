namespace Fams
{
    partial class frmNebartva
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
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label numberLabel;
            System.Windows.Forms.Label saxeLabel;
            System.Windows.Forms.Label f_spectrumLabel;
            System.Windows.Forms.Label geo_zoneLabel;
            System.Windows.Forms.Label pirobebiLabel;
            System.Windows.Forms.Label issue_dateLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.fls_NEBARTVABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.saxeTextBox = new System.Windows.Forms.TextBox();
            this.f_spectrumTextBox = new System.Windows.Forms.TextBox();
            this.geo_zoneTextBox = new System.Windows.Forms.TextBox();
            this.pirobebiTextBox = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.issue_textBox = new System.Windows.Forms.TextBox();
            this.expiry_textBox = new System.Windows.Forms.TextBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.registration_textBox = new System.Windows.Forms.TextBox();
            this.fls_NEBARTVATableAdapter = new DataBase.OfficeDataSetTableAdapters.fls_NEBARTVATableAdapter();
            this.fls_LICENCE_FREQBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fls_LICENCE_FREQTableAdapter = new DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter();
            idLabel = new System.Windows.Forms.Label();
            numberLabel = new System.Windows.Forms.Label();
            saxeLabel = new System.Windows.Forms.Label();
            f_spectrumLabel = new System.Windows.Forms.Label();
            geo_zoneLabel = new System.Windows.Forms.Label();
            pirobebiLabel = new System.Windows.Forms.Label();
            issue_dateLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fls_NEBARTVABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_FREQBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            idLabel.Location = new System.Drawing.Point(14, 16);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(84, 14);
            idLabel.TabIndex = 1;
            idLabel.Text = "მოწმობის #:";
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numberLabel.Location = new System.Drawing.Point(14, 44);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new System.Drawing.Size(131, 14);
            numberLabel.TabIndex = 3;
            numberLabel.Text = "ნებართვის ნომერი:";
            // 
            // saxeLabel
            // 
            saxeLabel.AutoSize = true;
            saxeLabel.Location = new System.Drawing.Point(14, 72);
            saxeLabel.Name = "saxeLabel";
            saxeLabel.Size = new System.Drawing.Size(95, 14);
            saxeLabel.TabIndex = 5;
            saxeLabel.Text = "ნებართვის სახე:";
            // 
            // f_spectrumLabel
            // 
            f_spectrumLabel.AutoSize = true;
            f_spectrumLabel.Location = new System.Drawing.Point(13, 166);
            f_spectrumLabel.Name = "f_spectrumLabel";
            f_spectrumLabel.Size = new System.Drawing.Size(161, 14);
            f_spectrumLabel.TabIndex = 7;
            f_spectrumLabel.Text = "რადიოსიხშირული სპექთრი:";
            // 
            // geo_zoneLabel
            // 
            geo_zoneLabel.AutoSize = true;
            geo_zoneLabel.Location = new System.Drawing.Point(13, 255);
            geo_zoneLabel.Name = "geo_zoneLabel";
            geo_zoneLabel.Size = new System.Drawing.Size(200, 14);
            geo_zoneLabel.TabIndex = 9;
            geo_zoneLabel.Text = "სარგებლობის გეოგრაფიული ზონა:";
            // 
            // pirobebiLabel
            // 
            pirobebiLabel.AutoSize = true;
            pirobebiLabel.Location = new System.Drawing.Point(14, 306);
            pirobebiLabel.Name = "pirobebiLabel";
            pirobebiLabel.Size = new System.Drawing.Size(133, 14);
            pirobebiLabel.TabIndex = 11;
            pirobebiLabel.Text = "სანებართვო პირობები:";
            // 
            // issue_dateLabel
            // 
            issue_dateLabel.AutoSize = true;
            issue_dateLabel.Location = new System.Drawing.Point(13, 489);
            issue_dateLabel.Name = "issue_dateLabel";
            issue_dateLabel.Size = new System.Drawing.Size(161, 14);
            issue_dateLabel.TabIndex = 13;
            issue_dateLabel.Text = "ნებართვის გაცემის თარიღი:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 516);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(165, 14);
            label1.TabIndex = 18;
            label1.Text = "ნებართვის მოქმედების ვადა:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(15, 102);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(236, 14);
            label2.TabIndex = 21;
            label2.Text = "მფლობელის სარეგისტრაციო მონაცემები:";
            // 
            // idTextBox
            // 
            this.idTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "id", true));
            this.idTextBox.Location = new System.Drawing.Point(239, 12);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(200, 22);
            this.idTextBox.TabIndex = 1;
            // 
            // fls_NEBARTVABindingSource
            // 
            this.fls_NEBARTVABindingSource.DataMember = "fls_NEBARTVA";
            this.fls_NEBARTVABindingSource.DataSource = this.officeDataSet;
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // numberTextBox
            // 
            this.numberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "Number", true));
            this.numberTextBox.Location = new System.Drawing.Point(239, 40);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(97, 22);
            this.numberTextBox.TabIndex = 2;
            // 
            // saxeTextBox
            // 
            this.saxeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.saxeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "Saxe", true));
            this.saxeTextBox.Location = new System.Drawing.Point(115, 68);
            this.saxeTextBox.Name = "saxeTextBox";
            this.saxeTextBox.Size = new System.Drawing.Size(324, 22);
            this.saxeTextBox.TabIndex = 3;
            // 
            // f_spectrumTextBox
            // 
            this.f_spectrumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.f_spectrumTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "F_spectrum", true));
            this.f_spectrumTextBox.Location = new System.Drawing.Point(16, 183);
            this.f_spectrumTextBox.Multiline = true;
            this.f_spectrumTextBox.Name = "f_spectrumTextBox";
            this.f_spectrumTextBox.Size = new System.Drawing.Size(422, 62);
            this.f_spectrumTextBox.TabIndex = 5;
            // 
            // geo_zoneTextBox
            // 
            this.geo_zoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.geo_zoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "geo_zone", true));
            this.geo_zoneTextBox.Location = new System.Drawing.Point(16, 272);
            this.geo_zoneTextBox.Name = "geo_zoneTextBox";
            this.geo_zoneTextBox.Size = new System.Drawing.Size(421, 22);
            this.geo_zoneTextBox.TabIndex = 6;
            // 
            // pirobebiTextBox
            // 
            this.pirobebiTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pirobebiTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "Pirobebi", true));
            this.pirobebiTextBox.Location = new System.Drawing.Point(16, 327);
            this.pirobebiTextBox.Multiline = true;
            this.pirobebiTextBox.Name = "pirobebiTextBox";
            this.pirobebiTextBox.Size = new System.Drawing.Size(422, 153);
            this.pirobebiTextBox.TabIndex = 7;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(238, 545);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(97, 26);
            this.CancelBtn.TabIndex = 11;
            this.CancelBtn.Text = "გაუქმება";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(341, 545);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(98, 26);
            this.OKBtn.TabIndex = 10;
            this.OKBtn.Text = "მზადაა";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // issue_textBox
            // 
            this.issue_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.issue_textBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "issue_date", true));
            this.issue_textBox.Location = new System.Drawing.Point(201, 486);
            this.issue_textBox.Name = "issue_textBox";
            this.issue_textBox.Size = new System.Drawing.Size(237, 22);
            this.issue_textBox.TabIndex = 8;
            // 
            // expiry_textBox
            // 
            this.expiry_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expiry_textBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fls_NEBARTVABindingSource, "expiry_date", true));
            this.expiry_textBox.Location = new System.Drawing.Point(201, 514);
            this.expiry_textBox.Name = "expiry_textBox";
            this.expiry_textBox.Size = new System.Drawing.Size(237, 22);
            this.expiry_textBox.TabIndex = 9;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.ForeColor = System.Drawing.Color.White;
            this.DeleteBtn.Location = new System.Drawing.Point(16, 545);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(113, 26);
            this.DeleteBtn.TabIndex = 12;
            this.DeleteBtn.Text = "ნებართვის წაშლა";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Visible = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // registration_textBox
            // 
            this.registration_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.registration_textBox.Location = new System.Drawing.Point(16, 119);
            this.registration_textBox.Multiline = true;
            this.registration_textBox.Name = "registration_textBox";
            this.registration_textBox.Size = new System.Drawing.Size(422, 44);
            this.registration_textBox.TabIndex = 4;
            // 
            // fls_NEBARTVATableAdapter
            // 
            this.fls_NEBARTVATableAdapter.ClearBeforeFill = true;
            // 
            // fls_LICENCE_FREQBindingSource
            // 
            this.fls_LICENCE_FREQBindingSource.DataMember = "fls_LICENCE_FREQ";
            this.fls_LICENCE_FREQBindingSource.DataSource = this.officeDataSet;
            // 
            // fls_LICENCE_FREQTableAdapter
            // 
            this.fls_LICENCE_FREQTableAdapter.ClearBeforeFill = true;
            // 
            // frmNebartva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 585);
            this.Controls.Add(this.registration_textBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.expiry_textBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.issue_textBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(numberLabel);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(saxeLabel);
            this.Controls.Add(this.saxeTextBox);
            this.Controls.Add(f_spectrumLabel);
            this.Controls.Add(this.f_spectrumTextBox);
            this.Controls.Add(geo_zoneLabel);
            this.Controls.Add(this.geo_zoneTextBox);
            this.Controls.Add(pirobebiLabel);
            this.Controls.Add(this.pirobebiTextBox);
            this.Controls.Add(issue_dateLabel);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "frmNebartva";
            this.Opacity = 0.95;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "სანებართვო მოწმობა";
            this.Load += new System.EventHandler(this.frmNebartva_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNebartva_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fls_NEBARTVABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fls_LICENCE_FREQBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource fls_NEBARTVABindingSource;
        private DataBase.OfficeDataSetTableAdapters.fls_NEBARTVATableAdapter fls_NEBARTVATableAdapter;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox saxeTextBox;
        private System.Windows.Forms.TextBox f_spectrumTextBox;
        private System.Windows.Forms.TextBox geo_zoneTextBox;
        private System.Windows.Forms.TextBox pirobebiTextBox;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.TextBox issue_textBox;
        private System.Windows.Forms.BindingSource fls_LICENCE_FREQBindingSource;
        private DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter fls_LICENCE_FREQTableAdapter;
        private System.Windows.Forms.TextBox expiry_textBox;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TextBox registration_textBox;
    }
}