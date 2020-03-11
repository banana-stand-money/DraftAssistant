using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Core
{
    public static class NormalizationUtils
    {
        public static readonly Dictionary<string, string> _normalizeNames = new Dictionary<string, string>()
        {
            {"Peter", "Pete" },
            {"Nicholas", "Nick" },
            {"Giovanny", "Gio" },
            {"Joshua", "Josh" },
            {"J.D.","JD" },
            {"Acuna Jr.", "Acuna" }
            //{"Jr.", "Jr"} TODO why didn't this work
        };

        public static string NormalizeName(string orig)
        {
            var normalized = orig;
            foreach (var item in _normalizeNames)
            {
                if (orig.Contains(item.Key))
                {
                    normalized = orig.Replace(item.Key, item.Value);
                }
            }
            return normalized.Replace(",",String.Empty).Trim();
        }

    }
}
