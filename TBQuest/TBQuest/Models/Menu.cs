﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuest
{
    public class Menu
    {
        public string MenuName { get; set; }
        public string MenuTitle { get; set; }
        public Dictionary<char, ColonistAction> MenuChoices { get; set; }
        public Dictionary<char, EditColonist> EditColonistMenuChoices { get; set; }

    }
}
