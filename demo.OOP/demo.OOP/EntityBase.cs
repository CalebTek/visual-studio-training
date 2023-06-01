using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }
    public abstract class EntityBase
    {
        // Fields
        public bool IsNew { get; private set; }
        public bool HasChanges { get; set; }
        public bool IsValid => Validate(); 
        public EntityStateOption EntityState { get; set; }

        // Methods
        public abstract bool Validate(); //{ return true; }
    }
}
