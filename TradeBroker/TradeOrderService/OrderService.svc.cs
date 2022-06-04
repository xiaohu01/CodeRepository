using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TradeOrderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class OrderService : IOrderService
    {
        private readonly List<Client> _clients;
        object locker = new object();

        public OrderService()
        {
            _clients = new List<Client>();
        }

        INotifyOrderService GetCurrentCallback()
        {
            return OperationContext.Current.GetCallbackChannel<INotifyOrderService>();
        }
        public Order AddOrUpdateOrder(Order order)
        {
            lock (locker)
            {
                if(order != null && !string.IsNullOrEmpty(order.Trader))
                {
                    Client client = new Client { Username = order.Trader, ClientCallback = GetCurrentCallback() };

                    foreach(Client c in _clients)
                    {
                        if(c.Username == order.Trader)
                        {
                            _clients.Remove(c);
                            break;
                        }
                    }
                    _clients.Add(client);
                }
            }

            if(_clients != null && _clients.Count > 0)
            {
                foreach(Client c in _clients)
                {
                    if(c.ClientCallback != null)
                    {
                        try
                        {
                            c.ClientCallback.NotifyOrder(order);
                        }
                        catch(Exception e)
                        {

                        }
                    }
                }
            }

            Order result = OrderRepository.Instance.AddOrUpdateOrder(order);

            return result;
        }

        public Order DeleteOrder(Order order)
        {
            return OrderRepository.Instance.DeleteOrder(order);
        }

        public IList<Order> GetAllOrders()
        {
            return OrderRepository.Instance.GetAllOrders();
        }

        public Order GetOrder(int Id)
        {
            return OrderRepository.Instance.GetOrder(Id);
        }
    }
}
