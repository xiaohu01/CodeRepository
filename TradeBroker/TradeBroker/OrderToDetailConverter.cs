using System;
using System.Globalization;
using System.Windows.Data;
using TradeOrderService;

namespace TradeBroker
{
    public sealed class OrderToDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Order order = (Order)value;
            if(order != null )
            {   
                string buysell = order.BuySell ? "buys" : "sells";
                string detail = $"Trader {order.Trader} {buysell} {order.Amount} of {order.Product} for customer {order.Customer} at price of £{order.Price}";
                return detail;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
