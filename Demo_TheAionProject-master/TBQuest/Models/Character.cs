﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human
        }

        #endregion

        #region FIELDS

        private string _name;
        protected int _locationID;
        private int _age;
        private RaceType _race;
        private bool _isAlive = true;
        

        



        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        
        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }
        

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int locationID)
        {
            _name = name;
            _race = race;
            _locationID = locationID;
        }

        #endregion

        #region METHODS



        #endregion
    }
}
