using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class Address : EntityBase
    {
        // Constructor
        public Address()
        {

        }

        public Address(int addressId)
        {
            AddressID = addressId;
        }

        // Fields
        public int AddressID { get; private set; }
        public int AddressType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }


        // Methods

        ///<summary>
        ///Validates the product data.
        ///</summary>
        ///<returns></returns>
        public override bool Validate()
        {
            var isValid = true;
            if (PostalCode == null) { isValid = false; }

            return isValid;
        }

    }
}
