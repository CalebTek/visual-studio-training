using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class CustomerRepository
    {
        // Constructor
        public CustomerRepository() 
        {
            addressRepository = new AddressRepository();
        }

        // Fields
        private AddressRepository addressRepository { get; set; }

        ///<summary>
        ///Retrieve one customer.
        /// </summary>
        public Customer Retrieve(int customerId)
        {
            // Code that retrieves the defined customer
            Customer customer = new Customer(customerId);

            // temporary hard-coded values to return
            if (customerId == 1 )
            {
                customer.EmailAddress = "fbaggins@hobbiton.me";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList();
            }

            //return new Customer();
            return customer;
        }


        ///<summary>
        ///Retrieve all customers.
        /// </summary>
        public List<Customer> Retrieve()
        {
            // Code that retrieves all of the customers.

            return new List<Customer>();
        }

        ///<summary>
        ///Saves the current customer.
        /// </summary>
        /// <returns></returns>
        public bool Save(Customer customer)
        {
            // Code that saves the defined customer.
            var success = true;
            if (customer.HasChanges)
            {
                if (customer.IsValid)
                {
                    if (customer.IsNew)
                    {
                        // Call an Insert Stored Procedure

                    }
                    else
                    {
                        // Call an Update Store Procedure

                    }
                }
                else
                {
                    success = false;
                }
            }

            return success;
        }
    }
}
