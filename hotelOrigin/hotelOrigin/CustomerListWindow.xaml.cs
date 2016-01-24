using hotelOrigin.Core;
using hotelOrigin.Core.Repository;
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
using System.Windows.Shapes;


namespace hotelOrigin
{
    public partial class CustomerListWindow : Window
    {
        private Customer currentlySelectedCustomer = null;

        public CustomerListWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = CustomerRepository.GetAll();
        }
        
        private void addCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer
            {
                FirstName = "Nate",
                LastName = "Haskell",
                Telephone = "8184348962",
                EmailAddress = "nbhaskell@gmail.com"
            };
        }

        private void deleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerRepository.Delete(currentlySelectedCustomer);
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentlySelectedCustomer = (Customer)dataGrid.SelectedItem;
        }

        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CustomerRepository.SaveToDisk();
        }
    }   

    

}