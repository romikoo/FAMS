using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fams
{
    public partial class progress : Form
    {
        string _txt="მიმდინარეობს დამუშავება...";

        public progress()
        {
            InitializeComponent();
        }

        public progress(string txt) : this()
        {
            _txt = txt;
        }

        private void progress_Load(object sender, EventArgs e)
        {
            label1.Text = _txt;
        }
    }
}