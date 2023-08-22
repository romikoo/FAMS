using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DataBase;
using DevExpress.Utils;
using DevExpress.XtraMap;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using Helpers;

namespace Fams
{
    public partial class frmCalcResults : Form
    {
        List<calcResults> results = new List<calcResults>();
        DataSet ds;
        private BindingSource _bs;
        private bool CalendarVisible;


        public frmCalcResults(ref BindingSource bs)
        {
            _bs = bs;

            CultureInfo ci = new CultureInfo("ka-GE");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            InitializeComponent();

            dateTimePicker1.Value = DateTime.Now;
            bwthColumn.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatter();
            bwthColumn.DisplayFormat.FormatType = FormatType.Custom;
            freqColumn.DisplayFormat.Format = (IFormatProvider)new FreqCustomFormatter();
            freqColumn.DisplayFormat.FormatType = FormatType.Custom;

            proceedCalculations();


        }

        private void proceedCalculations()
        {
            showWait();
            gridControl.Focus();
            results.Clear();
            gridControl.DataSource = results;
            if (this.ds == null)
            {
                ds = new DataSet();
                new SqlDataAdapter(new SqlCommand("select * from Zone where koef is not null", new SqlConnection(DataBase.Properties.Settings.Default.OfficeConnectionString.ToString()))).Fill(ds);
            }
            int position = this._bs.Position;
            for (int index = 0; index < this._bs.Count; index++)
            {
                _bs.Position = index;
                OfficeDataSet.Fixed_rel_linksRow fixedRelLinksRow = (OfficeDataSet.Fixed_rel_linksRow)((DataRowView)_bs.Current).Row;
                double pwr1;
                try
                {
                    pwr1 = fixedRelLinksRow.Apower;
                }
                catch
                {
                    pwr1 = 0.25;
                }
                this.results.Add(new calcResults(this.ds, fixedRelLinksRow.AName, new GeoPoint((double)fixedRelLinksRow.Alat, (double)fixedRelLinksRow.Alon), pwr1, fixedRelLinksRow.ATX_B, (int)fixedRelLinksRow.ATX, firstYearDaysCoef(), mobCheckBox.Checked));
                try
                {
                    double pwr2;
                    try
                    {
                        pwr2 = fixedRelLinksRow.Bpower;
                    }
                    catch
                    {
                        pwr2 = 0.25;
                    }
                    this.results.Add(new calcResults(this.ds, fixedRelLinksRow.BName, new GeoPoint((double)fixedRelLinksRow.Blat, (double)fixedRelLinksRow.Blon), pwr2, fixedRelLinksRow.BTX_B, (int)fixedRelLinksRow.BTX, this.firstYearDaysCoef(), this.mobCheckBox.Checked));
                }
                catch
                {
                }
                gridView.UpdateTotalSummary();
            }
            _bs.Position = position;
            _bs.MoveFirst();
            gridView.RefreshData();
            hideWait();
        }

