namespace Fams
{
    partial class frmEditLicence
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.endText = new System.Windows.Forms.TextBox();
            this.IssueText = new System.Windows.Forms.TextBox();
            this.lICENCELabel = new System.Windows.Forms.Label();
            this.LicText = new System.Windows.Forms.TextBox();
            this.lIC_ISSU_DATELabel = new System.Windows.Forms.Label();
            this.lIC_EXPIRY_DATELabel = new System.Windows.Forms.Label();
            this.remText = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(19, 180);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(97, 24);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "გაუქმება";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(122, 180);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(98, 24);
            this.OKBtn.TabIndex = 3;
            this.OKBtn.Text = "მზადაა";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // endText
            // 
            this.endText.Location = new System.Drawing.Point(6, 109);
            this.endText.Name = "endText";
            this.endText.Size = new System.Drawing.Size(121, 22);
            this.endText.TabIndex = 2;
            this.endText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.endText_KeyUp);
            // 
            // IssueText
            // 
            this.IssueText.Location = new System.Drawing.Point(6, 67);
            this.IssueText.Name = "IssueText";
            this.IssueText.Size = new System.Drawing.Size(118, 22);
            this.IssueText.TabIndex = 1;
            this.IssueText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IssueText_KeyUp);
            // 
            // lICENCELabel
            // 
            this.lICENCELabel.AutoSize = true;
            this.lICENCELabel.Location = new System.Drawing.Point(3, 8);
            this.lICENCELabel.Name = "lICENCELabel";
            this.lICENCELabel.Size = new System.Drawing.Size(52, 14);
            this.lICENCELabel.TabIndex = 58;
            this.lICENCELabel.Text = "ნომერი:";
            // 
            // LicText
            // 
            this.LicText.Location = new System.Drawing.Point(6, 25);
            this.LicText.Name = "LicText";
            this.LicText.Size = new System.Drawing.Size(194, 22);
            this.LicText.TabIndex = 0;
            // 
            // lIC_ISSU_DATELabel
            // 
            this.lIC_ISSU_DATELabel.AutoSize = true;
            this.lIC_ISSU_DATELabel.Location = new System.Drawing.Point(3, 50);
            this.lIC_ISSU_DATELabel.Name = "lIC_ISSU_DATELabel";
            this.lIC_ISSU_DATELabel.Size = new System.Drawing.Size(99, 14);
            this.lIC_ISSU_DATELabel.TabIndex = 61;
            this.lIC_ISSU_DATELabel.Text = "გაცემის თარიღი:";
            // 
            // lIC_EXPIRY_DATELabel
            // 
            this.lIC_EXPIRY_DATELabel.AutoSize = true;
            this.lIC_EXPIRY_DATELabel.Location = new System.Drawing.Point(3, 92);
            this.lIC_EXPIRY_DATELabel.Name = "lIC_EXPIRY_DATELabel";
            this.lIC_EXPIRY_DATELabel.Size = new System.Drawing.Size(197, 14);
            this.lIC_EXPIRY_DATELabel.TabIndex = 64;
            this.lIC_EXPIRY_DATELabel.Text = "მოქმედების დასრულების თარიღი:";
            // 
            // remText
            // 
            this.remText.Location = new System.Drawing.Point(6, 6);
            this.remText.Multiline = true;
            this.remText.Name = "remText";
            this.remText.Size = new System.Drawing.Size(196, 131);
            this.remText.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(216, 170);
            this.tabControl1.TabIndex = 77;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.endText);
            this.tabPage1.Controls.Add(this.lIC_EXPIRY_DATELabel);
            this.tabPage1.Controls.Add(this.lIC_ISSU_DATELabel);
            this.tabPage1.Controls.Add(this.IssueText);
            this.tabPage1.Controls.Add(this.LicText);
            this.tabPage1.Controls.Add(this.lICENCELabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(208, 143);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ინფორმაცია";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.remText);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(208, 143);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "შენიშვნა";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmEditLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(223, 211);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ლიცენზია / ნებართვა";
            this.Load += new System.EventHandler(this.frmLicence_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLicence_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.TextBox endText;
        private System.Windows.Forms.TextBox IssueText;
        private System.Windows.Forms.Label lICENCELabel;
        private System.Windows.Forms.TextBox LicText;
        private System.Windows.Forms.Label lIC_ISSU_DATELabel;
        private System.Windows.Forms.Label lIC_EXPIRY_DATELabel;
        private System.Windows.Forms.TextBox remText;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}