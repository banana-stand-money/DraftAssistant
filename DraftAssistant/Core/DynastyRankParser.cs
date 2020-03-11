using DraftAssistant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Core
{
    public static class DynastyRankParser
    {

        //RANK	PLAYER	TEAM	LEAGUE	POS	CAT	AGE	BLURB	ETA
        public static IEnumerable<PlayerDynastyRank> ParseDynastyCsv(string file)
        {
            var projs = new List<PlayerDynastyRank>();
            using (StreamReader sr = new StreamReader(file))
            {
                //skip headers
                sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine().Replace("\"", String.Empty);
                    var flds = line.Split(",");
                    projs.Add(new PlayerDynastyRank
                    {
                        Age = double.Parse(flds[6]),
                        Rank = int.Parse(flds[0]),
                        ETA = flds[8],
                        Blurb = flds[7],
                        Name = flds[1].Trim(),
                        League = flds[3],
                        Position = flds[4]
                    });
                }
                return projs;
            }
        }
    }
}
