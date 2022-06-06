using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradeBroker;

namespace TradeBrokerUnitTest
{
    [TestClass]
    public class BooleanToBuySellConverterTest
    {
        [TestMethod]
        public void ConvertBuyTest()
        {
            var converter = new BooleanToBuySellConverter();

            string result = (string)converter.Convert((object)true, null, null, null);

            Assert.AreEqual("Buy", result);
        }

        [TestMethod]
        public void ConvertSellTest()
        {
            var converter = new BooleanToBuySellConverter();

            string result = (string)converter.Convert((object)false, null, null, null);

            Assert.AreEqual("Sell", result);
        }

        [TestMethod]
        public void ConvertNullTest()
        {
            var converter = new BooleanToBuySellConverter();

            string result = (string)converter.Convert(null, null, null, null);

            Assert.AreEqual("Sell", result);
        }
    }
}
