namespace Earth
{
    partial class frmLinkParams
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.possible_freqs_list = new System.Windows.Forms.ListBox();
            this.couplRadio = new System.Windows.Forms.RadioButton();
            this.singleRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(8, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(89, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "3",
            "6",
            "7",
            "8",
            "11",
            "13",
            "15",
            "18",
            "23",
            "26",
            "28",
            "38"});
            this.comboBox1.Location = new System.Drawing.Point(8, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MHz";
            // 
            // possible_freqs_list
            // 
            this.possible_freqs_list.FormattingEnabled = true;
            this.possible_freqs_list.Location = new System.Drawing.Point(191, 26);
            this.possible_freqs_list.Name = "possible_freqs_list";
            this.possible_freqs_list.Size = new System.Drawing.Size(438, 186);
            this.possible_freqs_list.TabIndex = 4;
            // 
            // couplRadio
            // 
            this.couplRadio.AutoSize = true;
            this.couplRadio.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.couplRadio.Location = new System.Drawing.Point(194, 5);
            this.couplRadio.Name = "couplRadio";
            this.couplRadio.Size = new System.Drawing.Size(107, 18);
            this.couplRadio.TabIndex = 5;
            this.couplRadio.TabStop = true;
            this.couplRadio.Text = "წყვილი არხები";
            this.couplRadio.UseVisualStyleBackColor = true;
            this.couplRadio.CheckedChanged += new System.EventHandler(this.couplRadio_CheckedChanged);
            // 
            // singleRadio
            // 
            this.singleRadio.AutoSize = true;
            this.singleRadio.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.singleRadio.Location = new System.Drawing.Point(325, 5);
            this.singleRadio.Name = "singleRadio";
            this.singleRadio.Size = new System.Drawing.Size(125, 18);
            this.singleRadio.TabIndex = 6;
            this.singleRadio.TabStop = true;
            this.singleRadio.Text = "ცალკეული არხები";
            this.singleRadio.UseVisualStyleBackColor = true;
            this.singleRadio.CheckedChanged += new System.EventHandler(this.couplRadio_CheckedChanged);
            // 
            // frmLinkParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(641, 222);
            this.Controls.Add(this.singleRadio);
            this.Controls.Add(this.couplRadio);
            this.Controls.Add(this.possible_freqs_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLinkParams";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ლინკი";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox possible_freqs_list;
        private System.Windows.Forms.RadioButton couplRadio;
        private System.Windows.Forms.RadioButton singleRadio;
    }
}