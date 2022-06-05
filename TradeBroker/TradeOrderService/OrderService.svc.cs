using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace TradeOrderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class OrderService : IOrderService
    {
        private static readonly List<Client> _clients = new List<Client>();
        object locker = new object();

        INotifyOrderService GetCurrentCallback()
        {
            return OperationContext.Current.GetCallbackChannel<INotifyOrderService>();
        }
        public void AddOrUpdateOrder(Order order)
        {
            if (_clients != null && _clients.Count > 0)
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

            OrderRepository.Instance.AddOrUpdateOrder(order);
        }

        public void DeleteOrder(Order order)
        {
            OrderRepository.Instance.DeleteOrder(order);
        }

        public IList<Order> GetAllOrders()
        {
            return OrderRepository.Instance.GetAllOrders();
        }

        public Order GetOrder(int Id)
        {
            return OrderRepository.Instance.GetOrder(Id);
        }

        public void Subscribe(string user)
        {
            lock (locker)
            {
                if (!string.IsNullOrEmpty(user))
                {
                    Client client = new Client { Username = user, ClientCallback = GetCurrentCallback() };

                    if(!_clients.Any(c => c.Username == user))
                        _clients.Add(client);
                } 
            }
        }

        public void Unsubscribe(string user)
        {
            lock (locker)
            {
                if (!string.IsNullOrEmpty(user))
                {
                    foreach (Client c in _clients)
                    {
                        if (c.Username == user)
                        {
                            _clients.Remove(c);
                            break;
                        }
                    }
                } 
            }
        }
    }
}
