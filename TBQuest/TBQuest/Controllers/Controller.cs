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

			//
			// add initial items to the player's inventory
			//
			_gameColonist.Inventory.Add(_gameUniverse.GetGameObjectById(2) as ColonistObject);
            

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
				//
				// get next game action from player
				//
				if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
				{
					travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
				}
				else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
				{
					travelerActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
				}
				
                
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
						_gameConsoleView.GetContinueKey();
                        break;
                    case ColonistAction.LookAt:
                        LookAtAction();
						_gameConsoleView.GetContinueKey();
                        break;
                    case ColonistAction.AdminMenu:
						AdminMenu();
						break;
					case ColonistAction.ColonistInventory:
						_gameConsoleView.DisplayInventory();
						_gameConsoleView.GetContinueKey();
						break;
					case ColonistAction.ObjectInteractionMenu:
						ObjectInteractionMenu();
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
				
            }

        }

		/// <summary>
		/// process the Pick Up action
		/// </summary>
		private void PickUpAction()
		{
			//
			// display a list of colonist objects in the location and get a player choice
			//
			int colonistObjectToPickUpId = _gameConsoleView.DisplayGetColonistObjectToPickUp();

			//
			// add the object to inventory
			//
			if (colonistObjectToPickUpId != 0)
			{
				//
				// get the game object from the universe
				//
				ColonistObject colonistObject = _gameUniverse.GetGameObjectById(colonistObjectToPickUpId) as ColonistObject;

				//
				// note:object is added to list and the location is set to 0
				//
				_gameColonist.Inventory.Add(colonistObject);
				colonistObject.LocationId = 0;

				//
				// display confirmation message
				//
				_gameConsoleView.DisplayConfirmColonistObjectAddedToInventory(colonistObject);
			}
		}
		/// <summary>
		/// processes the admin menu choices
		/// </summary>
		private void AdminMenu()
		{
			bool inAdminMenu = true;
			ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
			ColonistAction adminMenuChoice = ColonistAction.None;
			while (inAdminMenu)
			{
				_gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
				adminMenuChoice = _gameConsoleView.GetAdminMenuChoice(ActionMenu.AdminMenu);
				switch (adminMenuChoice)
				{
					case ColonistAction.None:
						break;
					case ColonistAction.ListLocations:
						_gameConsoleView.DisplayListOfLocations();
						break;
					case ColonistAction.ListGameObjects:
						_gameConsoleView.DisplayListOfAllGameObjects();
						_gameConsoleView.GetContinueKey();
						break;
					case ColonistAction.ReturnToMainMenu:
						ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
						inAdminMenu = false;
						break;
				}
			}
		}
		/// <summary>
		/// handles object interaction menu choices
		/// </summary>
		private void ObjectInteractionMenu()
		{
			bool inObjectMenu = true;
			ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectInteractionMenu;
			ColonistAction objectMenuChoice = ColonistAction.None;
			while (inObjectMenu)
			{
				_gameConsoleView.DisplayGamePlayScreen("Object Interaction Menu", "Select an operation from the menu.", ActionMenu.ObjectInteractionMenu, "");
				objectMenuChoice = _gameConsoleView.GetObjectMenuChoice(ActionMenu.ObjectInteractionMenu);
				switch (objectMenuChoice)
				{
					case ColonistAction.None:
						break;
					case ColonistAction.PickUp:
						PickUpAction();
						_gameConsoleView.GetContinueKey();
						break;
					case ColonistAction.PutDown:
						PutDownAction();
						_gameConsoleView.GetContinueKey();
						break;
					case ColonistAction.ReturnToMainMenu:
						ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
						inObjectMenu = false;
						break;
				}
			}
		}

		/// <summary>
		/// process the Put Down action
		/// </summary>
		private void PutDownAction()
		{
			//
			// display a list of traveler objects in inventory and get a player choice
			//
			int inventoryObjectToPutDownId = _gameConsoleView.DisplayGetInventoryObjectToPutDown();

			//
			// get the game object from the universe
			//
			ColonistObject colonistObject = _gameUniverse.GetGameObjectById(inventoryObjectToPutDownId) as ColonistObject;

			//
			// remove the object from inventory and set the space-time location to the current value
			//
			_gameColonist.Inventory.Remove(colonistObject);
			colonistObject.LocationId = _gameColonist.LocationID;

			//
			// display confirmation message
			//
			_gameConsoleView.DisplayConfirmColonistObjectRemovedFromInventory(colonistObject);

		}

		#endregion
	}
}
