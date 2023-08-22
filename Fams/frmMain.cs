using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using System.Xml;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Win32;
using System.IO;
using Fams.Reports;
using Helpers;
using DataBase;
using XNA;

namespace Fams
{

    

    public partial class frmMain : Form
    {
        private User user;

        //private bool _dragging = false;
        //private int _X, _Y;

        private Process myProcess = new Process();

        private GridEXTable table;
        private int lic = -1, freq = -1;
        public int frqID;

        private bool _visible = false;
        private BackgroundWorker relLinksGetter;
        private int prev_link_id = -1;
        private bool admStationsCheckBox_checkedChanging = false;
        zone_cities zCities;


        private int Current_lic;
        private int current_lic
        {
            get
            {
                return Current_lic;
            }

            set
            {
                int prev = Current_lic;
                Current_lic = value;
                admAddBtn.Enabled = (Current_lic >= 0 && user.admStAdd);
                if (relLinksGetter != null && admStationsCheckBox_checkedChanging || admStationsCheckBox.Checked)
                {
                    Debug.WriteLine("admStationsCheckBox_checkedChanging =" + admStationsCheckBox_checkedChanging);
                    if (!relLinksGetter.CancellationPending) relLinksGetter.CancelAsync();
                    if (Current_lic != prev || admStationsCheckBox_checkedChanging)
                    {
                        Debug.WriteLine(string.Format("#### lic_id changed from {0} to {1}", prev, Current_lic));
                        if (!relLinksGetter.IsBusy) relLinksGetter.RunWorkerAsync();
                        //splitContainer.Panel2Collapsed = Current_lic < 0;
                    }
                }
            }
        }

        //for repeatible frequencies enter:
        long f;
        int bwth;
        bool rees;


        System.Collections.ArrayList stations = new System.Collections.ArrayList();
        private commShare common;

        
        /*
        private event CheckHandler OnCheck;
        private delegate void CheckHandler(
          object obj,
          CheckEventArgs myArgs
        );*/


        public frmMain(User _user, ref commShare comm)
        {
            user = _user;
            zCities = new zone_cities(user);

            this.common = comm;
            InitializeComponent();
            common.goToCompFreqChange += new commShare.GoToCompFreqDelegate(gotofreq);

            this.ActiveControl = gridEX1;



            this.fls_COMPANY_INFOTableAdapter.Fill(this.officeDataSet.fls_COMPANY_INFO);
            this.fls_LICENCE_INFOTableAdapter.Fill(this.officeDataSet.fls_LICENCE_INFO);
            this.fls_LICENCE_FREQTableAdapter.Fill(this.officeDataSet.fls_LICENCE_FREQ);
            this.zone_CityTableAdapter.Fill(this.officeDataSet.Zone_City);


            // TODO: This line of code loads data into the 'officeDataSet.arc_fls_LICENCE_INFO' table. You can move, or remove it, as needed.
            this.arc_fls_LICENCE_INFOTableAdapter.Fill(this.officeDataSet.arc_fls_LICENCE_INFO);
            // TODO: This line of code loads data into the 'officeDataSet.arc_fls_LICENCE_FREQ' table. You can move, or remove it, as needed.
            this.arc_fls_LICENCE_FREQTableAdapter.Fill(this.officeDataSet.arc_fls_LICENCE_FREQ);
            // TODO: This line of code loads data into the 'officeDataSet.acc_projectWorkflow' table. You can move, or remove it, as needed.
            this.acc_projectWorkflowTableAdapter.Fill(this.officeDataSet.acc_projectWorkflow);
            // TODO: This line of code loads data into the 'officeDataSet.shekvanili_sadgurebi' table. You can move, or remove it, as needed.
            this.shekvanili_sadgurebiTableAdapter.Fill(this.officeDataSet.shekvanili_sadgurebi);
            // TODO: This line of code loads data into the 'officeDataSet.fls_NEBARTVA' table. You can move, or remove it, as needed.
            this.fls_NEBARTVATableAdapter.Fill(this.officeDataSet.fls_NEBARTVA);
            // TODO: This line of code loads data into the 'officeDataSet.acc_FREQ' table. You can move, or remove it, as needed.
            this.acc_FREQTableAdapter.Fill(this.officeDataSet.acc_FREQ);
            // TODO: This line of code loads data into the 'officeDataSet.acc_Letters' table. You can move, or remove it, as needed.
            this.acc_LettersTableAdapter.Fill(this.officeDataSet.acc_Letters);
            

            

           


            relLinksGetter = new BackgroundWorker();
            relLinksGetter.DoWork += new DoWorkEventHandler(relLinksGetter_DoWork);
            relLinksGetter.RunWorkerCompleted += new RunWorkerCompletedEventHandler(relLinksGetter_RunWorkerCompleted);
            relLinksGetter.ProgressChanged += new ProgressChangedEventHandler(relLinksGetter_ProgressChanged);
            relLinksGetter.WorkerReportsProgress = true;
            relLinksGetter.WorkerSupportsCancellation = true;

            splitContainer.Panel2Collapsed = true;

        }


        #region asyncGetRelLinks

        private void relLinksGetter_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("prev link_id: " + prev_link_id);

            List<string> res = new List<string>();

            DataSet ds = Functions.fill(string.Format("select * from Fixed_rel_links where Alic_id={0} or Blic_id={0}", current_lic), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
            int count = Convert.ToInt32(ds.Tables[0].Rows.Count.ToString());
            res.Add(count.ToString()); //napovnia sul amdeni chanatseri
            
            /*xom araa gacherebuli procesi? */
            if (relLinksGetter.CancellationPending) { e.Cancel = true; e.Result = null; return; }

            this.Invoke((MethodInvoker)delegate
                        {
                            this.fixed_rel_linksTableAdapter.FillByLic(this.officeDataSet.Fixed_rel_links, current_lic);
                            gridEX2.CollapseCards();
                            try
                            {
                                fixed_rel_linksBindingSource.Position = this.fixed_rel_linksBindingSource.Find("link_id", prev_link_id);
                            }
                            catch { }
                            
                            /*
                            linksListBox.Items.Clear();
                            for (int i = 0; i < count; i++)
                            {
                                linksListBox.Items.Add(ds.Tables[0].Rows[i]["AName"].ToString() + " - "+ ds.Tables[0].Rows[i]["BName"].ToString());
                                siteACoords.Text = ds.Tables[0].Rows[i]["Alat"].ToString() + "/" + ds.Tables[0].Rows[i]["Alon"].ToString();
                                siteBCoords.Text = ds.Tables[0].Rows[i]["Blat"].ToString() + "/" + ds.Tables[0].Rows[i]["Blon"].ToString();
                                elevALabel.Text = ds.Tables[0].Rows[i]["Aant_height"].ToString() + " m.";
                                elevBLabel.Text = ds.Tables[0].Rows[i]["Bant_height"].ToString() + " m.";

                                xom araa gacherebuli procesi? 
                                if (relLinksGetter.CancellationPending) { e.Cancel = true; e.Result = null; return; }
                            }*/
                        });


            e.Result = res;
        }

