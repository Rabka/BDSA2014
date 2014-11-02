using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NorthWindVisualizer.Model;

namespace NorthWindVisualizer
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Orders _Order;
        private NorthWind northWind;

        public MainWindow()
        {
            MessageBox.Show(
                "It will take a while for the program to set up the database. Please click ok to start the process and wait for window to appear.");
            DataContext = this;
            ConnectToDatabase();
            InitializeComponent();
            OrdersDataGrid.SelectionChanged += OrdersDataGrid_SelectionChanged;
        }

        public Orders CurrentOrder
        {
            get { return _Order; }
            set
            {
                _Order = value;
                NotifyPropertyChanged("CurrentOrder");
            }
        }

        public ObservableCollection<Orders> ListOrders
        {
            get
            {
                var orders = new ObservableCollection<Orders>();
                foreach (Orders order in northWind.Orders())
                {
                    orders.Add(order);
                }
                return orders;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void ConnectToDatabase()
        {
            try
            {
                var db = new NORTHWNDEntities();
                Console.WriteLine("Connecting NORTHWND.MDF");
                db.Database.Connection.Open();
                Console.WriteLine("Connected");
                var respiratory = new Respiratory(db);
                northWind = new NorthWind(respiratory);
                Console.WriteLine("Preparing database meta data");
                //Dummy query
                northWind.Products().Take(0);
                Console.WriteLine("Ready");
            }
            catch
            {
            }
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersDataGrid.SelectedIndex > -1)
            {
                CurrentOrder = (Orders) OrdersDataGrid.SelectedItem;
            }
        }
    }
}