using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using Microsoft.Xna.Framework;

namespace Helpers
{
    public class ero_Allocation
    {
        public int id;
        public string GName;
        public string EName;
    }


    public class ero_Implementation
    {
        public Microsoft.Xna.Framework.Rectangle displayedPos = new Microsoft.Xna.Framework.Rectangle();

        public int id;
        public string Name;
        public float FFrom;
        public float FTo;
        public bool inUse;
        public string Note;
        public System.Drawing.Color color;

        public bool mouseIn(Vector2 position)
        {
            if (position.X > displayedPos.X && position.X < displayedPos.X + displayedPos.Width && position.Y > displayedPos.Y && position.Y < displayedPos.Y + displayedPos.Height) return true;
            else return false;
        }
    }

    public class fr_Plan
    {
        public Microsoft.Xna.Framework.Rectangle displayedPos = new Microsoft.Xna.Framework.Rectangle();

        public int id;
        public float FFrom;
        public float FTo;
        public string Description;
        public System.Drawing.Color color;

        public List<ero_Allocation> allocations = new List<ero_Allocation>();
        public List<ero_Implementation> implementations = new List<ero_Implementation>();

        public fr_Plan(int ID, float ffrom, float fto)
        {
            this.id = ID;
            this.FFrom = ffrom;
            this.FTo = fto;

            DataSet ds = HelperFunctions.fill("SELECT dbo.ero_Allocations.id, dbo.ero_Allocations.GName, dbo.ero_Allocations.EName FROM         dbo.ero_AllocationPlan INNER JOIN dbo.ero_Allocations ON dbo.ero_AllocationPlan.Allocation_id = dbo.ero_Allocations.id where dbo.ero_AllocationPlan.FR_Band_id=" + ID + " ORDER BY dbo.ero_AllocationPlan.FR_Band_id", DataBase.Properties.Settings.Default.OfficeConnectionString);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ero_Allocation al = new ero_Allocation();
                al.id = (int)dr["id"];
                al.GName = dr["GName"].ToString();
                al.EName = dr["EName"].ToString();
                allocations.Add(al);
            }

          


            /*ds = HelperFunctions.fill("SELECT     dbo.ero_Implementations.id, dbo.ero_Implementations.Name, CASE WHEN dbo.ero_Implementations.FFrom IS NULL " +
                          "THEN dbo.ero_FR_Band.FFrom ELSE dbo.ero_Implementations.FFrom END AS FFrom, CASE WHEN dbo.ero_Implementations.FTo IS NULL " +
                          "THEN dbo.ero_FR_Band.FTo ELSE dbo.ero_Implementations.FTo END AS FTo, dbo.ero_Implementations.inUse, dbo.ero_Implementations.Note, " +
                          "dbo.ero_Implementations.band_id " +
                          "FROM         dbo.ero_FR_Band  INNER JOIN " +
                          "dbo.ero_Implementations ON dbo.ero_FR_Band.id = dbo.ero_Implementations.band_id " +
                          "where dbo.ero_Implementations.band_id=" + ID +
                          " order by dbo.ero_Implementations.band_id, dbo.ero_Implementations.FFrom, dbo.ero_Implementations.FTo", DataBase.Properties.Settings.Default.OfficeConnectionString);
            */
            ds = HelperFunctions.fill("SELECT     dbo.ero_Implementations.id, dbo.ero_Implementations.Name, dbo.ero_Implementations.FFrom, dbo.ero_Implementations.FTo, dbo.ero_Implementations.inUse, dbo.ero_Implementations.Note, " +
                          "dbo.ero_Implementations.band_id " +
                          "FROM         dbo.ero_FR_Band  INNER JOIN " +
                          "dbo.ero_Implementations ON dbo.ero_FR_Band.id = dbo.ero_Implementations.band_id "+
                          "where dbo.ero_Implementations.band_id=" + ID +
                          " order by dbo.ero_Implementations.band_id, dbo.ero_Implementations.FFrom, dbo.ero_Implementations.FTo, dbo.ero_Implementations.InUse DESC", DataBase.Properties.Settings.Default.OfficeConnectionString);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ero_Implementation imp = new ero_Implementation();
                imp.id = (int)dr["id"];
                imp.Name = dr["Name"].ToString();

                if (dr["FFrom"].ToString() != "" && dr["FTo"].ToString() !="")
                {
                    imp.FFrom = float.Parse(dr["FFrom"].ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    if (imp.FFrom < this.FFrom) { imp.FFrom = this.FFrom; }

                    imp.FTo = float.Parse(dr["FTo"].ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    if (imp.FTo > this.FTo) { imp.FTo = this.FTo; }

                    imp.Note = "(" + HelperFunctions.getHZ(double.Parse(dr["FFrom"].ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)) + " - " + HelperFunctions.getHZ(double.Parse(dr["FTo"].ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat)) + ") ";
                }
                else
                {
                    imp.FFrom = this.FFrom;
                    imp.FTo = this.FTo;
                }
               

                imp.Note += dr["Note"].ToString();
                imp.inUse = Convert.ToBoolean(dr["inUse"].ToString());
                
                Random rnd = new Random(imp.id+DateTime.Now.Millisecond);
                int colorStart = 30, colorEnd = 200;
                if (!imp.inUse) {colorStart = 60; colorEnd = 100;}
                imp.color = System.Drawing.Color.FromArgb(rnd.Next(colorStart, colorEnd), rnd.Next(colorStart, colorEnd), rnd.Next(colorStart, colorEnd));
                //System.Diagnostics.Debug.WriteLine(imp.color.ToString(), imp.id);

                implementations.Add(imp);
            }

            
        }

        public bool mouseIn(Vector2 position)
        {
            if (position.X > displayedPos.X && position.X < displayedPos.X + displayedPos.Width && position.Y > displayedPos.Y && position.Y < displayedPos.Y + displayedPos.Height) return true;
            else return false;
        }
    }


    public class ero
    {
        public List<fr_Plan> Plans = new List<fr_Plan>();

        public ero()
        {
            System.Diagnostics.Debug.WriteLine(DataBase.Properties.Settings.Default.OfficeConnectionString, "ero:");
            DataSet ds = HelperFunctions.fill("select * from ero_FR_Band order by FFrom", DataBase.Properties.Settings.Default.OfficeConnectionString);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                float ffrom, fto;
                ffrom = (float)Convert.ToDouble(dr["FFrom"]);
                fto = (float)Convert.ToDouble(dr["FTo"]);

                fr_Plan pl = new fr_Plan((int)dr["id"], ffrom, fto);
                pl.Description = dr["Description"].ToString();
                Random rnd = new Random(Plans.Count);
                pl.color = System.Drawing.Color.FromArgb(rnd.Next(50, 100), rnd.Next(50, 100), rnd.Next(50, 100));
                Plans.Add(pl);
            }
        }

        public fr_Plan mouseIn(Vector2 position, int y, int height)
        {
            foreach (fr_Plan pl in Plans)
            {
                if (pl.mouseIn(position)) return pl;
            }

            return null;
        }
    }
}
