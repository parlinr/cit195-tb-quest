using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static partial class UniverseObjects
    {
        
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                Id = 1,
                Name = "Adoring Fan",
                LocationID = 1,
                Health = 1,
                canFight = false,
                Description = "An adoring fan. He won't stop following you around.",
                Messages = new List<string>
                {
                        "You're the best!"
                }
            },
			new Civilian
			{
				Id = 2,
				Name = "Doomsayer",
				LocationID = 5,
				Health = 1,
				canFight = false,
				Description = "A strange man who is convinced the end times are here.",
				Messages = new List<string>
				{
					"The end is coming!",
					"I knew it!"
				}
			},
			new Civilian
			{
				Id = 3,
				Name = "Dr. Kleiner",
				LocationID = 2,
				Health = 1,
				canFight = false,
				Description = "A professor of physics from the homeland. We still don't know why he volunteered to come out here.",
				Messages = new List<string>
				{
					"There's a certain mysticism about the frontier, probably associated with the proverbial blank slate it offers.",
					
				}
			}
			
        };

        public static List<Monster> Monsters = new List<Monster>()
        {
            new Monster
            {
                Id = 1,
                Name = "Wyvern",
                LocationID = 8,
                canFight = true,
                Description = "A winged beast, similar to a dragon but not as dangerous. " +
                                "He's still a pretty tough customer.",
                Health = 200,
                Strength = 4,
                Constitution = 3,
                Agility = 3
            },
            new Monster
            {
                Id = 2,
				LocationID = 9,
				canFight = true,
				Name = "Troll",
				Description = "A large humanoid creture. He has quite a menacing club.",
				Health = 300,
				Strength = 8,
				Constitution = 8,
				Agility = 2
            },
            new Monster
            {
                Id = 3,
                Name = "Chimera",
				LocationID = 7,
                canFight = true,
                Description = "A three-headed beast. If this is the first monster you have "
                                + "encountered, you're not going to make it.",
				Strength = 9,
				Constitution = 9,
				Agility = 6
            },
			
        };
    }
}
