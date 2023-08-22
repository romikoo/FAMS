using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Xna.Framework;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;


namespace Helpers
{
    public class FREQVIEW
    {
        public Microsoft.Xna.Framework.Rectangle displayedPos = new Microsoft.Xna.Framework.Rectangle();
        public bool currentlyActive = true;
        public int id;
        public int freq;
        public string Comp_Name;
        public string city;
        public string remark;
        public int FREQ;
        public int BandWidth;
        public bool reestrit;
        public string LICENCE;
        public string LIC_ISSU_DATE;
        public string LIC_EXPIRY_DATE;
        public int comp_id;
        public int lic_id;
        public bool? isCanceled;
        private int _fromX;
        private int _toX;
        private System.Drawing.Color _color;

        public int fromX
        {
            get
            {
                this._fromX = this.freq - this.BandWidth / 2;
                return this._fromX;
            }
        }

        public int toX
        {
            get
            {
                this._toX = this.freq + this.BandWidth / 2;
                return this._toX;
            }
        }

        public System.Drawing.Color color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
            }
        }


        public bool mouseIn(Vector2 position)
        {
            if (position.X > displayedPos.X && position.X < displayedPos.X + displayedPos.Width && position.Y > displayedPos.Y && position.Y < displayedPos.Y + displayedPos.Height) return true;
            else return false;
        }
    }

    public class frequencies
    {
        public List<FREQVIEW> freq = new List<FREQVIEW>();
        private int _total;
        private int _minFreq = -1;
        public int mimFreq
        {
            get { return _minFreq; }
        }

        private int _maxFreq = -1;
        public int maxFreq
        {
            get { return _maxFreq; }
        }


        public int total
        {
            get { return _total; }
        }

        private bool _securedAllowed;
        public bool securedAllowed
        {
            get { return _securedAllowed; }
        }

        public frequencies(User us)
        {
            DataSet dataSet1 = new DataSet();
            if (us.Confidential)
            {
                try
                {
                    DataSet dataSet2 = HelperFunctions.fill("SELECT *, DateDiff(dd, GetDate(), LIC_EXPIRY_DATE) as diff, 1 as secured, 0 as arc, 0 as isCanceled FROM FreqVisualSecured ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.SecureConnectionString.ToString());
                    dataSet1.Tables.Add(dataSet2.Tables[0].Copy());
                    foreach (DataRow row in (InternalDataCollectionBase)HelperFunctions.fill("SELECT *, DateDiff(dd, GetDate(), LIC_EXPIRY_DATE) as diff, 0 as secured, 0 as arc FROM FreqVisual ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString()).Tables[0].Rows)
                        dataSet1.Tables[0].ImportRow(row);
                    foreach (DataRow row in (InternalDataCollectionBase)HelperFunctions.fill("SELECT *, DateDiff(dd, GetDate(), LIC_EXPIRY_DATE) as diff, 0 as secured, 1 as arc, 0 as isCanceled FROM FreqVisualArc ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString()).Tables[0].Rows)
                        dataSet1.Tables[0].ImportRow(row);
                    this._securedAllowed = true;
                }
                catch (Exception ex)
                {
                    int num = (int)System.Windows.Forms.MessageBox.Show("არ გაიხსნა სპეც სიხშირეების ბაზა!", "ყურადება", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    DataSet dataSet2 = HelperFunctions.fill("SELECT *, DateDiff(dd, GetDate(), LIC_EXPIRY_DATE) as diff, 0 as secured, 0 as arc FROM FreqVisual ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                    dataSet1.Tables.Add(dataSet2.Tables[0].Copy());
                    foreach (DataRow row in (InternalDataCollectionBase)HelperFunctions.fill("SELECT *, DateDiff(dd, GetDate(), LIC_EXPIRY_DATE) as diff, 0 as secured, 1 as arc, 0 as isCanceled FROM FreqVisualArc ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString()).Tables[0].Rows)
                        dataSet1.Tables[0].ImportRow(row);
                    this._securedAllowed = false;
                }
            }
            else
            {
                DataSet dataSet2 = HelperFunctions.fill("SELECT *, DateDiff(dd, GetDate(), LIC_EXPIRY_DATE) as diff, 0 as secured, 0 as arc FROM FreqVisual where Comp_Name NOT LIKE N'%ბანკი%' and Comp_Name NOT LIKE N'%უშიშროებ%' and Comp_Name NOT LIKE N'%გამოძი%' and Comp_Name NOT LIKE N'%თავდაცვ%' and Comp_Name NOT LIKE N'%საელჩო%' and Comp_Name NOT LIKE N'%შინაგან%'  and Comp_Name NOT LIKE N'%ფინანსთა%'  and Comp_Name NOT LIKE N'%საზღვრის%' and Comp_Name NOT LIKE N'%სასაზღვრო%' ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                dataSet1.Tables.Add(dataSet2.Tables[0].Copy());
                foreach (DataRow row in (InternalDataCollectionBase)HelperFunctions.fill("SELECT *, DateDiff(dd, GetDate(), LIC_EXPIRY_DATE) as diff, 0 as secured, 1 as arc, 0 as isCanceled FROM FreqVisualArc ORDER BY freq, Comp_Name, city", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString()).Tables[0].Rows)
                    dataSet1.Tables[0].ImportRow(row);
            }
            this._total = dataSet1.Tables[0].Rows.Count;
            foreach (DataRow dataRow in (InternalDataCollectionBase)dataSet1.Tables[0].Rows)
            {
                FREQVIEW freqview = new FREQVIEW();
                freqview.id = Convert.ToInt32(dataRow["id"]);
                freqview.freq = Convert.ToInt32(dataRow["freq"]);
                freqview.Comp_Name = !(dataRow["arc"].ToString() == "1") ? dataRow["Comp_Name"].ToString() : "#არქივი# " + dataRow["Comp_Name"].ToString();
                freqview.city = dataRow["city"].ToString();
                freqview.remark = dataRow["remark"].ToString();
                freqview.FREQ = Convert.ToInt32(dataRow["FREQ"]);
                freqview.BandWidth = Convert.ToInt32(dataRow["BandWidth"]);
                freqview.reestrit = Convert.ToBoolean(dataRow["reestrit"]);
                freqview.LICENCE = Convert.ToString(dataRow["LICENCE"]);
                freqview.comp_id = Convert.ToInt32(dataRow["comp_id"]);
                freqview.lic_id = Convert.ToInt32(dataRow["lic_id"]);
                freqview.isCanceled = dataRow["isCanceled"] != DBNull.Value ? new bool?(Convert.ToBoolean(dataRow["isCanceled"])) : new bool?(false);
                string str1 = dataRow["LIC_ISSU_DATE"].ToString();
                if (str1 != "")
                {
                    string str2 = str1.Substring(0, str1.IndexOf(" "));
                    freqview.LIC_ISSU_DATE = str2;
                }
                string str3 = dataRow["LIC_EXPIRY_DATE"].ToString();
                if (str3 != "")
                {
                    string str2 = str3.Substring(0, str3.IndexOf(" "));
                    freqview.LIC_EXPIRY_DATE = str2;
                }
                Random random = new Random(this.freq.Count);
                System.Drawing.Color color = System.Drawing.Color.FromArgb(random.Next(90, 130), random.Next(90, 130), random.Next(90, 130));
                if (freqview.LICENCE.Equals("პროექტი"))
                {
                    color = System.Drawing.Color.FromArgb(random.Next(220, (int)byte.MaxValue), 0, random.Next(220, (int)byte.MaxValue));
                    freqview.currentlyActive = false;
                }
                else
                {
                    bool? nullable = freqview.isCanceled;
                    if ((!nullable.GetValueOrDefault() ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
                    {
                        freqview.Comp_Name = "#გაუქმებული# " + freqview.Comp_Name;
                        freqview.color = color = System.Drawing.Color.FromArgb(random.Next(200, (int)byte.MaxValue), 0, random.Next(100, 150));
                        freqview.currentlyActive = false;
                    }
                    else if (dataRow["diff"].ToString().Length > 0)
                    {
                        if (Convert.ToInt32(dataRow["diff"]) > 0 && Convert.ToInt32(dataRow["diff"]) <= 31)
                            color = System.Drawing.Color.FromArgb(random.Next(200, (int)byte.MaxValue), random.Next(200, (int)byte.MaxValue), 0);
                        else if (Convert.ToInt32(dataRow["diff"]) <= 0)
                        {
                            color = System.Drawing.Color.FromArgb(random.Next(200, (int)byte.MaxValue), 0, 0);
                            freqview.currentlyActive = false;
                        }
                    }
                    else
                    {
                        if (freqview.LIC_ISSU_DATE != null)
                            color = System.Drawing.Color.FromArgb(0, 0, random.Next(200, (int)byte.MaxValue));
                        freqview.currentlyActive = false;
                    }
                }
                if (dataRow["secured"].ToString() == "1")
                    freqview.color = System.Drawing.Color.FromArgb(0, random.Next(200, (int)byte.MaxValue), 0);
                else if (dataRow["arc"].ToString() == "1")
                {
                    freqview.color = System.Drawing.Color.FromArgb(random.Next(200, 230), random.Next(200, 230), random.Next(200, 230));
                    freqview.currentlyActive = false;
                }
                else
                    freqview.color = color;
                this.freq.Add(freqview);
                if (this._minFreq > freqview.freq || this._minFreq == -1)
                    this._minFreq = freqview.freq;
                if (this._maxFreq < freqview.freq || this._maxFreq == -1)
                    this._maxFreq = freqview.freq;
            }
        }

        public FREQVIEW mouseIn(Vector2 position, int y, int height)
        {
            foreach (FREQVIEW freqview in this.freq)
            {
                if (freqview.mouseIn(position))
                    return freqview;
            }
            return (FREQVIEW)null;
        }
    }
}