        private void relLinksGetter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
                Debug.WriteLine("BackgroundWorker Error");
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.
                Debug.WriteLine("BackgroundWorker Cancelled");
                relLinksGetter.RunWorkerAsync();
            }
            else
            {
                // Finally, handle the case where the operation  
                // succeeded.
                if (e.Result == null) return;
                int i = Convert.ToInt32(((List<string>)e.Result)[0].ToString());
                
                        
                        this.Invoke((MethodInvoker)delegate
                        {
                            //splitContainer.Panel2Collapsed = (i==0);
                            //stationInfoPanel.Visible = (i > 0);
                        });
            }

        }

        private void relLinksGetter_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Debug.WriteLine(e.ProgressPercentage);
        }


        #endregion



        protected void gotofreq(object sender,  ShowFreqArgs e)
        {
            this.BeginInvoke((Action)delegate()
            {
                if (e.freqID >= 0)
                {
                    gridEX1.Find(gridEX1.Tables["FK_fls_LICENCE_FREQ_fls_LICENCE_INFO"].Columns["id"], ConditionOperator.Equal,
                                e.freqID, -1, 1);
                    gridEX1.FirstRow = gridEX1.SelectedItems[0].Position;
                }
            });
        }
     

        private void frmMain_Activated(object sender, EventArgs e)
        {
            Companies.Select();
            ribbon_CommandTabSelected(sender, null);

            if (!_visible)
            {
                _visible = true;
                if (frqID >= 0)
                {
                    gridEX1.Find(gridEX1.Tables["FK_fls_LICENCE_FREQ_fls_LICENCE_INFO"].Columns["id"], ConditionOperator.Equal,
                                frqID, -1, 1);
                    gridEX1.FirstRow = gridEX1.SelectedItems[0].Position;
                }
                else gridEX1.FirstRow = 0;
            }

            gridEX1_CurrentCellChanged(this, new EventArgs());
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            //if (!this.Visible) _visible = false;
        }

        private void frmMain_OnCheck(object myObject, CheckEventArgs Args)
        {

            string retValue = "";
            if (Args.TBL == "fls_COMPANY_INFO")
            {
            }
            else if (Args.TBL == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO")
            {
                retValue = queriesTableAdapter._checkLicence(Convert.ToInt32(Args.ID)).ToString();
                //chkText.Text = retValue;
            }
            else if (Args.TBL == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO")
            {
                retValue = queriesTableAdapter._checkFreq(Convert.ToInt32(Args.ID)).ToString();
                //chkText.Text = retValue;
            }
            else if (Args.TBL == "FK_fls_STATION_INFO_fls_COMPANY_INFO")
            {
            }

            if (retValue != "-" && retValue != "" && retValue != "OK")
            {
                //SideBar.Groups["check"].Visible = true;
                string filetoplay = "fault.wav";

                try
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(filetoplay);
                    player.Play();
                }
                catch { }
            }
        }

        private void gridEX1_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            if (e.Row.Table.Key.ToString() == "fls_COMPANY_INFO" || e.Row.Table.Key.ToString() == "shekvanili sadgurebi" && user.EditComp)
            {
                fls_COMPANY_INFOBindingSource.Position = this.fls_COMPANY_INFOBindingSource.Find("id", Convert.ToInt32(e.Row.Cells["id"].Value));
                frmCompany co = new frmCompany(ref this.fls_COMPANY_INFOBindingSource);
                if (co.ShowDialog() == DialogResult.OK) this.fls_COMPANY_INFOTableAdapter.Update(this.officeDataSet.fls_COMPANY_INFO);
            }
            else if (e.Row.Table.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO" && user.EditFreqLic)
            {
                this.fls_LICENCE_INFOBindingSource.Position = this.fls_LICENCE_INFOBindingSource.Find("id", Convert.ToInt32(e.Row.Cells["id"].Value));
                arcButton_Click(sender, null);
                frmEditLicence li = new frmEditLicence(ref this.fls_LICENCE_INFOBindingSource);
                if (li.ShowDialog() == DialogResult.OK) this.fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.fls_LICENCE_INFO);
            }
            else if (e.Row.Table.Key.ToString() == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO" && user.EditFreqs)
            {
                this.fls_LICENCE_FREQBindingSource.Position = this.fls_LICENCE_FREQBindingSource.Find("id", Convert.ToInt32(e.Row.Cells["id"].Value));
                frmEditFreq fr = new frmEditFreq(ref this.fls_LICENCE_FREQBindingSource, user);
                if (fr.ShowDialog() == DialogResult.OK) this.fls_LICENCE_FREQTableAdapter.Update(this.officeDataSet.fls_LICENCE_FREQ);

            }
            else if ((e.Row.Table.Key.ToString() == "FK_acc_Letters_fls_COMPANY_INFO" || e.Row.Table.Key.ToString() == "acc_Letters") && user.Nebartva)
            {
                this.acc_LettersBindingSource.Position = this.acc_LettersBindingSource.Find("id", Convert.ToInt32(e.Row.Cells["id"].Value));
                frmLetter let = new frmLetter(ref this.acc_LettersBindingSource);
                if (let.ShowDialog() == DialogResult.OK) this.acc_LettersTableAdapter.Update(this.officeDataSet.acc_Letters);
            }
            else if (e.Row.Table.Key.ToString() == "FK_acc_FREQ_acc_Letters" && user.Nebartva)
            {
                this.acc_FREQBindingSource.Position = this.acc_FREQBindingSource.Find("id", Convert.ToInt32(e.Row.Cells["id"].Value));
                frmEditFreq fr = new frmEditFreq(ref this.acc_FREQBindingSource, user, true);
                if (fr.ShowDialog() == DialogResult.OK) this.acc_FREQTableAdapter.Update(this.officeDataSet.acc_FREQ);
            }
        }

        private void gridEX1_RecordsDeleted(object sender, EventArgs e)
        {
            try
            {
                this.fls_COMPANY_INFOTableAdapter.Update(this.officeDataSet.fls_COMPANY_INFO);
                this.fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.fls_LICENCE_INFO);
                this.fls_LICENCE_FREQTableAdapter.Update(this.officeDataSet.fls_LICENCE_FREQ);
                this.acc_FREQTableAdapter.Update(this.officeDataSet.acc_FREQ);


                this.arc_fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.arc_fls_LICENCE_INFO);
            }
            catch (Exception ee) { MessageBox.Show(ee.Message + "\n" + ee.InnerException + "\n" + ee.Data); }

            gridEX1.Refresh();
        }

        private void gridEX1_DeletingRecords(object sender, CancelEventArgs e)
        {

            if (gridEX1.CurrentTable.Key.ToString() == "FK_arc_fls_LICENCE_FREQ_arc_fls_LICENCE_INFO")
            {
                e.Cancel = true;
                return;
            }

            if (gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO" && !user.DelComp)
            {
                e.Cancel = true;
                return;
            }
            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO" && !user.DeleteLicence)
            {
                e.Cancel = true;
                return;
            }
            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO" && !user.DeleteFreqs)
            {
                e.Cancel = true;
                return;
            }
            if (gridEX1.CurrentTable.Key.ToString() == "acc_Letters")
            {
                e.Cancel = true;
                return;
            }
            if (gridEX1.CurrentTable.Key.ToString() == "arc_Table" && !user.ReestritCheck)
            {
                e.Cancel = true;
                return;
            }


            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO")
            {
                DataSet ds = Helpers.Functions.fill(string.Format("select dbo.getFreqUsageStats({0})", gridEX1.CurrentRow.Cells["id"].Value.ToString()), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    MessageBox.Show("სიხშირე არის გამოყენებაში, ჯერ უნდა წაშალოთ სადგური რათა წაიშალოს სიხშირე.", "შეცდომა");
                    e.Cancel = true;
                    return;
                }
            }




            if (MessageBox.Show("ნამდვილად გნებავთ ამ ჩანაწერის წაშლა?", "გთხოვთ დაადასტუროთ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) e.Cancel = true;
            else
            {
                if (gridEX1.CurrentTable.Key.ToString() == "arc_Table")
                {
                    HelperFunctions.ExecuteNonQuery("delete from arc_fls_LICENCE_FREQ where licence_id=" + gridEX1.CurrentRow.Cells["id"].Value.ToString(), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                    this.arc_fls_LICENCE_FREQTableAdapter.Fill(this.officeDataSet.arc_fls_LICENCE_FREQ);
                }
                else if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO")
                {
                    arcButton_Click(sender, null);
                    HelperFunctions.ExecuteNonQuery("delete from fls_LICENCE_FREQ where licence_id=" + gridEX1.CurrentRow.Cells["id"].Value.ToString(), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                    this.fls_LICENCE_FREQTableAdapter.Fill(this.officeDataSet.fls_LICENCE_FREQ);
                }

            }


        }

        private void gridEX1_CurrentCellChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(gridEX1.CurrentTable.Key.ToString());

            OrgButton1.Enabled = true;
            LetterButton.Enabled = false;
            LicButton1.Enabled = false;
            FreqButton1.Enabled = false;
            PermButton1.Enabled = false;
            DesButton1.Enabled = false;
            TechButton1.Enabled = false;
            GoToFreqBtn.Enabled = false;
            arcButton.Enabled = false;
            prnButton.Enabled = false;


            
            if (gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO")
            {
                LetterButton.Enabled = true;
                LicButton1.Enabled = true;
                TechButton1.Enabled = true;
                prnButton.Enabled = true;
            }



            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO")
            {
                FreqButton1.Enabled = true;
                PermButton1.Enabled = true;
                DesButton1.Enabled = true;
                prnButton.Enabled = true;
                if (gridEX1.CurrentRow.Cells["LICENCE"].Value.ToString() != "" &&
                    gridEX1.CurrentRow.Cells["LIC_ISSU_DATE"].Value.ToString() != "" &&
                    gridEX1.CurrentRow.Cells["LIC_EXPIRY_DATE"].Value.ToString() != "" &&
                    Convert.ToDateTime(gridEX1.CurrentRow.Cells["LIC_ISSU_DATE"].Value.ToString()) < Convert.ToDateTime(gridEX1.CurrentRow.Cells["LIC_EXPIRY_DATE"].Value.ToString()))
                    arcButton.Enabled = true;

                fls_LICENCE_INFOBindingSource.Position = this.fls_LICENCE_INFOBindingSource.Find("id", Convert.ToInt32(gridEX1.CurrentRow.Cells["id"].Value.ToString()));
                current_lic = ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).id;
                
            }
            else current_lic = -1;

            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO")
                GoToFreqBtn.Enabled = true;


            if (gridEX1.CurrentTable.Key.ToString() == "FK_acc_Letters_fls_COMPANY_INFO")
                FreqButton1.Enabled = true;

            if (gridEX1.CurrentTable.Key.ToString() == "acc_Letters")
            {
                LetterButton.Enabled = true;
            }




            if (((gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO") || (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO")) && user.EditFreqLic && user.EditFreqs)
                CutButton1.Enabled = true;
            else CutButton1.Enabled = false;


            if ((gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO") && lic > 0 && user.EditFreqLic)
                PasteButton1.Enabled = true;

            else if ((gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO") && freq > 0 && user.EditFreqs)
                PasteButton1.Enabled = true;

            else
                PasteButton1.Enabled = false;






            /*

            GridEXFilterCondition condition = new GridEXFilterCondition(RepeaterGrid.RootTable.Columns["comp_id"], ConditionOperator.Equal, currectComp);
            condition.AddCondition(new GridEXFilterCondition(RepeaterGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.Equal, 1));
            RepeaterGrid.RootTable.FilterCondition = condition;
            RepeaterTab.Visibility = RepeaterGrid.RecordCount > 0 ? Telerik.WinControls.ElementVisibility.Visible:Telerik.WinControls.ElementVisibility.Collapsed;

            condition = new GridEXFilterCondition(BaseGrid.RootTable.Columns["comp_id"], ConditionOperator.Equal, currectComp);
            condition.AddCondition(new GridEXFilterCondition(BaseGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.Equal, 5));
            BaseGrid.RootTable.FilterCondition = condition;
            BaseTab.Visibility = BaseGrid.RecordCount > 0 ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;

            condition = new GridEXFilterCondition(MobileGrid.RootTable.Columns["comp_id"], ConditionOperator.Equal, currectComp);
            condition.AddCondition(new GridEXFilterCondition(MobileGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.Equal, 6));
            MobileGrid.RootTable.FilterCondition = condition;
            MobileTab.Visibility = MobileGrid.RecordCount > 0 ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;

            condition = new GridEXFilterCondition(RelGrid.RootTable.Columns["comp_id"], ConditionOperator.Equal, currectComp);
            condition.AddCondition(new GridEXFilterCondition(RelGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.Equal, 3));
            RelGrid.RootTable.FilterCondition = condition;
            RelTab.Visibility = RelGrid.RecordCount > 0 ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;

            condition = new GridEXFilterCondition(OtherGrid.RootTable.Columns["comp_id"], ConditionOperator.Equal, currectComp);
            condition.AddCondition(new GridEXFilterCondition(OtherGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.NotEqual, 1));
            condition.AddCondition(new GridEXFilterCondition(OtherGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.NotEqual, 5));
            condition.AddCondition(new GridEXFilterCondition(OtherGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.NotEqual, 6));
            condition.AddCondition(new GridEXFilterCondition(OtherGrid.RootTable.Columns["LIC_SUB_TYPE"], ConditionOperator.NotEqual, 3));
            OtherGrid.RootTable.FilterCondition = condition;
            OtherTab.Visibility = OtherGrid.RecordCount > 0 ? Telerik.WinControls.ElementVisibility.Visible : Telerik.WinControls.ElementVisibility.Collapsed;

            */

        }

        private void FilterCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            searchBox.Focus();
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (searchBox.Text != "")
            {
                if (FilterCombo.SelectedIndex == -1) FilterCombo.SelectedIndex = 0;
                panel1.BackColor = Color.LightSteelBlue;
            }
            else panel1.BackColor = Color.Transparent;

            if (searchBox.Text != "")
            {
                GridEXFilterCondition condition = null;
                GridEXTable tbl = gridEX1.RootTable;
                if (gridEX1.CurrentLayout.Key.Equals("Companies"))
                {
                    if (FilterCombo.SelectedIndex == 0) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["Comp_Name"], ConditionOperator.Contains, searchBox.Text);
                    else if (FilterCombo.SelectedIndex == 1) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["tax_id"], ConditionOperator.Contains, searchBox.Text);
                    else if (FilterCombo.SelectedIndex == 2) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["Comp_city"], ConditionOperator.Contains, searchBox.Text);
                    else if (FilterCombo.SelectedIndex == 3)
                    {
                        tbl = gridEX1.Tables["FK_fls_LICENCE_INFO_fls_COMPANY_INFO"];
                        condition = new GridEXFilterCondition(tbl.Columns["LICENCE"], ConditionOperator.Contains, searchBox.Text);
                    }
                    else MessageBox.Show("უცნობი ფილტრი");
                }
                else if (gridEX1.CurrentLayout.Key.Equals("Letters"))
                {
                    if (FilterCombo.SelectedIndex == 0) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["comp_id"], ConditionOperator.Contains, searchBox.Text);
                    else if (FilterCombo.SelectedIndex == 1) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["number"], ConditionOperator.Contains, searchBox.Text);
                    else if (FilterCombo.SelectedIndex == 2) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["received"], ConditionOperator.Contains, searchBox.Text);
                    else if (FilterCombo.SelectedIndex == 3) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["remark"], ConditionOperator.Contains, searchBox.Text);
                    else MessageBox.Show("უცნობი ფილტრი");
                }
                else if (gridEX1.CurrentLayout.Key.Equals("Nebartva"))
                {
                    tbl = gridEX1.Tables["fls_NEBARTVA"];
                    if (FilterCombo.SelectedIndex == 0) condition = new GridEXFilterCondition(tbl.Columns["Number"], ConditionOperator.Contains, searchBox.Text);
                    else if (FilterCombo.SelectedIndex == 1) condition = new GridEXFilterCondition(tbl.Columns["function_compName"], ConditionOperator.Contains, searchBox.Text);
                    else MessageBox.Show("უცნობი ფილტრი");
                }
                else if (gridEX1.CurrentLayout.Key.Equals("StationsEntered"))
                {
                    if (FilterCombo.SelectedIndex == 0) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["Comp_Name"], ConditionOperator.Contains, searchBox.Text);
                    else MessageBox.Show("უცნობი ფილტრი");
                }
                else if (gridEX1.CurrentLayout.Key.Equals("AdminStations"))
                {
                    if (FilterCombo.SelectedIndex == 0) condition = new GridEXFilterCondition(gridEX1.RootTable.Columns["Comp_Name"], ConditionOperator.Contains, searchBox.Text);
                    else MessageBox.Show("უცნობი ფილტრი");
                }

                if (!condition.Equals(null)) tbl.FilterCondition = condition;
            }
            else foreach (GridEXTable tbl in gridEX1.Tables) tbl.RemoveFilter();
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            //გადაწყვეტილებაToolStripMenuItem.Visible = gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO" && _parent.user.AddFreq ? true : false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*e.Cancel = true;
            this.Hide();*/
            common.goToCompFreqChange -= new commShare.GoToCompFreqDelegate(gotofreq);
        }

        private void gridEX1_RowExpanded(object sender, RowActionEventArgs e)
        {
            if (gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO")
            {
                fls_COMPANY_INFOBindingSource.Position = this.fls_COMPANY_INFOBindingSource.Find("id", Convert.ToInt32(gridEX1.GetValue("id")));
            }
            else if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO")
            {
                fls_LICENCE_INFOBindingSource.Position = this.fls_LICENCE_INFOBindingSource.Find("id", Convert.ToInt32(gridEX1.GetValue("id")));
            }
            //MessageBox.Show("expanded: id=" + Convert.ToInt32(gridEX1.GetValue("id")).ToString());
        }





        private void ribbon_CommandTabSelected(object sender, Telerik.WinControls.UI.CommandTabEventArgs args)
        {
            gridEX1.ContextMenuStrip = null;

            if (ribbon.SelectedCommandTab.Name != "")
            {
                FilterCombo.Items.Clear();
                gridEX1.CurrentLayout = gridEX1.Layouts[ribbon.SelectedCommandTab.Name];
                if (gridEX1.CurrentLayout.Key.Equals("Companies"))
                {
                    FilterCombo.Items.Add("ორგანიზაცია");
                    FilterCombo.Items.Add("საგ. კოდი");
                    FilterCombo.Items.Add("ორგ. ქალაქი");
                    FilterCombo.Items.Add("ლიცენზია/ნებართვა");
                }
                else if (gridEX1.CurrentLayout.Key.Equals("Letters"))
                {
                    FilterCombo.Items.Add("ორგანიზაცია");
                    FilterCombo.Items.Add("წერილის ნომერი");
                    FilterCombo.Items.Add("შემოსვლის თარიღი");
                    FilterCombo.Items.Add("დამატ. ინფორმაცია");
                    gridEX1.ContextMenuStrip = contextMenu;
                }
                else if (gridEX1.CurrentLayout.Key.Equals("Nebartva"))
                {
                    FilterCombo.Items.Add("F ნომერი");
                    FilterCombo.Items.Add("ორგანიზაცია");
                }
                else if (gridEX1.CurrentLayout.Key.Equals("StationsEntered"))
                {
                    FilterCombo.Items.Add("ორგანიზაცია");
                }

            }

            try
            {
                gridEX1.DropDowns["comp_city_combo"].SetDataBinding(officeDataSet, "Zone_city");
                gridEX1.DropDowns["freq_city_combo"].SetDataBinding(officeDataSet, "Zone_city");
            }
            catch { }

            try
            {
                gridEX1.DropDowns["comp_combo"].SetDataBinding(officeDataSet, "fls_COMPANY_INFO");
                gridEX1.DropDowns["projectWorkflowDropDown"].SetDataBinding(officeDataSet, "acc_projectWorkflow");
            }
            catch { }


        }

        private void OrgButton1_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO" && user.EditComp)
            {
                this.fls_COMPANY_INFOBindingSource.AddNew();
                frmCompany co = new frmCompany(ref this.fls_COMPANY_INFOBindingSource);
                if (co.ShowDialog() == DialogResult.OK) this.fls_COMPANY_INFOTableAdapter.Update(this.officeDataSet.fls_COMPANY_INFO);
            }
        }

        private void LicButton1_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO" && user.EditFreqLic)
            {
                int company = Convert.ToInt32(gridEX1.GetValue("id"));
                this.fls_LICENCE_INFOBindingSource.AddNew();
                ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).comp_id = company;
                frmEditLicence li = new frmEditLicence(ref this.fls_LICENCE_INFOBindingSource);
                if (li.ShowDialog() == DialogResult.OK) this.fls_LICENCE_INFOTableAdapter.Update(this.officeDataSet.fls_LICENCE_INFO);
            }
            else
            {
                MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FreqButton1_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO" && user.AddFreq)
            {
                this.fls_LICENCE_FREQBindingSource.AddNew();
                if (f > 0 && bwth > 0)
                {
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).FREQ = f;
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).BandWidth = bwth;
                    ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).reestrit = rees;
                }
                ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).licence_id = Convert.ToInt32(gridEX1.GetValue("id"));
                frmEditFreq fr = new frmEditFreq(ref this.fls_LICENCE_FREQBindingSource, user);
                if (fr.ShowDialog() == DialogResult.OK)
                {
                    f = ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).FREQ;
                    bwth = ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).BandWidth;
                    rees = ((OfficeDataSet.fls_LICENCE_FREQRow)((DataRowView)fls_LICENCE_FREQBindingSource.Current).Row).reestrit;
                    this.fls_LICENCE_FREQTableAdapter.Update(this.officeDataSet.fls_LICENCE_FREQ);
                }
            }
            else if ((gridEX1.CurrentTable.Key.ToString() == "FK_acc_Letters_fls_COMPANY_INFO" || gridEX1.CurrentTable.Key.ToString() == "acc_Letters") && user.Nebartva)
            {
                this.acc_FREQBindingSource.AddNew();
                ((OfficeDataSet.acc_FREQRow)((DataRowView)acc_FREQBindingSource.Current).Row).letter_id = Convert.ToInt32(gridEX1.GetValue("id"));
                frmEditFreq fr = new frmEditFreq(ref this.acc_FREQBindingSource, user, true);
                if (fr.ShowDialog() == DialogResult.OK) this.acc_FREQTableAdapter.Update(this.officeDataSet.acc_FREQ);
            }
            else MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void PermButton1_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO" && user.Nebartva)
            {
                frmNebartva fr = new frmNebartva(Convert.ToInt32(gridEX1.GetValue("id")), ((OfficeDataSet.fls_COMPANY_INFORow)((DataRowView)fls_COMPANY_INFOBindingSource.Current).Row).Comp_Name, ref fls_COMPANY_INFOBindingSource, user);
                if (fr.ShowDialog() == DialogResult.OK) this.fls_COMPANY_INFOTableAdapter.Update(this.officeDataSet.fls_COMPANY_INFO);
            }
            else
            {
                MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LetterButton1_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentLayout == gridEX1.Layouts["Letters"] && gridEX1.CurrentTable.Key.ToString() == "acc_Letters" && user.Nebartva)
            {
                this.acc_LettersBindingSource.AddNew();
                ((OfficeDataSet.acc_LettersRow)((DataRowView)acc_LettersBindingSource.Current).Row).comp_id = -1;
                frmLetter frm = new frmLetter(ref this.acc_LettersBindingSource);
                if (frm.ShowDialog() == DialogResult.OK) this.acc_LettersTableAdapter.Update(this.officeDataSet.acc_Letters);
            }
            else
                MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void CutButton1_Click(object sender, EventArgs e)
        {
            PasteButton1.Enabled = false;
            lic = -1; freq = -1;
            if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO")
            {
                lic = Convert.ToInt32(gridEX1.SelectedItems[0].GetRow().Cells["id"].Value);
                //PasteBtn.Enabled = true;            
            }
            else if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO")
            {
                freq = Convert.ToInt32(gridEX1.SelectedItems[0].GetRow().Cells["id"].Value);
                //PasteBtn.Enabled = true;
            }
        }

        private void PasteButton1_Click(object sender, EventArgs e)
        {
            int mimdinare = Convert.ToInt32(gridEX1.SelectedItems[0].GetRow().Cells["id"].Value);
            if (gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO" && lic >= 0)
            {
                officeDataSet.EnforceConstraints = false;
                this.fls_LICENCE_INFOTableAdapter.UpdateParenteness(mimdinare, lic);
                this.fls_LICENCE_INFOTableAdapter.Fill(officeDataSet.fls_LICENCE_INFO);
                officeDataSet.EnforceConstraints = true;
                lic = -1;
            }
            else if (gridEX1.CurrentTable.Key.ToString() == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO" && freq >= 0)
            {
                officeDataSet.EnforceConstraints = false;
                this.fls_LICENCE_FREQTableAdapter.UpdateParenteness(mimdinare, freq);
                this.fls_LICENCE_FREQTableAdapter.Fill(officeDataSet.fls_LICENCE_FREQ);
                officeDataSet.EnforceConstraints = true;
                freq = -1;
            }
            PasteButton1.Enabled = false;
        }

        private void DesButton1_Click(object sender, EventArgs e)
        {
            FREQVIEW fr = new FREQVIEW();
            fr.LICENCE = gridEX1.GetValue("LICENCE").ToString();

            string s = gridEX1.GetValue("LIC_ISSU_DATE").ToString();
            if (s != "")
            {
                s = s.Substring(0, s.IndexOf(" "));
                fr.LIC_ISSU_DATE = s;
            }
            s = gridEX1.GetValue("LIC_EXPIRY_DATE").ToString();
            if (s != "")
            {
                s = s.Substring(0, s.IndexOf(" "));
                fr.LIC_EXPIRY_DATE = s;
            }

            decision dec = new decision();
            dec.ShowDecision(fr);
        }

        private void TechButton1_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentTable.Key.ToString() == "fls_COMPANY_INFO")
            {
                if (user.EditFreqs)
                {
                    TechData td = new TechData(gridEX1.GetValue("tax_id").ToString());
                    td.ShowDialog();
                }
                else
                    MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridEX1_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.Table.Key == "FK_fls_LICENCE_FREQ_fls_LICENCE_INFO" && e.Row.Cells["Usage"].Text.Equals("") && gridEX1.RootTable.ChildTables[1].ChildTables[0].Columns["usage"].Visible)
            {
                DataSet ds = Helpers.Functions.fill(string.Format("select dbo.getFreqUsageStats({0})", e.Row.Cells["id"].Value), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                e.Row.Cells["Usage"].Text = ds.Tables[0].Rows[0][0].ToString();
                
                Debug.WriteLine(ds.Tables[0].Rows[0][0].ToString()+" usage updated");
                ds.Dispose();
            }

            if (e.Row.Table.Key != "FK_acc_Letters_fls_COMPANY_INFO" && e.Row.Table.Key != "acc_Letters") return;
            else
                try
                {
                    if ((bool)e.Row.Cells["isReceived"].Value)
                    {
                        e.Row.Cells["Icon"].ImageKey = "down.png";
                    }
                    else
                        e.Row.Cells["Icon"].ImageKey = "up.png";

                    if ((bool)e.Row.Cells["isPayed"].Value)
                    {
                        e.Row.Cells["Payed"].ImageKey = "money.png";
                    }
                }
                catch { }

        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            if (gridEX1.CurrentLayout == gridEX1.Layouts["Letters"] && gridEX1.CurrentTable.Key.ToString() == "acc_Letters" && user.Nebartva)
            {
                this.acc_LettersBindingSource.AddNew();
                ((OfficeDataSet.acc_LettersRow)((DataRowView)acc_LettersBindingSource.Current).Row).comp_id = Convert.ToInt32(gridEX1.GetValue("comp_id"));
                ((OfficeDataSet.acc_LettersRow)((DataRowView)acc_LettersBindingSource.Current).Row).parent_letter_id = Convert.ToInt32(gridEX1.GetValue("id"));
                frmLetter frm = new frmLetter(ref this.acc_LettersBindingSource);
                if (frm.ShowDialog() == DialogResult.OK) this.acc_LettersTableAdapter.Update(this.officeDataSet.acc_Letters);
            }
            else
                MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            frmLetterScan scan = new frmLetterScan(((OfficeDataSet.acc_LettersRow)((DataRowView)acc_LettersBindingSource.Current).Row).id, user);
            scan.ShowDialog();
        }

        private void delLetterButton_Click(object sender, EventArgs e)
        {
            if (user.Nebartva)
            {
                if (MessageBox.Show("ნამდვილად გნებავთ ამ ჩანაწერის წაშლა?", "გთხოვთ დაადასტუროთ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    acc_LettersTableAdapter.DeleteByID(Convert.ToInt32(gridEX1.GetValue("id")));
                    this.acc_LettersTableAdapter.Update(this.officeDataSet.acc_Letters);
                    this.acc_LettersTableAdapter.Fill(this.officeDataSet.acc_Letters);
                }
            }
        }

        private void FilterCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //searchBox.Text = "";
            searchBox_KeyUp(sender, null);
        }








        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (user.EditFreqs)
            {
                acc_LettersBindingSource.Find("id", Convert.ToInt32(gridEX1.GetValue("id")));
                ((OfficeDataSet.acc_LettersRow)((DataRowView)acc_LettersBindingSource.Current).Row).projectWorkflow_id = 1;
                acc_LettersTableAdapter.Update(this.officeDataSet.acc_Letters);
            }
            else MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void მზადდებაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.EditFreqs)
            {
                acc_LettersBindingSource.Find("id", Convert.ToInt32(gridEX1.GetValue("id")));
                ((OfficeDataSet.acc_LettersRow)((DataRowView)acc_LettersBindingSource.Current).Row).projectWorkflow_id = 2;
                acc_LettersTableAdapter.Update(this.officeDataSet.acc_Letters);
            }
            else MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void მომზადებულიაToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user.EditFreqs)
            {
                acc_LettersBindingSource.Find("id", Convert.ToInt32(gridEX1.GetValue("id")));
                ((OfficeDataSet.acc_LettersRow)((DataRowView)acc_LettersBindingSource.Current).Row).projectWorkflow_id = 3;
                acc_LettersTableAdapter.Update(this.officeDataSet.acc_Letters);
            }
            else MessageBox.Show("უფლებები შეზღუდულია!!!", "ინფორმაცია", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void GoToFreqBtn_Click(object sender, EventArgs e)
        {
            //this.GoToFreq(sender, new GoToFreqArgs(Convert.ToInt32(gridEX1.GetValue("FREQ"))));

            common.fire_GoToFreq(sender, new GoToFreqArgs(Convert.ToInt32(gridEX1.GetValue("FREQ"))));

            //_parent.ScrollToFound(Convert.ToInt32(gridEX1.GetValue("FREQ")));
            

            //_parent.ScrollToFound(Convert.ToInt32(gridEX1.GetValue("FREQ")));
            //this.Hide();
        }

        private void arcButton_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDateTime(((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LIC_ISSU_DATE);
                Convert.ToDateTime(((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LIC_EXPIRY_DATE);
            }
            catch { return; }

            int mimdinare = Convert.ToInt32(gridEX1.SelectedItems[0].GetRow().Cells["id"].Value);

            fls_LICENCE_INFOBindingSource.Position = this.fls_LICENCE_INFOBindingSource.Find("id", mimdinare);
            int raod = (Int32)this.arc_fls_LICENCE_INFOTableAdapter.ifPresentInArchieve(((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LICENCE, ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LIC_ISSU_DATE, ((OfficeDataSet.fls_LICENCE_INFORow)((DataRowView)fls_LICENCE_INFOBindingSource.Current).Row).LIC_EXPIRY_DATE);

            if (raod == 0)
            {
                DataSet ds = HelperFunctions.fill("INSERT INTO arc_fls_LICENCE_INFO " +
                    "(LICENCE, LIC_ISSU_DATE, LIC_EXPIRY_DATE, COMMENTS, comp_id) " +
                    "SELECT        LICENCE, LIC_ISSU_DATE, LIC_EXPIRY_DATE, COMMENTS, comp_id " +
                    "FROM            fls_LICENCE_INFO " +
                    "WHERE        (id = " + mimdinare.ToString() + "); select id=scope_identity()", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                int LastID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                ds.Clear();

                DataSet ds1 = HelperFunctions.fill("INSERT INTO [arc_fls_LICENCE_FREQ] ([FREQ], [BandWidth], [power], [remark], [reestrit], [licence_id], [city_id]) " +
                    "SELECT FREQ, BandWidth, power, remark, reestrit, " + LastID.ToString() + ", city_id FROM fls_LICENCE_FREQ " +
                    "WHERE        (licence_id = " + mimdinare.ToString() + "); select id=scope_identity()", DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                ds1.Clear();


                this.arc_fls_LICENCE_INFOTableAdapter.Fill(this.officeDataSet.arc_fls_LICENCE_INFO);
                this.arc_fls_LICENCE_FREQTableAdapter.Fill(this.officeDataSet.arc_fls_LICENCE_FREQ);
            }

        }

        private void arcVisibleCheckBox_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (arcVisibleCheckBox.Checked == false)
                gridEX1.RootTable.ChildTables.RemoveAt(2);
            else gridEX1.RootTable.ChildTables.Add(table);
        }

        private void prnButton_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            progress progForm = new progress("მიმდინარეობს ინიციალიზაცია...");
            progForm.Show();
            progForm.Refresh();

            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string strSQL = "";
            RepPreview preview = new RepPreview();
            if (gridEX1.CurrentTable.Key == "fls_COMPANY_INFO")
            {
                strSQL = "select * from FLS_COMPANY_INFO where id=" + gridEX1.GetValue("id") + ";" +
                                "select * from COMBO_CompAccount;";
            }
            else
                if (gridEX1.CurrentTable.Key == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO")
                {
                    strSQL = "SELECT     id, LICENCE, CAST(LIC_ISSU_DATE AS varchar(12)) AS LIC_ISSU_DATE, CAST(LIC_EXPIRY_DATE AS varchar(12)) AS LIC_EXPIRY_DATE, COMMENTS, comp_id FROM fls_LICENCE_INFO where id=" + gridEX1.GetValue("id") + ";" +
                             "select dbo.frequency(FREQ) as FREQ, dbo.frequency(BandWidth) as BandWidth, function_getCityName, remark, licence_id from fls_LICENCE_FREQ;" +
                             "select * from fls_COMPANY_INFO where id=" + gridEX1.GetValue("comp_id") + ";";
                }
            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (gridEX1.CurrentTable.Key == "fls_COMPANY_INFO")
            {
                compInfo CompRep = new compInfo();
                CompRep.Database.Tables["FLS_COMPANY_INFO"].SetDataSource(ds.Tables[0]);
                CompRep.Database.Tables["COMBO_CompAccount"].SetDataSource(ds.Tables[1]);
                preview.crystalReportViewer.ReportSource = CompRep;
            }
            else
                if (gridEX1.CurrentTable.Key == "FK_fls_LICENCE_INFO_fls_COMPANY_INFO")
                {
                    licReport LicRep = new licReport();
                    LicRep.Database.Tables["fls_LICENCE_INFO"].SetDataSource(ds.Tables[0]);
                    LicRep.Database.Tables["fls_LICENCE_FREQ"].SetDataSource(ds.Tables[1]);
                    LicRep.Database.Tables["fls_COMPANY_INFO"].SetDataSource(ds.Tables[2]);
                    preview.crystalReportViewer.ReportSource = LicRep;
                }

            progForm.Close();
            preview.ShowDialog();

        }

       

        private void gridEX1_LayoutLoad(object sender, EventArgs e)
        {
            if (gridEX1.CurrentLayout.Key.ToString().Equals("Companies")) table = gridEX1.RootTable.ChildTables[2];         
        }

        private void gridEX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(gridEX1.GetClipString());
            }
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Debug.WriteLine(splitContainer.Panel1.Width.ToString());
        }









        private void gridEX2_SelectionChanged(object sender, EventArgs e)
        {
            admEditBtn.Enabled = false;
            admDeleteBtn.Enabled = false;

            if (fixed_rel_linksBindingSource.Count > 0)
            {
                if (((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).Alic_id>=0 && ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).Blic_id>=0)
                {
                    if (user.admStEdit) admEditBtn.Enabled = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).link_id >= 0;
                    if (user.admStDel) admDeleteBtn.Enabled = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).link_id >= 0;
                }
                try
                {
                    //radRibbonBarGroup12.Text = ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).AName + " - " + ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).BName;
                    Debug.WriteLine(((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).Aid + " : " + ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).Bid);
                }
                catch {  }
            }

            
        }

        private void newAdminStationBtn_Click(object sender, EventArgs e)
        {
            frmRelLink frm = new frmRelLink(zCities, Convert.ToInt32(gridEX1.CurrentRow.Cells["comp_id"].Value.ToString()), current_lic, ref fls_LICENCE_FREQBindingSource, ref fls_LICENCE_FREQTableAdapter, this.officeDataSet.fls_LICENCE_FREQ);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.fixed_rel_linksTableAdapter.FillByLic(this.officeDataSet.Fixed_rel_links, current_lic);
                gridEX2.CollapseCards();
                ActiveControl = gridEX2;
            }
        }

        private void editAdminStationBtn_Click(object sender, EventArgs e)
        {
            prev_link_id = Convert.ToInt32(gridEX2.CurrentRow.Cells["link_id"].Value.ToString());
            frmRelLink frm = new frmRelLink(zCities, Convert.ToInt32(gridEX1.CurrentRow.Cells["comp_id"].Value.ToString()), Convert.ToInt32(gridEX1.CurrentRow.Cells["id"].Value.ToString()), ref fls_LICENCE_FREQBindingSource, ref fls_LICENCE_FREQTableAdapter, this.officeDataSet.fls_LICENCE_FREQ, ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).Aid, ((OfficeDataSet.Fixed_rel_linksRow)((DataRowView)fixed_rel_linksBindingSource.Current).Row).Bid, fixed_rel_linksBindingSource);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                fixed_rel_linksTableAdapter.FillByLic(this.officeDataSet.Fixed_rel_links, current_lic);
                gridEX2.CollapseCards();                
            }
            fixed_rel_linksBindingSource.Position = this.fixed_rel_linksBindingSource.Find("link_id", prev_link_id);
            gridEX2.Find(gridEX2.Tables[0].Columns["link_id"], ConditionOperator.Equal, prev_link_id, -1, 1);
            ActiveControl = gridEX2;
        }

        private void gridEX2_FormattingRow(object sender, RowLoadEventArgs e)
        {
            if (e.Row.Cells["Alic_id"].Value != DBNull.Value) e.Row.Cells["Icon"].ImageKey = "relfixed_flip_admin.png"; else e.Row.Cells["Icon"].ImageKey = "relfixed_flip.png";
            if (e.Row.Cells["Blic_id"].Value != DBNull.Value) e.Row.Cells["Icon2"].ImageKey = "relfixed_admin.png"; else e.Row.Cells["Icon2"].ImageKey = "relfixed.png";

        }

        private void printAdminStations_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select * from Fixed_rel_links where Alic_id=" + current_lic + " or Blic_id=" + current_lic + " order by AName, BName", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            Reports.admStationsReport admRep = new Fams.Reports.admStationsReport();
            admRep.Database.Tables["Fixed_rel_links"].SetDataSource(ds.Tables[0]);
            Reports.RepPreview preview = new Fams.Reports.RepPreview();
            preview.crystalReportViewer.ReportSource = admRep;
            preview.ShowDialog();
        }

        private void usageVisibleCheckBox_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            gridEX1.RootTable.ChildTables[1].ChildTables[0].Columns["usage"].Visible = usageVisibleCheckBox.Checked;
        }

        private void delAdminStationBtn_Click(object sender, EventArgs e)
        {
            int Aid = Convert.ToInt32(gridEX2.CurrentRow.Cells["Aid"].Value.ToString());
            int Bid = Convert.ToInt32(gridEX2.CurrentRow.Cells["Bid"].Value.ToString());
            if (MessageBox.Show("ნამდვილად გნებავთ ამ ჩანაწერის წაშლა?", "გთხოვთ დაადასტუროთ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HelperFunctions.ExecuteNonQuery(string.Format("delete from st_rel_fixed where id={0} or id={1}", Aid, Bid), DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
                if (!relLinksGetter.IsBusy) relLinksGetter.RunWorkerAsync();
            }
        }

        private void exportAdminStationsBtn_Click(object sender, EventArgs e)
        {
            RelRoutines.export_stations(current_lic, DataBase.Properties.Settings.Default.OfficeConnectionString.ToString());
        }

        private void admStationsCheckBox_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            admStationsCheckBox_checkedChanging = false;
        }

        private void admStationsCheckBox_ToggleStateChanging(object sender, Telerik.WinControls.UI.StateChangingEventArgs args)
        {
            admStationsCheckBox_checkedChanging = true;
            if (args.NewValue == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                admStationsGroup.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                this.ActiveControl = gridEX1;
                gridEX1_CurrentCellChanged(sender, new EventArgs());
                splitContainer.Panel2Collapsed = false;
            }
            else
            {
                admStationsGroup.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                splitContainer.Panel2Collapsed = true;
                
            }

        }

        private void fixed_rel_linksBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            admPrintBtn.Enabled = fixed_rel_linksBindingSource.Count > 0;
            admExportBtn.Enabled = fixed_rel_linksBindingSource.Count > 0;
        }

        




  








    }


    


    public class CheckEventArgs : EventArgs
    {

        // declare a private field named message
        private string id;
        private string tbl = "";

        // define a constructor
        public CheckEventArgs(string id, string tbl)
        {
            this.id = id;
            this.tbl = tbl;
        }

        // define a property to get the message
        public string ID
        {
            get
            {
                return id;
            }
        }

        public string TBL
        {
            get
            {
                return tbl;
            }
        }

    }

    public class ZoneHash
    {
        public SortedDictionary<string, System.Collections.ArrayList> znhash = new SortedDictionary<string, System.Collections.ArrayList>();

        public ZoneHash(DataSet data)
        {
            DataSet ds = new DataSet();
            string connectionstring = DataBase.Properties.Settings.Default.OfficeConnectionString.ToString();
            SqlConnection northwindConnection = new SqlConnection(connectionstring);
            string strSQL = "select * from Zone";
            SqlCommand cmd = new SqlCommand(strSQL, northwindConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                znhash.Add(ds.Tables[0].Rows[i]["Name"].ToString(), new System.Collections.ArrayList());
            }
            znhash.Add("სხვა", new System.Collections.ArrayList());



            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                Point p = new Point(Convert.ToInt32(Convert.ToDouble(data.Tables[0].Rows[i]["lon"]) * 10000), Convert.ToInt32(Convert.ToDouble(data.Tables[0].Rows[i]["lat"]) * 10000));

                bool other = true;
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    string str = ds.Tables[0].Rows[k]["Coords"].ToString();
                    string[] s = str.Split(new string[] { ")(" }, StringSplitOptions.RemoveEmptyEntries);

                    Regioni rg = new Regioni();
                    Point[] pt = new Point[s.GetLength(0)];
                    for (int j = 0; j < s.GetLength(0); j++)
                    {
                        s[j] = s[j].Replace("(", "");
                        s[j] = s[j].Replace(")", "");
                        string[] tmp = s[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        pt[j] = new Point(Convert.ToInt32(Convert.ToDouble(tmp[0]) * 10000), Convert.ToInt32(Convert.ToDouble(tmp[1]) * 10000));
                    }
                    if (rg.PointInPolygon(pt, p))
                    {
                        System.Collections.ArrayList arr = new System.Collections.ArrayList();
                        arr = (System.Collections.ArrayList)znhash[ds.Tables[0].Rows[k]["Name"].ToString()];

                        Punkt pk = new Punkt();
                        pk.city = data.Tables[0].Rows[i]["city"].ToString();
                        pk.channel = Convert.ToInt32(data.Tables[0].Rows[i]["CH"]);
                        pk.comp_name = data.Tables[0].Rows[i]["Comp_Name"].ToString();
                        pk.lat = Convert.ToDouble(data.Tables[0].Rows[i]["lat"]);
                        pk.lon = Convert.ToDouble(data.Tables[0].Rows[i]["lon"]);
                        pk.img = data.Tables[0].Rows[i]["img"].ToString();
                        pk.remark = data.Tables[0].Rows[i]["remark"].ToString();
                        try
                        {
                            pk.tp = Convert.ToInt16(data.Tables[0].Rows[i]["tp"]);
                        }
                        catch { }
                        arr.Add(pk);
                        other = false;
                        break;
                    }
                }

                if (other)
                {
                    System.Collections.ArrayList arr = new System.Collections.ArrayList();
                    arr = (System.Collections.ArrayList)znhash["სხვა"];

                    Punkt pk = new Punkt();
                    pk.city = data.Tables[0].Rows[i]["city"].ToString();
                    pk.channel = Convert.ToInt32(data.Tables[0].Rows[i]["CH"]);
                    pk.comp_name = data.Tables[0].Rows[i]["Comp_Name"].ToString();
                    pk.lat = Convert.ToDouble(data.Tables[0].Rows[i]["lat"]);
                    pk.lon = Convert.ToDouble(data.Tables[0].Rows[i]["lon"]);
                    pk.img = data.Tables[0].Rows[i]["img"].ToString();
                    pk.remark = data.Tables[0].Rows[i]["remark"].ToString();
                    try
                    {
                        pk.tp = Convert.ToInt16(data.Tables[0].Rows[i]["tp"]);
                    }
                    catch { }
                    arr.Add(pk);
                }
            }



        }

    }

    public class Punkt
    {
        public string comp_name;
        public string city;
        public int channel;
        
        private double _fm_channel;
        public double fm_channel
        {
            get { return _fm_channel/1000; }
            set { _fm_channel = value; }
        }

        public string img;

        public double lat;
        public double lon;

        public double n;
        public double s;
        public double e;
        public double w;

        public short tp;

        public string remark;

    }
}