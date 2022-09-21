namespace Restaurant.Core.Entities
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public string IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}