using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NorthWindVisualizer.Model;
using NorthWindVisualizer.ModelView;
namespace NorthWindVisualizer
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthWind northWind;
        OrdersModelView modelView;
        public MainWindow()
        {
            MessageBox.Show("It will take a while for the program to set up the database. Please click ok to start the process and wait for window to appear.");
            DataContext = this;
            ConnectToDatabase();
            InitializeComponent();
            modelView = new OrdersModelView(northWind);
            formGrid.DataContext = modelView;
            OrdersDataGrid.SelectionChanged += OrdersDataGrid_SelectionChanged;
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
                modelView.CurrentOrder = (Orders)OrdersDataGrid.SelectedItem;
            }
        }
    }
}