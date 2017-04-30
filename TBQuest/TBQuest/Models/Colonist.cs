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
    public class Colonist : Character, IBattle
    {
        #region ENUMERABLES
       

        #endregion

        #region FIELDS
        private int _magic = 0;
        private int _abilityPoints = 0;
        private bool _isBeingChased = false;
        private bool _isMeleeColonist = false;
        private string _weaponName = "";
        private List<int> _locationsVisited;
        private List<Key> _keyring;
        private double _experiencePoints;
        private int _lives;
		private List<ColonistObject> _inventory;
		private List<ColonistObject> _equippedItems;


        #endregion


        #region PROPERTIES
        /*
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
        */
        public int Magic
        {
            get { return _magic; }
            set { _magic = value; }
        }
        /*

        public int Agility
        {
            get { return _agility; }
            set { _agility = value; }
        }

        */
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

        public double ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        /*
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        */
		public List<ColonistObject> Inventory
		{
			get { return _inventory; }
			set { _inventory = value; }
		}

		public List<ColonistObject> EquippedItems
		{
			get { return _equippedItems; }
			set { _equippedItems = value; }
		}


        #endregion


        #region CONSTRUCTORS

        public Colonist()
        {
            _locationsVisited = new List<int>();
            _keyring = new List<Key>();
			_inventory = new List<ColonistObject>();
			_equippedItems = new List<ColonistObject>();
        }

        public Colonist(string name, RaceType race, int spaceTimeLocationID) : base(name, race, spaceTimeLocationID)
        {
            _locationsVisited = new List<int>();
            _keyring = new List<Key>();
			_inventory = new List<ColonistObject>();
			_equippedItems = new List<ColonistObject>();
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

		public int Attack()
		{
			int attackScore = this.Agility + this.Constitution + this.Strength;
			//
			// if the player has a certain weapon equipped, they get an attackScore buff
			// implementation from: http://stackoverflow.com/questions/4937060/how-to-check-if-listt-element-contains-an-item-with-a-particular-property-valu
			//
			ColonistObject equippedWeapon = _equippedItems.Find(x => (x.Id == 1) || (x.Id == 6) || (x.Id == 7));
			try
			{
				if (equippedWeapon.Id == 1) // if steel sword is equipped
				{
					attackScore += 3;
				}
				else if (equippedWeapon.Id == 7) // if mithril sword is equipped
				{
					attackScore += 5;
				}
				else if (equippedWeapon.Id == 6) // if adamantine sword is equipped
				{
					attackScore += 7;
				}
				else
				{
					attackScore += 0;
				}
			}
			catch (Exception e)
			{

			}
			

			return attackScore;
		}

        #endregion
    }
}
