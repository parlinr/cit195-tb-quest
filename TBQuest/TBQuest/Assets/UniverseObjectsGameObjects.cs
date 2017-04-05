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
                Name = "Health Potion",
                Description = "A potion that restores X health.",
                Type = ColonistObjectType.Medicine,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            }
        };
        
    }
}
