using System.Collections.ObjectModel;
using TradeOrderService;

namespace TradeBroker
{
    public class NotifyOrderHandler : IOrderServiceCallback
    {
        private readonly ObservableCollection<Order> _notifiedOrders;

        public NotifyOrderHandler(ObservableCollection<Order> notifiedOrders)
        {
            _notifiedOrders = notifiedOrders;
        }
        public void NotifyOrder(Order order)
        {
            _notifiedOrders?.Add(order);
        }
    }
}
