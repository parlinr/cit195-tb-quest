using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public class ConsoleView
    {
        #region ENUMERABLES
        private enum ViewStatus
        { 
            ColonistInitialization,
            PlayingGame
        }
        #endregion
    

        #region FIELDS

        //
        // declare a Colonist object for the ConsoleView object to use
        //
        Colonist _gameColonist;
        Universe _gameUniverse;
        ViewStatus _viewStatus;

        

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Colonist gameColonist, Universe gameUniverse)
        {
            _gameColonist = gameColonist;
            _gameUniverse = gameUniverse;

            _viewStatus = ViewStatus.ColonistInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// Displays the content of the screen
        /// </summary>
        /// <param name="messageBoxHeaderText"></param>
        /// <param name="messageBoxText"></param>
        /// <param name="menu"></param>
        /// <param name="inputBoxPrompt"></param>
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
            DisplayStatusBox();
        }

        /// <summary>
        /// clear the current line
        /// </summary>
        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.Write(new string(' ', Console.WindowWidth - 7));
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get an action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public ColonistAction GetActionMenuChoice(Menu menu)
        {
            ColonistAction choosenAction = ColonistAction.None;
            Console.CursorVisible = false;

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
                    ClearCurrentConsoleLine();
                    DisplayInputBoxPrompt("Invalid keystroke. Press enter to try again.");
                    Console.ReadLine();
                    ClearCurrentConsoleLine();
                    continue;
                }
                validKeystroke = true;
            }
            
           

            return choosenAction;
        }

		/// <summary>
		/// get an admin menu choice from the user
		/// </summary>
		/// <returns>action menu choice</returns>
		public ColonistAction GetAdminMenuChoice(Menu menu)
		{
			ColonistAction choosenAction = ColonistAction.None;
			Console.CursorVisible = false;

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
					ClearCurrentConsoleLine();
					DisplayInputBoxPrompt("Invalid keystroke. Press enter to try again.");
					Console.ReadLine();
					ClearCurrentConsoleLine();
					continue;
				}
				validKeystroke = true;
			}



			return choosenAction;
		}

        public ColonistAction GetColonistMenuChoice(Menu menu)
        {
            ColonistAction choosenAction = ColonistAction.None;
            Console.CursorVisible = false;

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
                    ClearCurrentConsoleLine();
                    DisplayInputBoxPrompt("Invalid keystroke. Press enter to try again.");
                    Console.ReadLine();
                    ClearCurrentConsoleLine();
                    continue;
                }
                validKeystroke = true;
            }



            return choosenAction;
        }


        /// <summary>
        /// get an object menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public ColonistAction GetObjectMenuChoice(Menu menu)
		{
			ColonistAction choosenAction = ColonistAction.None;
			Console.CursorVisible = false;

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
					ClearCurrentConsoleLine();
					DisplayInputBoxPrompt("Invalid keystroke. Press enter to try again.");
					Console.ReadLine();
					ClearCurrentConsoleLine();
					continue;
				}
				validKeystroke = true;
			}



			return choosenAction;
		}

		/// <summary>
		/// get an edit character menu choice from the user
		/// </summary>
		/// <returns>action menu choice</returns>
		public EditColonist GetActionEditMenuChoice(Menu menu)
        {
            EditColonist choosenAction = EditColonist.None;
            Console.CursorVisible = false;

            bool validKeystroke = false;
            while (!validKeystroke)
            {
                try
                {
                    ConsoleKeyInfo keyPressedInfo = Console.ReadKey();
                    char keyPressed = keyPressedInfo.KeyChar;
                    choosenAction = menu.EditColonistMenuChoices[keyPressed];
                }
                catch (KeyNotFoundException)
                {
                    ClearCurrentConsoleLine();
                    DisplayInputBoxPrompt("Invalid keystroke. Press enter to try again.");
                    Console.ReadLine();
                    ClearCurrentConsoleLine();
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

        private bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // validate range if either min or max value is nonzero
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                   
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
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
        /// gets the initial strength value form the user
        /// </summary>
        /// <param name="console"></param>
        /// <param name="tempObject"></param>
        /// <returns>user's chosen strength value</returns>
        public int GetStrength(ConsoleView console, Colonist tempObject)
        {
            int userStrength = 0;
            bool validStrength = false;
            while (!validStrength)
            {
                console.ClearCurrentConsoleLine();
                console.DisplayInputBoxPrompt($"Enter your strength value {tempObject.Name} (0-{tempObject.AbilityPoints}): ");
                try
                {
                    userStrength = console.GetInteger();
                }
                catch (FormatException)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("Not an integer. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }
                catch (Exception)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("An unknown error occurred. Press enter to try agian.");
                    console.GetContinueKey();
                    continue;
                }

                if (userStrength > tempObject.AbilityPoints || userStrength < 0)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("You either chose a higher or lower amount of strength than is possible. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                tempObject.AbilityPoints -= userStrength;
                validStrength = true;

            }

            return userStrength;
            

        }
        /// <summary>
        /// gets the initial constitution value from the user
        /// </summary>
        /// <param name="console"></param>
        /// <param name="tempObject"></param>
        /// <returns>user chosen constitution value</returns>
        public int GetConstitution(ConsoleView console, Colonist tempObject)
        {
            console.DisplayGamePlayScreen("Mission Initialization - Ability Points", Text.InitializeMissionGetAbilityPoints(tempObject), ActionMenu.MissionIntro, "");
            int userConstitution = 0;
            bool validConstitution = false;
            while (!validConstitution)
            {
                console.ClearCurrentConsoleLine();
                console.DisplayInputBoxPrompt($"Enter your constitution value {tempObject.Name} (0-{tempObject.AbilityPoints}): ");
                try
                {
                    userConstitution = console.GetInteger();
                }
                catch (FormatException)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("Not an integer. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }
                catch (Exception)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("An unknown error occurred. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                if (userConstitution > tempObject.AbilityPoints || userConstitution < 0)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("You either chose a higher or lower amount of constitution than is possible. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                tempObject.AbilityPoints -= userConstitution;
                validConstitution= true;

            }

            return userConstitution;



        }

        /// <summary>
        /// gets the initial magic value from the user
        /// </summary>
        /// <param name="console"></param>
        /// <param name="tempObject"></param>
        /// <returns>user chosen magic value</returns>
        public int GetMagic(ConsoleView console, Colonist tempObject)
        {
            int userMagic = 0;
            bool validMagic = false;
            while (!validMagic)
            {
                console.ClearCurrentConsoleLine();
                console.DisplayInputBoxPrompt($"Enter your magic value {tempObject.Name} (0-{tempObject.AbilityPoints}): ");
                try
                {
                    userMagic = console.GetInteger();
                }
                catch (FormatException)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("Not an integer. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }
                catch (Exception)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("An unknown error occurred. Pres enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                if (userMagic > tempObject.AbilityPoints || userMagic < 0)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("You either chose a higher or lower amount of magic than is possible. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                tempObject.AbilityPoints -= userMagic;
                validMagic = true;

            }

            return userMagic;


        }

        /// <summary>
        /// gets the initial agility value from the user
        /// </summary>
        /// <param name="console"></param>
        /// <param name="tempObject"></param>
        /// <returns>user chosen agility value</returns>
        public int GetAgility(ConsoleView console, Colonist tempObject)
        {
            int userAgility = 0;
            bool validAgility = false;
            while (!validAgility)
            {
                console.ClearCurrentConsoleLine();
                console.DisplayInputBoxPrompt($"Enter your agility value {tempObject.Name} (0-{tempObject.AbilityPoints}): ");
                try
                {
                    userAgility = console.GetInteger();
                }
                catch (FormatException)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("Not an integer. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }
                catch (Exception)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("An unknown error occurred. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                if (userAgility > tempObject.AbilityPoints || userAgility < 0)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("You either chose a higher or lower amount of agility than is possible. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                tempObject.AbilityPoints -= userAgility;
                validAgility = true;

            }

            return userAgility;


        }

        /// <summary>
        /// melee characters (>=4 strength at character creation) can name their weapon
        /// </summary>
        /// <param name="console"></param>
        /// <param name="tempObject"></param>
        /// <returns></returns>
        public string GetWeaponName (ConsoleView console, Colonist tempObject)
        {
            string playerWeaponName = "";

            if (tempObject.Strength >= 4)
            {
                tempObject.IsMeleeColonist = true;
                console.DisplayGamePlayScreen("Mission Intiialization - Name Weapon", Text.InitializeMissionGetWeaponName(tempObject), ActionMenu.MissionIntro, "");
                console.DisplayInputBoxPrompt($"Enter your weapon's name {tempObject.Name}.");
                playerWeaponName = console.GetString();
            }

            return playerWeaponName;
        }

        /// <summary>
        /// if a player has >=4 strength on edit, they can modify weapon name.
        /// </summary>
        /// <param name="console"></param>
        /// <param name="tempObject"></param>
        /// <returns></returns>
        public string EditWeaponName(ConsoleView console, Colonist tempObject)
        {
            string playerWeaponName = "";

            if (tempObject.Strength >= 4)
            {
                tempObject.IsMeleeColonist = true;
                console.DisplayGamePlayScreen("Colonist Edit - Name Weapon", Text.EditColonistGetWeaponName(tempObject), ActionMenu.MissionIntro, "");
                console.DisplayInputBoxPrompt($" Enter you weapon's new name (or press Enter to leave it unchanged) .");
                playerWeaponName = console.GetString();
            }

            return playerWeaponName;
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
            Console.WriteLine(tabSpace + @"                  _              _               _____           _ _ ");
            Console.WriteLine(tabSpace + @"  /\ /\__ _ _ __ | |_ ___  _ __ (_) __ _ _ __   /__   \_ __ __ _(_) |");
            Console.WriteLine(tabSpace + @" / //_/ _` | '_ \| __/ _ \| '_ \| |/ _` | '_ \    / /\/ '__/ _` | | |");
            Console.WriteLine(tabSpace + @"/ __ \ (_| | | | | || (_) | | | | | (_| | | | |  / /  | | | (_| | | |");
            Console.WriteLine(tabSpace + @"\/  \/\__,_|_| |_|\__\___/|_| |_|_|\__,_|_| |_|  \/   |_|  \__,_|_|_|");
              

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
            Console.Title = "Kantonian Trail";

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

            //
            // use the proper dictionary based on what menu is being passed
            //
            if (menu == ActionMenu.MainMenu)
            {
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
            else if (menu == ActionMenu.EditColonistMenu)
            {
                foreach (KeyValuePair<char, EditColonist> menuChoice in menu.EditColonistMenuChoices)
                {
                    if (menuChoice.Value != EditColonist.None)
                    {
                        string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                        Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                        Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                    }
                }
            }
			else if (menu == ActionMenu.AdminMenu)
			{
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
			else if (menu == ActionMenu.ObjectInteractionMenu)
			{
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

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameColonist, _gameUniverse))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
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
            DisplayGamePlayScreen("Colonist Information", Text.InitializeMissionEchoTravelerInfo(_gameColonist), ActionMenu.MainMenu, "");
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
            bool validAge = false;
            while (!validAge)
            {
                int userAge;
                console.DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetTravelerAge(tempObject), ActionMenu.MissionIntro, "");
                console.DisplayInputBoxPrompt($"Enter your age {tempObject.Name}: ");
                try
                {
                    userAge = console.GetInteger();
                }
                catch (FormatException)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("You did not enter an integer. Press enter to try again.");
                    console.GetContinueKey();
                    continue;

                }
                catch (Exception)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("You did not enter an integer. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                if (userAge < 0)
                {
                    console.ClearCurrentConsoleLine();
                    console.DisplayInputBoxPrompt("You did not enter a valid age. Press enter to try again.");
                    console.GetContinueKey();
                    continue;
                }

                validAge = true;
                tempObject.Age = userAge;
            }
            

            //
            // get traveler's race
            //

            /*
            console.DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetTravelerRace(tempObject), ActionMenu.MissionIntro, "");
            console.DisplayInputBoxPrompt($"Enter your race {tempObject.Name}: ");
            tempObject.Race = console.GetRace();
            */

            //
            // get ability points
            //

            
            console.DisplayGamePlayScreen("Mission Initialization - Ability Points", Text.InitializeMissionGetAbilityPoints(tempObject), ActionMenu.MissionIntro, "");
            
            tempObject.AbilityPoints = 10;
            tempObject.Strength = console.GetStrength(console, tempObject);
            tempObject.WeaponName = console.GetWeaponName(console, tempObject);
            tempObject.Constitution = console.GetConstitution(console, tempObject);
            tempObject.Magic = console.GetMagic(console, tempObject);
            tempObject.Agility = console.GetAgility(console, tempObject);
            

            //reset ability points in case player did not use all 10 of them
            tempObject.AbilityPoints = 0;

            //console.GetContinueKey();
            



            //
            // echo the traveler's info
            //
            console.DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTravelerInfo(tempObject), ActionMenu.MissionIntro, "");
            console.GetContinueKey();

            //
            // set _viewStatus to PlayingGame
            //
            _viewStatus = ViewStatus.PlayingGame;


            return tempObject;
        }

        public Colonist DisplayEditColonistInfo(ConsoleView console)
        {
            Colonist playerEdit = new Colonist();

            /*playerEdit = DisplayGetColonistInfo(console);*/
            EditColonist editActionChoice = EditColonist.None;

            


            bool editing = true;
            while (editing)
            {
                //
                // sub-screen
                //
                console.DisplayGamePlayScreen("Edit Colonist Info", Text.EditColonistSubMenu(), ActionMenu.EditColonistMenu, "");
                editActionChoice = console.GetActionEditMenuChoice(ActionMenu.EditColonistMenu);

                //
                // choose the edit screen based on user's choice
                //
                switch (editActionChoice)
                {
                    case EditColonist.None:
                        break;
                    case EditColonist.Name:
                        console.DisplayGamePlayScreen("Colonist Edit - Name", Text.InitializeMissionGetTravelerName(), ActionMenu.MissionIntro, "");
                        console.DisplayInputBoxPrompt("Enter your name: ");
                        playerEdit.Name = console.GetString();
                        break;
                    case EditColonist.Age:
                        bool validAge = false;
                        while (!validAge)
                        {
                            int userAge;
                            console.DisplayGamePlayScreen("Colonist Edit - Age", Text.InitializeMissionGetTravelerAge(playerEdit), ActionMenu.MissionIntro, "");
                            console.DisplayInputBoxPrompt($"Enter your age {playerEdit.Name}: ");
                            try
                            {
                                userAge = console.GetInteger();
                            }
                            catch (FormatException)
                            {
                                console.ClearCurrentConsoleLine();
                                console.DisplayInputBoxPrompt("You did not enter an integer. Press enter to try again.");
                                console.GetContinueKey();
                                continue;

                            }
                            catch (Exception)
                            {
                                console.ClearCurrentConsoleLine();
                                console.DisplayInputBoxPrompt("You did not enter an integer. Press enter to try again.");
                                console.GetContinueKey();
                                continue;
                            }

                            if (userAge < 0)
                            {
                                console.ClearCurrentConsoleLine();
                                console.DisplayInputBoxPrompt("You did not enter a valid age. Press enter to try again.");
                                console.GetContinueKey();
                                continue;
                            }

                            validAge = true;
                            playerEdit.Age = userAge;
                        }
                        break;
                    case EditColonist.AbilityPoints:
                        
                        console.DisplayGamePlayScreen("Colonist Edit - Ability Points", Text.InitializeMissionGetAbilityPoints(playerEdit), ActionMenu.MissionIntro, "");

                        playerEdit.AbilityPoints = 10;
                        playerEdit.Strength = console.GetStrength(console, playerEdit);
                        
                        playerEdit.Constitution = console.GetConstitution(console, playerEdit);
                        playerEdit.Magic = console.GetMagic(console, playerEdit);
                        playerEdit.Agility = console.GetAgility(console, playerEdit);

                        //
                        // reset ability points in case player did not use all of them
                        //
                        playerEdit.AbilityPoints = 0;

                        //
                        // if strength >= 4, offer a chance to edit weapon name
                        //
                        if (playerEdit.Strength >= 4)
                        {
                            playerEdit.WeaponName = console.GetWeaponName(console, playerEdit);
                        }
                        
                        break;

                    case EditColonist.ExitEditMenu:
                        editing = false;
                        break;


                }
            }
            
            return playerEdit;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisplayCurrentLocationInfo()
        {
            int LocationID = _gameColonist.LocationID;

            Location currentLocation = _gameUniverse.GetLocationById(LocationID);
            DisplayGamePlayScreen("Current Location Info", Text.CurrentLocationInfo(LocationID, _gameUniverse), ActionMenu.MainMenu, "");
            GetContinueKey();
        }

        public void DisplayListOfLocations()
        {
            DisplayGamePlayScreen("List: Locations", Text.ListLocations
                (_gameUniverse.Locations), ActionMenu.AdminMenu, "");
            GetContinueKey();
        }

        public void DisplayLookAround()
        {
            //
            // get current location 
            //
            Location currentLocation = _gameUniverse.GetLocationById
                (_gameColonist.LocationID);

            //
            // get list of game objects in current location 
            //
            List<GameObject> gameObjectsInCurrentLocation = _gameUniverse.GetGameObjectByLocationId(_gameColonist.LocationID);

            //
            // get list of NPCs in current location
            //
            List<Npc> npcsInCurrentLocation = _gameUniverse.GetNpcByLocationId(_gameColonist.LocationID);

            string messageBoxText = Text.LookAround(currentLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.ListAllGameObjects(gameObjectsInCurrentLocation) + Environment.NewLine;
            messageBoxText += Text.NpcsChooseList(npcsInCurrentLocation);


            DisplayGamePlayScreen("Current Location", messageBoxText,
                ActionMenu.MainMenu, "");
            GetContinueKey();
        }

		public int DisplayGetNextLocation()
        {
            int locationId = 0;
            bool validLocationId = false;

            DisplayGamePlayScreen("Travel to a New Location", Text.Travel(_gameColonist, _gameUniverse,
                _gameUniverse.Locations), ActionMenu.MainMenu, "");

            while (!validLocationId)
            {
                //get integer from the player
                GetInteger($"Enter your new location {_gameColonist.Name}: ", 1, _gameUniverse.GetMaxLocationId(), out locationId);

                //
                //validate integer as valid location ID and determine accessibility
                //
                if (_gameUniverse.IsValidLocationId(locationId))
                {
                    if (_gameUniverse.IsAccessibleLocation(locationId, _gameColonist.LocationID))
                    {
                        validLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you are attempting to travel to an inaccessible location. Please try again.");
                    }

                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered a invalid location ID. Please try again.");
                }
                
            }

            return locationId;
        }

        public void DisplayLocationsVisited()
        {
            //
            //generate a list of locations that have been visited
            //
            List<Location> visitedLocations = new List<Location>();
            foreach (int locationId in _gameColonist.LocationsVisited)
            {
                visitedLocations.Add(_gameUniverse.GetLocationById(locationId));
            }

            DisplayGamePlayScreen("Locations Visited", Text.VisitedLocations(visitedLocations), ActionMenu.ColonistMenu, "");
            GetContinueKey();
        }

        public void DisplayListOfAllGameObjects()
        {
            DisplayGamePlayScreen("List: Game Objects", Text.ListAllGameObjects(_gameUniverse.GameObjects), ActionMenu.AdminMenu, "");
        }

        public int DisplayGetGameObjectsToLookAt()
        {
            int gameObjectId = 0;
            bool validGameObjectId = false;

            //
            // get a list of game objects in the current location
            //
            List<GameObject> gameObjectsInLocation = _gameUniverse.GetGameObjectByLocationId(_gameColonist.LocationID);

            if (gameObjectsInLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at an Object", Text.ListAllGameObjects(gameObjectsInLocation), ActionMenu.ObjectInteractionMenu, "");

                while (!validGameObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out gameObjectId);

                    //
                    // validate integer as valid object id in current location
                    //
                    if (_gameUniverse.IsValidGameObjectByLocationId(gameObjectId, _gameColonist.LocationID))
                    {
                        validGameObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered a invalid game object ID. Please try again.");
                    }
                 
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at an Object", "It appears there are no game objects here.", ActionMenu.ObjectInteractionMenu, "");
            }

            return gameObjectId;
        }

        /// <summary>
        /// display all relevant information about a game object
        /// </summary>
        /// <param name="gameObject"></param>
        public void DisplayGameObjectInfo(GameObject gameObject)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(gameObject), ActionMenu.ObjectInteractionMenu, "");
        }

		public void DisplayInventory()
		{
			DisplayGamePlayScreen("Current Inventory", Text.CurrentInventory(_gameColonist.Inventory), ActionMenu.ColonistMenu, "");
		}

		/// <summary>
		/// display the information required for the player to choose an object to pick up
		/// </summary>
		/// <returns>game object Id</returns>
		public int DisplayGetColonistObjectToPickUp()
		{
			int gameObjectId = 0;
			bool validGameObjectId = false;

			//
			// get a list of colonist objects in the current location
			//
			List<ColonistObject> colonistObjectsInLocation = _gameUniverse.GetColonistObjectsByLocationId(_gameColonist.LocationID);

			if (colonistObjectsInLocation.Count > 0)
			{
				DisplayGamePlayScreen("Pick Up Game Object", Text.GameObjectsChooseList(colonistObjectsInLocation), ActionMenu.ObjectInteractionMenu, "");

				while (!validGameObjectId)
				{
					//
					// get an integer from the player
					//
					GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out gameObjectId);

					//
					// validate integer as a valid game object id and in current location
					//
					if (_gameUniverse.IsValidColonistObjectByLocationId(gameObjectId, _gameColonist.LocationID))
					{
						ColonistObject travelerObject = _gameUniverse.GetGameObjectById(gameObjectId) as ColonistObject;
						if (travelerObject.CanInventory)
						{
							validGameObjectId = true;
						}
						else
						{
							ClearInputBox();
							DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
						}
					}
					else
					{
						ClearInputBox();
						DisplayInputErrorMessage("It appears you entered an invalid game object id. Please try again.");
					}
				}
			}
			else
			{
				DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no game objects here.", ActionMenu.ObjectInteractionMenu, "");
			}

			return gameObjectId;
		}

		public void DisplayConfirmColonistObjectAddedToInventory(ColonistObject objectAddedToInventory)
		{
			DisplayGamePlayScreen("Pick Up Game Object", $"The {objectAddedToInventory.Name} has been added to your inventory. Press any key to continue.", ActionMenu.ObjectInteractionMenu, "");
		}

		/// <summary>
		/// display the information required for the player to choose an object to put down
		/// </summary>
		/// <returns>game object Id</returns>
		public int DisplayGetInventoryObjectToPutDown()
		{
			int colonistObjectId = 0;
			bool validInventoryObjectId = false;

			if (_gameColonist.Inventory.Count > 0)
			{
				DisplayGamePlayScreen("Put Down Game Object", Text.GameObjectsChooseList(_gameColonist.Inventory), ActionMenu.ObjectInteractionMenu, "");

				while (!validInventoryObjectId)
				{
					//
					// get an integer from the player
					//
					GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 0, out colonistObjectId);

					//
					// find object in inventory
					// note: LINQ used, but a foreach loop may also be used 
					//
					ColonistObject objectToPutDown = _gameColonist.Inventory.FirstOrDefault(o => o.Id == colonistObjectId);

					//
					// validate object in inventory
					//
					if (objectToPutDown != null)
					{
						validInventoryObjectId = true;
					}
					else
					{
						ClearInputBox();
						DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
					}
				}
			}
			else
			{
				DisplayGamePlayScreen("Put Down Game Object", "It appears there are no objects currently in inventory.", ActionMenu.ObjectInteractionMenu, "");
			}

			return colonistObjectId;
		}

		/// <summary>
		/// confirm object removed from inventory
		/// </summary>
		/// <param name="objectRemovedFromInventory">game object</param>
		public void DisplayConfirmColonistObjectRemovedFromInventory(ColonistObject objectRemovedFromInventory)
		{
			DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromInventory.Name} has been removed from your inventory. Press any key to continue.", ActionMenu.ObjectInteractionMenu, "");
		}

        public void DisplayListOfAllNpcObjects()
        {
            DisplayGamePlayScreen("List: NPC Objects", Text.ListAllNpcObjects(_gameUniverse.Npcs), ActionMenu.AdminMenu, "");
        }



		#endregion
	}
}
