using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Kantonian Trail" };
        public static List<string> FooterText = new List<string>() { "(c) MMXVII" };

        /// <summary>
        /// Returns a string containing the introduction to the game's story
        /// </summary>
        /// <returns></returns>
        public static string MissionIntro()
        {
            string messageBoxText =
            "You are a colonist of a far-off land, atempting to establish a colony " +
            "in the Kanti system. The Kanti system has three planets: Phobos, Brypso, and Duskore; " +
            "your colony is on Brypso. The Kanti system has native life that is impeding your progress in " +
            "establishing a colony. Since you have limited ammunition for your modern weapons, you will have to travel " +
            "as light as possible until you can find materials to make more. You may have to improvise for combat. Also, since the Kanti system is the only place for some distance with the " +
            "conditions necessary to support life and the resources to make colonization worthwhile, you may find " +
            "that there is a competitor waiting in the wings ....";

            return messageBoxText;
        }

        //
        //Method regions
        //

        #region CurrentLocationInfo 
        /// <summary>
        /// Returns a string containing information about the player's current location
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="gameUniverse"></param>
        /// <returns></returns>
        public static string CurrentLocationInfo(int LocationID, Universe gameUniverse)
        {
            Location currentLocation = gameUniverse.GetLocationById(LocationID);
            string messageBoxText = currentLocation.Description;
            messageBoxText += "\nChoose from the menu options to proceed.\n";

            return messageBoxText;
        }
        #endregion

        #region InitializeMissionIntro
        /// <summary>
        /// Returns a string of text telling the player they must set up their character 
        /// </summary>
        /// <returns></returns>
        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "Before you begin you must enter some information about yourself and select your " +
                "character attributes. \n \n" +
                "Press any key to continue.";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerName()
        {
            string messageBoxText =
                "Enter your name.";
              
            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerAge(Colonist gameColonist)
        {
            string messageBoxText =
                $"Very well, we will call you {gameColonist.Name}.\n" +
                " \n" +
                "Enter your age below.\n";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerRace(Colonist gameTraveler)
        {
            string messageBoxText =
                $"{gameTraveler.Name}, it will be important for us to know your race on this mission.\n" +
                " \n" +
                "Enter your race below.\n" +
                " \n" +
                "Please use the universal race classifications below." +
                " \n";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }

        public static string InitializeMissionGetAbilityPoints(Colonist gameColonist)
        {
            string messageBoxText =
                $"{gameColonist.Name}, you will now have to select your desired distribution of ability points. By distributing your " +
                $"ability points, you influence how your character will perform in combat. There are four abilities that you may add points " +
                $"to, and when you level up, you will gain one point to add to any of these categories. The categories are: \n \n" +

                $"Strength (influences melee combat) \n" +
                $"Constitution (influences total health points) \n" +
                $"Magic (influences magic combat) \n" +
                $"Agility (influences damage resistance) \n \n" +

                $"You will receive 10 points to distribute as you choose. Keep in mind that you should put at least one point in " +
                $"either Strength or Magic, or else you will do no damage and not be able to fend off the attackers that will " +
                "inevitably come your way. \n \n";

            return messageBoxText;
        }

        public static string InitializeMissionGetWeaponName(Colonist gameColonist)
        {
            string messageBoxText =
                $"Since you put four or more points into strength {gameColonist.Name} you may now name your weapon.";

            return messageBoxText;
        }

        public static string EditColonistGetWeaponName(Colonist gameColonist)
        {
            string messageBoxText =
                $"Since you put four or more points into strength you may now edit your weapon.";

            return messageBoxText;
        }

        public static string InitializeMissionEchoTravelerInfo(Colonist gameTraveler)
        {
            string messageBoxText =
                $"Very good then {gameTraveler.Name}.\n" +
                " \n" +
                "It appears we have all the necessary data to begin your mission. You will find it" +
                " listed below.\n" +
                " \n" +
                $"\tColonist Name: {gameTraveler.Name}\n" +
                $"\tColonist Age: {gameTraveler.Age}\n" +
                $"\tColonist Strength: {gameTraveler.Strength}\n" +
                $"\tColonist Constitution: {gameTraveler.Constitution}\n" +
                $"\tColonist Magic: {gameTraveler.Magic}\n" +
                $"\tColonist Agility: {gameTraveler.Agility}\n";
                if (gameTraveler.IsMeleeColonist)
                {
                    messageBoxText += $"\tWeapon Name: {gameTraveler.WeaponName}\n";
                }
                messageBoxText += " \n" +
                "Press any key to begin your mission.";

            return messageBoxText;
        }

        public static string EditColonistInfo()
        {
            string messageBoxText =
                $"Use the menu to the right to edit the desired attribute.";

            return messageBoxText;
        }

        #endregion

        #region StatusBox
        public static List<string> StatusBox(Colonist colonist, Universe universe)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {colonist.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {colonist.Health}\n");
            statusBoxText.Add($"Lives: {colonist.Lives}\n");

            return statusBoxText;
        }
        #endregion

        #region List All Locations
        public static string ListLocations(List<Location> locations)
        {
            string messageBoxText = 
                "Locations\n" +
                "\n" +

                //
                //display table header
                //
            "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
            "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

            //
            //display all locations
            //
            string locationList = null;
            foreach (Location location in locations)
            {
                locationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += locationList;
            messageBoxText += "\n" + "\n" + "\n" +
            "Press any key to continue.";
            
            return messageBoxText;
        }

        public static string LookAround(Location location)
        {
            string messageBoxText =
                $"Current Location: {location.CommonName}\n" +
                "\n" +
                location.GeneralContents + "\n" +
                "Press any key to continue.";

            return messageBoxText;
        }

        #endregion

        #region Travel
        public static string Travel(Colonist gameColonist, Universe gameUniverse, List<Location> locations)
        {
            string messageBoxText =
                $"{gameColonist.Name}, the colony HQ will need to know the name of the new location. \n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

                //
                //display table header
                //

                "ID".PadRight(10) + "Name".PadRight(30) + " \n" +
                "---".PadRight(10) + "---------------------".PadRight(30) + "\n";

            //
            //display all accessible locations except current location
            //
            string locationList = null;
            Location currentLocation = gameUniverse.GetLocationById(gameColonist.LocationID);
            foreach (Location location in locations)
            {
                if (currentLocation.AccessibleLocations.Contains(location.LocationID))
                {
                    locationList +=
                        $"{location.LocationID}".PadRight(10) +
                        $"{location.CommonName}".PadRight(30) +
                        Environment.NewLine;
                }
            }

            messageBoxText += locationList;

            return messageBoxText;
        }
        #endregion

        #region CurrentLocationInfo
        public static string CurrentLocationInfo(Location location)
        {
            string messageBoxText =
                $"Current Location: {location.CommonName}\n" +
                " \n" +
                location.Description;

            return messageBoxText;
        }
        #endregion

        #region VisitedLocations
        public static string VisitedLocations(List<Location> locations)
        {
            string messageBoxText =
                "Locations Visited\n" +
                " \n" +

                //
                //display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                "---".PadRight(10) + "-------------------".PadRight(30) + "\n";

            //
            //display all locations
            //
            string locationList = null;
            foreach (Location location in locations)
            {
                locationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += locationList;
            messageBoxText += "\n" +
                "Press any key to continue.";

            return messageBoxText;
        }
        #endregion

        #region EditColonistInfo
        public static string EditColonistSubMenu()
        {
            string messageBoxText =
                "Use the menu to the right to edit your information.";

            return messageBoxText;
        }


        #endregion

        #region ListAllGameObjects
        public static string ListAllGameObjects(List<GameObject> gameObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Game Objects \n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Location ID".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "--------------------".PadRight(30) +
                "---".PadRight(10) + "\n";

            //
            // display all colonist objects in rows
            //
            string gameObjectRows = null;
            foreach (GameObject gameObject in gameObjects)
            {
                gameObjectRows +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30) +
                    $"{gameObject.LocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += gameObjectRows;

            return messageBoxText;
            
        }
        #endregion
    }
}
