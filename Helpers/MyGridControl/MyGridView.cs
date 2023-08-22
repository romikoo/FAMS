using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Tab;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Helpers
{
    [System.ComponentModel.DesignerCategory("")]
      
    public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        FieldInfo fi = typeof(BaseView).GetField("tabControl", BindingFlags.NonPublic | BindingFlags.Instance);
        public MyGridView() : this(null) {
            MyViewTab viewTab = new MyViewTab(this);
            fi.SetValue(this, viewTab);
        }

		public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
            MyViewTab viewTab = new MyViewTab(this);
            fi.SetValue(this, viewTab);
		}



        protected override string ViewName { get { return "MyGridView"; } }
        protected override void PopulateTabMasterData(DevExpress.XtraGrid.Tab.ViewTab tabControl, int rowHandle)
        {
            base.PopulateTabMasterData(tabControl, rowHandle);

            foreach (ViewTabPage tabPage in tabControl.Pages)
            {
                (tabPage as IXtraTabPage).Appearance.Header.Font = new Font("Sylfaen", 8, FontStyle.Bold);

                Color c = new Color();
                //System.Diagnostics.Debug.WriteLine(tabPage.DetailInfo.RelationName);
                switch (tabPage.DetailInfo.RelationName)
                {
                    case "FK_fls_LICENCE_INFO_fls_COMPANY_INFO":
                        c = Color.FromArgb(50, 245, 161, 192);
                        (tabPage as IXtraTabPage).Appearance.Header.BackColor = c;
                        (tabPage as IXtraTabPage).Appearance.Header.Options.UseBackColor = true;
                        break;
                    case "FK_acc_Letters_fls_COMPANY_INFO":
                        c = Color.FromArgb(50, 167, 172, 214);
                        (tabPage as IXtraTabPage).Appearance.Header.BackColor =c;
                        (tabPage as IXtraTabPage).Appearance.Header.Options.UseBackColor = true;
                        break;
                    case "FK_arc_fls_LICENCE_INFO_fls_COMPANY_INFO":
                        c = Color.FromArgb(50, 253, 206, 163);
                        (tabPage as IXtraTabPage).Appearance.Header.BackColor = c;
                        (tabPage as IXtraTabPage).Appearance.Header.Options.UseBackColor = true;
                        break;
                    case "FK_fls_verificationAct_fls_COMPANY_INFO":
                        c = Color.FromArgb(50, 0, 170, 90);
                        (tabPage as IXtraTabPage).Appearance.Header.BackColor = c;
                        (tabPage as IXtraTabPage).Appearance.Header.Options.UseBackColor = true;
                        break;


                    case "FK_ero_Implementations_ero_FR_Band":
                        c = Color.FromArgb(50, 0, 170, 90);
                        (tabPage as IXtraTabPage).Appearance.Header.BackColor = c;
                        (tabPage as IXtraTabPage).Appearance.Header.Options.UseBackColor = true;
                        break;
                    case "FK_ero_AllocationPlan_ero_FR_Band":
                        c = Color.FromArgb(50, 253, 206, 163);
                        (tabPage as IXtraTabPage).Appearance.Header.BackColor = c;
                        (tabPage as IXtraTabPage).Appearance.Header.Options.UseBackColor = true;
                        break;

                    default: break;

                }
               
            }

        }


        protected override int ScrollPageSize
        {
            get
            {
                return 1000;
                //return base.ScrollPageSize;
            }
        }
    }
}