        private double firstYearDaysCoef()
        {
            DateTime dateTime1 = new DateTime(this.dateTimePicker1.Value.Year, 1, 1);
            DateTime dateTime2 = new DateTime(this.dateTimePicker1.Value.Year + 1, 1, 1);
            return (double)((dateTime2 - this.dateTimePicker1.Value).Days + 1) / (double)(dateTime2 - dateTime1).Days;
        }


        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CellPaintHelper.CreateCellPaintHelper((GridView) sender, e.RowHandle, e.Column);
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.Info == null && e.SelectedControl == gridControl)
            {
                
                DevExpress.XtraGrid.Views.Grid.GridView view = gridView;
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info =  view.CalcHitInfo(e.ControlMousePosition);
                if (info.InRowCell)
                {
                    string text = view.GetRowCellDisplayText(info.RowHandle, info.Column);
                    string cellKey = info.RowHandle.ToString() + " - " + info.Column.ToString();
                    e.Info = new DevExpress.Utils.ToolTipControlInfo(cellKey, results[info.RowHandle].formula);
                    Debug.WriteLine(results[info.RowHandle].formula);
                }
                
            }
            
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (!gridControl.IsPrintingAvailable) MessageBox.Show("The 'DevExpress.XtraPrinting' library is not found", "Error");
            else gridControl.ShowPrintPreview();
        }

        private void spinEdit1_ValueChanged(object sender, EventArgs e)
        {
            int count = this.gridView.Columns.Count;
            for (int index = count - 15; index < count; ++index)
            {
                if ((Decimal)index < (Decimal)(count - 15) + this.spinEdit1.Value)
                    this.gridView.Columns[index].Visible = true;
                else
                    this.gridView.Columns[index].Visible = false;
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            CalendarVisible = false;
            proceedCalculations();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (this.CalendarVisible)
                return;
            this.proceedCalculations();
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            this.CalendarVisible = true;
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        protected void showWait()
        {
            System.Diagnostics.Debug.WriteLine("showWait");
            splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Helpers.WaitForm1), true, true);
            splashScreenManager1.ShowWaitForm();
        }

        protected void hideWait()
        {
            try
            {
                splashScreenManager1.CloseWaitForm();
                splashScreenManager1.Dispose();
            }
            catch
            {
            }
        }

        private void mobCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            proceedCalculations();
        }


    }


    class calcResults
    {
        public string station { get; set; }

        public int bandwidth { get; set; }

        public double power { get; set; }

        public string region { get; set; }

        public double Pf { get; set; }

        public double Kq { get; set; }

        public double Kp { get; set; }

        public double Ks { get; set; }

        public double Kg { get; set; }

        public double price { get; set; }

        public double p1 { get; set; }

        public double p2 { get; set; }

        public double p3 { get; set; }

        public double p4 { get; set; }

        public double p5 { get; set; }

        public double p6 { get; set; }

        public double p7 { get; set; }

        public double p8 { get; set; }

        public double p9 { get; set; }

        public double p10 { get; set; }

        public double p11 { get; set; }

        public double p12 { get; set; }

        public double p13 { get; set; }

        public double p14 { get; set; }

        public double p15 { get; set; }

        public int frequency { get; set; }

        public string formula
        {
            get
            {
                return string.Format("Pf={0}; Kq={1}; Kp={2}; Ks={3}; Kg={4}", (object)this.Pf, (object)this.Kq, (object)this.Kp, (object)this.Ks, (object)this.Kg);
            }
        }

        public calcResults(DataSet ds, string st, GeoPoint location, double pwr, int bwth, int freq, double daysCoef = 1.0, bool asMobile = false)
        {
            station = st;
            power = pwr;
            bandwidth = bwth;
            frequency = freq;
            Point t = new Point(Convert.ToInt32(location.Longitude * 10000.0), Convert.ToInt32(location.Latitude * 10000.0));
            for (int index1 = 0; index1 < ds.Tables[0].Rows.Count; ++index1)
            {
                string[] strArray1 = ds.Tables[0].Rows[index1]["Coords"].ToString().Split(new string[1]{")("}, StringSplitOptions.RemoveEmptyEntries);
                Regioni regioni = new Regioni();
                Point[] p = new Point[strArray1.GetLength(0)];
                for (int index2 = 0; index2 < strArray1.GetLength(0); ++index2)
                {
                    strArray1[index2] = strArray1[index2].Replace("(", "");
                    strArray1[index2] = strArray1[index2].Replace(")", "");
                    string[] strArray2 = strArray1[index2].Split(new string[1]{","}, StringSplitOptions.RemoveEmptyEntries);
                    p[index2] = new Point(Convert.ToInt32(Convert.ToDouble(strArray2[0], (IFormatProvider)CultureInfo.InvariantCulture) * 10000.0), Convert.ToInt32(Convert.ToDouble(strArray2[1], (IFormatProvider)CultureInfo.InvariantCulture) * 10000.0));
                }
                if (regioni.PointInPolygon(p, t))
                {
                    this.region = ds.Tables[0].Rows[index1]["Name"].ToString();
                    try
                    {
                        this.Kg = !asMobile ? Convert.ToDouble(ds.Tables[0].Rows[index1]["koef"].ToString()) : 1.0;
                        break;
                    }
                    catch
                    {
                        this.Kg = 0.0;
                        break;
                    }
                }
            }
            Pf = (double)this.calcPf(this.bandwidth, this.frequency);
            Kq = calcKq(frequency);
            Kp = calcKp(power);
            Ks = (double)this.calcKs(this.bandwidth);
            price = this.Pf * this.Kq * this.Kp * this.Ks * this.Kg;
            p1 = Math.Round(price * 0.2 * daysCoef, 2);
            p2 = Math.Round(price * 0.2, 2);
            p3 = Math.Round(price * 0.1, 2);
            p4 = Math.Round(price * 0.1, 2);
            p5 = Math.Round(price * 0.1, 2);
            p6 = Math.Round(price * 0.3, 2);
            p7 = Math.Round(price * 0.3, 2);
            p8 = Math.Round(price * 0.3, 2);
            p9 = Math.Round(price * 0.3, 2);
            p10 = Math.Round(price * 0.3, 2);
            p11 = Math.Round(price * 0.4, 2);
            p12 = Math.Round(price * 0.4, 2);
            p13 = Math.Round(price * 0.4, 2);
            p14 = Math.Round(price * 0.4, 2);
            p15 = Math.Round(price * 0.4, 2);
        }

        private int calcPf(int bandwidth, int freq)
        {
            if (bandwidth <= 25)
                return 800;
            if (bandwidth > 25 && bandwidth <= 125)
                return 1700;
            if (bandwidth > 125 && bandwidth <= 250)
                return 3200;
            if (bandwidth > 250 && bandwidth <= 500)
                return 4500;
            if (bandwidth > 500 && bandwidth <= 1700)
            {
                if (freq < 10000000)
                    return 8700;
                if (freq > 10000000 && freq <= 20000000)
                    return 4410;
                return freq > 20000000 && freq <= 30000000 ? 3000 : 2100;
            }
            if (bandwidth > 1700 && bandwidth <= 3500)
            {
                if (freq < 10000000)
                    return 11100;
                if (freq > 10000000 && freq <= 20000000)
                    return 6600;
                return freq > 20000000 && freq <= 30000000 ? 4410 : 3000;
            }
            if (bandwidth > 3500 && bandwidth <= 7000)
            {
                if (freq < 10000000)
                    return 17700;
                if (freq > 10000000 && freq <= 20000000)
                    return 13410;
                return freq > 20000000 && freq <= 30000000 ? 8700 : 6000;
            }
            if (bandwidth > 7000 && bandwidth <= 14000)
            {
                if (freq < 10000000)
                    return 24450;
                if (freq > 10000000 && freq <= 20000000)
                    return 19950;
                return freq > 20000000 && freq <= 30000000 ? 13410 : 8700;
            }
            if (bandwidth > 14000 && bandwidth <= 28000)
            {
                if (freq < 10000000)
                    return 30900;
                if (freq > 10000000 && freq <= 20000000)
                    return 26640;
                return freq > 20000000 && freq <= 30000000 ? 17700 : 11700;
            }
            if (bandwidth > 28000 && bandwidth <= 56000)
            {
                if (freq < 10000000)
                    return 37800;
                if (freq > 10000000 && freq <= 20000000)
                    return 33300;
                return freq > 20000000 && freq <= 30000000 ? 21000 : 14850;
            }
            if (freq < 10000000)
                return 44400;
            if (freq > 10000000 && freq <= 20000000)
                return 39900;
            return freq > 20000000 && freq <= 30000000 ? 26400 : 17700;
        }

        private double calcKq(int freq)
        {
            if (freq > 9 && freq <= 470000)
                return 1.8;
            if (freq > 470000 && freq <= 960000)
                return 1.5;
            if (freq > 960000 && freq <= 3000000)
                return 1.0;
            if (freq > 3000000 && freq <= 10000000)
                return 0.8;
            if (freq > 10000000 && freq <= 17700000)
                return 0.6;
            if (freq > 17700000 && freq <= 40000000)
                return 0.4;
            return freq > 40000000 && freq <= 60000000 ? 0.2 : -1.0;
        }

        private double calcKp(double power)
        {
            if (power <= 5.0)
                return 0.1;
            if (power > 5.0 && power <= 10.0)
                return 0.18;
            if (power > 10.0 && power <= 25.0)
                return 0.35;
            if (power > 25.0 && power <= 50.0)
                return 0.52;
            if (power > 50.0 && power <= 100.0)
                return 0.7;
            if (power > 100.0 && power <= 250.0)
                return 0.85;
            if (power > 250.0 && power <= 500.0)
                return 1.0;
            if (power > 500.0 && power <= 1000.0)
                return 1.1;
            if (power > 1000.0 && power <= 2500.0)
                return 1.2;
            if (power > 2500.0 && power <= 5000.0)
                return 1.25;
            return power > 5000.0 && power <= 10000.0 ? 1.3 : 1.4;
        }

        private int calcKs(int bandwidth)
        {
            return 1;
        }
            
    }


}
