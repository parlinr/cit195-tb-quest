using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public static partial class UniverseObjects
    {
        //TODO: Add NPCs
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
				canFight = true
            },
            new Monster
            {
                Id = 3,
                Name = "Chimera",
				LocationID = 7,
                canFight = true,
                Description = "A three-headed beast. If this is the first monster you have "
                                + "encountered, you're not going to make it."
            }


        };
    }
}
