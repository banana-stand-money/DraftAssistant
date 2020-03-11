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
                sw.WriteLine("Name,Pos,Team,ADP,Range,DyRank,Age,ETA,PA|IP,AVG|W,R|ERA,HR|WHIP,RBI|K/9,SB|BB/9,SO|SV,OBP|HLD,FIP|SLG"); ;
                foreach (var player in players.OrderBy(p => p.ADPInfo.ADP))
                {
                    sw.WriteLine(player);
                }
            }
        }
    }
}
