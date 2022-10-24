﻿using System.Text.RegularExpressions;

namespace DTC.Models.FA18.PrePlanned
{
    public class PrePlannedCoordinate
    {
		public static Regex coordRegex = new Regex("^([N|S] \\d\\d°\\d\\d\\.\\d\\d\\d\\d) ([E|W] \\d\\d\\d°\\d\\d\\.\\d\\d\\d\\d)$");
        public string Lat { get; set; }
        public string Lon { get; set; }
        public int Elev { get; set; }
        public bool Enabled { get; set; }

        public PrePlannedCoordinate()
        {
            Lat = "";
            Lon = "";
            Elev = 0;
            Enabled = false;
        }

        public bool CanBeEnabled
        {
            get
            {
                if (Lat.Length > 0 && Lon.Length > 0 && Elev >= 0) return true;
                return false;
            }
        }
        
		public static bool IsCoordinateValid(string coord)
		{
			var match = coordRegex.Match(coord);
			return match.Success;
		}
    }
}
