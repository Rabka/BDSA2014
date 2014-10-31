using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using NorthWindVisualizer.Model;
namespace NorthWindVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        Orders _Order = null;
        public Orders CurrentOrder
        {
            get {
                return _Order;
            }
            set {
                _Order = value;
                NotifyPropertyChanged("CurrentOrder");
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
        NorthWind northWind;
        public MainWindow()
        {
            MessageBox.Show("It will take a while for the program to set up the database. Please click ok to start the process and wait for window to appear.");
            DataContext = this;
            ConnectToDatabase();
            InitializeComponent();
            OrdersDataGrid.SelectionChanged += OrdersDataGrid_SelectionChanged;
        }
        private void ConnectToDatabase()
        {
            try
            {
                NORTHWNDEntities db = new NORTHWNDEntities();
                Console.WriteLine("Connecting NORTHWND.MDF");
                db.Database.Connection.Open();
                Console.WriteLine("Connected");
                Respiratory respiratory = new Respiratory(db);
                northWind = new NorthWind(respiratory);
                Console.WriteLine("Preparing database meta data");
                //Dummy query
                northWind.Products().Take(0) ;
                Console.WriteLine("Ready");
            }
            catch
            {

            }
        }
        public ObservableCollection<Orders> ListOrders
        {
            get
            {
                ObservableCollection<Orders> orders = new ObservableCollection<Orders>();
                foreach (Orders order in northWind.Orders())
                {
                    orders.Add(order);
                }
                return orders;
            }
          
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersDataGrid.SelectedIndex > -1)
            {
                CurrentOrder = (Orders)OrdersDataGrid.SelectedItem;
            }
        }



    }
}
