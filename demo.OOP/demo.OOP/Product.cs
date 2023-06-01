using demo.OOP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class Product : EntityBase, ILoggable
    {
        // Constructor
        public Product()
        {

        }

        public Product(int productId)
        {
            ProductID = productId;
        }

        // Fields
        public int ProductID { get; private set; }
        public string ProductDescription { get; set; }
        public decimal? CurrentPrice { get; set; }
        private string _productName;
        public string ProductName
        {
            get
            { 
                //var stringHandler = new StringHandler();
                //return StringHandler.InsertSpaces(_productName); 
                return _productName.InsertSpaces();
            }
            set
            { _productName = value; }
        }


        // Methods

        public string Log() =>
            $"{ProductID}: {ProductName} Email: {ProductDescription} Status: {EntityState.ToString()}";

        ///<summary>
        ///Validates the product data.
        ///</summary>
        ///<returns></returns>
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName)) { isValid = false; }
            if (CurrentPrice == null) { isValid = false; }

            return isValid;
        }

        public override string ToString() => ProductName;

        /*
        ///<summary>
        ///Retrieve one product.
        /// </summary>
        public Product Retrieve(int productId)
        {
            // Code that retrieves the defined product

            return new Product();
        }

        ///<summary>
        ///Retrieve all product.
        /// </summary>
        public List<Product> Retrieve()
        {
            // Code that retrieves all of the products.

            return new List<Product>();
        }

        ///<summary>
        ///Saves the current product.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined product.

            return true;
        }
        */
    }
}
