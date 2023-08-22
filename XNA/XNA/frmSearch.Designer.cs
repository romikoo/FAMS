namespace XNA
{
    partial class frmSearch
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
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.FilterText = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshBtn.ForeColor = System.Drawing.Color.White;
            this.RefreshBtn.Location = new System.Drawing.Point(78, 41);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(75, 25);
            this.RefreshBtn.TabIndex = 13;
            this.RefreshBtn.Text = "განახლება";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // FilterBtn
            // 
            this.FilterBtn.Enabled = false;
            this.FilterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FilterBtn.ForeColor = System.Drawing.Color.White;
            this.FilterBtn.Location = new System.Drawing.Point(159, 41);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(83, 25);
            this.FilterBtn.TabIndex = 12;
            this.FilterBtn.Text = "ფილტრაცია";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // FilterText
            // 
            this.FilterText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilterText.Location = new System.Drawing.Point(12, 13);
            this.FilterText.Name = "FilterText";
            this.FilterText.Size = new System.Drawing.Size(230, 22);
            this.FilterText.TabIndex = 14;
            this.FilterText.TextChanged += new System.EventHandler(this.rX_FREQTextBox_TextChanged);
            this.FilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilterText_KeyPress);
            // 
            // listBox
            // 
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.ItemHeight = 14;
            this.listBox.Location = new System.Drawing.Point(12, 73);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(230, 198);
            this.listBox.TabIndex = 15;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(254, 284);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.FilterText);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.FilterBtn);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmSearch";
            this.Opacity = 0.8;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmSearch";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.VisibleChanged += new System.EventHandler(this.frmSearch_VisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSearch_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.TextBox FilterText;
        private System.Windows.Forms.ListBox listBox;
    }
}