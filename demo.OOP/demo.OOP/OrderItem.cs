using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public class OrderItem : EntityBase
    {
        // Constructor
        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            OrderItemID = orderItemId;
        }

        // Fields
        public int OrderItemID { get; private set; }
        private decimal? PurchasePrice { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        
        // Methods

        ///<summary>
        ///Validates the order item data.
        ///</summary>
        ///<returns></returns>
        public override bool Validate()
        {
            var isValid = true;
            if (Quantity <= 0) { isValid = false; }
            if (ProductID <= 0) { isValid = false; }
            if (PurchasePrice == null) { isValid = false; }

            return isValid;
        }

        ///<summary>
        ///Retrieve one order item.
        /// </summary>
        public OrderItem Retrieve(int orderItemId)
        {
            // Code that retrieves the defined order item

            return new OrderItem();
        }

        ///<summary>
        ///Retrieve all order items.
        /// </summary>
        public List<OrderItem> Retrieve()
        {
            // Code that retrieves all of the order items.

            return new List<OrderItem>();
        }

        ///<summary>
        ///Saves the current order item.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            // Code that saves the defined order item.

            return true;
        }
    }
}
