using System;
using System.Collections.Generic;

namespace CustomerReader
{
    class CustomerReader
    {
        private static List<CustomerReaderModal.Customer> customers;

        public CustomerReader()
        {
            customers = new List<CustomerReaderModal.Customer>();
        }

        static void Main(string[] args)
        {
            CustomerReader objCustomerReader = new CustomerReader();
            CustomerReaderBL.CustomerReaderBL objCustomerReaderBL = new CustomerReaderBL.CustomerReaderBL();

            try
            {
                customers = objCustomerReaderBL.GetCustomers();
                Console.WriteLine("Added this many customers: " + customers.Count + "\n");
                objCustomerReader.DisplayCustomers();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write("OH NO!!!!");
                Console.Write(ex.StackTrace);
            }

        }

        /*
         * This method displays the end result.
         */
        public void DisplayCustomers()
        {
            try
            {
                foreach (CustomerReaderModal.Customer customer in customers)
                {
                    String customerString = "";
                    customerString += "Email: " + customer.email + "\n";
                    customerString += "First Name: " + customer.firstName + "\n";
                    customerString += "Last Name: " + customer.lastName + "\n";
                    customerString += "Full Name: " + customer.fullName + "\n";
                    customerString += "Phone Number: " + customer.phone + "\n";
                    customerString += "Street Address: " + customer.streetAddress + "\n";
                    customerString += "City: " + customer.city + "\n";
                    customerString += "State: " + customer.state + "\n";
                    customerString += "Zip Code: " + customer.zipCode + "\n";

                    Console.WriteLine(customerString);
                }
            }
            catch (Exception ex)
            {
                Console.Write("OH NO!!!!");
                Console.Write(ex.StackTrace);
            }
        }
    }
}
