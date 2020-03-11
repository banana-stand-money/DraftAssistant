using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraftAssistant.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DraftAssistant.Models;

namespace DraftAssistant.Core.Tests
{
    [TestClass()]
    public class PlayerAggregatorTests
    {
        private IEnumerable<PlayerADP> playerADPs;
        private IEnumerable<PlayerDynastyRank> dynastyRanks;

        [TestInitialize]
        public void Setup()
        {
            playerADPs = Core.NFBCParser.ParseADP(@"C:\ProjectionData\ADP.tsv");
            dynastyRanks = Core.DynastyRankParser.ParseDynastyCsv(@"C:\ProjectionData\IBWDynasty2020.csv");
        }

        [TestMethod()]
        public void AggregatePitchersTest()
        {
            var players = Core.DepthChartsParser.ParsePitcherCsv(@"C:\ProjectionData\DepthChartsProjectionsPitchers.csv");
            var combined = PlayerAggregator.AggregatePitchers(playerADPs, players, dynastyRanks);
            Assert.AreEqual(175,
                combined.Where(c => c.DynastyRAnk.Name == "Michael Kopech")
                 .Select(c => new { rank = c.DynastyRAnk as PlayerDynastyRank })
                 .First().rank.Rank);
            Assert.AreEqual(262, combined.Count());
        }

        [TestMethod()]
        public void AggregateHittersTest()
        {
            var players = Core.DepthChartsParser.ParseHitterCsv(@"C:\ProjectionData\DepthChartsProjectionsHitters.csv");
            var combined = PlayerAggregator.AggregateHitters(playerADPs, players, dynastyRanks);
            Assert.AreEqual(31,
    combined.Where(c => c.ADPInfo.Name == "Max Muncy").
    Select(c => new { proj = c.ProjectionInfo as HitterProjection }).
    First().proj.HomeRuns
    );
            Assert.AreEqual(346, combined.Count());

        }
    }
}