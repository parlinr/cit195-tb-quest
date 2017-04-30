using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public class Monster : Npc, ISpeak, IBattle
    {
        public override int Id { get; set; }
        public override string Description { get; set; }

        public override bool canFight { get; set; }

        public List<string> Messages { get; set; }
        
        public string Speak()
        {
            return "Roar! (This NPC may be attacked.)";
        } 
        
    }
}
