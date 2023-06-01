using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class OrderRepository
    {
        ///<summary>
        ///Retrieve one order.
        /// </summary>
        public Order Retrieve(int orderId)
        {
            // Code that retrieves the defined order

            var order = new Order(orderId);

            if (orderId == 10)
            {
                // use current year in hard-coded data
                order.OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0));
            }

            //return new Order();
            return order;
        }

        ///<summary>
        ///Retrieve all order.
        /// </summary>
        public List<Order> Retrieve()
        {
            // Code that retrieves all of the orders.

            return new List<Order>();
        }

        ///<summary>
        ///Saves the current order.
        /// </summary>
        /// <returns></returns>
        public bool Save(Order order)
        {
            // Code that saves the defined product.
            var success = true;
            if (order.HasChanges)
            {
                if (order.IsValid)
                {
                    if (order.IsNew)
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
