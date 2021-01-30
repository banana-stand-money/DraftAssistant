using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraftAssistant.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DraftAssistant.Core.Tests
{
    [TestClass()]
    public class DynastyRankParserTests
    {
        [TestMethod()]
        public void ParseDynastyCsvTest()
        {
            var recs = Core.DynastyRankParser.ParseDynastyCsv(@".\TestFiles\IBWDynasty2020.csv");
            var numRecs = recs.Count();
            Assert.AreEqual(1013, numRecs);
            Assert.AreEqual(21, recs.First(r => r.Name == "Jo Adell").Age);
            Assert.AreEqual("2022", recs.First(r => r.Name == "Nolan Gorman").ETA);           

        }
    }
}