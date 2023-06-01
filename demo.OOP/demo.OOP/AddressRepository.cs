using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class AddressRepository
    {
        ///<summary>
        ///Retrieve one address.
        /// </summary>
        public Address Retrieve(int addressId)
        {
            // Code that retrieves the defined address
            var address = new Address(addressId);

            // temporary hard-coded values to return
            if (addressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "Bag End";
                address.StreetLine2 = "Bagshot row";
                address.City = "Hobbiton";
                address.State = "Shire";
                address.Country = "Middle Earth";
                address.PostalCode = "144";
            }

            return address;
        }


        ///<summary>
        ///Retrieve all customers.
        /// </summary>
        public List<Address> Retrieve()
        {
            // Code that retrieves all of the customers.

            return new List<Address>();
        }

        ///<summary>
        ///Retrieve all customers address by ID.
        /// </summary>
        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            // Code that retrieves all of the customers.

            var addressList = new List<Address>();

            // temporary hard-coded values to return
            Address address = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144"
            };

            
            addressList.Add(address);

            address = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "Green Dragon",
                City = "Bywater",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "146"
            };
            addressList.Add(address);


            return addressList;
        }

        ///<summary>
        ///Saves the current address.
        /// </summary>
        /// <returns></returns>
        public bool Save(Address address)
        {
            // Code that saves the defined address.
            var success = true;
            if (address.HasChanges)
            {
                if (address.IsValid)
                {
                    if (address.IsNew)
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
