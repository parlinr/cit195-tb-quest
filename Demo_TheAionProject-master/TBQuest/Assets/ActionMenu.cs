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
                    { '2', ColonistAction.Exit }
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
    }
}
