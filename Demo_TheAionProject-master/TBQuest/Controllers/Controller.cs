﻿using System;
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
            _gameConsoleView = new ConsoleView(_gameColonist);
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
            // game loop
            //
            while (_playingGame)
            {
                _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(), ActionMenu.MainMenu, "");
                travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case ColonistAction.None:
                        break;

                    case ColonistAction.ColonistInfo:
                        _gameConsoleView.DisplayTravelerInfo();
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
            playerResponse = _gameConsoleView.DisplayGetTravelerInfo(_gameConsoleView);

            _gameColonist.Name = playerResponse.Name;
            _gameColonist.Age = playerResponse.Age;
            _gameColonist.Race = playerResponse.Race;
            
            
        }

        #endregion
    }
}
