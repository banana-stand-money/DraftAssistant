using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Models
{
    public class HitterProjection : PlayerProjection
    {
        public int Games { get; set; }
        public int PlateAppearances { get; set; }
        public int Runs { get; set; }
        public int RBIs { get; set; }
        public int HomeRuns { get; set; }
        public int StolenBases { get; set; }
        public int Strikeouts { get; set; }
        public double Average { get; set; }
        public double OBP { get; set; }
        public double SLG { get; set; }

    }
}
