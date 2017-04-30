using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// game area class
    /// </summary>
    public class Universe
    {
        #region FIELDS
        private List<Location> _locations;
        private List<GameObject> _gameObjects;
        private List<Npc> _npcs;
        private List<Monster> _monsters;
        #endregion

        #region PROPERTIES
        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }

        }
        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
            set { _gameObjects = value; }
        }

        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }
        public List<Monster> Monsters
        {
            get { return _monsters; }
            set { _monsters = value; }
        }



        #endregion


        #region Constructor
        //default constructor
        public Universe()
        {
            //add universe objects to game
            InitializeUniverse();
        }
        #endregion

        #region Methods
        private void InitializeUniverse()
        {
            _locations = UniverseObjects.Locations;
            _gameObjects = UniverseObjects.gameObjects;
            _npcs = UniverseObjects.Npcs;
            _monsters = UniverseObjects.Monsters;


        }

        public Location GetLocationById(int LocationID)
        {
            Location returnLocation = null;

            //
            //iterate through list and get correct one
            //
            foreach (Location location in _locations)
            {
                if (location.LocationID == LocationID)
                {
                    returnLocation = location;
                }
            }

            //
            //the specified Id was not found
            //throw an exception
            //
            if (returnLocation == null)
            {
                string feedbackMessage = $"The Location ID {LocationID} does not exist in the " +
                    "current game universe.";
                throw new ArgumentException(LocationID.ToString(), feedbackMessage);
            }

            return returnLocation;
        }

        public bool IsValidLocationId(int locationId)
        {
            List<int> locationIds = new List<int>();

            //
            //create list of location ids
            //
            foreach (Location location in _locations)
            {
                locationIds.Add(location.LocationID);
            }

            //
            //determine if the location id is a valid id and return
            //the result
            //
            if (locationIds.Contains(locationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAccessibleLocation(int locationId, int currentLocationId)
        {
            Location location = GetLocationById(locationId);
            if (location.AccessibleLocations.Contains(currentLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetMaxLocationId()
        {
            int maxId = 0;

            foreach (Location location in Locations)
            {
                if (location.LocationID > maxId)
                {
                    maxId = location.LocationID;
                }
            }

            return maxId;
        }
        
        public bool IsValidGameObjectByLocationId(int gameObjectId, int currentLocation)
        {
            List<int> gameObjectIds = new List<int>();

            //
            // create list of game object ids in current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == currentLocation)
                {
                    gameObjectIds.Add(gameObject.Id);
                }
            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (gameObjectIds.Contains(gameObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public GameObject GetGameObjectById(int Id)
        {
            GameObject gameObjectToReturn = null;

            //
            // run through the game object list and get the right one
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == Id)
                {
                    gameObjectToReturn = gameObject;
                }
            }

            //
            // if specified id not found, throw an exception
            //
            if (gameObjectToReturn == null)
            {
                string feedback = $"The game object ID {Id} does not exist in the"
                    + "current game universe.";
                throw new ArgumentException(Id.ToString(), feedback);
            }

            return gameObjectToReturn;

        }

        public List<GameObject> GetGameObjectByLocationId(int locationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            //
            // loop though the list and get all objects in current location
            //
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == locationId)
                {
                    gameObjects.Add(gameObject);
                }

            }

            return gameObjects;
        }

		/// <summary>
		/// validate colonist object id number in current location
		/// </summary>
		/// <param name="colonistObjectId"></param>
		/// <returns>is Id valid</returns>
		public bool IsValidColonistObjectByLocationId(int colonistObjectId, int currentLocation)
		{
			List<int> colonistObjectIds = new List<int>();

			//
			// create a list of traveler object ids in current space-time location
			//
			foreach (GameObject gameObject in _gameObjects)
			{
				if (gameObject.LocationId == currentLocation && gameObject is ColonistObject)
				{
					colonistObjectIds.Add(gameObject.Id);
				}

			}

			//
			// determine if the game object id is a valid id and return the result
			//
			if (colonistObjectIds.Contains(colonistObjectId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// get all colonist objects in a location
		/// </summary>
		/// <param name="locationId">space-time location id</param>
		/// <returns>list of traveler objects</returns>
		public List<ColonistObject> GetColonistObjectsByLocationId(int locationId)
		{
			List<ColonistObject> colonistObjects = new List<ColonistObject>();

			//
			// run through the game object list and grab all that are in the current space-time location
			//
			foreach (GameObject gameObject in _gameObjects)
			{
				if (gameObject.LocationId ==  locationId && gameObject is ColonistObject)
				{
					colonistObjects.Add(gameObject as ColonistObject);
				}
			}

			return colonistObjects;
		}

        public bool IsValidNpcByLocationId(int npcId, int currentLocation)
        {
            List<int> npcIds = new List<int>();

            //
            // create a list of NPC Ids in current location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.LocationID == currentLocation)
                {
                    npcIds.Add(npc.Id);
                }
            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (npcIds.Contains(npcId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Npc GetNpcById(int Id)
        {
            Npc npcToReturn = null;

            //
            // run through the NPC object list and grab the right one
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // the specified Id was not found in the universe
            // throw an exception 
            //
            if (npcToReturn == null)
            {
                string feedbackMessage = $"The NPC ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return npcToReturn;

        }

        public List<Npc> GetNpcByLocationId(int locationId)
        {
            List<Npc> npcs = new List<Npc>();

            //
            // run through the NPC object list and grab all the ones in the current location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.LocationID == locationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }
        
        public List<Monster> GetMonsterByLocationId(int locationId)
        {
            List<Monster> monsters = new List<Monster>();

            //
            // run through the monster object list and grab all the ones in the current location
            //
            foreach (Monster monster in _monsters)
            {
                if (monster.LocationID == locationId && monster.IsAlive == true)
                {
                    monsters.Add(monster);
                }
            }

            return monsters;
        }

        public bool IsValidMonsterByLocationId(int monsterId, int currentLocation)
        {
            List<int> monsterIds = new List<int>();

            //
            // create a list of monster Ids in current location
            //
            foreach (Monster monster in _monsters)
            {
                if (monster.LocationID == currentLocation)
                {
                    monsterIds.Add(monster.Id);
                }
            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (monsterIds.Contains(monsterId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Monster GetMonsterById(int Id)
        {
            Monster monsterToReturn = null;

            //
            // run through the monster object list and grab the right one
            //
            foreach (Monster monster in _monsters)
            {
                if (monster.Id == Id && monster.IsAlive == true)
                {
                    monsterToReturn = monster;
                }
            }

            //
            // the specified Id was not found in the universe
            // throw an exception 
            //
            if (monsterToReturn == null)
            {
                string feedbackMessage = $"The monster ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return monsterToReturn;

        }



        #endregion
    }
}
