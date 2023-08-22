namespace XNA
{
    partial class frmPickCity
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
            this.OKbtn = new System.Windows.Forms.Button();
            this.checkList = new System.Windows.Forms.CheckedListBox();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnCheckAllUnused = new System.Windows.Forms.Button();
            this.btnUncheckAllUnused = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // OKbtn
            // 
            this.OKbtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbtn.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OKbtn.ForeColor = System.Drawing.Color.White;
            this.OKbtn.Location = new System.Drawing.Point(194, 402);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(85, 27);
            this.OKbtn.TabIndex = 0;
            this.OKbtn.Text = "მზადაა";
            this.OKbtn.UseVisualStyleBackColor = true;
            // 
            // checkList
            // 
            this.checkList.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.checkList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkList.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkList.FormattingEnabled = true;
            this.checkList.Location = new System.Drawing.Point(12, 10);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(269, 362);
            this.checkList.TabIndex = 2;
            this.checkList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkList_ItemCheck);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAll.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckAll.ForeColor = System.Drawing.Color.White;
            this.btnCheckAll.Location = new System.Drawing.Point(12, 402);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(29, 27);
            this.btnCheckAll.TabIndex = 3;
            this.btnCheckAll.Text = "+";
            this.toolTip.SetToolTip(this.btnCheckAll, "პუნქტების არჩევა, რომლებშიც\r\nარის მინიჭებული სიხშირე");
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncheckAll.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUncheckAll.ForeColor = System.Drawing.Color.White;
            this.btnUncheckAll.Location = new System.Drawing.Point(75, 402);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(29, 27);
            this.btnUncheckAll.TabIndex = 4;
            this.btnUncheckAll.Text = "-";
            this.toolTip.SetToolTip(this.btnUncheckAll, "პუნქტების გამორთვა, რომლებშიც\r\nარის მინიჭებული სიხშირე");
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnCheckAllUnused
            // 
            this.btnCheckAllUnused.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckAllUnused.Font = new System.Drawing.Font("Sylfaen", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCheckAllUnused.ForeColor = System.Drawing.Color.White;
            this.btnCheckAllUnused.Location = new System.Drawing.Point(44, 402);
            this.btnCheckAllUnused.Name = "btnCheckAllUnused";
            this.btnCheckAllUnused.Size = new System.Drawing.Size(12, 27);
            this.btnCheckAllUnused.TabIndex = 5;
            this.btnCheckAllUnused.Text = "+";
            this.toolTip.SetToolTip(this.btnCheckAllUnused, "პუნქტების არჩევა, რომლებშიც\r\nარ არის მინიჭებული სიხშირე");
            this.btnCheckAllUnused.UseVisualStyleBackColor = true;
            this.btnCheckAllUnused.Click += new System.EventHandler(this.btnCheckAllUnused_Click);
            // 
            // btnUncheckAllUnused
            // 
            this.btnUncheckAllUnused.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncheckAllUnused.Font = new System.Drawing.Font("Sylfaen", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUncheckAllUnused.ForeColor = System.Drawing.Color.White;
            this.btnUncheckAllUnused.Location = new System.Drawing.Point(107, 402);
            this.btnUncheckAllUnused.Name = "btnUncheckAllUnused";
            this.btnUncheckAllUnused.Size = new System.Drawing.Size(12, 27);
            this.btnUncheckAllUnused.TabIndex = 6;
            this.btnUncheckAllUnused.Text = "-";
            this.toolTip.SetToolTip(this.btnUncheckAllUnused, "პუნქტების გამორთვა, რომლებშიც\r\nარ არის მინიჭებული სიხშირე");
            this.btnUncheckAllUnused.UseVisualStyleBackColor = true;
            this.btnUncheckAllUnused.Click += new System.EventHandler(this.btnUncheckAllUnused_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "დახმარება";
            // 
            // frmPickCity
            // 
            this.AcceptButton = this.OKbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(292, 445);
            this.Controls.Add(this.btnUncheckAllUnused);
            this.Controls.Add(this.btnCheckAllUnused);
            this.Controls.Add(this.btnUncheckAll);
            this.Controls.Add(this.btnCheckAll);
            this.Controls.Add(this.checkList);
            this.Controls.Add(this.OKbtn);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPickCity";
            this.Opacity = 0.8;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPickCity";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.CheckedListBox checkList;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnCheckAllUnused;
        private System.Windows.Forms.Button btnUncheckAllUnused;
        private System.Windows.Forms.ToolTip toolTip;
    }
}