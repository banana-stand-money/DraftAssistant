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
        IEnumerable<PlayerADP> playerADPs;

        [TestInitialize]
        public void Setup()
        {
            playerADPs = Core.NFBCParser.ParseADP(@"C:\ProjectionData\ADP.tsv");
        }

        [TestMethod()]
        public void AggregatePitchersTest()
        {            
            var players = Core.DepthChartsParser.ParsePitcherCsv(@"C:\ProjectionData\DepthChartsProjectionsPitchers.csv");
            var combined = PlayerAggregator.AggregatePitchers(playerADPs, players);
            Assert.AreEqual(441, combined.Count());
        }

        [TestMethod()]
        public void AggregateHittersTest()
        {
            var players = Core.DepthChartsParser.ParseHitterCsv(@"C:\ProjectionData\DepthChartsProjectionsHitters.csv");
            var combined = PlayerAggregator.AggregateHitters(playerADPs, players);
            Assert.AreEqual(505, combined.Count());
            Assert.AreEqual(31,
                combined.Where(c => c.ADPInfo.Name == "Max Muncy").
                Select(c => new {proj = c.ProjectionInfo as HitterProjection }).
                First().proj.HomeRuns
                );
        }
    }
}