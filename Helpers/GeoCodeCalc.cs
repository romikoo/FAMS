using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;

namespace Helpers
{
    public class GeoCodeCalc
    {
        public const double EarthRadiusInMiles = 3956.0;
        public const double EarthRadiusInKilometers = 6372.7976;
        public static double ToRadian(double val) { return val * (Math.PI / 180); }
        public static double DiffRadian(double val1, double val2) { return ToRadian(val2) - ToRadian(val1); }
        /// <summary> 
        /// Calculate the distance between two geocodes. Defaults to using Miles. 
        /// </summary> 
        public static double CalcDistance(double lat1, double lng1, double lat2, double lng2)
        {
            return CalcDistance(lat1, lng1, lat2, lng2, GeoCodeCalcMeasurement.Miles);
        }
        /// <summary> 
        /// Calculate the distance between two geocodes. 
        /// </summary> 
        public static double CalcDistance(double lat1, double lng1, double lat2, double lng2, GeoCodeCalcMeasurement m)
        {
            double radius = GeoCodeCalc.EarthRadiusInMiles;
            if (m == GeoCodeCalcMeasurement.Kilometers) { radius = GeoCodeCalc.EarthRadiusInKilometers; }
            return radius * 2 * Math.Asin(Math.Min(1, Math.Sqrt((Math.Pow(Math.Sin((DiffRadian(lat1, lat2)) / 2.0), 2.0) + Math.Cos(ToRadian(lat1)) * Math.Cos(ToRadian(lat2)) * Math.Pow(Math.Sin((DiffRadian(lng1, lng2)) / 2.0), 2.0)))));
        }

        public static PointLatLng getPoint(PointLatLng p, double dst, double angl)
        {
            double lat1 = p.Lat * Math.PI / 180;
            double lon1 = p.Lng * Math.PI / 180;
            double brg = angl * Math.PI / 180.0;

            double b = dst / 6372.7976;
            double lat2 = Math.Asin(Math.Sin(lat1) * Math.Cos(b) + Math.Cos(lat1) * Math.Sin(b) * Math.Cos(brg));
            double lon2 = lon1 + Math.Atan2(Math.Sin(brg) * Math.Sin(b) * Math.Cos(lat1), Math.Cos(b) - Math.Sin(lat1) * Math.Sin(lat2));
            double dLon = lon1 - lon2;
            double y = Math.Sin(dLon) * Math.Cos(p.Lat);
            double x = Math.Cos(lat2) * Math.Sin(lat1) - Math.Sin(lat2) * Math.Cos(lat1) * Math.Cos(dLon);
            double d = Math.Atan2(y, x);
            double finalBrg = d + Math.PI;
            double backBrg = d + 2 * Math.PI;

            lat2 = lat2 * 180 / Math.PI; ;
            lon2 = lon2 * 180 / Math.PI;
            finalBrg = finalBrg * 180 / Math.PI;
            backBrg = backBrg * 180 / Math.PI;

            return new PointLatLng(lat2, lon2);
        }

        public ﻿static Double bearing(Double lat1, Double long1, Double lat2, Double long2)
        {
            Double phi1 = lat1 * Math.PI/180;
            Double phi2 = lat2 * Math.PI/180;
            Double lam1 = long1 * Math.PI/180;
            Double lam2 = long2 * Math.PI/180;
 
            double angel = Math.Atan2(Math.Sin(lam2-lam1)*Math.Cos(phi2),
                Math.Cos(phi1)*Math.Sin(phi2) - Math.Sin(phi1)*Math.Cos(phi2)*Math.Cos(lam2-lam1)
            ) * 180/Math.PI;

            if (angel < 0) return 360 + angel;
            return angel;
        }

        public static List<PointLatLng> RegionOfInterference(PointLatLng from, PointLatLng to, double distance)
        {
            List<PointLatLng> result = new List<PointLatLng>();
            double dst = GeoCodeCalc.CalcDistance(from.Lat, from.Lng, to.Lat, to.Lng, GeoCodeCalcMeasurement.Kilometers);
            double link_angle = GeoCodeCalc.bearing(from.Lat, from.Lng, to.Lat, to.Lng);
            PointLatLng p1 = GeoCodeCalc.getPoint(from, distance, link_angle + 180);
            PointLatLng p2 = GeoCodeCalc.getPoint(p1, distance, link_angle + 90);
            PointLatLng p3 = GeoCodeCalc.getPoint(p2, dst + distance * 2, link_angle);
            PointLatLng p4 = GeoCodeCalc.getPoint(p3, distance * 2, link_angle - 90);
            PointLatLng p5 = GeoCodeCalc.getPoint(from, distance, link_angle - 90);
            PointLatLng p6 = GeoCodeCalc.getPoint(p5, distance, link_angle - 180);

            result.Add(p1);
            result.Add(p2);
            result.Add(p3);
            result.Add(p4);
            result.Add(p5);
            result.Add(p6);
            result.Add(p1);

            return result;
        }

        public static string ToDegreeNotation(decimal angle)
        {
         

            ﻿//ensure the value will fall within the primary range [-180.0..+180.0]
            while (angle < -180)
                angle += 360;

            while (angle > 180)
                angle -= 360;

            

            //switch the value to positive
            angle = Math.Abs(angle);

            //gets the degree
            var Degrees = (int)Math.Floor(angle);
            var delta = angle - Degrees;

            //gets minutes and seconds
            var seconds = (int)Math.Floor(3600 * delta);
            var Seconds = seconds % 60.0M;
            var Minutes = (int)Math.Floor(seconds / 60.0);
            delta = delta * 3600 - seconds;
       
            //gets fractions
            var Milliseconds = Math.Round(delta*10)*1.0M;
            Seconds += Milliseconds / 10.0M;

            string iDegrees = Degrees.ToString();
            string iMinutes = Minutes.ToString();
            string iSeconds = Seconds.ToString();
            if (Degrees < 10) iDegrees = "0" + Degrees;
            if (Minutes < 10) iMinutes = "0" + Minutes;
            if (Seconds < 10) iSeconds = "0" + Seconds;

            return iDegrees + iMinutes + iSeconds;
        }

        public static double DMStoDD(string coordinate)
        {
           

            double angle = Convert.ToDouble(coordinate)/10000.00;

            //degrees, minutes and seconds
            double degminsec = angle;
            // decimal seconds
            double decsec = (degminsec * 100 - Math.Truncate(degminsec * 100)) / .6;
            //degrees and minutes
            double degmin = (Math.Truncate(degminsec * 100) + decsec) / 100;
            //degrees
            double deg = Math.Truncate(degmin);
            //decimal degrees
            double decdeg = deg + (degmin - deg) / .6;

           

            return Convert.ToDouble(decdeg);
        }

    }

    public enum GeoCodeCalcMeasurement : int
    {
        Miles = 0,
        Kilometers = 1
    }
}
