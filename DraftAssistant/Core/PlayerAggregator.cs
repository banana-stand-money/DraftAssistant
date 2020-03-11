using DraftAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Core
{
    public static class PlayerAggregator
    {
        public static IEnumerable<Player> AggregatePitchers(IEnumerable<PlayerADP> adps,
            IEnumerable<PitcherProjection> pitcherInfos, IEnumerable<PlayerDynastyRank> ranks)
        {
            return adps.Where(a => a.Positions.Contains("P"))
                .Join(pitcherInfos,
                a => a.Name.ToLower(),
                p => p.Name.ToLower(),
                (a, p) => new { a, p }
                ).Join(ranks.Where(r => (r.Position.Contains("P") || r.Position.Contains("CL") || r.Position.Contains("SU"))),
                p => p.a.Name.ToLower(),
                r => r.Name.ToLower(),
                (p, r) => new Player(p.a, p.p,r)
                ).ToList();

            /*  
            var pitchers =  adps.Where(a => a.Positions.Contains("P"))
                .Join(pitcherInfos,
                a => a.Name.ToLower(),
                p => p.Name.ToLower(),
                (a, p) => new Player(a,p)
                ).ToList();

            return pitchers.Join(ranks,
                p => p.ADPInfo.Name.ToLower(),
                r => r.Name.ToLower(),
                (p, r) => 
                */


        }

        public static IEnumerable<Player> AggregateHitters(IEnumerable<PlayerADP> adps,
            IEnumerable<HitterProjection> hitterProj,
            IEnumerable<PlayerDynastyRank> ranks)
        {
            return adps.Where(a => !a.Positions.Contains("P"))
                .Join(hitterProj,
                a => a.Name.ToLower(),
                p => p.Name.ToLower(),
                (a, p) => new { a, p }
                ).Join(ranks.Where(r => (!r.Position.Contains("P") && !r.Position.Contains("CL") && !r.Position.Contains("SU"))),
                p => p.a.Name.ToLower(),
                r => r.Name.ToLower(),
                (p, r) => new Player(p.a, p.p, r)
                ).ToList();
        }
    }
}
