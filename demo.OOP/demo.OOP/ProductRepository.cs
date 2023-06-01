using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class ProductRepository
    {
        ///<summary>
        ///Retrieve one product.
        /// </summary>
        public Product Retrieve(int productId)
        {
            // Code that retrieves the defined product
            var product = new Product(productId);

            if (productId == 2)
            {
                product.ProductName = "Sunflowers";
                product.ProductDescription = "Assorted size set of 4 Bright Yellow Mini Sunflowers";
                product.CurrentPrice = 15.96M;
            }

            object myObject = new Object();
            Console.WriteLine($"Object: {myObject.ToString()}");
            Console.WriteLine($"Product: {product.ToString()}");

            //return new Product();
            return product;
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
        public bool Save(Product product)
        {
            // Code that saves the defined product.
            var success = true;
            if (product.HasChanges)
            {
                if (product.IsValid)
                {
                    if (product.IsNew)
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
