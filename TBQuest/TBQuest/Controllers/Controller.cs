using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Colonist _gameColonist;
        private bool _playingGame;
        private Universe _gameUniverse;
        private Location _currentLocation;

        
        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameColonist = new Colonist();
            _gameUniverse = new Universe();
            _gameConsoleView = new ConsoleView(_gameColonist, _gameUniverse);
            _playingGame = true;
            

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            ColonistAction travelerActionChoice = ColonistAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            //prepare game play screen
            //
            _currentLocation = _gameUniverse.GetLocationById(_gameColonist.LocationID);
            
            

            //
            // game loop
            //
            while (_playingGame)
            {
                //
                //process all flags, updates, and stats
                //
                UpdateGameStatus();

                _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_gameColonist.LocationID, _gameUniverse), ActionMenu.MainMenu, "");
                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                
                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case ColonistAction.None:
                        break;

                    case ColonistAction.ColonistInfo:
                        _gameConsoleView.DisplayColonistInfo();
                        break;
                    case ColonistAction.EditColonistInfo:
                        EditColonistInfo();
                        break;

                    case ColonistAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case ColonistAction.ListLocations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;
                    case ColonistAction.Travel:
                        //
                        //get new location choice and update the current location property
                        //
                        _gameColonist.LocationID = _gameConsoleView.DisplayGetNextLocation();
                        _currentLocation = _gameUniverse.GetLocationById(_gameColonist.LocationID);

                        //
                        //set the game play screen to the current location info format
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;
                    case ColonistAction.ColonistLocationsVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;
                    case ColonistAction.ListGameObjects:
                        _gameConsoleView.DisplayListOfAllGameObjects();
                        break;
                    case ColonistAction.LookAt:
                        LookAtAction();
                        break;
                    case ColonistAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;
                    case ColonistAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;
                    
                    case ColonistAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }

                
            }

            //
            // close the application
            //
            Environment.Exit(42);
        }

        private void InitializeMission()
        {
            Colonist playerResponse = new Colonist();
            playerResponse = _gameConsoleView.DisplayGetColonistInfo(_gameConsoleView);

            _gameColonist.Name = playerResponse.Name;
            _gameColonist.IsMeleeColonist = playerResponse.IsMeleeColonist;
            _gameColonist.Age = playerResponse.Age;
            _gameColonist.Strength = playerResponse.Strength;
            _gameColonist.Constitution = playerResponse.Constitution;
            _gameColonist.Magic = playerResponse.Magic;
            _gameColonist.Agility = playerResponse.Agility;
            _gameColonist.WeaponName = playerResponse.WeaponName;
            _gameColonist.LocationID = 1;

            _gameColonist.ExperiencePoints = 0;
            _gameColonist.Health = 100;
            _gameColonist.Lives = 3;
            
                      
        }



        private void UpdateGameStatus()
        {
            if (!_gameColonist.HasVisited(_currentLocation.LocationID))
            {
                //
                //add new location to list of visited locations if this is a first visit
                //
                _gameColonist.LocationsVisited.Add(_currentLocation.LocationID);

                //
                //update experience points for visiting locations
                //
                _gameColonist.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        private void EditColonistInfo()
        {
            Colonist playerEdit = new Colonist();
            playerEdit = _gameConsoleView.DisplayEditColonistInfo(_gameConsoleView);

            if (playerEdit.Name != "")
            {
                _gameColonist.Name = playerEdit.Name;
            }
            if (playerEdit.Age != 0)
            {
                _gameColonist.Age = playerEdit.Age;
            }
            if (playerEdit.Strength != 0)
            {
                _gameColonist.Strength = playerEdit.Strength;
            }
            if (playerEdit.Strength >= 4)
            {
                _gameColonist.IsMeleeColonist = true;
            }
            else if (playerEdit.Strength > 0 && playerEdit.Strength < 4)
            {
                _gameColonist.IsMeleeColonist = false;
            }

            if (playerEdit.Constitution != 0)
            {
                _gameColonist.Constitution = playerEdit.Constitution;
            }
            if (playerEdit.Magic != 0)
            {
                _gameColonist.Magic = playerEdit.Magic;
            }
            if (playerEdit.Agility != 0)
            {
                _gameColonist.Agility = playerEdit.Agility;
            }
            if (playerEdit.WeaponName != "")
            {
                _gameColonist.WeaponName = playerEdit.WeaponName;
            }

        }

        private void LookAtAction()
        {
            //
            // display a list of traveler objects in location and get a player choice
            //
            int gameObjectToLookAtId = _gameConsoleView.DisplayGetGameObjectsToLookAt();

            //
            // display game object info
            //
            if (gameObjectToLookAtId != 0)
            {
                //
                // get the game object from the universe
                //
                GameObject gameObject = _gameUniverse.GetGameObjectById(gameObjectToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(gameObject);
                _gameConsoleView.GetContinueKey();
            }

        }
        

        #endregion
    }
}
