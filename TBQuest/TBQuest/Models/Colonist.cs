using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Colonist : Character
    {
        #region ENUMERABLES
       

        #endregion

        #region FIELDS
        private int _strength = 0;
        private int _constitution = 0;
        private int _magic = 0;
        private int _agility = 0;
        private int _abilityPoints = 0;
        private bool _isBeingChased = false;
        private bool _isMeleeColonist = false;
        private string _weaponName = "";
        private List<int> _locationsVisited;
        private List<Key> _keyring;
        private int _experiencePoints;
        private int _health;
        private int _lives;
		private List<ColonistObject> _inventory;


        #endregion


        #region PROPERTIES
        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public int Constitution
        {
            get { return _constitution; }
            set { _constitution = value; }
        }

        public int Magic
        {
            get { return _magic; }
            set { _magic = value; }
        }

        public int Agility
        {
            get { return _agility; }
            set { _agility = value; }
        }

        public int AbilityPoints
        {
            get { return _abilityPoints; }
            set { _abilityPoints = value; }
        }

        public bool IsBeingChased
        {
            get { return _isBeingChased; }
            set { _isBeingChased = value; }
        }

        public bool IsMeleeColonist
        {
            get { return _isMeleeColonist; }
            set { _isMeleeColonist = value; }
        }

        public string WeaponName
        {
            get { return _weaponName; }
            set { _weaponName = value; }
        }

        public List<int> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public List<Key> Keyring
        {
            get { return _keyring; }
            set { _keyring = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

		public List<ColonistObject> Inventory
		{
			get { return _inventory; }
			set { _inventory = value; }
		}


        #endregion


        #region CONSTRUCTORS

        public Colonist()
        {
            _locationsVisited = new List<int>();
            _keyring = new List<Key>();
			_inventory = new List<ColonistObject>();
        }

        public Colonist(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {
            _locationsVisited = new List<int>();
            _keyring = new List<Key>();
			_inventory = new List<ColonistObject>();
		}

        #endregion


        #region METHODS
        public bool HasVisited(int _locationId)
        {
            if (LocationsVisited.Contains(_locationId))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
