using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAionProject
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Traveler : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS
        bool _isCool = true;
        int _currency = 0;
        string _surname = "";

        #endregion


        #region PROPERTIES
        public bool IsCool
        { get { return _isCool; } }

        public int Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Traveler()
        {

        }

        public Traveler(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {

        }

        #endregion


        #region METHODS
        

        #endregion
    }
}
