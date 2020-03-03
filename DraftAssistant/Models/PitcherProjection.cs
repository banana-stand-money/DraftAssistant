using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Models
{

    public class PitcherProjection : IProjection 
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public int Win { get; set; }
        public int Save { get; set; }
        public int Hold { get; set; }
        public double IP { get; set; }
        public double ERA { get; set; }
        public double WHIP { get; set; }
        public double Kper9 { get; set; }
        public double BBper9 { get; set; }
        public double FIP { get; set; }
    }
}
