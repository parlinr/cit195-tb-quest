using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Colonist object for the ConsoleView object to use
        //
        Colonist _gameColonist;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Colonist gameColonist)
        {
            _gameColonist = gameColonist;

            InitializeDisplay();
        }

        #endregion

        #region METHODS

        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public ColonistAction GetActionMenuChoice(Menu menu)
        {
            ColonistAction choosenAction = ColonistAction.None;

            bool validKeystroke = false;
            while (!validKeystroke)
            {
                try
                {
                    ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                    char keyPressed = keyPressedInfo.KeyChar;
                    choosenAction = menu.MenuChoices[keyPressed];
                }
                catch (KeyNotFoundException)
                {
                    DisplayInputBoxPrompt("Invalid keystroke");
                    continue;
                }
                validKeystroke = true;
            }
            
           

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public int GetInteger()
        {
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;

            //use the "ogre" font from www.network-science.de/ascii/
            //Ogre font (c) 1993 Glenn Chappell & Ian Chai
            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine(tabSpace + @"   __                           _     ");
            Console.WriteLine(tabSpace + @"  /__\_  ____ _ _ __ ___  _ __ | | ___ ");
            Console.WriteLine(tabSpace + @" /_\ \ \/ / _` | '_ ` _ \| '_ \| |/ _ \");
            Console.WriteLine(tabSpace + @"//__  >  < (_| | | | | | | |_) | |  __/");
            Console.WriteLine(tabSpace + @"\__/ /_/\_\__,_|_| |_| |_| .__/|_|\___|");
            Console.WriteLine(tabSpace + @"                         |_|           ");
  

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Example";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, ColonistAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != ColonistAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }


        public void DisplayColonistInfo()
        {
            DisplayGamePlayScreen("Colonist Information", Text.InitializeMissionEchoTravelerInfo(_gameColonist), ActionMenu.MissionIntro, "");
            GetContinueKey();
        }

        public Colonist DisplayGetColonistInfo(ConsoleView console)
        {
            Colonist tempObject = new Colonist();

            //
            // intro
            //
            console.DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            console.GetContinueKey();

            //
            // get traveler's name
            //
            console.DisplayGamePlayScreen("Mission Initialization - Name", Text.InitializeMissionGetTravelerName(), ActionMenu.MissionIntro, "");
            console.DisplayInputBoxPrompt("Enter your name: ");
            tempObject.Name = console.GetString();

            //
            // get traveler's age
            //
            console.DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetTravelerAge(tempObject), ActionMenu.MissionIntro, "");
            console.DisplayInputBoxPrompt($"Enter your age {tempObject.Name}: ");
            tempObject.Age = console.GetInteger();

            //
            // get traveler's race
            //
            console.DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetTravelerRace(tempObject), ActionMenu.MissionIntro, "");
            console.DisplayInputBoxPrompt($"Enter your race {tempObject.Name}: ");
            tempObject.Race = console.GetRace();

            //
            // echo the traveler's info
            //
            console.DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTravelerInfo(tempObject), ActionMenu.MissionIntro, "");
            console.GetContinueKey();


            return tempObject;
        }

        #endregion
    }
}
