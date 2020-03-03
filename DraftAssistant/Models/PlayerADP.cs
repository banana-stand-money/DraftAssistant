using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Models
{
    public class PlayerADP
    {
        public string Name { get; set; }
        public string Team { get; set; }

        public List<string> Positions { get; set; }

        public double ADP { get; set; }
            public int MinPick { get; set; }

        public int MaxPick { get; set; }
    }
}
