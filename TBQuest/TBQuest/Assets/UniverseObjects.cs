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
                ExperiencePoints = 0,
                AccessibleLocations = new List<int>()
                {
                    1,
                    2,
                    3
                }
                
            },

            new Location
            {
                CommonName = "Hangar",
                LocationID = 2,
                Description = "You are in the hangar of the main colony building. From here, you "
                              + "may travel to the other planets in the system.",
                GeneralContents = "",
                Accessible = true,
                ExperiencePoints = 0,
                AccessibleLocations = new List<int>()
                {
                    1,
                    2,
                    5,
                    6
                }

            },

            new Location
            {
                CommonName = "Motor Pool",
                LocationID = 3,
                Description = "You are in the motor pool of the main colony building. From here, "
                               + "you may travel to other locations on Brypso.",
                GeneralContents = "",
                Accessible = true,
                ExperiencePoints = 0,
                AccessibleLocations = new List<int>()
                {
                    1,
                    3,
                    4
                }
            },

            new Location
            {
                CommonName = "Brypso Forward Outpost",
                LocationID = 4,
                Description = "This is a location away from the colony on Brypso that is nearby several locations of interest.",
                GeneralContents = "",
                Accessible = true,
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    3,
                    4
                }
        
            },

            new Location
            {
                CommonName = "Phobos Forward Outpost",
                LocationID = 5,
                Description = "This is a location on Phobos that is nearby several locations of interest. Also, this is the location where you "
                                + "will travel from Phobos to another planet.",
                GeneralContents = "",
                Accessible = true,
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    2,
                    5
                }
            },

            new Location
            {
                CommonName = "Duskore Forward Outpost",
                LocationID = 6,
                Description = "This is a location on Duskore that is nearby several locations of interest. Also, this is the location where you "
                                + "will travel from Duskore to another planet.",
                GeneralContents = "",
                Accessible = true,
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    2,
                    6
                }
            }

        };
        
    }
}
