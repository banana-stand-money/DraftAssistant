using DraftAssistant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftAssistant.Core
{
    public static class PlayerAggregator
    {
        public static IEnumerable<Player> AggregatePitchers(IEnumerable<PlayerADP> adps, IEnumerable<PitcherProjection> pitcherInfos)
        { 
            return adps.Where(a => a.Positions.Contains("P"))
                .Join(pitcherInfos,
                a => a.Name.ToLower(),
                p => p.Name.ToLower(),
                (a, p) => new Player(a,p)
                ).ToList();
        }

        public static IEnumerable<Player> AggregateHitters(IEnumerable<PlayerADP> adps, IEnumerable<HitterProjection> hitterProj)
        {
            return adps.Where(a => !a.Positions.Contains("P"))
                .Join(hitterProj,
                a => a.Name.ToLower(),
                p => p.Name.ToLower(),
                (a, p) => new Player(a, p)
                ).ToList();
        }
    }
}
