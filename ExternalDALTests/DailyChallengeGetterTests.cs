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
    public class DailyChallengeGetterTests
    {
        [TestMethod()]
        public void getAllDailysTest()
        {
            // arrange 
            DailyChallengeGetter dcg = new DailyChallengeGetter();

            // act
            MetaData md = dcg.getAllDailys();

            Assert.IsTrue(md.Category == "daily");

        }
    }
}