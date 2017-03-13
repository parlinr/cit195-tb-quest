using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static class ActionMenu
    {
        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, ColonistAction>()
                    {
                        { ' ', ColonistAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, ColonistAction>()
                {
                    { '1', ColonistAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, ColonistAction>()
                {
                    { '1', ColonistAction.ColonistInfo },
                    { '2', ColonistAction.EditColonistInfo},
                    { '3', ColonistAction.LookAround},
                    { '4', ColonistAction.Travel},
                    { '5', ColonistAction.ColonistLocationsVisited},
                    {'6', ColonistAction.ListLocations},
                    {'0', ColonistAction.Exit }
                }
        };

        //public static Menu ManageTraveler = new Menu()
        //{
        //    MenuName = "ManageTraveler",
        //    MenuTitle = "Manage Colonist",
        //    MenuChoices = new Dictionary<char, ColonistAction>()
        //            {
        //                ColonistAction.MissionSetup,
        //                ColonistAction.TravelerInfo,
        //                ColonistAction.Exit
        //            }
        //};

        /*
        public static Menu EditColonistMenu = new Menu()
        {
            MenuName = "EditColonistMenu",
            MenuTitle = "Edit Character Menu",
            EditColonistMenuChoices = new Dictionary<char, EditColonist>()
            {
                { '1', EditColonist.Name },
                { '2', EditColonist.Age },
                { '3', EditColonist.Strength },
                { '4', EditColonist.Constitution },
                { '5', EditColonist.Magic },
                { '6', EditColonist.Agility },
                { '7', EditColonist.WeaponName },
                { '8', EditColonist.Exit }
            }
        };
        */

    }
}
