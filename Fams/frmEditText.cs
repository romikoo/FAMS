using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fams
{
    public partial class frmEditText : Form
    {
        public Color cl;

        public frmEditText()
        {
            InitializeComponent();
        }

        private void frmEditText_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox;
            colorBtn.BackColor = cl;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) OKBtn_Click(sender, e);
        }

        private void colorBtn_Click(object sender, EventArgs e)
        {
            colorDialog.Color = cl;
            colorDialog.ShowDialog();
            colorBtn.BackColor = colorDialog.Color;
            cl = colorDialog.Color;
        }
    }
}