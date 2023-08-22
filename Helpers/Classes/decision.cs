using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Data;
using DataBase;

namespace Helpers
{
    public class decision
    {
        private System.ComponentModel.IContainer components = null;


        private GNCCDBDataSet gNCCDBDataSet;
        private System.Windows.Forms.BindingSource vDataExchange_LicensesBindingSource;
        private DataBase.GNCCDBDataSetTableAdapters.vDataExchange_LicensesTableAdapter vDataExchange_LicensesTableAdapter;

        public decision()
        {
            this.components = new System.ComponentModel.Container();
            this.gNCCDBDataSet = new DataBase.GNCCDBDataSet();
            this.vDataExchange_LicensesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vDataExchange_LicensesTableAdapter = new DataBase.GNCCDBDataSetTableAdapters.vDataExchange_LicensesTableAdapter();

            
            
            

            
            // 
            // gNCCDBDataSet
            // 
            this.gNCCDBDataSet.DataSetName = "GNCCDBDataSet";
            this.gNCCDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vDataExchange_LicensesBindingSource
            // 
            this.vDataExchange_LicensesBindingSource.DataMember = "vDataExchange_Licenses";
            this.vDataExchange_LicensesBindingSource.DataSource = this.gNCCDBDataSet;
            // 
            // vDataExchange_LicensesTableAdapter
            // 
            this.vDataExchange_LicensesTableAdapter.ClearBeforeFill = true;
        }


        public void ShowDecision(FREQVIEW freq)
        {
            vDataExchange_LicensesTableAdapter.Fill(this.gNCCDBDataSet.vDataExchange_Licenses);

            string defaultBrowserPath = GetDefaultBrowserPath();
            string d1 = "";
            string day1 = "";
            string month = "";
            string d2 = "";

            if (!freq.LIC_ISSU_DATE.Contains("-"))
            {
                try
                {
                    if (Convert.ToInt32(freq.LIC_ISSU_DATE.Split('/')[1]) < 10) day1 = "0" + Convert.ToInt32(freq.LIC_ISSU_DATE.Split('/')[1]);
                    else day1 = freq.LIC_ISSU_DATE.Split('/')[1];

                    if (Convert.ToInt32(freq.LIC_ISSU_DATE.Split('/')[0]) < 10) month = "0" + Convert.ToInt32(freq.LIC_ISSU_DATE.Split('/')[0]);
                    else month = freq.LIC_ISSU_DATE.Split('/')[0];

                    d1 = day1 + "-" + month + "-" + freq.LIC_ISSU_DATE.Split('/')[2];
                    d2 = d1;
                    
                }
                catch { }
            } 
            else
            {
                d1 = freq.LIC_ISSU_DATE;
                d2 = d1;
            }
        


            string n1 = "";
            string n2 = "";
            string URL = "";

            try
            {
                /*
                n1 = freq.LICENCE.Split('/')[0]; n1 = n1.Trim();
                n2 = freq.LICENCE.Split('/')[1]; n2 = n2.Trim();
                URL = "http://www.gncc.ge/index.php?info_legal_form=" + n1 + "&info_legal_form2=" + n2 + "&search_string_legal=&search_string_legal_full=&info_date_from=" + d1 + "&info_date_to=" + d2 + "&sec_id=7070&lang_id=GEO&Submit=ძიება";
                Process.Start(defaultBrowserPath, URL);
                */

                /*
                n1 = freq.LICENCE.Split('/')[0]; n1 = n1.Trim();
                n2 = freq.LICENCE.Split('/')[1]; n2 = n2.Trim();
                string query = "{\"text\":\"\",\"body\":\"\",\"order_number_first\":\""+n1+"\",\"order_number_second\":\""+n2+"\",\"getting_date_from\":\""+d1+"\",\"getting_date_to\":\""+d2+"\"}";
                URL = Properties.Settings.Default.decisionURL + Base64Encode(query) + Properties.Settings.Default.decisionURL_end;
                Debug.WriteLine(query);
                Debug.WriteLine(Base64Encode(query));
                Process.Start(defaultBrowserPath, URL);*/

                
                n1 = freq.LICENCE.Split('/')[0]; n1 = n1.Trim();
                n2 = freq.LICENCE.Split('/')[1]; n2 = n2.Trim();
                URL = string.Format("https://comcom.ge/ge/legal-acts/solutions/{0}-{1}-{2}.page", DateTime.Parse(freq.LIC_ISSU_DATE).Year, n1.Replace("გ", ""), n2);
                Process.Start(defaultBrowserPath, URL);
                

            }
            catch (Exception exp)
            {
                URL = getLicenceURL(freq.LICENCE);
                if (URL!=null) Process.Start(defaultBrowserPath, URL);
                else MessageBox.Show("შეცდომა: გადაწყვეტილება ვერ მოიძებნა.\r\nსავარაუდო პრობლემა: გადაწყვეტილების ნომერი ან/და გაცემის თარიღი.\r\nშეცდომის კოდი: " + exp.Message);
            }

            
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes).Replace("==", "");
        }


        private static string GetDefaultBrowserPath()
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            // get default browser path
            return ((string)registryKey.GetValue(null, null)).Split('"')[1];
        }

        public string getLicenceURL(string LICENCE)
        {
            vDataExchange_LicensesBindingSource.MoveFirst();

            for (int i = 0; i < vDataExchange_LicensesBindingSource.Count; i++)
            {
                if (((GNCCDBDataSet.vDataExchange_LicensesRow)((DataRowView)vDataExchange_LicensesBindingSource.Current).Row).LicNum == LICENCE)
                    return ((GNCCDBDataSet.vDataExchange_LicensesRow)((DataRowView)vDataExchange_LicensesBindingSource.Current).Row).URL;
                vDataExchange_LicensesBindingSource.MoveNext();
            }

            return null;

        }
    }


    public class decisionURL
    {
        public string text { get; set; }
        public string body { get; set; }
        public string order_number_first { get; set; }
        public string order_number_second { get; set; }
        public string getting_date_from { get; set; }
        public string getting_date_to { get; set; }
       
    }
}
