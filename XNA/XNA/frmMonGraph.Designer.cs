namespace XNA
{
    partial class frmMonGraph
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.picturePaste = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturePaste)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(195, 238);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // picturePaste
            // 
            this.picturePaste.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePaste.BackColor = System.Drawing.Color.Black;
            this.picturePaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturePaste.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picturePaste.Location = new System.Drawing.Point(213, 12);
            this.picturePaste.Name = "picturePaste";
            this.picturePaste.Size = new System.Drawing.Size(348, 238);
            this.picturePaste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturePaste.TabIndex = 13;
            this.picturePaste.TabStop = false;
            this.picturePaste.DoubleClick += new System.EventHandler(this.picturePaste_DoubleClick);
            // 
            // frmMonGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(575, 262);
            this.Controls.Add(this.picturePaste);
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMonGraph";
            this.Opacity = 0.9;
            this.Text = "frmMonGraph";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMonGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturePaste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.PictureBox picturePaste;
    }
}