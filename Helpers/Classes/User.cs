using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Helpers
{
    public class User
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
        }

        public string TypeID;
        public bool AddFreq;
        public bool EditFreqs;
        public bool DeleteFreqs;
        public bool EditLicence;
        public bool DeleteLicence;
        public bool EditComp;
        public bool DelComp;
        public bool EditFreqLic;
        public bool EditFreqComp;
        public bool ReestritCheck;
        public bool Confidential;
        public bool FreqGraph;
        public bool Nebartva;

        public bool admStAdd;
        public bool admStEdit;
        public bool admStDel;

        public User(string UserName)
        {
            _UserName = UserName;

            DataSet ds = HelperFunctions.fill("SELECT   Users.TypeID,  Permissions.AddFreq, Permissions.EditFreqs, Permissions.DeleteFreqs, Permissions.EditLicence, Permissions.DeleteLicence, Permissions.EditComp, Permissions.DelComp, Permissions.EditFreqLic, Permissions.EditFreqComp, Permissions.ReestritCheck, Permissions.Confidential, Permissions.Nebartva, Permissions.AdminStationsAdd, Permissions.AdminStationsEdit, Permissions.AdminStationsDelete, FreqGraph FROM         Users LEFT OUTER JOIN  Permissions ON Users.TypeID = Permissions.TypeID where Username=N'" + UserName + "'", DataBase.Properties.Settings.Default.PrivilegiesConnectionString.ToString());

            this.TypeID = ds.Tables[0].Rows[0]["TypeID"].ToString();
            this.AddFreq = Convert.ToBoolean(ds.Tables[0].Rows[0]["AddFreq"]);
            this.EditFreqs = Convert.ToBoolean(ds.Tables[0].Rows[0]["EditFreqs"]);
            this.DeleteFreqs = Convert.ToBoolean(ds.Tables[0].Rows[0]["DeleteFreqs"]);
            this.EditLicence = Convert.ToBoolean(ds.Tables[0].Rows[0]["EditLicence"]);
            this.DeleteLicence = Convert.ToBoolean(ds.Tables[0].Rows[0]["DeleteLicence"]);
            this.EditComp = Convert.ToBoolean(ds.Tables[0].Rows[0]["EditComp"]);
            this.DelComp = Convert.ToBoolean(ds.Tables[0].Rows[0]["DelComp"]);
            this.EditFreqLic = Convert.ToBoolean(ds.Tables[0].Rows[0]["EditFreqLic"]);
            this.EditFreqComp = Convert.ToBoolean(ds.Tables[0].Rows[0]["EditFreqComp"]);
            this.ReestritCheck = Convert.ToBoolean(ds.Tables[0].Rows[0]["ReestritCheck"]);
            this.Confidential = Convert.ToBoolean(ds.Tables[0].Rows[0]["Confidential"]);
            this.FreqGraph = Convert.ToBoolean(ds.Tables[0].Rows[0]["FreqGraph"]);
            this.Nebartva = Convert.ToBoolean(ds.Tables[0].Rows[0]["Nebartva"]);
            this.admStAdd = Convert.ToBoolean(ds.Tables[0].Rows[0]["AdminStationsAdd"]);
            this.admStEdit = Convert.ToBoolean(ds.Tables[0].Rows[0]["AdminStationsEdit"]);
            this.admStDel = Convert.ToBoolean(ds.Tables[0].Rows[0]["AdminStationsDelete"]);

        }

    }
}
