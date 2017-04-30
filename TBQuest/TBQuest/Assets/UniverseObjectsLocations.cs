using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static partial class UniverseObjects
    {
        public static List<Location> Locations = new List<Location>()
        {
			new Location
			{
				CommonName = "Player's Equipped Items",
				LocationID = -1,
				Description = "Player's Equipped Items",
				GeneralContents = "",
				ExperiencePoints = 0
			},

			new Location
            {
                CommonName = "Player's Inventory",
                LocationID = 0,
                Description = "Player's Inventory",
                GeneralContents = "",
                ExperiencePoints = 0
            },

            new Location
            {
                CommonName = "Colony Home Base",
                LocationID = 1,
                Description = "You are in the atrium of the main colony building.",
                GeneralContents = "",
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
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    3,
                    4,
                    8
                }

            },

            new Location
            {
                CommonName = "Phobos Forward Outpost",
                LocationID = 5,
                Description = "This is a location on Phobos that is nearby several locations of interest. Also, this is the location where you "
                                + "will travel from Phobos to another planet.",
                GeneralContents = "",
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    2,
                    5,
					6
                }
            },

            new Location
            {
                CommonName = "Duskore Forward Outpost",
                LocationID = 6,
                Description = "This is a location on Duskore that is nearby several locations of interest. Also, this is the location where you "
                                + "will travel from Duskore to another planet.",
                GeneralContents = "",
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    2,
					5,
                    6
                }
            },

            new Location
            {
                CommonName = "Boreal Forest",
                LocationID = 7,
                Description = "This is a dense forest with many old-growth plants that resemble trees. Some wildlife can be heard within the forest. "
                                +"Initial scouting reveals that there could be a water source which could serve the colony's water needs.",
                GeneralContents = "",
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    6,
                    7
                }

            },

            new Location
            {
                CommonName = "Brypsonian Mountains",
                LocationID = 8,
                Description = "This is a location at the foothills of a mountain range on Brypso. The mountians may contain mineral resources "
                                + "that could be used by the colony.",
                GeneralContents = "",
                ExperiencePoints = 10,
                AccessibleLocations = new List<int>()
                {
                    4,
                    8
                }
            },

			new Location
			{
				CommonName = "Steppes",
				LocationID = 9,
				Description = "A wide expanse of grassland.",
				GeneralContents = "",
				ExperiencePoints = 10,
				AccessibleLocations = new List<int>()
				{
					5,
					9
				}

			}

        };
        
    }
}
