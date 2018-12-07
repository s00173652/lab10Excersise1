using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.IO;

namespace labSheet10ConorKoritor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Initialize Collections
        
        private ObservableCollection<Bike> bikes = new ObservableCollection<Bike>();
        private ObservableCollection<Bike> cart = new ObservableCollection<Bike>();
        private ObservableCollection<Bike> filtered = new ObservableCollection<Bike>();

        public MainWindow()
        {
            InitializeComponent();

        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Initialize Bikes

            Bike bike1 = new Bike(1234, "Road Bike", 535.00m, "Female");
            Bike bike2 = new Bike(1235, "Road Bike", 635.00m, "Male");
            Bike bike3 = new Bike(1236, "Mountain Bike", 740.00m, "Male");
            Bike bike4 = new Bike(1237, "Mountain Bike", 780.00m, "Female");
            Bike bike5 = new Bike(1238, "Hybrid Bike", 155.00m, "Female");
            Bike bike6 = new Bike(1239, "Hybrid Bike", 150.00m, "Male");

            //Add Them to the Product List
            bikes.Add(bike1);
            bikes.Add(bike2);
            bikes.Add(bike3);
            bikes.Add(bike4);
            bikes.Add(bike5);
            bikes.Add(bike6);


            //Display Bikes
            lbxProduct.ItemsSource = bikes;

            //Adding values to combo box
            string[] bikeTypes = { "All", "Male", "Female" };
            cbxBikeType.ItemsSource = bikeTypes;
            cbxBikeType.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Initialize Variables
            decimal totalCost = 0.00m;
            //Save selected Item
            Bike selected = lbxProduct.SelectedItem as Bike;

            //Check if item is selected
            if(selected != null)
            {
                //if there is a selected item add it to cart
                cart.Add(selected);
            }

            //Refresh lbxCart
            lbxCart.ItemsSource = cart;

            //refresh total cost by running through each item in cart and adding price together
            foreach(Bike b in cart)
            {

                totalCost += b.Price;
                tblkTotal.Text = $"{totalCost:C}";

            }

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            decimal totalCost = 0.00m;

            Bike selected = lbxCart.SelectedItem as Bike;

            if (selected != null)
            {
                cart.Remove(selected);
            }
            
            lbxCart.ItemsSource = cart;

            foreach (Bike b in cart)
            {

                totalCost += b.Price;
                tblkTotal.Text = $"{totalCost:C}";

            }

        }

        private void cbxBikeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Clear Everything already in filtered to avoid duplicates
            filtered.Clear();

            //Check if selected index is not  "All"
            if(cbxBikeType.SelectedIndex != 0)
            {
                //Run Through all bikes to check for match between selected index and bikes.Gender
                foreach(Bike b in bikes)
                {
                    //If there is a match add it to filtered list
                    if (b.Gender.Contains(cbxBikeType.SelectedItem.ToString()))
                    {
                        filtered.Add(b);
                    }
                }

                //make filtered list the new display
                lbxProduct.ItemsSource = filtered;
            }
            else
            {
                //if selected index equals "All" make bikes the display
                lbxProduct.ItemsSource = bikes;
            }

        }
    }
}
