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
            //_gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(1, _gameUniverse), ActionMenu.MainMenu, "");
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
                        Colonist playerEdit = new Colonist();
                        playerEdit = _gameConsoleView.DisplayEditColonistInfo(_gameConsoleView);

                        _gameColonist.Name = playerEdit.Name;
                        _gameColonist.IsMeleeColonist = playerEdit.IsMeleeColonist;
                        _gameColonist.Age = playerEdit.Age;
                        _gameColonist.Strength = playerEdit.Strength;
                        _gameColonist.Constitution = playerEdit.Constitution;
                        _gameColonist.Magic = playerEdit.Magic;
                        _gameColonist.Agility = playerEdit.Agility;
                        _gameColonist.WeaponName = playerEdit.WeaponName;
                        break;
                    case ColonistAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case ColonistAction.ListLocations:
                        _gameConsoleView.DisplayListOfLocations();
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
            
            
        }

        #endregion
    }
}
