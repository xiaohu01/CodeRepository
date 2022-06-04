using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TradeOrderService;

namespace TradeBroker
{
    public class OrderBookViewModel
    {
        public OrderBookViewModel()
        {
            var client = new OrderServiceClient(new InstanceContext(new NotifyOrderHandler(null)));

            Orders = new ObservableCollection<Order>(client.GetAllOrders());
        }

        public ObservableCollection<Order> Orders { get; set; }
    }
}
