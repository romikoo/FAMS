namespace Fams
{
    partial class frmRelFreqAllocValidity
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
            this.okBtn = new System.Windows.Forms.Button();
            this.ABox = new System.Windows.Forms.ListBox();
            this.BBox = new System.Windows.Forms.ListBox();
            this.Alabel = new System.Windows.Forms.Label();
            this.Blabel = new System.Windows.Forms.Label();
            this.AText = new System.Windows.Forms.Label();
            this.BText = new System.Windows.Forms.Label();
            this.a_saveBtn = new System.Windows.Forms.Button();
            this.b_saveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Location = new System.Drawing.Point(763, 186);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(41, 41);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // ABox
            // 
            this.ABox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ABox.FormattingEnabled = true;
            this.ABox.Location = new System.Drawing.Point(12, 46);
            this.ABox.Name = "ABox";
            this.ABox.Size = new System.Drawing.Size(432, 134);
            this.ABox.TabIndex = 1;
            this.ABox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Box_DrawItem);
            this.ABox.SelectedIndexChanged += new System.EventHandler(this.Box_SelectedIndexChanged);
            // 
            // BBox
            // 
            this.BBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BBox.FormattingEnabled = true;
            this.BBox.Location = new System.Drawing.Point(467, 46);
            this.BBox.Name = "BBox";
            this.BBox.Size = new System.Drawing.Size(432, 134);
            this.BBox.TabIndex = 2;
            this.BBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.Box_DrawItem);
            this.BBox.SelectedIndexChanged += new System.EventHandler(this.Box_SelectedIndexChanged);
            // 
            // Alabel
            // 
            this.Alabel.AutoSize = true;
            this.Alabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Alabel.Location = new System.Drawing.Point(12, 24);
            this.Alabel.Name = "Alabel";
            this.Alabel.Size = new System.Drawing.Size(51, 16);
            this.Alabel.TabIndex = 3;
            this.Alabel.Text = "label1";
            // 
            // Blabel
            // 
            this.Blabel.AutoSize = true;
            this.Blabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Blabel.Location = new System.Drawing.Point(464, 24);
            this.Blabel.Name = "Blabel";
            this.Blabel.Size = new System.Drawing.Size(51, 16);
            this.Blabel.TabIndex = 4;
            this.Blabel.Text = "label1";
            // 
            // AText
            // 
            this.AText.AutoSize = true;
            this.AText.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AText.Location = new System.Drawing.Point(12, 5);
            this.AText.Name = "AText";
            this.AText.Size = new System.Drawing.Size(40, 18);
            this.AText.TabIndex = 5;
            this.AText.Text = "label1";
            // 
            // BText
            // 
            this.BText.AutoSize = true;
            this.BText.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BText.Location = new System.Drawing.Point(464, 5);
            this.BText.Name = "BText";
            this.BText.Size = new System.Drawing.Size(40, 18);
            this.BText.TabIndex = 6;
            this.BText.Text = "label1";
            // 
            // a_saveBtn
            // 
            this.a_saveBtn.Enabled = false;
            this.a_saveBtn.Image = global::Fams.Properties.Resources.down;
            this.a_saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.a_saveBtn.Location = new System.Drawing.Point(324, 5);
            this.a_saveBtn.Name = "a_saveBtn";
            this.a_saveBtn.Size = new System.Drawing.Size(120, 37);
            this.a_saveBtn.TabIndex = 7;
            this.a_saveBtn.Text = "A სიხშირის შეცვლა";
            this.a_saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.a_saveBtn.UseVisualStyleBackColor = true;
            this.a_saveBtn.Click += new System.EventHandler(this.a_saveBtn_Click);
            // 
            // b_saveBtn
            // 
            this.b_saveBtn.Enabled = false;
            this.b_saveBtn.Image = global::Fams.Properties.Resources.down;
            this.b_saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.b_saveBtn.Location = new System.Drawing.Point(779, 5);
            this.b_saveBtn.Name = "b_saveBtn";
            this.b_saveBtn.Size = new System.Drawing.Size(120, 37);
            this.b_saveBtn.TabIndex = 8;
            this.b_saveBtn.Text = "B სიხშირის შეცვლა";
            this.b_saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.b_saveBtn.UseVisualStyleBackColor = true;
            this.b_saveBtn.Click += new System.EventHandler(this.b_saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(169, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 68);
            this.label1.TabIndex = 9;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(656, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 68);
            this.label2.TabIndex = 10;
            this.label2.Text = "B";
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(810, 186);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(89, 41);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // frmRelFreqAllocValidity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(912, 233);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.b_saveBtn);
            this.Controls.Add(this.a_saveBtn);
            this.Controls.Add(this.BText);
            this.Controls.Add(this.AText);
            this.Controls.Add(this.Blabel);
            this.Controls.Add(this.Alabel);
            this.Controls.Add(this.BBox);
            this.Controls.Add(this.ABox);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelFreqAllocValidity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "სიხშირეების შემოწმება გეგმის მიხედვით";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ListBox ABox;
        private System.Windows.Forms.ListBox BBox;
        private System.Windows.Forms.Label Alabel;
        private System.Windows.Forms.Label Blabel;
        private System.Windows.Forms.Label AText;
        private System.Windows.Forms.Label BText;
        private System.Windows.Forms.Button a_saveBtn;
        private System.Windows.Forms.Button b_saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelBtn;
    }
}