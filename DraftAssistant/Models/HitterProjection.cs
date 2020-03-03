using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Models
{
    public class HitterProjection : IProjection
    {
        public string Name { get; set; }
        public string Team { get; set; }
        public int Games { get; set; }
        public int PlateAppearances { get; set; }
        public int Runs { get; set; }
        public int RBIs { get; set; }
        public int HomeRuns { get; set; }
        public int StolenBases { get; set; }
        public int Strikeouts { get; set; }
        public double Average { get; set; }
    }
}
