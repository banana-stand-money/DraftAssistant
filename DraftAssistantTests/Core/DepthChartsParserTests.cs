using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraftAssistant.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DraftAssistant.Core.Tests
{
    [TestClass()]
    public class DepthChartsParserTests
    {
        [TestMethod()]
        public void ParseHitterCsvTest()
        {
            var recs = Core.DepthChartsParser.ParseHitterCsv(@"C:\ProjectionData\DepthChartsProjectionsHitters.csv");
            var numRecs = recs.Count();
            Assert.AreEqual(611, numRecs);
            Assert.AreEqual(45, recs.First(r => r.Name == "Mike Trout").HomeRuns);
        }

        [TestMethod()]
        public void ParsePitcherCsvTest()
        {
            var recs = Core.DepthChartsParser.ParsePitcherCsv(@"C:\ProjectionData\DepthChartsProjectionsPitchers.csv");
            var numRecs = recs.Count();
            Assert.AreEqual(747, numRecs);
            Assert.AreEqual(11.68, recs.First(r => r.Name == "Tyler Glasnow").Kper9);
        }
    }
}