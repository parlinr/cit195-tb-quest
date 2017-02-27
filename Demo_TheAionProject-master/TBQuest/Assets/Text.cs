﻿using System;
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
        public static List<string> HeaderText = new List<string>() { "Example" };
        public static List<string> FooterText = new List<string>() { "(c) MMXVII" };

        public static string MissionIntro()
        {
            string messageBoxText =
            "You are a colonist of a far-off land, atempting to establish a colony " +
            "in the Kanti system. The Kanti system has three planets: Phobos, Brypso, and Duskore; " +
            "your colony is on Brypso. The Kanti system has native life that is impeding your progress in " +
            "establishing a colony. Also, since the Kanti system is the only place for some distance with the" +
            "conditions necessary to support life and the resources to make colonization worthwhile, you may find " +
            "that there is a competitor waiting in the wings ....";

            return messageBoxText;
        }

        public static string CurrentLocationInfo()
        {
            string messageBoxText =
            "You are at the colony on Brypso. \n" +
            " \n" +
            "\tChoose from the menu options to proceed.\n";

            return messageBoxText;
        }

        #region Initialize Mission Text

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
                $"\tColonist Agility: {gameTraveler.Agility}\n" +
                " \n" +
                "Press any key to begin your mission.";

            return messageBoxText;
        }

        #endregion
    }
}
