namespace Fams
{
    partial class RepSetupImages
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.TextBox();
            this.calendar2 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.calendar1 = new System.Windows.Forms.MonthCalendar();
            this.date1 = new System.Windows.Forms.TextBox();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.repFreqList = new System.Windows.Forms.ListBox();
            this.repSiteList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 14);
            this.label4.TabIndex = 44;
            this.label4.Text = "სიხშირე";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 14);
            this.label3.TabIndex = 42;
            this.label3.Text = "მონიტორინგის საიტი";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 14);
            this.label2.TabIndex = 40;
            this.label2.Text = "-მდე";
            // 
            // date2
            // 
            this.date2.BackColor = System.Drawing.Color.Khaki;
            this.date2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.date2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.date2.Location = new System.Drawing.Point(259, 182);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(227, 20);
            this.date2.TabIndex = 39;
            this.date2.TextChanged += new System.EventHandler(this.date1_TextChanged);
            this.date2.Leave += new System.EventHandler(this.date2_Leave);
            // 
            // calendar2
            // 
            this.calendar2.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calendar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calendar2.Location = new System.Drawing.Point(259, 13);
            this.calendar2.MaxDate = new System.DateTime(2031, 12, 31, 0, 0, 0, 0);
            this.calendar2.MaxSelectionCount = 1;
            this.calendar2.MinDate = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            this.calendar2.Name = "calendar2";
            this.calendar2.TabIndex = 38;
            this.calendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar2_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 14);
            this.label1.TabIndex = 37;
            this.label1.Text = "-დან";
            // 
            // calendar1
            // 
            this.calendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calendar1.Location = new System.Drawing.Point(11, 13);
            this.calendar1.MaxDate = new System.DateTime(2031, 12, 31, 0, 0, 0, 0);
            this.calendar1.MaxSelectionCount = 1;
            this.calendar1.MinDate = new System.DateTime(2006, 1, 1, 0, 0, 0, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.TabIndex = 35;
            this.calendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendar1_DateChanged);
            // 
            // date1
            // 
            this.date1.BackColor = System.Drawing.Color.Khaki;
            this.date1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.date1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.date1.Location = new System.Drawing.Point(11, 180);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(227, 20);
            this.date1.TabIndex = 34;
            this.date1.TextChanged += new System.EventHandler(this.date1_TextChanged);
            this.date1.Leave += new System.EventHandler(this.date1_Leave);
            // 
            // PrintBtn
            // 
            this.PrintBtn.Enabled = false;
            this.PrintBtn.Location = new System.Drawing.Point(375, 474);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(111, 35);
            this.PrintBtn.TabIndex = 33;
            this.PrintBtn.Text = "ბეჭდვა";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // repFreqList
            // 
            this.repFreqList.ColumnWidth = 70;
            this.repFreqList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repFreqList.FormattingEnabled = true;
            this.repFreqList.ItemHeight = 16;
            this.repFreqList.Items.AddRange(new object[] {
            "FM",
            "52.500",
            "62.000",
            "80.000",
            "88.000",
            "96.000",
            "178.000",
            "186.000",
            "194.000",
            "202.000",
            "210.000",
            "218.000",
            "226.000",
            "474.000",
            "482.000",
            "490.000",
            "498.000",
            "506.000",
            "514.000",
            "522.000",
            "530.000",
            "538.000",
            "546.000",
            "554.000",
            "562.000",
            "570.000",
            "578.000",
            "586.000",
            "594.000",
            "602.000",
            "610.000",
            "618.000",
            "626.000",
            "634.000",
            "642.000",
            "650.000",
            "658.000",
            "666.000",
            "674.000",
            "682.000",
            "690.000",
            "698.000",
            "706.000",
            "714.000",
            "722.000",
            "730.000",
            "738.000",
            "746.000",
            "754.000",
            "762.000",
            "770.000",
            "778.000",
            "786.000"});
            this.repFreqList.Location = new System.Drawing.Point(11, 257);
            this.repFreqList.MultiColumn = true;
            this.repFreqList.Name = "repFreqList";
            this.repFreqList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.repFreqList.Size = new System.Drawing.Size(475, 148);
            this.repFreqList.TabIndex = 47;
            this.repFreqList.SelectedIndexChanged += new System.EventHandler(this.date1_TextChanged);
            // 
            // repSiteList
            // 
            this.repSiteList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repSiteList.FormattingEnabled = true;
            this.repSiteList.ItemHeight = 16;
            this.repSiteList.Items.AddRange(new object[] {
            "RMS1",
            "RMS2",
            "RMS3",
            "RMS4",
            "MMS-K",
            "MMS-T"});
            this.repSiteList.Location = new System.Drawing.Point(11, 441);
            this.repSiteList.Name = "repSiteList";
            this.repSiteList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.repSiteList.Size = new System.Drawing.Size(88, 68);
            this.repSiteList.TabIndex = 48;
            this.repSiteList.SelectedIndexChanged += new System.EventHandler(this.date1_TextChanged);
            // 
            // RepSetupImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 521);
            this.Controls.Add(this.repSiteList);
            this.Controls.Add(this.repFreqList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.calendar2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.PrintBtn);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RepSetupImages";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "რეპორტის პარამეტრები";
            this.Load += new System.EventHandler(this.RepSetupImages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox date2;
        private System.Windows.Forms.MonthCalendar calendar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar calendar1;
        private System.Windows.Forms.TextBox date1;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.ListBox repFreqList;
        private System.Windows.Forms.ListBox repSiteList;



    }
}