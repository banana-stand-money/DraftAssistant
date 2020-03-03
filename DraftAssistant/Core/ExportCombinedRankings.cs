using DraftAssistant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Core
{
    public static class ExportCombinedRankings
    {
        public static void ExportToCsv(string path, IEnumerable<Player> players)
        {
            using (var sw = new StreamWriter(path))
            {
                foreach (var player in players.OrderBy(p => p.ADPInfo.ADP))
                {
                    sw.WriteLine(player);
                }
            }
        }
    }
}
