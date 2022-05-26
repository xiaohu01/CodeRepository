using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TradeOrderService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {

        [OperationContract]
        Order GetOrder(int Id);

        [OperationContract]
        IList<Order> GetAllOrders();

        [OperationContract]
        Order AddOrUpdateOrder(Order order);

        [OperationContract]
        Order DeleteOrder(Order order);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Order
    {
        private bool _buySell;
        private string _product;
        private string _trader;
        private string _customer;
        private decimal _price;
        private int _amount;
        private int _id;

        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public bool BuySell
        {
            get { return _buySell; }
            set { _buySell = value; }
        }

        [DataMember]
        public string Product
        {
            get { return _product; }
            set { _product = value; }
        }

        [DataMember]
        public string Trader
        {
            get { return _trader; }
            set { _trader = value; }
        }

        [DataMember]
        public string Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        [DataMember]
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [DataMember]
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
