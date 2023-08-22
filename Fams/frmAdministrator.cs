﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DataBase;
using Helpers;

namespace Fams
{
    public partial class frmAdministrator : Form
    {
        User _user;
        RepositoryItemLookUpEdit lookupEdit;

        public frmAdministrator(User user)
        {
            _user = user;
            

            InitializeComponent();
            if (_user == null || _user.TypeID != "Administrator") disableForm();

            // This line of code is generated by Data Source Configuration Wizard
            permissionsTableAdapter.Fill(privilegiesDataSet.Permissions);
            // This line of code is generated by Data Source Configuration Wizard
            usersTableAdapter.Fill(privilegiesDataSet.Users);


            lookupEdit = new RepositoryItemLookUpEdit();
            lookupEdit.DataSource = permissionsBindingSource;
            lookupEdit.ValueMember = "TypeID";
            lookupEdit.DisplayMember = "TypeID";
            lookupEdit.Columns.Clear();
            lookupEdit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeID", "მომხმარებლის როლი"));
            lookupEdit.NullValuePrompt = "";
            lookupEdit.NullText = "";

            gridView.Columns[1].ColumnEdit = lookupEdit;

            
        }

        private void disableForm()
        {
            gridControl.Enabled = false;
            usersGridControl.Enabled = false;
        }

        private void cardView_CustomDrawCardCaption(object sender, DevExpress.XtraGrid.Views.Card.CardCaptionCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.CardView view = sender as DevExpress.XtraGrid.Views.Card.CardView;
            (e.CardInfo as DevExpress.XtraGrid.Views.Card.ViewInfo.CardInfo).CaptionInfo.CardCaption = view.GetRowCellDisplayText(e.RowHandle, view.Columns["TypeID"]);

        }

        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (MessageBox.Show("გნებავთ შენახვა?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                usersTableAdapter.Update(this.privilegiesDataSet.Users);
            else
            {
                usersBindingSource.CancelEdit();
                usersTableAdapter.Fill(privilegiesDataSet.Users);
            }
        }


        private void gridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control)
            {
                if (MessageBox.Show("გნებავთ წაშლა?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    return;

                GridView view = sender as GridView;
                view.DeleteRow(view.FocusedRowHandle);
                this.usersTableAdapter.Update(this.privilegiesDataSet.Users);
            }
        }

      
				
 


    }
}
