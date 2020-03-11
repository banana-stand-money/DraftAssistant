using DraftAssistant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Core
{
    public static class DepthChartsParser
    {
        //Name	Team	G	PA	AB[4]	H	2B	3B	HR	R[9]	RBI	BB	SO	HBP	SB[14]	CS	AVG	OBP	SLG	OPS[19]	wOBA	Fld	BsR	WAR	playerid[24]
        public static IEnumerable<HitterProjection> ParseHitterCsv(string file)
        {
            var projs = new List<HitterProjection>();
            using (StreamReader sr = new StreamReader(file))
            {
                //skip headers
                sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine().Replace("\"",String.Empty) ;
                    var flds = line.Split(',');
                    projs.Add(new HitterProjection
                    {
                        Average = double.Parse(flds[16]),
                        OBP = double.Parse(flds[17]),
                        SLG = double.Parse(flds[18]),
                        Games = int.Parse(flds[2]),
                        HomeRuns = int.Parse(flds[8]),
                        Name = flds[0],
                        PlateAppearances = int.Parse(flds[4]),
                        RBIs = int.Parse(flds[10]),
                        Runs = int.Parse(flds[9]),
                        StolenBases = int.Parse(flds[14]),
                        Strikeouts = int.Parse(flds[12]),
                        Team = flds[1]
                    });
                }
                return projs;
            }
        }

        //Name	Team	W	L	SV[4]	HLD	ERA	GS	G	IP[9]	H	ER	HR	SO	BB[14]	WHIP	K/9	BB/9	FIP	WAR[19]	playerid
        public static IEnumerable<PitcherProjection> ParsePitcherCsv(string file)
        {
            var projs = new List<PitcherProjection>();
            using (StreamReader sr = new StreamReader(file))
            {
                //skip headers
                sr.ReadLine();
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine().Replace("\"", String.Empty);
                    var flds = line.Split(',');
                    projs.Add(new PitcherProjection
                    {
                        ERA = double.Parse(flds[6]),
                        FIP = double.Parse(flds[18]),
                        BBper9 = double.Parse(flds[17]),
                        Kper9 = double.Parse(flds[16]),
                        WHIP = double.Parse(flds[15]),
                        IP = double.Parse(flds[9]),
                        Win = int.Parse(flds[2]),
                        Name = flds[0],
                        Hold = int.Parse(flds[5]),
                        Save = int.Parse(flds[4]),
                        Team = flds[1]
                    });
                }
                return projs;
            }
        }
    }
}
