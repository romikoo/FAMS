namespace Fams
{
    partial class frmLetterScan
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
            this.officeDataSet = new DataBase.OfficeDataSet();
            this.acc_Letters_scanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acc_Letters_scanTableAdapter = new DataBase.OfficeDataSetTableAdapters.acc_Letters_scanTableAdapter();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.printImageBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imgDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.letteridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picture = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acc_Letters_scanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // officeDataSet
            // 
            this.officeDataSet.DataSetName = "OfficeDataSet";
            this.officeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // acc_Letters_scanBindingSource
            // 
            this.acc_Letters_scanBindingSource.DataMember = "acc_Letters_scan";
            this.acc_Letters_scanBindingSource.DataSource = this.officeDataSet;
            this.acc_Letters_scanBindingSource.CurrentChanged += new System.EventHandler(this.acc_Letters_scanBindingSource_CurrentChanged);
            // 
            // acc_Letters_scanTableAdapter
            // 
            this.acc_Letters_scanTableAdapter.ClearBeforeFill = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files (.jpg;.jpeg)|*.jpg;*.jpeg";
            // 
            // printImageBtn
            // 
            this.printImageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printImageBtn.Image = global::Fams.Properties.Resources.print;
            this.printImageBtn.Location = new System.Drawing.Point(441, 25);
            this.printImageBtn.Name = "printImageBtn";
            this.printImageBtn.Size = new System.Drawing.Size(35, 36);
            this.printImageBtn.TabIndex = 16;
            this.printImageBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.printImageBtn.UseVisualStyleBackColor = true;
            this.printImageBtn.Click += new System.EventHandler(this.printImageBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browseBtn.Location = new System.Drawing.Point(368, 491);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(119, 25);
            this.browseBtn.TabIndex = 14;
            this.browseBtn.Text = "ფაილის არჩევა...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.imgDataGridViewImageColumn,
            this.letteridDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.acc_Letters_scanBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 130;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(126, 472);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 30;
            // 
            // imgDataGridViewImageColumn
            // 
            this.imgDataGridViewImageColumn.DataPropertyName = "img";
            this.imgDataGridViewImageColumn.HeaderText = "img";
            this.imgDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.imgDataGridViewImageColumn.Name = "imgDataGridViewImageColumn";
            // 
            // letteridDataGridViewTextBoxColumn
            // 
            this.letteridDataGridViewTextBoxColumn.DataPropertyName = "letter_id";
            this.letteridDataGridViewTextBoxColumn.HeaderText = "letter_id";
            this.letteridDataGridViewTextBoxColumn.Name = "letteridDataGridViewTextBoxColumn";
            this.letteridDataGridViewTextBoxColumn.Visible = false;
            this.letteridDataGridViewTextBoxColumn.Width = 30;
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Gray;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Cursor = System.Windows.Forms.Cursors.Default;
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(341, 471);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.TabIndex = 17;
            this.picture.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picture);
            this.panel1.Location = new System.Drawing.Point(144, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 473);
            this.panel1.TabIndex = 19;
            // 
            // frmLetterScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 522);
            this.Controls.Add(this.printImageBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.browseBtn);
            this.Font = new System.Drawing.Font("Sylfaen", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLetterScan";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "დასკანირებული გამოსახულება";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLetterScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.officeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acc_Letters_scanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataBase.OfficeDataSet officeDataSet;
        private System.Windows.Forms.BindingSource acc_Letters_scanBindingSource;
        private DataBase.OfficeDataSetTableAdapters.acc_Letters_scanTableAdapter acc_Letters_scanTableAdapter;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button printImageBtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn imgDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn letteridDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
    }
}