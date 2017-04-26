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
    }
}
