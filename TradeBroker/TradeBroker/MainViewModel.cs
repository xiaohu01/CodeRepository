using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradeOrderService;

namespace TradeBroker
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _product;
        private string _trader;
        private string _customer;
        private decimal _price;
        private int _amount;
        private OrderServiceClient _client;
        public MainViewModel()
        {
            Products = new List<string> { "Apple", "Tesla", "Facebook", "Amazon", "Google", "Netflex" };
            Traders = new List<string> { "John Smith", "Boris Johnson", "George Bush", "Joe Biden" };
            Customers = new List<string> { "Bill Clinton", "Richard Nixon", "Donald Trump" };

            BuyCommand = new RelayCommand(ExecuteBuyOrder, CanExecuteBuyOrder);
            SellCommand = new RelayCommand(ExecuteSellOrder, CanExecuteSellOrder);
            OpenBookCommand = new RelayCommand(ExecuteOpenBook, CanExecuteOpenBook);

            _client = new OrderServiceClient();
        }
        public ICollection<string> Products { get; private set; }
        public ICollection<string> Traders { get; private set; }
        public ICollection<string> Customers { get; private set; }

        public ICommand BuyCommand { get; private set; }
        public ICommand SellCommand { get; private set; }
        public ICommand OpenBookCommand { get; private set; }

        public string Product 
        {
            get { return _product; } 
            set
            {
                _product = value;
                OnPropertyChange(nameof(Product));
            } 
        }
        public string Trader 
        {
            get { return _trader; }
            set
            {
                _trader = value;
                OnPropertyChange(nameof(Trader));
            }
        }
        public string Customer 
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChange(nameof(Customer));
            }
        }

        public decimal Price 
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChange(nameof(Price));
            }
        }
        public int Amount 
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChange(nameof(Amount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ExecuteBuyOrder(object obj)
        {
            var order = new Order
            {
                Product = Product,
                Trader = Trader,
                Customer = Customer,
                Price = Price,
                Amount = Amount,
                Id = 0,
                BuySell = true
            };

            var retOrder = _client.AddOrUpdateOrder(order);
        }

        private bool CanExecuteBuyOrder(object obj)
        {
            return true;
        }

        private void ExecuteSellOrder(object obj)
        {
            var order = new Order
            {
                Product = Product,
                Trader = Trader,
                Customer = Customer,
                Price = Price,
                Amount = Amount,
                Id = 0,
                BuySell = false
            };

            var retOrder = _client.AddOrUpdateOrder(order);
        }

        private bool CanExecuteSellOrder(object obj)
        {
            return true;
        }

        private void ExecuteOpenBook(object obj)
        {
            var book = new OrderBookView();
            var viewModel = new OrderBookViewModel();
            book.DataContext = viewModel;
            book.Show();
        }

        private bool CanExecuteOpenBook(object obj)
        {
            return true;
        }
    }
}
