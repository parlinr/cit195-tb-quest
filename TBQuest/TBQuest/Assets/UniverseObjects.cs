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
                Accessible = true,
                ExperiencePoints = 0


            },

            new Location
            {
                CommonName = "Hangar",
                LocationID = 2,
                Description = "You are in the hangar of the main colony building. From here, you "
                              + "may travel to the other planets in the system.",
                GeneralContents = "",
                Accessible = true,
                ExperiencePoints = 0

            },

            new Location
            {
                CommonName = "Motor Pool",
                LocationID = 3,
                Description = "You are in the motor pool of the main colony building. From here, "
                               + "you may travel to other locations on Brypso.",
                GeneralContents = "",
                Accessible = true,
                ExperiencePoints = 0
            }
        };
    }
}
