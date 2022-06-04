using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeOrderService;

namespace TradeBroker
{
    public class NotifyOrderHandler : IOrderServiceCallback
    {
        private readonly ObservableCollection<Order> _notifiedOreders;

        public NotifyOrderHandler(ObservableCollection<Order> notifiedOreders)
        {
            _notifiedOreders = notifiedOreders;
        }
        public void NotifyOrder(Order order)
        {
            _notifiedOreders?.Add(order);
        }
    }
}
