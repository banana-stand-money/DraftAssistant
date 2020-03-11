using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftAssistant.Models
{
    public class Player
    {
        public PlayerADP ADPInfo { get; set; }
        public PlayerProjection ProjectionInfo {get; set;}

        public PlayerDynastyRank DynastyRAnk { get; set; }

        public Player(PlayerADP adp, PlayerProjection proj, PlayerDynastyRank dynastyRAnk)
        {
            ADPInfo = adp;
            ProjectionInfo = proj;
            DynastyRAnk = dynastyRAnk;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(String.Join(',', 
                ADPInfo.Name,
                String.Join('|', ADPInfo.Positions),
                ADPInfo.Team,
                ADPInfo.ADP,
                $"{ADPInfo.MinPick}->{ADPInfo.MaxPick}",
                DynastyRAnk.Rank,
                DynastyRAnk.Age,
                DynastyRAnk.ETA));
            
            sb.Append(",");

            if (ProjectionInfo.GetType().Equals((new HitterProjection()).GetType()))
            {
                var pr = ProjectionInfo as HitterProjection;
                sb.Append(
                    String.Join(',',
                    pr.PlateAppearances,
                    pr.Average,
                    pr.Runs,
                    pr.HomeRuns,
                    pr.RBIs,
                    pr.StolenBases,
                    pr.Strikeouts,
                    pr.OBP,
                    pr.SLG
                    ));
            }
            else
            {
                var pr = ProjectionInfo as PitcherProjection;
                sb.Append(
                    String.Join(',',
                    pr.IP,
                    pr.Win,
                    pr.ERA,
                    pr.WHIP,
                    pr.Kper9,
                    pr.BBper9,
                    pr.Save,
                    pr.Hold,
                    pr.FIP
                    ));
            }
            sb.Append(",");
            sb.Append(DynastyRAnk.Blurb);

            return sb.ToString();
        }
    }

}
