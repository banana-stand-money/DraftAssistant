using DraftAssistant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Core
{
    public static class NFBCParser
    {
        public static IEnumerable<PlayerADP> ParseADP(string file)
        {
            var adps = new List<PlayerADP>();
            using (StreamReader sr = new StreamReader(file))
            {
                //skip headers
                sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    var flds = line.Split('\t');
                    //Rank	Player	Team	Position(s)	ADP[4]	Min Pick	Max Pick	Difference	# Picks	Team[9]	Team Pick
                    var name = flds[1].Split(',');
                    adps.Add(new PlayerADP
                    {
                        ADP = double.Parse(flds[4]),
                        MinPick = int.Parse(flds[5]),
                        MaxPick = int.Parse(flds[6]),
                        Name = $"{name[1].Trim()} {name[0].Trim()}",
                        Team = flds[2],
                        Positions = flds[3].Split(',').ToList()
                    });
                }
                return adps;
            }
        }
    }
}
