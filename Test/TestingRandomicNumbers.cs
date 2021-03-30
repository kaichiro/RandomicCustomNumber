using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;

namespace test
{
    [TestClass]
    public class TestingRandomicNumbers
    {
        [TestMethod]
        public void TestRangeIntToIgnore()
        {
            List<int> ListIntToIgnore = new List<int> {-10, -8, -6, -4, -2 , 1, 3, 5, 7, 9}; 
            int randomInt = RandomicInteger.GenRandomicInt(StartNumber: -10, FinalNumber: 10, IntsToIgnore: ListIntToIgnore);
            Assert.IsFalse(ListIntToIgnore.Exists(item => item.Equals(randomInt)), $" existem int {randomInt}");
        }

        [TestMethod]
        // [DataRow(1.1, DisplayName = " ==>> 1.1")]
        // [DataRow(1.3, DisplayName = " ==>> 1.3")]
        // [DataRow(1.5, DisplayName = " ==>> 1.5")]
        // [DataRow(1.7, DisplayName = " ==>> 1.7")]
        // [DataRow(1.9, DisplayName = " ==>> 1.9")]
        // [DataRow(2.2, DisplayName = " ==>> 2.2")]
        // [DataRow(2.4, DisplayName = " ==>> 2.4")]
        // [DataRow(2.6, DisplayName = " ==>> 2.6")]
        [DataRow(2.8, DisplayName = " ==>> 2.8")]
        public void TestRangeDoubleToIgnore(double doubleItem)
        {
            List<double> ListDoubleToIgnore = new List<double> {1.2, 1.4, 1.6, 1.8, 2.1, 2.3, 2.5, 2.7, 2.9, doubleItem};
            double randomDouble = RandomicDouble.GenRandomicDouble(StartNumber: 2.8, FinalNumber: 3, PrecisionDecimal: 1, DoublesToIgnore: ListDoubleToIgnore);
            Assert.IsFalse(ListDoubleToIgnore.Exists(item => item.Equals(randomDouble)), $" existem double {randomDouble}");
        }
    }
}
