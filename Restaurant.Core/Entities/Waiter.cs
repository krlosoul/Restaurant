namespace Restaurant.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Waiter
    {
        public Waiter()
        {
            Bills = new HashSet<Bill>();
        }

        public int IdWaiter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
