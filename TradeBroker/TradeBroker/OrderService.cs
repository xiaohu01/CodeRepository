﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradeOrderService
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/TradeOrderService")]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int AmountField;
        
        private bool BuySellField;
        
        private string CustomerField;
        
        private int IdField;
        
        private decimal PriceField;
        
        private string ProductField;
        
        private string TraderField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Amount
        {
            get
            {
                return this.AmountField;
            }
            set
            {
                this.AmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BuySell
        {
            get
            {
                return this.BuySellField;
            }
            set
            {
                this.BuySellField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Customer
        {
            get
            {
                return this.CustomerField;
            }
            set
            {
                this.CustomerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                this.PriceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Product
        {
            get
            {
                return this.ProductField;
            }
            set
            {
                this.ProductField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Trader
        {
            get
            {
                return this.TraderField;
            }
            set
            {
                this.TraderField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IOrderService")]
public interface IOrderService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrder", ReplyAction="http://tempuri.org/IOrderService/GetOrderResponse")]
    TradeOrderService.Order GetOrder(int Id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrder", ReplyAction="http://tempuri.org/IOrderService/GetOrderResponse")]
    System.Threading.Tasks.Task<TradeOrderService.Order> GetOrderAsync(int Id);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetAllOrders", ReplyAction="http://tempuri.org/IOrderService/GetAllOrdersResponse")]
    TradeOrderService.Order[] GetAllOrders();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetAllOrders", ReplyAction="http://tempuri.org/IOrderService/GetAllOrdersResponse")]
    System.Threading.Tasks.Task<TradeOrderService.Order[]> GetAllOrdersAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/AddOrUpdateOrder", ReplyAction="http://tempuri.org/IOrderService/AddOrUpdateOrderResponse")]
    TradeOrderService.Order AddOrUpdateOrder(TradeOrderService.Order order);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/AddOrUpdateOrder", ReplyAction="http://tempuri.org/IOrderService/AddOrUpdateOrderResponse")]
    System.Threading.Tasks.Task<TradeOrderService.Order> AddOrUpdateOrderAsync(TradeOrderService.Order order);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/DeleteOrder", ReplyAction="http://tempuri.org/IOrderService/DeleteOrderResponse")]
    TradeOrderService.Order DeleteOrder(TradeOrderService.Order order);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/DeleteOrder", ReplyAction="http://tempuri.org/IOrderService/DeleteOrderResponse")]
    System.Threading.Tasks.Task<TradeOrderService.Order> DeleteOrderAsync(TradeOrderService.Order order);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IOrderServiceChannel : IOrderService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class OrderServiceClient : System.ServiceModel.ClientBase<IOrderService>, IOrderService
{
    
    public OrderServiceClient()
    {
    }
    
    public OrderServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public OrderServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public OrderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public OrderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public TradeOrderService.Order GetOrder(int Id)
    {
        return base.Channel.GetOrder(Id);
    }
    
    public System.Threading.Tasks.Task<TradeOrderService.Order> GetOrderAsync(int Id)
    {
        return base.Channel.GetOrderAsync(Id);
    }
    
    public TradeOrderService.Order[] GetAllOrders()
    {
        return base.Channel.GetAllOrders();
    }
    
    public System.Threading.Tasks.Task<TradeOrderService.Order[]> GetAllOrdersAsync()
    {
        return base.Channel.GetAllOrdersAsync();
    }
    
    public TradeOrderService.Order AddOrUpdateOrder(TradeOrderService.Order order)
    {
        return base.Channel.AddOrUpdateOrder(order);
    }
    
    public System.Threading.Tasks.Task<TradeOrderService.Order> AddOrUpdateOrderAsync(TradeOrderService.Order order)
    {
        return base.Channel.AddOrUpdateOrderAsync(order);
    }
    
    public TradeOrderService.Order DeleteOrder(TradeOrderService.Order order)
    {
        return base.Channel.DeleteOrder(order);
    }
    
    public System.Threading.Tasks.Task<TradeOrderService.Order> DeleteOrderAsync(TradeOrderService.Order order)
    {
        return base.Channel.DeleteOrderAsync(order);
    }
}