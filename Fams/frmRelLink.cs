using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Helpers;
using DataBase;

namespace Fams
{
    public partial class frmRelLink : Form
    {
        private BindingSource _src;
        private BindingSource _linksSource;
        private DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter _adapter;
        private OfficeDataSet.fls_LICENCE_FREQDataTable _table;
        zone_cities cts;
        List<Frequency> allocs;
        int _comp_id;
        bool ANameEditedManually = false;
        bool BNameEditedManually = false;
        bool AfreqCityEditedManually = false;
        bool BfreqCityEditedManually = false;
        bool editing = false;
        int _lic_id = -1;
        int _Aid, _Bid;
        public int Aid
        {
            get
            {
                return _Aid;
            }
        }
        public int Bid
        {
            get
            {
                return _Bid;
            }
        }

        public frmRelLink(zone_cities cts, int comp_id, int lic_id, ref BindingSource src, ref DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter adapter, OfficeDataSet.fls_LICENCE_FREQDataTable table)
        {
            InitializeComponent();

            // TODO: This line of code loads data into the 'officeDataSet.COMBO_Polarization' table. You can move, or remove it, as needed.
            this.cOMBO_PolarizationTableAdapter.Fill(this.officeDataSet.COMBO_Polarization);
            // TODO: This line of code loads data into the 'officeDataSet.st_rel_fixed' table. You can move, or remove it, as needed.
            this.st_rel_fixedTableAdapter.FillByComp(this.officeDataSet.st_rel_fixed, comp_id);


            _src = src;
            _adapter = adapter;
            _comp_id = comp_id;
            _lic_id = lic_id;
            _table = table;
            this.cts = cts;
            foreach (city ct in this.cts.cities)
            {
                ACityTextBox.AutoCompleteCustomSource.Add(ct.name.Trim());
                BCityTextBox.AutoCompleteCustomSource.Add(ct.name.Trim());

                AfreqCityBox.AutoCompleteCustomSource.Add(ct.name.Trim());
                BfreqCityBox.AutoCompleteCustomSource.Add(ct.name.Trim());
            }


            allocs = new List<Frequency>();
            DataSet ds = Functions.fill("select * from PlansView", DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                allocs.Add(new Frequency(
                    ds.Tables[0].Rows[i]["Name"].ToString() + " | " + ds.Tables[0].Rows[i]["Block"].ToString() + " | " + ds.Tables[0].Rows[i]["Spacing"].ToString(),
                    Convert.ToInt64(ds.Tables[0].Rows[i]["Frequency"].ToString()),
                    Convert.ToDouble(ds.Tables[0].Rows[i]["Bandwidth"].ToString()),
                    Convert.ToInt32(ds.Tables[0].Rows[i]["CH"].ToString()),
                    Convert.ToBoolean(ds.Tables[0].Rows[i]["LowBand"].ToString())
                    ));
            }

            foreach (Frequency f in allocs)
            {
                AFreqTextBox.AutoCompleteCustomSource.Add(Functions.getHZ(f.Freq));
                ABandwidthTextBox.AutoCompleteCustomSource.Add(Functions.getHZ(f.Bandwidth));

                BFreqTextBox.AutoCompleteCustomSource.Add(Functions.getHZ(f.Freq));
                BBandwidthTextBox.AutoCompleteCustomSource.Add(Functions.getHZ(f.Bandwidth));
            }


            BposRadioCoords.Checked = true;
            AposRadioCoords.Checked = true;

            if (Properties.Settings.Default["lastRelCoordsSystem"].ToString().Equals("WGS84")) coordsTypeRadiowgs84.Checked = true;
            else if (Properties.Settings.Default["lastRelCoordsSystem"].ToString().Equals("4DEC")) coordsTypeRadio4dec.Checked = true;

            Debug.WriteLine("settings: " + Properties.Settings.Default["lastRelCoordsSystem"].ToString());
        }

