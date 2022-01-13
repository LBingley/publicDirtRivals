using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExternalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirtRivalsswag.Models;

namespace ExternalDAL.Tests
{
    [TestClass()]
    public class DailyEntriesGetterTests
    {
        [TestMethod()]
        public void GetEntryByNameTest()
        {
            DailyEntriesGetter deg = new DailyEntriesGetter();
            DailyChallengeGetter dcg = new DailyChallengeGetter();
            MetaData md = dcg.getAllDailys();

            // act
            List<Entry> entries = deg.GetEntryByName(md.Challenges[0].ReferenceName);

            Assert.IsTrue(entries[0].DriverName != null);
        }
    }
}