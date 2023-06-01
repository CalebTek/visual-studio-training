using demo.OOP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class Order : EntityBase, ILoggable
    {
        // Constructor
        public Order() : this(0)
        {

        }

        public Order(int orderId)
        {
            OrderID = orderId;
            OrderItems = new List<OrderItem>();
        }

        // Fields
        public int CustomerID { get; set; }
        public int OrderID { get; private set; }
        public DateTimeOffset? OrderDate { get; set; }
        public int ShippingAddressID { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        // Methods

        ///<summary>
        ///Validates the order data.
        ///</summary>
        ///<returns></returns>
        public override bool Validate()
        {
            var isValid = true;
            if (OrderDate == null) { isValid = false; }

            return isValid;
        }

        public override string ToString() => $"{OrderDate.Value.Date} ({OrderID})";

        public string Log() => 
            $"{OrderID}: Date: {this.OrderDate.Value.Date} Status: {this.EntityState.ToString()}";

        /*
        ///<summary>
        ///Retrieve one order.
        /// </summary>
        public Order Retrieve(int orderId)
        {
            // Code that retrieves the defined order

            return new Order();
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
        public bool Save()
        {
            // Code that saves the defined order.

            return true;
        }
        */
    }
}
