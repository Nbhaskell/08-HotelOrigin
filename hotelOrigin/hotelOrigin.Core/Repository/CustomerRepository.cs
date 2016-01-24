using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotelOrigin.Core.Repository
{
    public class CustomerRepository
    {
        private static ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        // Create
        public static Customer Create()
        { 

        Customer customer = new Customer();

            customers.Add(customer);

            return new Customer();

            /* Customer customer = new Customer();

             customers.Add(customer); */
        }


        //Read
        public static Customer GetById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);

            // the hard way
            /* 
            Customer foundCustomer = null;
            
            for (int i = 0; i < customers.Count; i++)
            {
                if(customers.ElementAt(i).Id == id)
                {
                    foundCustomer = customers.ElementAt(i);
                }
            } 
            */

        }

        public static ObservableCollection<Customer> GetAll()
        {
            return customers;
        }

        //Update
        public static void Update(Customer customer, string firstName, string lastName, string phone, string email)
        {
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Telephone = phone;
            customer.EmailAddress = email;
        
            customers.Add(customer);
        }

        //Delete
        public static void Delete(int id)
        {
            var customer = GetById(id);

            customers.Remove(customer);
        }
        public static void Delete(Customer customer)
        {
            customers.Remove(customer);
        }

        // save load to disk
        public static void SaveToDisk()
        {
            string json = JsonConvert.SerializeObject(customers);

            File.WriteAllText("customers.json", json);
        }

        public static void LoadFromDisk()
        {
            if (File.Exists("customers.json"))
            {
                string json = File.ReadAllText("customers.json");

                customers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(json);
            }
        }

    }

}

