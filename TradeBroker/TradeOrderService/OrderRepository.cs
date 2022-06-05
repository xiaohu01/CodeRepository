using System.Collections.Generic;
using System.Linq;

namespace TradeOrderService
{
    public sealed class OrderRepository
    {
        private static OrderRepository _instance;
        private static readonly object _lock = new object();

        private IDictionary<int, Order> _orders;

        private OrderRepository()
        {
            _orders = new Dictionary<int, Order>();
        }

        public static OrderRepository Instance
        {
            get
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new OrderRepository();
                    }
                    return _instance;
                }
            }
        }

        public Order GetOrder(int Id)
        {
            if (_orders.Keys.Contains(Id))
                return _orders[Id];
            return null;
        }

        public Order AddOrUpdateOrder(Order order)
        {
            if(!_orders.Keys.Contains(order.Id))
            {
                if (_orders.Count > 0)
                    order.Id = _orders.Keys.Max() + 1;
                else
                    order.Id = 1;
            }

            _orders[order.Id] = order;

            return order;
        }

        public Order DeleteOrder(Order order)
        {
            if (_orders.Keys.Contains(order.Id))
                _orders.Remove(order.Id);

            return order;
        }

        public IList<Order> GetAllOrders()
        {
            return _orders.Values.ToList();
        }
    }
}