using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TradeOrderService;

namespace TradeOrderServiceUnitTest
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void GetInstanceTest()
        {
            OrderRepository orderRepository = OrderRepository.Instance;

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

            var createdOrder = orderRepository.AddOrUpdateOrder(order);

            Assert.AreEqual(1, createdOrder.Id);

            orderRepository.DeleteOrder(createdOrder);
        }

        [TestMethod]
        public void GetOrderTest()
        {
            OrderRepository orderRepository = OrderRepository.Instance;

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

            var createdOrder = orderRepository.AddOrUpdateOrder(order);
            var returnOrder = orderRepository.GetOrder(createdOrder.Id);

            Assert.AreEqual(1, returnOrder.Id);
            Assert.AreEqual("Apple", returnOrder.Product);
            Assert.AreEqual("John Smith", returnOrder.Trader);
            Assert.AreEqual("Peter Johnson", returnOrder.Customer);
            Assert.AreEqual(145.55m, returnOrder.Price);
            Assert.AreEqual(1000, returnOrder.Amount);
            Assert.AreEqual(true, returnOrder.BuySell);

            orderRepository.DeleteOrder(returnOrder);
        }

        [TestMethod]
        public void GetAllOrdersTest()
        {
            OrderRepository orderRepository = OrderRepository.Instance;

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

            var order2 = new Order
            {
                Product = "Apple",
                Trader = "John Smith",
                Customer = "Peter Johnson",
                Price = 145.55m,
                Amount = 1000,
                Id = 0,
                BuySell = false
            };

            var firstOrder = orderRepository.AddOrUpdateOrder(order);
            
            var secondOrder = orderRepository.AddOrUpdateOrder(order2);

            var orders = orderRepository.GetAllOrders();

            Assert.AreEqual(2, orders.Count);
            Assert.AreEqual(1, orders.Where(o => o.BuySell == true).Count());
            Assert.AreEqual(1, orders.Where(o => o.BuySell == false).Count());

            orderRepository.DeleteOrder(firstOrder);
            orderRepository.DeleteOrder(secondOrder);
        }

        [TestMethod]
        public void AddOrUpdateOrderTest()
        {
            OrderRepository orderRepository = OrderRepository.Instance;

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

            var order2 = new Order
            {
                Product = "Apple",
                Trader = "John Smith",
                Customer = "Peter Johnson",
                Price = 145.55m,
                Amount = 1000,
                Id = 1,
                BuySell = true
            };

            var createdOrder = orderRepository.AddOrUpdateOrder(order);
            var returnOrder = orderRepository.AddOrUpdateOrder(order2);

            var orders = orderRepository.GetAllOrders();

            Assert.AreEqual(1, orders.Count);

            orderRepository.DeleteOrder(returnOrder);
        }

        [TestMethod]
        public void DeleteOrderTest()
        {
            OrderRepository orderRepository = OrderRepository.Instance;

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

            var createdOrder = orderRepository.AddOrUpdateOrder(order);

            Assert.AreEqual(1, createdOrder.Id);

            orderRepository.DeleteOrder(createdOrder);

            Assert.AreEqual(0, orderRepository.GetAllOrders().Count);
        }
    }
}
