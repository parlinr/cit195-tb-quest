using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// Contains the user interface menus used throughout the project
    /// </summary>
    public static class ActionMenu
    {
        public enum CurrentMenu
        {
            None,
            MissionIntro,
            InitializeMission,
            MainMenu,
            AdminMenu,
			ObjectInteractionMenu,
            ColonistMenu,
            BattleMenu,
            NpcMenu
        }

        public static CurrentMenu currentMenu = CurrentMenu.MainMenu;
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
                    { '1', ColonistAction.LookAround},
                    { '2', ColonistAction.Travel},
                    {'3', ColonistAction.ObjectInteractionMenu },
                    {'4', ColonistAction.NonplayerCharacterMenu },
                    {'5', ColonistAction.ColonistMenu },
					{'6', ColonistAction.AdminMenu},
                    {'7', ColonistAction.BattleMenu},
                    {'0', ColonistAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, ColonistAction>()
            {
                {'1', ColonistAction.ListLocations},
                {'2', ColonistAction.ListGameObjects},
                {'3', ColonistAction.ListNonplayerCharacters},
                {'0', ColonistAction.ReturnToMainMenu }
            }
        };

        
        
        public static Menu EditColonistMenu = new Menu()
        {
            MenuName = "EditColonistMenu",
            MenuTitle = "Edit Character Menu",
            EditColonistMenuChoices = new Dictionary<char, EditColonist>()
            {
                { '1', EditColonist.Name },
                { '2', EditColonist.Age },
                { '3', EditColonist.AbilityPoints },
                { '0', EditColonist.ExitEditMenu }
            }
        };

		public static Menu ObjectInteractionMenu = new Menu()
		{
			MenuName = "ObjectInteractionMenu",
			MenuTitle = "Object Interaction Menu",
			MenuChoices = new Dictionary<char, ColonistAction>()
			{
                {'1', ColonistAction.LookAt },
				{'2', ColonistAction.PickUp },
				{'3', ColonistAction.PutDown },
				{'0', ColonistAction.ReturnToMainMenu }
			}
		};

        public static Menu ColonistMenu = new Menu()
        {
            MenuName = "ColonistMenu",
            MenuTitle = "Colonist Menu",
            MenuChoices = new Dictionary<char, ColonistAction>()
            {
                {'1', ColonistAction.ColonistInfo },
                {'2', ColonistAction.ColonistInventory },
                {'3', ColonistAction.ColonistLocationsVisited },
                {'0', ColonistAction.ReturnToMainMenu  }
            }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, ColonistAction>()
            {
                {'1', ColonistAction.TalkTo },
                {'0', ColonistAction.ReturnToMainMenu  }
            }

        };

        public static Menu BattleMenu = new Menu()
        {
            MenuName = "BattleMenu",
            MenuTitle = "Battle Menu",
            MenuChoices = new Dictionary<char, ColonistAction>()
            {
                {'1', ColonistAction.Attack},
                {'2', ColonistAction.RunAway },
                {'0', ColonistAction.ReturnToMainMenu }
            }
        };
        

    }
}
