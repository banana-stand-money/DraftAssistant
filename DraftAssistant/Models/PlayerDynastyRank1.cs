using DraftAssistant.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Models
{
    public class PlayerDynastyRank
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = NormalizationUtils.NormalizeName(value);
            }
        }
        public string League { get; set; }
        public double Age { get; set; }
        public int Rank { get; set; }
        public string Blurb { get; set; }
        public string ETA { get; set; }
        public string Position { get; set; }
    }
}
