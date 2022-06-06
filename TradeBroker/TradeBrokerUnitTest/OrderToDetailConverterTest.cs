using Microsoft.VisualStudio.TestTools.UnitTesting;
using TradeBroker;
using TradeOrderService;

namespace TradeBrokerUnitTest
{
    [TestClass]
    public class OrderToDetailConverterTest
    {
        [TestMethod]
        public void OrderToDetailTest()
        {
            var order = new Order
            {
                Product = "Apple",
                Trader = "John Smith",
                Customer = "Peter Johnson",
                Price = 145.55m,
                Amount = 1000,
                Id = 0,
                BuySell = true
            };

            var converter = new OrderToDetailConverter();

            string result = (string)converter.Convert((object)order, null, null, null);

            Assert.AreEqual("Trader John Smith buys 1000 of Apple for customer Peter Johnson at price of £145.55", result);
        }

        [TestMethod]
        public void NullToDetailTest()
        {
            var converter = new OrderToDetailConverter();

            string result = (string)converter.Convert(null, null, null, null); ;

            Assert.AreEqual(null, result);
        }
    }
}
