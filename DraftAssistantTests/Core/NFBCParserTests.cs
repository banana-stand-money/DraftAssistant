using Microsoft.VisualStudio.TestTools.UnitTesting;
using DraftAssistant.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DraftAssistant.Core.Tests
{
    [TestClass()]
    public class NFBCParserTests
    {
        [TestMethod()]
        public void ParseADPTest()
        {
            var recs = Core.NFBCParser.ParseADP(@"C:\ProjectionData\ADP.tsv");
            var numRecs = recs.Count();
            Assert.AreEqual(824, numRecs);
            Assert.AreEqual(1, recs.First(r => r.Name == "Mike Trout").MinPick);
        }
    }
}