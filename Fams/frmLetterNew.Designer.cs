namespace Fams
{
    partial class frmLetterNew
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
            System.Windows.Forms.Label receivedLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.receivedDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.remTextBox = new System.Windows.Forms.TextBox();
            this.comp_combo = new System.Windows.Forms.ComboBox();
            this.fls_COMPANY_INFOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.fls_COMPANY_INFOTableAdapter = new DataBase.OfficeDataSetTableAdapters.fls_COMPANY_INFOTableAdapter();
            this.isReceived = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.isPayedCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.acc_WorkflowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acc_WorkflowTableAdapter = new DataBase.OfficeDataSetTableAdapters.acc_WorkflowTableAdapter();
            this.worklowCombo = new System.Windows.Forms.ComboBox();
            this.AnotationTextBox = new System.Windows.Forms.TextBox();
            this.whosignedTextBox = new System.Windows.Forms.TextBox();
            this.receiverrdTextBox = new System.Windows.Forms.TextBox();
            this.resolutionTextBox = new System.Windows.Forms.TextBox();
            numberLabel = new System.Windows.Forms.Label();
            receivedLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fls_COMPANY_INFOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acc_WorkflowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // numberLabel
            // 
            numberLabel.AutoSize = true;
            numberLabel.Location = new System.Drawing.Point(6, 136);
            numberLabel.Name = "numberLabel";
            numberLabel.Size = new System.Drawing.Size(105, 14);
            numberLabel.TabIndex = 3;
            numberLabel.Text = "წერილის ნომერი:";
            // 
            // receivedLabel
            // 
            receivedLabel.AutoSize = true;
            receivedLabel.Location = new System.Drawing.Point(125, 136);
            receivedLabel.Name = "receivedLabel";
            receivedLabel.Size = new System.Drawing.Size(114, 14);
            receivedLabel.TabIndex = 5;
            receivedLabel.Text = "გატარების თარიღი:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 191);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(146, 14);
            label1.TabIndex = 7;
            label1.Text = "დამატებითი ინფორმაცია:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.Location = new System.Drawing.Point(8, 82);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(170, 14);
            label3.TabIndex = 21;
            label3.Text = "მიმდინარე მდგომარეობა:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(9, 288);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(61, 14);
            label4.TabIndex = 22;
            label4.Text = "ანოტაცია:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 316);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(74, 14);
            label5.TabIndex = 24;
            label5.Text = "ხელს აწერს:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(9, 344);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(56, 14);
            label6.TabIndex = 26;
            label6.Text = "დაეწერა:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(9, 395);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(79, 14);
            label7.TabIndex = 28;
            label7.Text = "რეზოლუცია:";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Enabled = false;
            this.numberTextBox.Location = new System.Drawing.Point(9, 153);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(102, 22);
            this.numberTextBox.TabIndex = 3;
            // 
            // receivedDateTimePicker
            // 
            this.receivedDateTimePicker.Enabled = false;
            this.receivedDateTimePicker.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.receivedDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.receivedDateTimePicker.Location = new System.Drawing.Point(128, 153);
            this.receivedDateTimePicker.MaxDate = new System.DateTime(2015, 12, 31, 0, 0, 0, 0);
            this.receivedDateTimePicker.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.receivedDateTimePicker.Name = "receivedDateTimePicker";
            this.receivedDateTimePicker.Size = new System.Drawing.Size(217, 22);
            this.receivedDateTimePicker.TabIndex = 4;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(144, 475);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(97, 26);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "გაუქმება";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Enabled = false;
            this.OKBtn.Location = new System.Drawing.Point(247, 475);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(98, 26);
            this.OKBtn.TabIndex = 7;
            this.OKBtn.Text = "მზადაა";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // remTextBox
            // 
            this.remTextBox.Location = new System.Drawing.Point(9, 213);
            this.remTextBox.Multiline = true;
            this.remTextBox.Name = "remTextBox";
            this.remTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.remTextBox.Size = new System.Drawing.Size(336, 66);
            this.remTextBox.TabIndex = 5;
            // 
            // comp_combo
            // 
            this.comp_combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comp_combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comp_combo.DataSource = this.fls_COMPANY_INFOBindingSource;
            this.comp_combo.DisplayMember = "Comp_Name";
            this.comp_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comp_combo.Enabled = false;
            this.comp_combo.FormattingEnabled = true;
            this.comp_combo.Location = new System.Drawing.Point(9, 26);
            this.comp_combo.Name = "comp_combo";
            this.comp_combo.Size = new System.Drawing.Size(336, 22);
            this.comp_combo.TabIndex = 0;
            this.comp_combo.ValueMember = "id";
            this.comp_combo.TextChanged += new System.EventHandler(this.comp_combo_TextChanged);
            this.comp_combo.Leave += new System.EventHandler(this.comp_combo_Leave);
            // 
            // fls_COMPANY_INFOBindingSource
            // 
            this.fls_COMPANY_INFOBindingSource.DataMember = "fls_COMPANY_INFO";
            this.fls_COMPANY_INFOBindingSource.DataSource = this.officeDataSet;
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fls_COMPANY_INFOTableAdapter
            // 
            this.fls_COMPANY_INFOTableAdapter.ClearBeforeFill = true;
            // 
            // isReceived
            // 
            this.isReceived.AutoSize = true;
            this.isReceived.Enabled = false;
            this.isReceived.Location = new System.Drawing.Point(9, 54);
            this.isReceived.Name = "isReceived";
            this.isReceived.Size = new System.Drawing.Size(175, 18);
            this.isReceived.TabIndex = 1;
            this.isReceived.Text = "ეს არის მიღებული წერილი";
            this.isReceived.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "ორგანიზაცია:";
            // 
            // isPayedCheckBox
            // 
            this.isPayedCheckBox.AutoSize = true;
            this.isPayedCheckBox.Location = new System.Drawing.Point(9, 485);
            this.isPayedCheckBox.Name = "isPayedCheckBox";
            this.isPayedCheckBox.Size = new System.Drawing.Size(15, 14);
            this.isPayedCheckBox.TabIndex = 6;
            this.isPayedCheckBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fams.Properties.Resources.money;
            this.pictureBox1.Location = new System.Drawing.Point(25, 483);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 18);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // acc_WorkflowBindingSource
            // 
            this.acc_WorkflowBindingSource.DataMember = "acc_Workflow";
            this.acc_WorkflowBindingSource.DataSource = this.officeDataSet;
            // 
            // acc_WorkflowTableAdapter
            // 
            this.acc_WorkflowTableAdapter.ClearBeforeFill = true;
            // 
            // worklowCombo
            // 
            this.worklowCombo.DataSource = this.acc_WorkflowBindingSource;
            this.worklowCombo.DisplayMember = "workflow";
            this.worklowCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.worklowCombo.FormattingEnabled = true;
            this.worklowCombo.Location = new System.Drawing.Point(9, 99);
            this.worklowCombo.Name = "worklowCombo";
            this.worklowCombo.Size = new System.Drawing.Size(336, 22);
            this.worklowCombo.TabIndex = 1;
            this.worklowCombo.ValueMember = "id";
            // 
            // AnotationTextBox
            // 
            this.AnotationTextBox.Enabled = false;
            this.AnotationTextBox.Location = new System.Drawing.Point(76, 285);
            this.AnotationTextBox.Name = "AnotationTextBox";
            this.AnotationTextBox.Size = new System.Drawing.Size(269, 22);
            this.AnotationTextBox.TabIndex = 23;
            // 
            // whosignedTextBox
            // 
            this.whosignedTextBox.Enabled = false;
            this.whosignedTextBox.Location = new System.Drawing.Point(92, 313);
            this.whosignedTextBox.Name = "whosignedTextBox";
            this.whosignedTextBox.Size = new System.Drawing.Size(253, 22);
            this.whosignedTextBox.TabIndex = 25;
            // 
            // receiverrdTextBox
            // 
            this.receiverrdTextBox.Enabled = false;
            this.receiverrdTextBox.Location = new System.Drawing.Point(76, 341);
            this.receiverrdTextBox.Multiline = true;
            this.receiverrdTextBox.Name = "receiverrdTextBox";
            this.receiverrdTextBox.Size = new System.Drawing.Size(269, 45);
            this.receiverrdTextBox.TabIndex = 27;
            // 
            // resolutionTextBox
            // 
            this.resolutionTextBox.Enabled = false;
            this.resolutionTextBox.Location = new System.Drawing.Point(92, 392);
            this.resolutionTextBox.Multiline = true;
            this.resolutionTextBox.Name = "resolutionTextBox";
            this.resolutionTextBox.Size = new System.Drawing.Size(253, 75);
            this.resolutionTextBox.TabIndex = 29;
            // 
            // frmLetterNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 509);
            this.Controls.Add(label7);
            this.Controls.Add(this.resolutionTextBox);
            this.Controls.Add(label6);
            this.Controls.Add(this.receiverrdTextBox);
            this.Controls.Add(label5);
            this.Controls.Add(this.whosignedTextBox);
            this.Controls.Add(label4);
            this.Controls.Add(this.AnotationTextBox);
            this.Controls.Add(this.worklowCombo);
            this.Controls.Add(label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.isPayedCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.isReceived);
            this.Controls.Add(this.comp_combo);
            this.Controls.Add(label1);
            this.Controls.Add(this.remTextBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(numberLabel);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(receivedLabel);
            this.Controls.Add(this.receivedDateTimePicker);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLetterNew";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " შემოსული წერილი";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLetter_FormClosing);
            this.Load += new System.EventHandler(this.frmLetter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fls_COMPANY_INFOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acc_WorkflowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.DateTimePicker receivedDateTimePicker;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.TextBox remTextBox;
        private System.Windows.Forms.ComboBox comp_combo;
        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource fls_COMPANY_INFOBindingSource;
        private DataBase.OfficeDataSetTableAdapters.fls_COMPANY_INFOTableAdapter fls_COMPANY_INFOTableAdapter;
        private System.Windows.Forms.CheckBox isReceived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox isPayedCheckBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource acc_WorkflowBindingSource;
        private DataBase.OfficeDataSetTableAdapters.acc_WorkflowTableAdapter acc_WorkflowTableAdapter;
        private System.Windows.Forms.ComboBox worklowCombo;
        private System.Windows.Forms.TextBox AnotationTextBox;
        private System.Windows.Forms.TextBox whosignedTextBox;
        private System.Windows.Forms.TextBox receiverrdTextBox;
        private System.Windows.Forms.TextBox resolutionTextBox;
    }
}