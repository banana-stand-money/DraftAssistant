using DraftAssistant.Core;
using System.Collections.Generic;

namespace DraftAssistant.Models
{
    public class PlayerProjection
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = NormalizationUtils.NormalizeName( value);
            }
        }
        public string Team { get; set; }
    }
}