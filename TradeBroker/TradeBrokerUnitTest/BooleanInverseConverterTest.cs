using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TradeBroker;

namespace TradeBrokerUnitTest
{
    [TestClass]
    public class BooleanInverseConverterTest
    {
        [TestMethod]
        public void TrueToFalseTest()
        {
            var converter = new BooleanInverseConverter();

            bool result = (bool)converter.Convert((object)true, typeof(bool), null, null);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FalseToTrueTest()
        {
            var converter = new BooleanInverseConverter();

            bool result = (bool)converter.Convert((object)false, typeof(bool), null, null);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ThrowExceptionTest()
        {
            var converter = new BooleanInverseConverter();

            Assert.ThrowsException<InvalidOperationException>(() => converter.Convert((object)false, typeof(int), null, null));
        }
    }
}
