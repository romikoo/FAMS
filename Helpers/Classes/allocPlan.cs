using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Xna.Framework;

namespace Helpers
{
    public class Plan
    {
        public int id;
        public string name;
        public int freqBand;
        public int bandwidth;
        public bool special;
        public ArrayList block;
    }

    public class Freq
    {
        public int id;
        public int CH;
        public int Frequency;
        public bool LowBand;
    }

    public class Block
    {
        public int id;
        public string name;
        public int spacing;
        public ArrayList freq;

        private int _fromFRQ;
        public int fromFRQ
        {
            get
            {
                _fromFRQ = -1;
             
                _chTotal = freq.Count;
                for (int j = 0; j < _chTotal; j++)
                {
                    Freq fr = (Freq)freq[j];
                    if (fr.Frequency < _fromFRQ || _fromFRQ < 0)
                    {
                        _fromFRQ = fr.Frequency;
                        j = 0;
                    }
                }
              

                return _fromFRQ;
            }
        }

        private int _toFRQ;
        public int toFRQ
        {
            get
            {
                _toFRQ = -1;
                
                _chTotal = freq.Count;
                for (int j = 0; j < _chTotal; j++)
                {
                    Freq fr = (Freq)freq[j];
                    if (fr.Frequency > _toFRQ || _toFRQ < 0)
                    {
                        _toFRQ = fr.Frequency ;
                        j = 0;
                    }
                }
                

                return _toFRQ;
            }
        }


        private int _chTotal = 0;
        public int chTotal
        {
            get { return _chTotal; }
        }
    }



    public class AllocationPlan
    {
        private int _minFreq = -1;
        public int minFreq
        {
            get { return _minFreq; }
        }

        private int _maxFreq = -1;
        public int maxFreq
        {
            get { return _maxFreq; }
        }


        private int _total;
        public int total
        {
            get { return _total; }
        }

        public ArrayList plans = new ArrayList();

        public AllocationPlan()
        {
            //fill allocations
            DataSet ds = HelperFunctions.fill("select * from Allocation", DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());
            _total = ds.Tables[0].Rows.Count; //sul amdeni gegmaa
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Plan plan = new Plan();
                

                plan.id = (int)dr["id"];
                plan.name = (string)dr["name"];
                plan.freqBand = Convert.ToInt32(dr["FreqBand"]);
                plan.bandwidth = Convert.ToInt32(dr["Bandwidth"]);
                plan.special = Convert.ToBoolean(dr["Special"]);

                //select all blocks
                ArrayList blocks = new ArrayList();
                DataSet dsBlock = HelperFunctions.fill("select * from block where allocation_id=" + plan.id, DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());
                foreach (DataRow drBlock in dsBlock.Tables[0].Rows)
                {
                    Block block = new Block();
                    block.id = Convert.ToInt32(drBlock["id"]);
                    block.name = (string)drBlock["Block"];
                    block.spacing = Convert.ToInt32(drBlock["Spacing"]);

                   //select all freqs in current block
                    ArrayList freqs = new ArrayList();
                    DataSet dsFreq = HelperFunctions.fill("select * from freq where block_id=" + block.id, DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());
                    foreach (DataRow drFreq in dsFreq.Tables[0].Rows)
                    {
                        Freq freq = new Freq();
                        freq.id = Convert.ToInt32(drFreq["id"]);
                        freq.CH = Convert.ToInt32(drFreq["CH"]);
                        freq.Frequency = Convert.ToInt32(drFreq["Frequency"]);
                        freq.LowBand = Convert.ToBoolean(drFreq["LowBand"]);

                        freqs.Add(freq);
                        if (_minFreq > freq.Frequency || _minFreq == -1) _minFreq = freq.Frequency;
                        if (_maxFreq < freq.Frequency || _maxFreq == -1) _maxFreq = freq.Frequency;
                    }
                    block.freq = freqs;
                    blocks.Add(block);
                }

                //block.freq = freq;
                plan.block = blocks;
                plans.Add(plan);
            }
        }
    }
}
