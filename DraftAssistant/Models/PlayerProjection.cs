using System.Collections.Generic;

namespace DraftAssistant.Models
{
    public class PlayerProjection
    {
        private Dictionary<string, string> _normalizeNames = new Dictionary<string, string>()
        {
            {"Peter", "Pete" },
            {"Nicholas", "Nick" },
            {"Giovanny", "Gio" },
            {"Joshua", "Josh" }
            //{"Jr.", "Jr"} TODO why didn't this work
        };

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                foreach (var item in _normalizeNames)
                {
                    if (value.Contains(item.Key))
                    {
                        _name = value.Replace(item.Key, item.Value);
                    }
                }
            }
        }
        public string Team { get; set; }
    }
}