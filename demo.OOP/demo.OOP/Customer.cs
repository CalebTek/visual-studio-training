using demo.OOP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class Customer : EntityBase, ILoggable
    {
        // Constructor
        public Customer(): this(0)
        {
            
        }

        public Customer(int customerId)
        {
            CustomerID = customerId;
            AddressList = new List<Address>();
        }

        // Fields
        public List<Address> AddressList { get; set; }
        public int CustomerID { get; private set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrWhiteSpace(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }
        private string _lastName;
        public string LastName { get { return _lastName; } set { _lastName = value; } }

        public string PhoneNumber { get; set; }

        public static int InstanceCount { get; set; }
        public int CustomerType { get; set; }

        // Methods

        public string Log() => 
            $"{CustomerID}: {FullName} Email: {EmailAddress} Status: {EntityState.ToString()}";

        ///<summary>
        ///Validates the customer data.
        ///</summary>
        ///<returns></returns>
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) { isValid = false; }
            if (string.IsNullOrWhiteSpace(EmailAddress)) { isValid = false; }
            if (string.IsNullOrWhiteSpace(PhoneNumber)) { isValid = false; }

            return isValid;
        }

        public override string ToString() => FullName;

        /*
        ///<summary>
        ///Retrieve one customer.
        /// </summary>
        public Customer Retrieve(int customerId)
        {
            // Code that retrieves the defined customer

            return new Customer();
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
        public bool Save()
        {
            // Code that saves the defined customer

            return true;
        }
        */

    }
}
