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
        #endregion

        #region PROPERTIES
        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }

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
        #endregion
    }
}
