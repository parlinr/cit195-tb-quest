using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static partial class UniverseObjects
    {
		//TODO: make more objects
		public static List<GameObject> gameObjects = new List<GameObject>()
		{
			new ColonistObject
			{
				Id = 1,
				Name = "Steel Sword,",
				Description = "A steel sword. It will likely be effective against lower level monsters.",
				Type = ColonistObjectType.Weapon,
				Value = 75,
				CanInventory = true,
				IsConsumable = false,
				IsVisible = true,
				LocationId = 4,
				CanEquip = true
            },

			new ColonistObject
			{
				Id = 2,
				Name = "Rusty Dagger",
				Description = "A rusty dagger. It probably will not be very effective in combat.",
				Type = ColonistObjectType.Weapon,
				Value = 10.5,
				CanInventory = true,
				IsConsumable = false,
				IsVisible = true,
				LocationId = 0,
				CanEquip = true
			},

			new ColonistObject
			{
				Id=3,
				Name = "Secret Box",
				Description = "A secret box.",
				Type = ColonistObjectType.Treasure,
				Value = 25.5,
				CanInventory = true,
				IsConsumable = false,
				IsVisible = true,
				LocationId = 1,
				CanEquip = false
			},

			new ColonistObject
			{
				Id = 4,
				Name = "Hastily Scrawled Note",
				Description = "A hastily scrawled note. It says, 'You should try searching Brypso first. There are some "
					+ "formidable monsters on Phobos and Duskore.'",
				Type = ColonistObjectType.Information,
				Value = 0,
				CanInventory = true,
				IsConsumable = false,
				IsVisible = true,
				LocationId = 2,
				CanEquip = false
		
			},

			new ColonistObject
			{
				Id = 5,
				Name = "Sack of electrum pieces",
				Description = "A sack of electrum (gold and silver mix) pieces.",
				Type = ColonistObjectType.Treasure,
				Value = 200,
				CanInventory = true,
				IsConsumable = false,
				IsVisible = true,
				LocationId = 8,
				CanEquip = false
			},

			new ColonistObject
			{
				Id = 6,
				Name = "Adamantine Sword",
				Description = "An adamantine sword. It looks like it could stand up to higher level monsters.",
				Type = ColonistObjectType.Weapon,
				Value = 300,
				CanInventory = true,
				IsConsumable = false,
				IsVisible = true,
				LocationId = 6,
				CanEquip = true
			},

			new ColonistObject
			{
				Id = 7,
				Name = "Mithril Sword",
				Description = "A mithril sword. It appears like it could stand up to medium level monsters.",
				Type = ColonistObjectType.Weapon,
				Value = 150,
				CanInventory = true,
				IsConsumable = false,
				IsVisible = true,
				LocationId = 5,
				CanEquip = true
			}





        };
        
    }
}
