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

        public Location GetLocationByID(int LocationID)
        {
            Location returnLocation = null;
            foreach (Location location in _locations)
            {
                if (location.LocationID == LocationID)
                {
                    returnLocation = location;
                }
            }

            return returnLocation;
        }
        #endregion
    }
}
