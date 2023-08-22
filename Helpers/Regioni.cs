using System;
using System.Data;
using System.Text;
using System.Drawing;

namespace Helpers
{
    public class Regioni
    {
        public static Point MinPy(Point a, Point b)
        {
            return a.Y < b.Y || (a.Y == b.Y && a.X < b.X) ? a : b;
        }
        public static Point MaxPy(Point a, Point b)
        {
            return a.Y > b.Y || (a.Y == b.Y && a.X > b.X) ? a : b;
        }
        public bool PointInPolygon(Point[] p, Point t)
        {
            int i, j, count = 0;
            for (i = 0; i < p.Length; ++i)
            {
                j = (i + 1) % p.Length;
                if (t.Y > Math.Min(p[i].Y, p[j].Y) && t.Y <= Math.Max(p[i].Y, p[j].Y) && ccw(MinPy(p[i], p[j]), MaxPy(p[i], p[j]), t))
                    count += 1;
            }
            return (count % 2) == 1;
        }





        public static bool ccw(Point a, Point b, Point c)
        {
            return SignAreaTriang(a, b, c) > 1e-7;
        }


        public static double SignAreaTriang(Point a, Point b, Point c)
        {
            return (a.X * b.Y - a.Y * b.X + a.Y * c.X - a.X * c.Y + b.X * c.Y - b.Y * c.X) / (double)2;
        }


    }
}
