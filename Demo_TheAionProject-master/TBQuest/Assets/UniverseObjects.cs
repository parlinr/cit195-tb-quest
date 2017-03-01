using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static class UniverseObjects
    {
        public static List<Location> Locations = new List<Location>()
        {
            new Location
            {
                CommonName = "Colony Home Base",
                LocationID = 1,
                Description = "You are in the atrium of the main colony building.",
                GeneralContents = "",
                Accessable = true
                
                               
            }
        };
    }
}