        public frmRelLink(zone_cities cts, int comp_id, int lic_id, ref BindingSource src, ref DataBase.OfficeDataSetTableAdapters.fls_LICENCE_FREQTableAdapter adapter, OfficeDataSet.fls_LICENCE_FREQDataTable table, int Aid, int Bid, BindingSource linksSource)
            : this(cts, comp_id, lic_id, ref src, ref adapter, table)
        {
            editing = true;
            _Aid = Aid;
            _Bid = Bid;
            _linksSource = linksSource;
            artNumberBox.Visible = true;

            #region vistavlyaem znacheniya vsex polei dlya redaktirovaniya

            _linksSource.Position = this._linksSource.Find("Aid", _Aid);
            try
            {
                artNumberBox.Value = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).AartNo;
            }
            catch
            {

                DataSet ds = Helpers.Functions.fill(string.Format("select max(artNo) as mx from st_rel_fixed where lic_id={0}", lic_id), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                string mx = ds.Tables[0].Rows[0]["mx"].ToString();
                if (mx != "") artNumberBox.Value = Convert.ToDecimal(mx) + 1;
                else artNumberBox.Value = 1;
            }
            ANameTextBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).AName;
            AFreqTextBox.Text = HelperFunctions.getHZ(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).ATX);
            ABandwidthTextBox.Text = HelperFunctions.getHZ(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).ATX_B);
            ACityTextBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).ATX_city.Trim();
            ALat.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Alat.ToString();
            ALon.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Alon.ToString();
            ALatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Alat);
            ALonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Alon);
            AfreqCityBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).ATX_city.Trim();
            try
            {
                APolarCombo.SelectedValue = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Aant_polar_id;
                PolarCheckBox.Checked = true;
            }
            catch { }
            FreqBand_Leave(ABandwidthTextBox, new EventArgs());


            _linksSource.Position = this._linksSource.Find("Bid", _Bid);
            BNameTextBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BName;
            try //esaa sachiro mashin, roca linkia simplexi, anu calmxrivi
            {
                BFreqTextBox.Text = HelperFunctions.getHZ(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BTX);
                BBandwidthTextBox.Text = HelperFunctions.getHZ(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BTX_B);
                FreqBand_Leave(BBandwidthTextBox, new EventArgs());
                BCityTextBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BTX_city.Trim();
                BfreqCityBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BTX_city.Trim();
            }
            catch
            {
                simplexRadio.Checked = true;
                BCityTextBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BRX_city.Trim();
                BfreqCityBox.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).BRX_city.Trim();
            }
            BLat.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Blat.ToString();
            BLon.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Blon.ToString();
            BLatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Blat);
            BLonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Blon);
            try
            {
                BPolarCombo.SelectedValue = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_linksSource.Current).Row).Bant_polar_id;
                PolarCheckBox.Checked = true;
            }
            catch { }



            ANameEditedManually = true;
            BNameEditedManually = true;
            AfreqCityEditedManually = true;
            BfreqCityEditedManually = true;
            #endregion

            Debug.WriteLine("second constructor end");
        }


        private void CityTextBox_Leave(object sender, EventArgs e)
        {
            bool present = false;
            if (((Control)sender).Name.Equals(ACityTextBox.Name) && ACityTextBox.Text != "")
            {
                foreach (city ct in cts.cities)
                {
                    if (ct.name.Equals(((TextBox)sender).Text))
                    {

                        ALat.Text = ct.lat.ToString();
                        ALon.Text = ct.lon.ToString();
                        ALatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)ct.lat).ToString();
                        ALonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)ct.lon).ToString();
                        if (AfreqCityBox.Text == "" || !AfreqCityEditedManually) AfreqCityBox.Text = ct.name;

                        present = true; break;
                    }
                }
                if (!present && !ACityTextBox.Text.Equals(""))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    this.ActiveControl = (Control)sender;
                }
            }





            else
            {
                present = false;
                if (((Control)sender).Name.Equals(BCityTextBox.Name) && BCityTextBox.Text != "")
                {
                    foreach (city ct in cts.cities)
                    {
                        if (ct.name.Equals(((TextBox)sender).Text))
                        {

                            BLat.Text = ct.lat.ToString();
                            BLon.Text = ct.lon.ToString();
                            BLatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)ct.lat).ToString();
                            BLonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)ct.lon).ToString();
                            if (BfreqCityBox.Text == "" || !BfreqCityEditedManually) BfreqCityBox.Text = ct.name;

                            present = true; break;
                        }
                    }
                    if (!present && !BCityTextBox.Text.Equals(""))
                    {
                        System.Media.SystemSounds.Asterisk.Play();
                        this.ActiveControl = (Control)sender;
                    }
                }
            }

            CorrectNameText((Control)sender);
        }

        private void coordsTypeRadio_CheckedChanged(object sender, EventArgs e)
        {
            ALat.Visible = coordsTypeRadio4dec.Checked;
            ALon.Visible = coordsTypeRadio4dec.Checked;
            ALatMasked.Visible = coordsTypeRadiowgs84.Checked;
            ALonMasked.Visible = coordsTypeRadiowgs84.Checked;

            BLat.Visible = coordsTypeRadio4dec.Checked;
            BLon.Visible = coordsTypeRadio4dec.Checked;
            BLatMasked.Visible = coordsTypeRadiowgs84.Checked;
            BLonMasked.Visible = coordsTypeRadiowgs84.Checked;

            //to 4DEC
            if (coordsTypeRadio4dec.Checked)
            {
                try
                {
                    if (Regex.Replace(ALatMasked.Text, "[˚ʼʺ. ]", "") != "" && Regex.Replace(ALonMasked.Text, "[˚ʼʺ. ]", "") != "")
                    {
                        ALat.Text = Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(ALatMasked.Text, "[˚ʼʺ ]", "")).ToString();
                        ALon.Text = Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(ALonMasked.Text, "[˚ʼʺ ]", "")).ToString();
                        ACityTextBox.Text = ClosestCity(cts, Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(ALatMasked.Text, "[˚ʼʺ ]", "")), Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(ALonMasked.Text, "[˚ʼʺ ]", "")));
                        if (AfreqCityBox.Text == "" || !AfreqCityEditedManually) AfreqCityBox.Text = ACityTextBox.Text;
                    }
                }
                catch (Exception ee)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    Debug.WriteLine(ee.Message);
                }

                try
                {
                    if (Regex.Replace(BLatMasked.Text, "[˚ʼʺ. ]", "") != "" && Regex.Replace(BLonMasked.Text, "[˚ʼʺ. ]", "") != "")
                    {
                        BLat.Text = Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(BLatMasked.Text, "[˚ʼʺ ]", "")).ToString();
                        BLon.Text = Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(BLonMasked.Text, "[˚ʼʺ ]", "")).ToString();
                        BCityTextBox.Text = ClosestCity(cts, Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(BLatMasked.Text, "[˚ʼʺ ]", "")), Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(BLonMasked.Text, "[˚ʼʺ ]", "")));
                        if (BfreqCityBox.Text == "" || !BfreqCityEditedManually) BfreqCityBox.Text = BCityTextBox.Text;
                    }
                }
                catch (Exception ee)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    Debug.WriteLine(ee.Message);
                }
            }


            //to DMS
            else
            {
                try
                {
                    if (!ALat.Text.Equals("") && !ALon.Text.Equals(""))
                    {
                        ALatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(Convert.ToDecimal(ALat.Text));
                        ALonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(Convert.ToDecimal(ALon.Text));
                        ACityTextBox.Text = ClosestCity(cts, Convert.ToDouble(ALat.Text), Convert.ToDouble(ALon.Text));
                        if (AfreqCityBox.Text == "" || !AfreqCityEditedManually) AfreqCityBox.Text = ACityTextBox.Text;
                    }
                }
                catch (Exception ee)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    Debug.WriteLine(ee.Message);
                }

                try
                {
                    if (!BLat.Text.Equals("") && !BLon.Text.Equals(""))
                    {
                        BLatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(Convert.ToDecimal(BLat.Text));
                        BLonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation(Convert.ToDecimal(BLon.Text));
                        BCityTextBox.Text = ClosestCity(cts, Convert.ToDouble(BLat.Text), Convert.ToDouble(BLon.Text));
                        if (BfreqCityBox.Text == "" || !BfreqCityEditedManually) BfreqCityBox.Text = BCityTextBox.Text;
                    }
                }
                catch (Exception ee)
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    Debug.WriteLine(ee.Message);
                }
            }
        }

        private void posRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (((Control)sender).Equals(AposRadioCoords) || ((Control)sender).Equals(AposRadioPunkt))
            {
                ACityTextBox.Enabled = AposRadioPunkt.Checked;
                ALat.Enabled = AposRadioCoords.Checked;
                ALon.Enabled = AposRadioCoords.Checked;
                ALatMasked.Enabled = AposRadioCoords.Checked;
                ALonMasked.Enabled = AposRadioCoords.Checked;
                ACoordsMapBtn.Enabled = AposRadioCoords.Checked;
                coordsTypeRadiowgs84.Checked = true;
                this.ActiveControl = ALatMasked;
            }
            else
            {
                BCityTextBox.Enabled = BposRadioPunkt.Checked;
                BLat.Enabled = BposRadioCoords.Checked;
                BLon.Enabled = BposRadioCoords.Checked;
                BLatMasked.Enabled = BposRadioCoords.Checked;
                BLonMasked.Enabled = BposRadioCoords.Checked;
                BCoordsMapBtn.Enabled = BposRadioCoords.Checked;
                this.ActiveControl = BLatMasked;
            }
        }

        private void CoordsLatLon_Leave(object sender, EventArgs e)
        {
            if (coordsTypeRadio4dec.Checked)
            {
                try
                {
                    ACityTextBox.Text = ClosestCity(cts, Convert.ToDouble(ALat.Text), Convert.ToDouble(ALon.Text));
                    if (AfreqCityBox.Text == "" || !AfreqCityEditedManually) AfreqCityBox.Text = ACityTextBox.Text;

                    BCityTextBox.Text = ClosestCity(cts, Convert.ToDouble(BLat.Text), Convert.ToDouble(BLon.Text));
                    if (BfreqCityBox.Text == "" || !BfreqCityEditedManually) BfreqCityBox.Text = BCityTextBox.Text;
                }
                catch { }
            }
            else if (coordsTypeRadiowgs84.Checked)
            {
                try
                {
                    ACityTextBox.Text = ClosestCity(cts, Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(ALatMasked.Text, "[˚ʼʺ ]", "")), Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(ALonMasked.Text, "[˚ʼʺ ]", "")));
                    if (AfreqCityBox.Text == "" || !AfreqCityEditedManually) AfreqCityBox.Text = ACityTextBox.Text;

                    BCityTextBox.Text = ClosestCity(cts, Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(BLatMasked.Text, "[˚ʼʺ ]", "")), Helpers.GeoCodeCalc.DMStoDD(Regex.Replace(BLonMasked.Text, "[˚ʼʺ ]", "")));
                    if (BfreqCityBox.Text == "" || !BfreqCityEditedManually) BfreqCityBox.Text = BCityTextBox.Text;
                }
                catch { }
            }

            CorrectNameText((Control)sender);
        }

        private string ClosestCity(zone_cities allCities, double lat, double lng)
        {
            string city = "not found";
            double distance = double.MaxValue;
            foreach (city ct in allCities.cities)
            {
                double dst = Helpers.GeoCodeCalc.CalcDistance(ct.lat, ct.lon, lat, lng);
                if (dst < distance)
                {
                    distance = dst;
                    city = ct.name;
                }
            }

            return city;
        }

        private void Coords_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar.Equals(char.Parse(System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)) || char.IsControl(e.KeyChar));
        }

        private void CoordsMapBtn_Click(object sender, EventArgs e)
        {
            Earth.miniEarthForm map = new Earth.miniEarthForm();
            if (map.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                //coordsTypeRadio4dec.Checked = true;

                if (((Control)sender).Name.Equals(ACoordsMapBtn.Name))
                {
                    ALat.Text = map.ReturnLat.ToString();
                    ALon.Text = map.ReturnLon.ToString();
                    ALatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)map.ReturnLat);
                    ALonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)map.ReturnLon);
                    CoordsLatLon_Leave(ALat, new EventArgs());
                    CoordsLatLon_Leave(ALon, new EventArgs());
                }
                else
                {
                    BLat.Text = map.ReturnLat.ToString();
                    BLon.Text = map.ReturnLon.ToString();
                    BLatMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)map.ReturnLat);
                    BLonMasked.Text = Helpers.GeoCodeCalc.ToDegreeNotation((decimal)map.ReturnLon);
                    CoordsLatLon_Leave(BLat, new EventArgs());
                    CoordsLatLon_Leave(BLon, new EventArgs());
                }
            }
            map.Dispose();
        }

        private void FreqBand_Leave(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button)) return;
            ((TextBox)sender).Text = HelperFunctions.ConvertToFreq(((TextBox)sender).Text);

            if (((Control)sender).Name.Equals(AFreqTextBox.Name) || ((Control)sender).Name.Equals(ABandwidthTextBox.Name) || ((Control)sender).Equals(swapFreqsBtn))
            {
                if (((Control)sender).Name.Equals(AFreqTextBox.Name) && !AFreqTextBox.Text.Equals(string.Empty) && ABandwidthTextBox.Text == string.Empty)
                    foreach (Frequency f in allocs)
                        if (f.Freq == HelperFunctions.FreqForDB(AFreqTextBox))
                        {
                            ABandwidthTextBox.Text = HelperFunctions.getHZ(f.Bandwidth);
                            break;
                        }


                AAllocLabel.Text = "";
                if (AFreqTextBox.Text != string.Empty && ABandwidthTextBox.Text != string.Empty)
                {
                    foreach (Frequency f in allocs)
                    {
                        if (f.Freq == HelperFunctions.FreqForDB(AFreqTextBox) && f.Bandwidth == HelperFunctions.FreqForDB(ABandwidthTextBox))
                        {
                            AAllocLabel.Text = string.Format(f.Alloc_Name + " | " + f.Channel + "ch{0}", f.Is_low_band ? "" : "'");
                            break;
                        }
                    }
                }
            }





            if (((Control)sender).Name.Equals(BFreqTextBox.Name) || ((Control)sender).Name.Equals(BBandwidthTextBox.Name) || ((Control)sender).Equals(swapFreqsBtn))
            {
                if (((Control)sender).Name.Equals(BFreqTextBox.Name) && !BFreqTextBox.Text.Equals(string.Empty) && BBandwidthTextBox.Text == string.Empty)
                    foreach (Frequency f in allocs)
                        if (f.Freq == HelperFunctions.FreqForDB(BFreqTextBox))
                        {
                            BBandwidthTextBox.Text = HelperFunctions.getHZ(f.Bandwidth);
                            break;
                        }


                BAllocLabel.Text = "";
                if (BFreqTextBox.Text != string.Empty && BBandwidthTextBox.Text != string.Empty)
                {
                    foreach (Frequency f in allocs)
                    {
                        if (f.Freq == HelperFunctions.FreqForDB(BFreqTextBox) && f.Bandwidth == HelperFunctions.FreqForDB(BBandwidthTextBox))
                        {
                            BAllocLabel.Text = string.Format(f.Alloc_Name + " | " + f.Channel + "ch{0}", f.Is_low_band ? "" : "'");
                            break;
                        }
                    }
                }
            }

            if (!AFreqTextBox.Text.Equals(string.Empty) && !ABandwidthTextBox.Text.Equals(string.Empty) &&
                !BFreqTextBox.Text.Equals(string.Empty) && !BBandwidthTextBox.Text.Equals(string.Empty) && !simplexRadio.Checked)
                swapFreqsBtn.Enabled = true;
            else swapFreqsBtn.Enabled = false;
        }



        private void FreqBand_KeyUp(object sender, KeyEventArgs e)
        {
            if (((Control)sender).Name.Equals(AFreqTextBox.Name) || ((Control)sender).Name.Equals(ABandwidthTextBox.Name))
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                    this.SelectNextControl((Control)sender, true, true, true, true);
            }

            if (((Control)sender).Name.Equals(BFreqTextBox.Name) || ((Control)sender).Name.Equals(BBandwidthTextBox.Name))
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                    this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void FreqBand_KeyDown(object sender, KeyEventArgs e)
        {
            HelperFunctions.catchKey(sender, e);
        }

        private void AAllocLabel_TextChanged(object sender, EventArgs e)
        {
            if (BFreqTextBox.Text.Equals(string.Empty) && BBandwidthTextBox.Text.Equals(string.Empty) && !simplexRadio.Checked)
            {
                foreach (Frequency f in allocs)
                {
                    if (f.Freq == HelperFunctions.FreqForDB(AFreqTextBox) && f.Bandwidth == HelperFunctions.FreqForDB(ABandwidthTextBox))
                    {
                        foreach (Frequency f1 in allocs)
                            if (f.Alloc_Name == f1.Alloc_Name && f.Bandwidth == f1.Bandwidth && f.Is_low_band != f1.Is_low_band && f.Channel == f1.Channel)
                            {
                                BFreqTextBox.Text = HelperFunctions.getHZ(f1.Freq);
                                BBandwidthTextBox.Text = HelperFunctions.getHZ(f1.Bandwidth);
                                FreqBand_Leave(BBandwidthTextBox, new EventArgs());
                                break;
                            }
                        break;
                    }
                }
            }



        }




        private void BAllocLabel_TextChanged(object sender, EventArgs e)
        {
            if (AFreqTextBox.Text.Equals(string.Empty) && ABandwidthTextBox.Text.Equals(string.Empty))
            {
                foreach (Frequency f in allocs)
                {
                    if (f.Freq == HelperFunctions.FreqForDB(BFreqTextBox) && f.Bandwidth == HelperFunctions.FreqForDB(BBandwidthTextBox))
                    {
                        foreach (Frequency f1 in allocs)
                            if (f.Alloc_Name == f1.Alloc_Name && f.Bandwidth == f1.Bandwidth && f.Is_low_band != f1.Is_low_band && f.Channel == f1.Channel)
                            {
                                AFreqTextBox.Text = HelperFunctions.getHZ(f1.Freq);
                                ABandwidthTextBox.Text = HelperFunctions.getHZ(f1.Bandwidth);
                                FreqBand_Leave(ABandwidthTextBox, new EventArgs());
                                break;
                            }
                        break;
                    }
                }
            }



        }

        private void swapFreqsBtn_Click(object sender, EventArgs e)
        {
            string tmp1 = BFreqTextBox.Text;
            string tmp2 = BBandwidthTextBox.Text;
            BFreqTextBox.Text = AFreqTextBox.Text;
            BBandwidthTextBox.Text = ABandwidthTextBox.Text;
            AFreqTextBox.Text = tmp1;
            ABandwidthTextBox.Text = tmp2;

            FreqBand_Leave(ABandwidthTextBox, new EventArgs());
            FreqBand_Leave(BBandwidthTextBox, new EventArgs());
        }

        private void CityTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                CityTextBox_Leave(sender, new EventArgs());
        }

        private void PolarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            APolarCombo.Enabled = PolarCheckBox.Checked;
            BPolarCombo.Enabled = PolarCheckBox.Checked;
        }





        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        /// <summary>
        /// sixshiris shenaxva
        /// </summary>
        /// <param name="f"></param>
        /// <param name="bwth"></param>
        /// <param name="city_id"></param>
        /// <param name="lic_id"></param>
        /// <returns></returns>
        private int SaveFreq(long f, int bwth, int city_id)
        {
            //ne vipolnyaem vibor licenzii, poskolku mi ee peredaem pri sozdanii formi
            #region vibor licenzii dlya zapisi
            if (_lic_id < 0)
            {
                frmPickLicence lic = new frmPickLicence(_comp_id);
                if (lic.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) _lic_id = lic.licence_id;
                else
                {
                    lic.Dispose();
                    MessageBox.Show("Execution stopped");
                    return -1;
                }
            }

            #endregion


            int id = -1;

            //sperva proveryaem net li uje takoi chastoti v baze
            DataSet ds = Helpers.Functions.fill(string.Format("select count(*) as raod from  dbo.fls_LICENCE_FREQ where FREQ={0} and Bandwidth={1} and city_id={2} and licence_id={3}", new object[] { f, bwth, city_id, _lic_id }), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            //esli takoi chastoti net to dobavlyaem ee
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["raod"].ToString()) == 0)
            {
                _src.AddNew();
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).FREQ = f;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).BandWidth = bwth;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).city_id = city_id;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).licence_id = _lic_id;
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).reestrit = false;
                _src.EndEdit();
                _adapter.Update(_table);
                id = ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)_src.Current).Row).id;

            }
            //tu egeti arsebobs - vedzebt mis id-s
            else
            {
                ds = Helpers.Functions.fill(string.Format("select id from  dbo.fls_LICENCE_FREQ where FREQ={0} and Bandwidth={1} and city_id={2} and licence_id={3}", new object[] { f, bwth, city_id, _lic_id }), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            return id;
        }

        /// <summary>
        /// sareleo sadguris shenaxva
        /// </summary>
        /// <param name="name"></param>
        /// <param name="RX"></param>
        /// <param name="TX"></param>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <param name="ant_polar_id"></param>
        /// <returns></returns>
        private int SaveFixedRel(string name, int? RX, int? TX, decimal lat, decimal lon, byte ant_polar_id)
        {
            int id = -1;

            if (!editing) st_rel_fixedBindingSource.AddNew();
            DataRowView current = (DataRowView)st_rel_fixedBindingSource.Current;

            ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).Name = name;

            if (RX == null) ((DataRowView)(st_rel_fixedBindingSource.Current))["RX_FREQ_id"] = DBNull.Value;
            else ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).RX_FREQ_id = RX;

            if (TX == null) ((DataRowView)(st_rel_fixedBindingSource.Current))["TX_FREQ_id"] = DBNull.Value;
            else ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).TX_FREQ_id = TX;

            ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).lat = lat;
            ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).lon = lon;
            if (PolarCheckBox.Checked) ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).ant_polar_id = ant_polar_id;
            ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).comp_id = _comp_id;
            ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).lic_id = _lic_id;
            ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).artNo = Convert.ToInt32(artNumberBox.Value);
            st_rel_fixedBindingSource.EndEdit();
            st_rel_fixedTableAdapter.Update(this.officeDataSet.st_rel_fixed);
            id = ((OfficeDataSet.st_rel_fixedRow)((DataRowView)st_rel_fixedBindingSource.Current).Row).id;


            return id;
        }

        private void EditFixedRel(int ID, string name, int? RX, int? TX, decimal lat, decimal lon, byte ant_polar_id)
        {
            st_rel_fixedBindingSource.Position = this.st_rel_fixedBindingSource.Find("id", ID);
            SaveFixedRel(name, RX, TX, lat, lon, ant_polar_id);
        }

        private int SaveFixedRelLink(int A, int B)
        {
            int id = -1;

            DataSet ds = Helpers.Functions.fill(string.Format("select count(*) as raod from  dbo.fls_REL_LINK where A_fixed={0} and B_fixed={1}", new object[] { A, B }), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["raod"].ToString()) == 0)
            {
                fls_REL_LINKBindingSource.AddNew();
                ((OfficeDataSet.fls_REL_LINKRow)((DataRowView)fls_REL_LINKBindingSource.Current).Row).A_fixed = A;
                ((OfficeDataSet.fls_REL_LINKRow)((DataRowView)fls_REL_LINKBindingSource.Current).Row).B_fixed = B;
                fls_REL_LINKBindingSource.EndEdit();
                fls_REL_LINKTableAdapter.Update(this.officeDataSet.fls_REL_LINK);
                id = ((OfficeDataSet.fls_REL_LINKRow)((DataRowView)fls_REL_LINKBindingSource.Current).Row).id;
            }
            else
            {
                ds.Clear();
                ds = Helpers.Functions.fill(string.Format("select id from  dbo.fls_REL_LINK where A_fixed={0} and B_fixed={1}", new object[] { A, B }), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
            }

            return id;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {


            #region soxranenie poslednei vibrannoi koordinatnoi sistemi
            if (coordsTypeRadiowgs84.Checked)
                Properties.Settings.Default["lastRelCoordsSystem"] = "WGS84";
            if (coordsTypeRadio4dec.Checked)
                Properties.Settings.Default["lastRelCoordsSystem"] = "4DEC";
            Properties.Settings.Default.Save();

            coordsTypeRadio4dec.Checked = true;
            coordsTypeRadiowgs84.Checked = true;
            #endregion


            #region proverka na oshibki
            errorProvider1.Clear();

            bool hasError = false;
            var controls = new[] { ANameTextBox, ACityTextBox, BNameTextBox, BCityTextBox, ALat, ALon, BLat, BLon, AfreqCityBox, BfreqCityBox };
            foreach (var control in controls.Where(i => String.IsNullOrEmpty(i.Text)))
            {
                errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(control, "გთხოვთ შეავსოთ მოცემული ველი");
                hasError = true;
            }

            if (simplexRadio.Checked) controls = new[] { AFreqTextBox, ABandwidthTextBox };  //simplexis dros marto A sixshires vamotsmeb
            else controls = new[] { AFreqTextBox, ABandwidthTextBox, BFreqTextBox, BBandwidthTextBox }; //duplexis dros A da B sixshires vamotsmeb
            foreach (var control in controls)
            {
                try
                {
                    long i = HelperFunctions.FreqForDB(control);
                    if (i == 0) throw new DivideByZeroException();
                }
                catch
                {
                    errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
                    errorProvider1.SetError(control, "გთხოვთ შეავსოთ მოცემული ველი");
                    hasError = true;
                }

            }
            if (hasError) return;



            //proveryaem ne sovpadaut li imena stancii A i B
            if (ANameTextBox.Text.Equals(BNameTextBox.Text))
            {
                errorProvider1.SetIconAlignment(ANameTextBox, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(ANameTextBox, "ორივე სადგურის დასახელება იდენტურია!!!");

                errorProvider1.SetIconAlignment(BNameTextBox, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(BNameTextBox, "ორივე სადგურის დასახელება იდენტურია!!!");
                return;
            }




            //proveryaem imena obeix stancii net li takix stancii uje - imena doljni bit unikalnimi!
            string sql;
            if (!editing) sql = string.Format("select count(*) as raod from dbo.st_rel_fixed where Name=N'{0}' and (not (lic_id is null)) and comp_id={1}", ANameTextBox.Text, _comp_id);
            else sql = string.Format("select count(*) as raod from dbo.st_rel_fixed where Name=N'{0}' and (not (lic_id is null)) and comp_id={1} and id<>{2}", ANameTextBox.Text, _comp_id, _Aid);
            Debug.WriteLine(sql);
            DataSet tmp = Helpers.Functions.fill(sql, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            if (Convert.ToInt32(tmp.Tables[0].Rows[0]["raod"].ToString()) > 0)
            {
                errorProvider1.SetIconAlignment(ANameTextBox, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(ANameTextBox, "ეგეთი სახელის მქონე სადგური უკვე არსებობს!!!");
                hasError = true;
                tmp.Dispose();
            }

            if (!editing) sql = string.Format("select count(*) as raod from dbo.st_rel_fixed where Name=N'{0}' and (not (lic_id is null)) and comp_id={1}", BNameTextBox.Text, _comp_id);
            else sql = string.Format("select count(*) as raod from dbo.st_rel_fixed where Name=N'{0}' and (not (lic_id is null)) and comp_id={1} and id<>{2}", BNameTextBox.Text, _comp_id, _Bid);
            Debug.WriteLine(sql);
            DataSet tmp1 = Helpers.Functions.fill(sql, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            if (Convert.ToInt32(tmp1.Tables[0].Rows[0]["raod"].ToString()) > 0)
            {
                errorProvider1.SetIconAlignment(BNameTextBox, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(BNameTextBox, "ეგეთი სახელის მქონე სადგური უკვე არსებობს!!!");
                hasError = true;
                tmp1.Dispose();
            }

            if (hasError) return;

            //proverka imen gorodov - prisutstvuut li takie v spiske?
            bool present = false;
            foreach (city ct in cts.cities)
                if (ct.name.Equals(AfreqCityBox.Text))
                {
                    present = true; break;
                }
            if (!present)
            {
                errorProvider1.SetIconAlignment(AfreqCityBox, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(AfreqCityBox, "შეცდომით შეყვანილი დასახელება");
                hasError = true;
                ActiveControl = AfreqCityBox;
            } if (hasError) return;




            present = false;
            foreach (city ct in cts.cities)
                if (ct.name.Equals(BfreqCityBox.Text))
                {
                    present = true; break;
                }
            if (!present)
            {
                errorProvider1.SetIconAlignment(BfreqCityBox, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(BfreqCityBox, "შეცდომით შეყვანილი დასახელება");
                hasError = true;
                ActiveControl = BfreqCityBox;
            } if (hasError) return;



            present = false;
            foreach (city ct in cts.cities)
                if (ct.name.Equals(ACityTextBox.Text))
                {
                    present = true; break;
                }
            if (!present)
            {
                errorProvider1.SetIconAlignment(ACityTextBox, ErrorIconAlignment.MiddleRight);
                errorProvider1.SetError(ACityTextBox, "შეცდომით შეყვანილი დასახელება");
                hasError = true;
                ActiveControl = ACityTextBox;
            } if (hasError) return;




            present = false;
            foreach (city ct in cts.cities)
                if (ct.name.Equals(BCityTextBox.Text))
                {
                    present = true; break;
                }
            if (!present)
            {
                errorProvider1.SetIconAlignment(BCityTextBox, ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(BCityTextBox, "შეცდომით შეყვანილი დასახელება");
                hasError = true;
                ActiveControl = BCityTextBox;
            } if (hasError) return;


            if (hasError) return;
            #endregion


            #region poisk i ustanovka rx i tx chastot



            long f;
            int bwth;
            int city_id = -1;




            //vtsert pirvel sixshires A punktshi
            f = HelperFunctions.FreqForDB(AFreqTextBox);
            bwth = Convert.ToInt32(HelperFunctions.FreqForDB(ABandwidthTextBox));
            foreach (city ct in cts.cities)
                if (AfreqCityBox.Text.Equals(ct.name))
                {
                    city_id = ct.id;
                    break;
                }
            int? ATX = SaveFreq(f, bwth, city_id);
            if (ATX < 0) return;


            //vtsert pirvel sixshires B punktshi
            f = HelperFunctions.FreqForDB(AFreqTextBox);
            bwth = Convert.ToInt32(HelperFunctions.FreqForDB(ABandwidthTextBox));
            foreach (city ct in cts.cities)
                if (BfreqCityBox.Text.Equals(ct.name))
                {
                    city_id = ct.id;
                    break;
                }
            int? BRX = SaveFreq(f, bwth, city_id);
            if (BRX < 0) return;


            //tu es araa simplexi, meore mxaresac vtsert
            int? ARX = null;
            int? BTX = null;
            if (!simplexRadio.Checked)
            {
                //vtsert meore sixshires A punktshi
                f = HelperFunctions.FreqForDB(BFreqTextBox);
                bwth = Convert.ToInt32(HelperFunctions.FreqForDB(BBandwidthTextBox));
                foreach (city ct in cts.cities)
                    if (AfreqCityBox.Text.Equals(ct.name))
                    {
                        city_id = ct.id;
                        break;
                    }
                ARX = SaveFreq(f, bwth, city_id);
                if (ARX < 0) return;


                //vtsert meore sixshires B punktshi
                f = HelperFunctions.FreqForDB(BFreqTextBox);
                bwth = Convert.ToInt32(HelperFunctions.FreqForDB(BBandwidthTextBox));
                foreach (city ct in cts.cities)
                    if (BfreqCityBox.Text.Equals(ct.name))
                    {
                        city_id = ct.id;
                        break;
                    }
                BTX = SaveFreq(f, bwth, city_id);
                if (BTX < 0) return;



            }



            Debug.WriteLine(ATX);
            Debug.WriteLine(ARX);
            Debug.WriteLine(BTX);
            Debug.WriteLine(BRX);



            #endregion


            #region zapis releinix stancii

            decimal lat = 0;
            decimal lon = 0;

            try
            {
                lat = Convert.ToDecimal(ALat.Text);
                lon = Convert.ToDecimal(ALon.Text);
            }
            catch { }
            if (coordsTypeRadiowgs84.Checked)
            {
                lat = Convert.ToDecimal(GeoCodeCalc.DMStoDD(Regex.Replace(ALatMasked.Text, "[˚ʼʺ ]", "")));
                lon = Convert.ToDecimal(GeoCodeCalc.DMStoDD(Regex.Replace(ALonMasked.Text, "[˚ʼʺ ]", "")));
            }

            int Aid = -1;
            if (!editing)
            {
                Aid = SaveFixedRel(ANameTextBox.Text, ARX, ATX, lat, lon, Convert.ToByte(APolarCombo.SelectedValue.ToString()));
                Debug.WriteLine(Aid);
            }
            else EditFixedRel(_Aid, ANameTextBox.Text, ARX, ATX, lat, lon, Convert.ToByte(APolarCombo.SelectedValue.ToString()));

            //---------------------------------------- ak ki meore sadguria ------------------------------------------

            lat = 0;
            lon = 0;

            try
            {
                lat = Convert.ToDecimal(BLat.Text);
                lon = Convert.ToDecimal(BLon.Text);
            }
            catch { }
            if (coordsTypeRadiowgs84.Checked)
            {
                lat = Convert.ToDecimal(GeoCodeCalc.DMStoDD(Regex.Replace(BLatMasked.Text, "[˚ʼʺ ]", "")));
                lon = Convert.ToDecimal(GeoCodeCalc.DMStoDD(Regex.Replace(BLonMasked.Text, "[˚ʼʺ ]", "")));
            }

            int Bid = -1;
            if (!editing)
            {
                Bid = SaveFixedRel(BNameTextBox.Text, BRX, BTX, lat, lon, Convert.ToByte(BPolarCombo.SelectedValue.ToString()));
                Debug.WriteLine(Bid);
            }
            else EditFixedRel(_Bid, BNameTextBox.Text, BRX, BTX, lat, lon, Convert.ToByte(BPolarCombo.SelectedValue.ToString()));


            #endregion


            #region zapis linkov
            if (editing)
            {
                Aid = _Aid;
                Bid = _Bid;
            }

            SaveFixedRelLink(Aid, Bid);
            if (!simplexRadio.Checked) SaveFixedRelLink(Bid, Aid);

            #endregion



            this.DialogResult = DialogResult.OK;
        }





        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsLetterOrDigit(e.KeyChar))
            //{
            if (((Control)sender).Equals(ANameTextBox))
                if (ANameTextBox.Text != "") ANameEditedManually = true; else ANameEditedManually = false;
            else
                if (((Control)sender).Equals(BNameTextBox))
                    if (BNameTextBox.Text != "") BNameEditedManually = true; else BNameEditedManually = false;
            Debug.WriteLine("NameTextBox_KeyPress");
            //}
        }

        private void CorrectNameText(Control sender)
        {
            string separator = " - ";

            if (!ANameEditedManually)
            {
                if ((AfreqCityBox.Text != "") && (BfreqCityBox.Text != "")) ANameTextBox.Text = AfreqCityBox.Text + separator + BfreqCityBox.Text;
            }

            if (!BNameEditedManually)
            {
                if ((BfreqCityBox.Text != "") && (BfreqCityBox.Text != "")) BNameTextBox.Text = BfreqCityBox.Text + separator + AfreqCityBox.Text;
            }

        }

        private void freqCityBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                freqCityBox_Leave(sender, new EventArgs());
        }

        private void freqCityBox_Leave(object sender, EventArgs e)
        {
            bool present = false;
            if (((Control)sender).Equals(AfreqCityBox) && AfreqCityBox.Text != "")
            {
                foreach (city ct in cts.cities)
                    if (ct.name.Equals(((TextBox)sender).Text))
                    {
                        present = true; break;
                    }

                if (!present && !AfreqCityBox.Text.Equals(""))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    this.ActiveControl = (Control)sender;
                }
            }

            present = false;
            if (((Control)sender).Equals(BfreqCityBox) && BfreqCityBox.Text != "")
            {
                foreach (city ct in cts.cities)
                    if (ct.name.Equals(((TextBox)sender).Text))
                    {
                        present = true; break;
                    }

                if (!present && !BfreqCityBox.Text.Equals(""))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    this.ActiveControl = (Control)sender;
                }
            }

            CorrectNameText((Control)sender);
        }

        private void freqCityBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((Control)sender).Equals(AfreqCityBox))
                if (AfreqCityBox.Text != "") AfreqCityEditedManually = true; else AfreqCityEditedManually = false;
            else
                if (((Control)sender).Equals(BfreqCityBox))
                    if (BfreqCityBox.Text != "") BfreqCityEditedManually = true; else BfreqCityEditedManually = false;

            Debug.WriteLine("freqCityBox_KeyPress");
        }

        private void simplexRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (simplexRadio.Checked) groupBox3.Enabled = false;
            else groupBox3.Enabled = true;
        }

        private void groupBox3_EnabledChanged(object sender, EventArgs e)
        {
            if (!groupBox3.Enabled)
            {
                BFreqTextBox.Text = "";
                BBandwidthTextBox.Text = "";
                BAllocLabel.Text = "";
                swapFreqsBtn.Enabled = false;
            }
        }

        private void ANameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!BNameEditedManually)
            {
                try
                {
                    string[] tmp = ANameTextBox.Text.Split('-');
                    string a = tmp[0].Trim();
                    string b = tmp[1].Trim();
                    BNameTextBox.Text = b + " - " + a;
                }
                catch { }
            }
        }




        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                double doub;
                decimal dec;
                bool isDouble = Double.TryParse(Clipboard.GetText(), out doub);
                bool isDecimal = Decimal.TryParse(Clipboard.GetText(), out dec);
                bool isString = Clipboard.ContainsData(DataFormats.Text);
                if (isDouble || isDecimal)
                {
                    if (this.ActiveControl.Equals(ALat) ||
                        this.ActiveControl.Equals(ALon) ||
                        this.ActiveControl.Equals(BLat) ||
                        this.ActiveControl.Equals(BLon) ||
                        this.ActiveControl.Equals(AFreqTextBox) ||
                        this.ActiveControl.Equals(BFreqTextBox) ||
                        this.ActiveControl.Equals(ABandwidthTextBox) ||
                        this.ActiveControl.Equals(BBandwidthTextBox))
                    {
                        TextBox element = (TextBox)this.ActiveControl;
                        element.SelectAll();
                        element.Paste();

                        if (ALon.Focused) this.BLat.Focus();
                        else if (BLon.Focused) this.ANameTextBox.Focus();
                        else if (AFreqTextBox.Focused) this.BFreqTextBox.Focus();
                        else if (BFreqTextBox.Focused) this.ABandwidthTextBox.Focus();
                        else if (ABandwidthTextBox.Focused) this.BBandwidthTextBox.Focus();
                        else if (BBandwidthTextBox.Focused) this.OKBtn.Focus();
                        else this.SelectNextControl(this.ActiveControl, true, true, true, true);

                        return true;    // indicate that you handled this keystroke
                    }

                    if (this.ActiveControl.Equals(ALatMasked) ||
                        this.ActiveControl.Equals(BLatMasked) ||
                        this.ActiveControl.Equals(ALonMasked) ||
                        this.ActiveControl.Equals(BLonMasked))
                    {
                        MaskedTextBox element = (MaskedTextBox)this.ActiveControl;
                        element.SelectAll();
                        element.Paste();

                        if (ALonMasked.Focused) this.BLatMasked.Focus();
                        else if (BLonMasked.Focused) this.ANameTextBox.Focus();
                        else this.SelectNextControl(this.ActiveControl, true, true, true, true);

                        return true;    // indicate that you handled this keystroke
                    }
                }
                else if (isString)
                {
                    if (this.ActiveControl.Equals(ANameTextBox) ||
                        this.ActiveControl.Equals(BNameTextBox))
                    {
                        TextBox element = (TextBox)this.ActiveControl;
                        element.SelectAll();
                        element.Paste();

                        if (ANameTextBox.Focused) this.AFreqTextBox.Focus();
                        else this.SelectNextControl(this.ActiveControl, true, true, true, true);

                        return true;    // indicate that you handled this keystroke                        
                    }
                }
                else return base.ProcessCmdKey(ref msg, keyData);
            }

            else if (keyData == Keys.F4)
            {
                string[] text = Clipboard.GetText().Split('\t');
                if (text.Length != 8)
                {
                    MessageBox.Show("არასწორი პარამეტრთა რაოდენობა!");
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                try
                {
                    coordsTypeRadio4dec.Checked = true;

                    
                    string tmp;
                    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("ka-GE");
                    string ch = ci.NumberFormat.NumberDecimalSeparator;

                    tmp = text[1].Replace(".", ch);
                    tmp = tmp.Replace(",", ch);
                    ALat.Text = tmp;

                    tmp = text[2].Replace(".", ch);
                    tmp = tmp.Replace(",", ch);
                    ALon.Text = tmp;

                    tmp = text[3].Replace(".", ch);
                    tmp = tmp.Replace(",", ch);
                    BLat.Text = tmp;

                    tmp = text[4].Replace(".", ch);
                    tmp = tmp.Replace(",", ch);
                    BLon.Text = tmp;

                    ANameTextBox.Focus(); ANameTextBox.Text = text[0];

                    AFreqTextBox.Focus();  AFreqTextBox.Text = text[5];
                    BFreqTextBox.Focus(); BFreqTextBox.Text = text[6];
                    ABandwidthTextBox.Focus(); ABandwidthTextBox.Text = text[7];
                    BBandwidthTextBox.Focus(); BBandwidthTextBox.Text = text[7];

                    OKBtn.Focus();
                    Clipboard.Clear();
                }
                catch (Exception ee) {
                    MessageBox.Show("არასწორი ფორმატის ჩასმის მცდელობა!");
                    //MessageBox.Show(ee.InnerException.Message);
                    return base.ProcessCmdKey(ref msg, keyData);
                }


                
            }

            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
