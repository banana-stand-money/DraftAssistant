using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraftAssistant.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using DraftAssistant.Models;

namespace DraftAssistant.Core.Tests
{
    [TestClass()]
    public class ExportCombinedRankingsTests
    {
        [TestMethod()]
        public void ExportToCsvTest()
        {
            var path = @"C:\ProjectionData\combined.csv";
            File.Delete(path);
            var playerADPs = Core.NFBCParser.ParseADP(@".\TestFiles\ADP.tsv");
            var hitters = Core.DepthChartsParser.ParseHitterCsv(@".\TestFiles\DepthChartsProjectionsHitters.csv");
            var pitchers = Core.DepthChartsParser.ParsePitcherCsv(@".\TestFiles\DepthChartsProjectionsPitchers.csv");
            var dynastyRanks = Core.DynastyRankParser.ParseDynastyCsv(@".\TestFiles\IBWDynasty2020.csv");

            var aggHitters = PlayerAggregator.AggregateHitters(playerADPs, hitters, dynastyRanks);
            var aggPitchers = PlayerAggregator.AggregatePitchers(playerADPs, pitchers,dynastyRanks);
            ExportCombinedRankings.ExportToCsv(path, aggHitters.Concat(aggPitchers));
            Assert.IsTrue(File.Exists(path));
        }
    }
}