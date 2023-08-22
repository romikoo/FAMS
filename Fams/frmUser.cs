using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;

namespace Fams
{
    public partial class frmUser : Form
    {
        int _compid;

        public frmUser(int compid)
        {
            InitializeComponent();
            _compid = compid;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Guid? g;
            g = Guid.NewGuid();

            DataBase.pubsDataSetTableAdapters.QueriesTableAdapter scalarQueriesTableAdapter = new DataBase.pubsDataSetTableAdapters.QueriesTableAdapter();
            

            string ApplicationName = "FAMS(c) - by R. Kurdadze, 2010";
            //string ApplicationName = "/";
            string UserName = usernameEdit.Text;
            string password = CreatePassword(8);
            string passwordSalt = GenerateSalt();
            string email = "1@1.com";
            //string passwordQuestion = "";
            //string passwordAnswer = "";
            bool? IsApproved = true;
            DateTime? currenttimeutc = DateTime.UtcNow;
            DateTime? CreateDate = DateTime.Now;
            int? uniqueEmail = 0;
            int? passwordFormat = 0;
            string roleName = "Restricted Users";


            int returnValue;
            returnValue = (int)scalarQueriesTableAdapter.aspnet_Membership_CreateUser(
                ApplicationName,
                UserName,
                password,
                passwordSalt,
                email,
                null,
                null,
                IsApproved,
                currenttimeutc,
                CreateDate,
                uniqueEmail,
                passwordFormat,
                ref g);
            System.Diagnostics.Debug.WriteLine(returnValue);

            returnValue = (int)scalarQueriesTableAdapter.aspnet_Membership_UpdateUser(
                ApplicationName,
                UserName,
                email,
                _compid.ToString(),
                IsApproved,
                CreateDate,
                CreateDate,
                uniqueEmail,
                currenttimeutc);
            System.Diagnostics.Debug.WriteLine(returnValue);

            ApplicationName = "/";
            returnValue = (int)scalarQueriesTableAdapter.aspnet_UsersInRoles_AddUsersToRoles(
                ApplicationName,
                UserName,
                roleName,
                currenttimeutc);
            System.Diagnostics.Debug.WriteLine(returnValue);

            /*
            string t = "use pubs; insert into aspnet_UsersInRoles (UserId, RoleId) select '" + g + "', RoleId from aspnet_Roles where RoleName='" + roleName + "'";
            HelperFunctions.ExecuteNonQuery(t, DataBase.Properties.Settings.Default.pubsConnectionString.ToString());
            System.Diagnostics.Debug.WriteLine(t);*/

            

        }

        internal string GenerateSalt()
        {
            byte[] buf = new byte[16];
            (new System.Security.Cryptography.RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

      

    }
}
