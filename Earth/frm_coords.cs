using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Helpers;

namespace Earth
{
    public partial class frm_coords : Form
    {
        private double _Lat, _Lon;
        public double Lat
        {
            get
            {
                return _Lat;
            }
        }
        public double Lon
        {
            get
            {
                return _Lon;
            }
        }



        public frm_coords(double lat, double lon)
        {
            InitializeComponent();
            _Lat = lat;
            _Lon = lon;
            LatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)_Lat).ToString();
            LonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)_Lon).ToString();
            LatMasked.Focus();
        }

        private void LatMasked_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar.Equals(char.Parse(".")) || char.IsControl(e.KeyChar));
        }


     

        private void Masked_TextChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {/*
                    if (((TextBox)sender).Name.Equals(ALat.Name) || ((TextBox)sender).Name.Equals(ALon.Name))
                    {
                        if (!ALat.Text.Equals("") && !ALon.Text.Equals(""))
                        {
                            ACityTextBox.Text = ClosestCity(cts, Convert.ToDouble(ALat.Text), Convert.ToDouble(ALon.Text));
                            if (AfreqCityBox.Text == "" || !AfreqCityEditedManually) AfreqCityBox.Text = ACityTextBox.Text;
                        }
                    }*/
            }


            else if (sender.GetType() == typeof(MaskedTextBox))
            {
                if (((MaskedTextBox)sender).Name.Equals(LatMasked.Name) || ((MaskedTextBox)sender).Name.Equals(LonMasked.Name))
                {
                    
                    try
                    {
                        _Lat = Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(LatMasked.Text, "[˚ʼʺ ]", ""));
                        _Lon = Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(LonMasked.Text, "[˚ʼʺ ]", ""));
                        okBtn.Enabled = true;
                    }
                    catch { okBtn.Enabled = false; }

                }
            }
         

            
        }
    }
}
