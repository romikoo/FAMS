using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Data;
using System.Data.SqlClient;

namespace Helpers
{
    public class Comment
    {
        public int id = -1;
        public Rectangle shape;
        public Microsoft.Xna.Framework.Color Xnacolor;
        public string text;

        public Comment(Vector2 start, Vector2 end, string txt, float currentScale, System.Drawing.Color color)
        {
            int width = (int)end.X - (int)start.X;
            int height = (int)end.Y - (int)start.Y;
            if (width < 0) {start.X += width; width *= -1;}
            if (height < 0) { start.Y += height; height *= -1; }

            shape = new Rectangle((int)start.X, (int)start.Y, width, height);
            Xnacolor = new Microsoft.Xna.Framework.Color(color.R, color.G, color.B);
            text = txt;
        }

        public bool mouseIn(Vector2 position)
        {
            if (position.X > shape.X && position.X < shape.X + shape.Width && position.Y > shape.Y && position.Y < shape.Y + shape.Height) return true;
            else return false;
        }

        public int insComment()
        {
            try
            {
                DataSet ds = HelperFunctions.fill("insert into Comment (Shape, Color, Text) values ('" + shape + "', '" + Xnacolor + "', N'" + text + "') select @@identity as id", DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            catch (Exception ee) { System.Windows.Forms.MessageBox.Show(ee.ToString()); }
            return id;
        }

        public bool Delete() 
        {
            try
            {
                HelperFunctions.ExecuteNonQuery("Delete from Comment where id=" + this.id, DataBase.Properties.Settings.Default.CHAllocationsConnectionString.ToString());
            }
            catch (Exception ee) { System.Windows.Forms.MessageBox.Show(ee.ToString()); return false; }
            return true;
        }
    }
}
