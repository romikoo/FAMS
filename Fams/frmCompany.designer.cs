namespace Fams
{
    partial class frmCompany
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.receivedEdit = new Janus.Windows.GridEX.EditControls.EditBox();
            this.has_NO_FREQLabel = new System.Windows.Forms.Label();
            this.has_NO_FREQCheckBox = new System.Windows.Forms.CheckBox();
            this.rEC_FormLabel1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CompAccountCombo = new System.Windows.Forms.ComboBox();
            this.cOMBOCompAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.gaveDateText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label8 = new System.Windows.Forms.Label();
            this.remText = new System.Windows.Forms.TextBox();
            this.sentDateText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TaxCodeText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comp_mailText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.comp_webText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.comp_MailLabel = new System.Windows.Forms.Label();
            this.comp_URLLabel = new System.Windows.Forms.Label();
            this.comp_faxText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.comp_phone_text = new Janus.Windows.GridEX.EditControls.EditBox();
            this.comp_indexText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.comp_addressText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.comp_NameTextBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.comp_NameLabel = new System.Windows.Forms.Label();
            this.comp_AddressLabel = new System.Windows.Forms.Label();
            this.comp_CityLabel = new System.Windows.Forms.Label();
            this.comp_IndexLabel = new System.Windows.Forms.Label();
            this.comp_TelLabel = new System.Windows.Forms.Label();
            this.comp_FaxLabel = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Chief_Position = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Chief = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label9 = new System.Windows.Forms.Label();
            this.faxText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.phoneText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.indexText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.addressText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nameText = new Janus.Windows.GridEX.EditControls.EditBox();
            this.cONTACT_NAMELabel = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.cOMBO_CompAccountTableAdapter = new DataBase.OfficeDataSetTableAdapters.COMBO_CompAccountTableAdapter();
            this.Comp_CityCombo = new System.Windows.Forms.ComboBox();
            this.zoneCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zone_CityTableAdapter = new DataBase.OfficeDataSetTableAdapters.Zone_CityTableAdapter();
            this.Cont_CityCombo = new System.Windows.Forms.ComboBox();
            this.zoneCityBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOMBOCompAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoneCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneCityBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(279, 348);
            this.tabControl1.TabIndex = 80;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.receivedEdit);
            this.tabPage3.Controls.Add(this.has_NO_FREQLabel);
            this.tabPage3.Controls.Add(this.has_NO_FREQCheckBox);
            this.tabPage3.Controls.Add(this.rEC_FormLabel1);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.CompAccountCombo);
            this.tabPage3.Controls.Add(this.gaveDateText);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.remText);
            this.tabPage3.Controls.Add(this.sentDateText);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.TaxCodeText);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(271, 321);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ზოგადი";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // receivedEdit
            // 
            this.receivedEdit.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.receivedEdit.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.receivedEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivedEdit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.receivedEdit.Location = new System.Drawing.Point(137, 145);
            this.receivedEdit.Name = "receivedEdit";
            this.receivedEdit.Size = new System.Drawing.Size(105, 20);
            this.receivedEdit.TabIndex = 138;
            this.receivedEdit.Text = "editBox1";
            this.receivedEdit.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.receivedEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.receivedEdit_KeyUp);
            // 
            // has_NO_FREQLabel
            // 
            this.has_NO_FREQLabel.AutoSize = true;
            this.has_NO_FREQLabel.Location = new System.Drawing.Point(91, 117);
            this.has_NO_FREQLabel.Name = "has_NO_FREQLabel";
            this.has_NO_FREQLabel.Size = new System.Drawing.Size(120, 14);
            this.has_NO_FREQLabel.TabIndex = 136;
            this.has_NO_FREQLabel.Text = "სიხშირეს არ იყენებს";
            // 
            // has_NO_FREQCheckBox
            // 
            this.has_NO_FREQCheckBox.AutoSize = true;
            this.has_NO_FREQCheckBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.has_NO_FREQCheckBox.Location = new System.Drawing.Point(53, 117);
            this.has_NO_FREQCheckBox.Name = "has_NO_FREQCheckBox";
            this.has_NO_FREQCheckBox.Size = new System.Drawing.Size(15, 14);
            this.has_NO_FREQCheckBox.TabIndex = 137;
            this.has_NO_FREQCheckBox.UseVisualStyleBackColor = false;
            // 
            // rEC_FormLabel1
            // 
            this.rEC_FormLabel1.AutoSize = true;
            this.rEC_FormLabel1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.rEC_FormLabel1.Location = new System.Drawing.Point(23, 148);
            this.rEC_FormLabel1.Name = "rEC_FormLabel1";
            this.rEC_FormLabel1.Size = new System.Drawing.Size(108, 14);
            this.rEC_FormLabel1.TabIndex = 129;
            this.rEC_FormLabel1.Text = "მიღებულია ანკეტა";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 14);
            this.label7.TabIndex = 135;
            this.label7.Text = "ორგანიზაციის ტიპი:";
            // 
            // CompAccountCombo
            // 
            this.CompAccountCombo.DataSource = this.cOMBOCompAccountBindingSource;
            this.CompAccountCombo.DisplayMember = "GName";
            this.CompAccountCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompAccountCombo.FormattingEnabled = true;
            this.CompAccountCombo.Location = new System.Drawing.Point(26, 77);
            this.CompAccountCombo.Name = "CompAccountCombo";
            this.CompAccountCombo.Size = new System.Drawing.Size(215, 22);
            this.CompAccountCombo.TabIndex = 134;
            this.CompAccountCombo.ValueMember = "id";
            // 
            // cOMBOCompAccountBindingSource
            // 
            this.cOMBOCompAccountBindingSource.DataMember = "COMBO_CompAccount";
            this.cOMBOCompAccountBindingSource.DataSource = this.officeDataSet;
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gaveDateText
            // 
            this.gaveDateText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.gaveDateText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.gaveDateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gaveDateText.Location = new System.Drawing.Point(136, 197);
            this.gaveDateText.Name = "gaveDateText";
            this.gaveDateText.Size = new System.Drawing.Size(105, 20);
            this.gaveDateText.TabIndex = 6;
            this.gaveDateText.Text = "editBox1";
            this.gaveDateText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.gaveDateText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gaveDateText_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 14);
            this.label8.TabIndex = 133;
            this.label8.Text = "გადაეცა ანკეტა:";
            // 
            // remText
            // 
            this.remText.Location = new System.Drawing.Point(26, 225);
            this.remText.Multiline = true;
            this.remText.Name = "remText";
            this.remText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.remText.Size = new System.Drawing.Size(215, 84);
            this.remText.TabIndex = 7;
            // 
            // sentDateText
            // 
            this.sentDateText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.sentDateText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.sentDateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sentDateText.Location = new System.Drawing.Point(136, 171);
            this.sentDateText.Name = "sentDateText";
            this.sentDateText.Size = new System.Drawing.Size(105, 20);
            this.sentDateText.TabIndex = 5;
            this.sentDateText.Text = "editBox1";
            this.sentDateText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.sentDateText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sentDateText_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 127;
            this.label1.Text = "გაეგზავნა ანკეტა:";
            // 
            // TaxCodeText
            // 
            this.TaxCodeText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.TaxCodeText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.TaxCodeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TaxCodeText.Location = new System.Drawing.Point(26, 29);
            this.TaxCodeText.Name = "TaxCodeText";
            this.TaxCodeText.Size = new System.Drawing.Size(215, 20);
            this.TaxCodeText.TabIndex = 0;
            this.TaxCodeText.Text = "editBox1";
            this.TaxCodeText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 14);
            this.label18.TabIndex = 122;
            this.label18.Text = "საგად.  კოდი:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Comp_CityCombo);
            this.tabPage1.Controls.Add(this.comp_mailText);
            this.tabPage1.Controls.Add(this.comp_webText);
            this.tabPage1.Controls.Add(this.comp_MailLabel);
            this.tabPage1.Controls.Add(this.comp_URLLabel);
            this.tabPage1.Controls.Add(this.comp_faxText);
            this.tabPage1.Controls.Add(this.comp_phone_text);
            this.tabPage1.Controls.Add(this.comp_indexText);
            this.tabPage1.Controls.Add(this.comp_addressText);
            this.tabPage1.Controls.Add(this.comp_NameTextBox);
            this.tabPage1.Controls.Add(this.comp_NameLabel);
            this.tabPage1.Controls.Add(this.comp_AddressLabel);
            this.tabPage1.Controls.Add(this.comp_CityLabel);
            this.tabPage1.Controls.Add(this.comp_IndexLabel);
            this.tabPage1.Controls.Add(this.comp_TelLabel);
            this.tabPage1.Controls.Add(this.comp_FaxLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(271, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ორგანიზაცია";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comp_mailText
            // 
            this.comp_mailText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.comp_mailText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.comp_mailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_mailText.Location = new System.Drawing.Point(22, 279);
            this.comp_mailText.Name = "comp_mailText";
            this.comp_mailText.Size = new System.Drawing.Size(221, 20);
            this.comp_mailText.TabIndex = 7;
            this.comp_mailText.Text = "editBox14";
            this.comp_mailText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // comp_webText
            // 
            this.comp_webText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.comp_webText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.comp_webText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_webText.Location = new System.Drawing.Point(22, 236);
            this.comp_webText.Name = "comp_webText";
            this.comp_webText.Size = new System.Drawing.Size(221, 20);
            this.comp_webText.TabIndex = 6;
            this.comp_webText.Text = "editBox13";
            this.comp_webText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // comp_MailLabel
            // 
            this.comp_MailLabel.AutoSize = true;
            this.comp_MailLabel.Location = new System.Drawing.Point(20, 261);
            this.comp_MailLabel.Name = "comp_MailLabel";
            this.comp_MailLabel.Size = new System.Drawing.Size(69, 14);
            this.comp_MailLabel.TabIndex = 118;
            this.comp_MailLabel.Text = "ელ. ფოსტა:";
            // 
            // comp_URLLabel
            // 
            this.comp_URLLabel.AutoSize = true;
            this.comp_URLLabel.Location = new System.Drawing.Point(19, 219);
            this.comp_URLLabel.Name = "comp_URLLabel";
            this.comp_URLLabel.Size = new System.Drawing.Size(89, 14);
            this.comp_URLLabel.TabIndex = 117;
            this.comp_URLLabel.Text = "ვებ მისამართი:";
            // 
            // comp_faxText
            // 
            this.comp_faxText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.comp_faxText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.comp_faxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_faxText.Location = new System.Drawing.Point(22, 196);
            this.comp_faxText.Name = "comp_faxText";
            this.comp_faxText.Size = new System.Drawing.Size(221, 20);
            this.comp_faxText.TabIndex = 5;
            this.comp_faxText.Text = "editBox7";
            this.comp_faxText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // comp_phone_text
            // 
            this.comp_phone_text.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.comp_phone_text.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.comp_phone_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comp_phone_text.Location = new System.Drawing.Point(22, 154);
            this.comp_phone_text.Name = "comp_phone_text";
            this.comp_phone_text.Size = new System.Drawing.Size(221, 20);
            this.comp_phone_text.TabIndex = 4;
            this.comp_phone_text.Text = "editBox6";
            this.comp_phone_text.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // comp_indexText
            // 
            this.comp_indexText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.comp_indexText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.comp_indexText.Location = new System.Drawing.Point(168, 70);
            this.comp_indexText.Name = "comp_indexText";
            this.comp_indexText.Size = new System.Drawing.Size(75, 22);
            this.comp_indexText.TabIndex = 2;
            this.comp_indexText.Text = "editBox5";
            this.comp_indexText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // comp_addressText
            // 
            this.comp_addressText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.comp_addressText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.comp_addressText.Location = new System.Drawing.Point(22, 112);
            this.comp_addressText.Name = "comp_addressText";
            this.comp_addressText.Size = new System.Drawing.Size(221, 22);
            this.comp_addressText.TabIndex = 3;
            this.comp_addressText.Text = "editBox3";
            this.comp_addressText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // comp_NameTextBox
            // 
            this.comp_NameTextBox.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.comp_NameTextBox.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.comp_NameTextBox.Location = new System.Drawing.Point(22, 27);
            this.comp_NameTextBox.Name = "comp_NameTextBox";
            this.comp_NameTextBox.Size = new System.Drawing.Size(221, 22);
            this.comp_NameTextBox.TabIndex = 0;
            this.comp_NameTextBox.Text = "editBox1";
            this.comp_NameTextBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // comp_NameLabel
            // 
            this.comp_NameLabel.AutoSize = true;
            this.comp_NameLabel.Location = new System.Drawing.Point(19, 10);
            this.comp_NameLabel.Name = "comp_NameLabel";
            this.comp_NameLabel.Size = new System.Drawing.Size(75, 14);
            this.comp_NameLabel.TabIndex = 100;
            this.comp_NameLabel.Text = "დასახელება:";
            // 
            // comp_AddressLabel
            // 
            this.comp_AddressLabel.AutoSize = true;
            this.comp_AddressLabel.Location = new System.Drawing.Point(19, 95);
            this.comp_AddressLabel.Name = "comp_AddressLabel";
            this.comp_AddressLabel.Size = new System.Drawing.Size(68, 14);
            this.comp_AddressLabel.TabIndex = 102;
            this.comp_AddressLabel.Text = "მისამართი:";
            // 
            // comp_CityLabel
            // 
            this.comp_CityLabel.AutoSize = true;
            this.comp_CityLabel.Location = new System.Drawing.Point(19, 53);
            this.comp_CityLabel.Name = "comp_CityLabel";
            this.comp_CityLabel.Size = new System.Drawing.Size(47, 14);
            this.comp_CityLabel.TabIndex = 103;
            this.comp_CityLabel.Text = "ქალაქი:";
            // 
            // comp_IndexLabel
            // 
            this.comp_IndexLabel.AutoSize = true;
            this.comp_IndexLabel.Location = new System.Drawing.Point(165, 53);
            this.comp_IndexLabel.Name = "comp_IndexLabel";
            this.comp_IndexLabel.Size = new System.Drawing.Size(54, 14);
            this.comp_IndexLabel.TabIndex = 104;
            this.comp_IndexLabel.Text = "ინდექსი:";
            // 
            // comp_TelLabel
            // 
            this.comp_TelLabel.AutoSize = true;
            this.comp_TelLabel.Location = new System.Drawing.Point(19, 137);
            this.comp_TelLabel.Name = "comp_TelLabel";
            this.comp_TelLabel.Size = new System.Drawing.Size(70, 14);
            this.comp_TelLabel.TabIndex = 105;
            this.comp_TelLabel.Text = "ტელეფონი:";
            // 
            // comp_FaxLabel
            // 
            this.comp_FaxLabel.AutoSize = true;
            this.comp_FaxLabel.Location = new System.Drawing.Point(19, 179);
            this.comp_FaxLabel.Name = "comp_FaxLabel";
            this.comp_FaxLabel.Size = new System.Drawing.Size(40, 14);
            this.comp_FaxLabel.TabIndex = 106;
            this.comp_FaxLabel.Text = "ფაქსი:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.Cont_CityCombo);
            this.tabPage4.Controls.Add(this.Chief_Position);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.Chief);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.faxText);
            this.tabPage4.Controls.Add(this.phoneText);
            this.tabPage4.Controls.Add(this.indexText);
            this.tabPage4.Controls.Add(this.addressText);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.nameText);
            this.tabPage4.Controls.Add(this.cONTACT_NAMELabel);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(271, 321);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "საკონტაქტო";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Chief_Position
            // 
            this.Chief_Position.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.Chief_Position.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.Chief_Position.Location = new System.Drawing.Point(22, 287);
            this.Chief_Position.Name = "Chief_Position";
            this.Chief_Position.Size = new System.Drawing.Size(221, 22);
            this.Chief_Position.TabIndex = 124;
            this.Chief_Position.Text = "editBox2";
            this.Chief_Position.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 14);
            this.label10.TabIndex = 125;
            this.label10.Text = "თანამდებობა";
            // 
            // Chief
            // 
            this.Chief.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.Chief.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.Chief.Location = new System.Drawing.Point(22, 245);
            this.Chief.Name = "Chief";
            this.Chief.Size = new System.Drawing.Size(221, 22);
            this.Chief.TabIndex = 122;
            this.Chief.Text = "editBox2";
            this.Chief.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 14);
            this.label9.TabIndex = 123;
            this.label9.Text = "ხელმძღვანელი:";
            // 
            // faxText
            // 
            this.faxText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.faxText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.faxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faxText.Location = new System.Drawing.Point(22, 192);
            this.faxText.Name = "faxText";
            this.faxText.Size = new System.Drawing.Size(221, 20);
            this.faxText.TabIndex = 5;
            this.faxText.Text = "editBox8";
            this.faxText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // phoneText
            // 
            this.phoneText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.phoneText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.phoneText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneText.Location = new System.Drawing.Point(22, 153);
            this.phoneText.Name = "phoneText";
            this.phoneText.Size = new System.Drawing.Size(221, 20);
            this.phoneText.TabIndex = 4;
            this.phoneText.Text = "editBox9";
            this.phoneText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // indexText
            // 
            this.indexText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.indexText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.indexText.Location = new System.Drawing.Point(167, 71);
            this.indexText.Name = "indexText";
            this.indexText.Size = new System.Drawing.Size(76, 22);
            this.indexText.TabIndex = 2;
            this.indexText.Text = "editBox10";
            this.indexText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // addressText
            // 
            this.addressText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.addressText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.addressText.Location = new System.Drawing.Point(22, 113);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(221, 22);
            this.addressText.TabIndex = 3;
            this.addressText.Text = "editBox12";
            this.addressText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 117;
            this.label2.Text = "მისამართი:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 14);
            this.label3.TabIndex = 118;
            this.label3.Text = "ქალაქი:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 119;
            this.label4.Text = "ინდექსი:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 120;
            this.label5.Text = "ტელეფონი:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 14);
            this.label6.TabIndex = 121;
            this.label6.Text = "ფაქსი:";
            // 
            // nameText
            // 
            this.nameText.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.nameText.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.nameText.Location = new System.Drawing.Point(22, 29);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(221, 22);
            this.nameText.TabIndex = 0;
            this.nameText.Text = "editBox2";
            this.nameText.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            // 
            // cONTACT_NAMELabel
            // 
            this.cONTACT_NAMELabel.AutoSize = true;
            this.cONTACT_NAMELabel.Location = new System.Drawing.Point(19, 12);
            this.cONTACT_NAMELabel.Name = "cONTACT_NAMELabel";
            this.cONTACT_NAMELabel.Size = new System.Drawing.Size(88, 14);
            this.cONTACT_NAMELabel.TabIndex = 84;
            this.cONTACT_NAMELabel.Text = "გვარი, სახელი:";
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(69, 357);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(103, 26);
            this.CancelBtn.TabIndex = 79;
            this.CancelBtn.Text = "გაუქმება";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(178, 357);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(103, 26);
            this.OKBtn.TabIndex = 78;
            this.OKBtn.Text = "მზადაა";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // cOMBO_CompAccountTableAdapter
            // 
            this.cOMBO_CompAccountTableAdapter.ClearBeforeFill = true;
            // 
            // Comp_CityCombo
            // 
            this.Comp_CityCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Comp_CityCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Comp_CityCombo.DataSource = this.zoneCityBindingSource;
            this.Comp_CityCombo.DisplayMember = "city";
            this.Comp_CityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Comp_CityCombo.FormattingEnabled = true;
            this.Comp_CityCombo.Location = new System.Drawing.Point(23, 70);
            this.Comp_CityCombo.Name = "Comp_CityCombo";
            this.Comp_CityCombo.Size = new System.Drawing.Size(139, 22);
            this.Comp_CityCombo.TabIndex = 120;
            this.Comp_CityCombo.ValueMember = "id";
            // 
            // zoneCityBindingSource
            // 
            this.zoneCityBindingSource.DataMember = "Zone_City";
            this.zoneCityBindingSource.DataSource = this.officeDataSet;
            // 
            // zone_CityTableAdapter
            // 
            this.zone_CityTableAdapter.ClearBeforeFill = true;
            // 
            // Cont_CityCombo
            // 
            this.Cont_CityCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Cont_CityCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Cont_CityCombo.DataSource = this.zoneCityBindingSource1;
            this.Cont_CityCombo.DisplayMember = "city";
            this.Cont_CityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cont_CityCombo.FormattingEnabled = true;
            this.Cont_CityCombo.Location = new System.Drawing.Point(22, 71);
            this.Cont_CityCombo.Name = "Cont_CityCombo";
            this.Cont_CityCombo.Size = new System.Drawing.Size(139, 22);
            this.Cont_CityCombo.TabIndex = 127;
            this.Cont_CityCombo.ValueMember = "id";
            // 
            // zoneCityBindingSource1
            // 
            this.zoneCityBindingSource1.DataMember = "Zone_City";
            this.zoneCityBindingSource1.DataSource = this.officeDataSet;
            // 
            // frmCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(290, 390);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "კომპანიის დამატება/რედაქტირება";
            this.Load += new System.EventHandler(this.frmCompany_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCompany_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cOMBOCompAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoneCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneCityBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private Janus.Windows.GridEX.EditControls.EditBox comp_faxText;
        private Janus.Windows.GridEX.EditControls.EditBox comp_phone_text;
        private Janus.Windows.GridEX.EditControls.EditBox comp_indexText;
        private Janus.Windows.GridEX.EditControls.EditBox comp_addressText;
        private Janus.Windows.GridEX.EditControls.EditBox comp_NameTextBox;
        private System.Windows.Forms.Label comp_NameLabel;
        private System.Windows.Forms.Label comp_AddressLabel;
        private System.Windows.Forms.Label comp_CityLabel;
        private System.Windows.Forms.Label comp_IndexLabel;
        private System.Windows.Forms.Label comp_TelLabel;
        private System.Windows.Forms.Label comp_FaxLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private Janus.Windows.GridEX.EditControls.EditBox TaxCodeText;
        private System.Windows.Forms.Label label18;
        private Janus.Windows.GridEX.EditControls.EditBox sentDateText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private Janus.Windows.GridEX.EditControls.EditBox comp_mailText;
        private Janus.Windows.GridEX.EditControls.EditBox comp_webText;
        private System.Windows.Forms.Label comp_MailLabel;
        private System.Windows.Forms.Label comp_URLLabel;
        private Janus.Windows.GridEX.EditControls.EditBox faxText;
        private Janus.Windows.GridEX.EditControls.EditBox phoneText;
        private Janus.Windows.GridEX.EditControls.EditBox indexText;
        private Janus.Windows.GridEX.EditControls.EditBox addressText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Janus.Windows.GridEX.EditControls.EditBox nameText;
        private System.Windows.Forms.Label cONTACT_NAMELabel;
        private System.Windows.Forms.Label rEC_FormLabel1;
        private System.Windows.Forms.TextBox remText;
        private Janus.Windows.GridEX.EditControls.EditBox gaveDateText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox CompAccountCombo;
        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource cOMBOCompAccountBindingSource;
        private DataBase.OfficeDataSetTableAdapters.COMBO_CompAccountTableAdapter cOMBO_CompAccountTableAdapter;
        private System.Windows.Forms.Label label7;
        private Janus.Windows.GridEX.EditControls.EditBox receivedEdit;
        private System.Windows.Forms.Label has_NO_FREQLabel;
        private System.Windows.Forms.CheckBox has_NO_FREQCheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox Chief_Position;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.GridEX.EditControls.EditBox Chief;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Comp_CityCombo;
        private System.Windows.Forms.BindingSource zoneCityBindingSource;
        private DataBase.OfficeDataSetTableAdapters.Zone_CityTableAdapter zone_CityTableAdapter;
        private System.Windows.Forms.ComboBox Cont_CityCombo;
        private System.Windows.Forms.BindingSource zoneCityBindingSource1;
    }
}