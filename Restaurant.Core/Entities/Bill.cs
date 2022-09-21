namespace Restaurant.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int IdBill { get; set; }
        public string IdCustomer { get; set; }
        public int IdDiningTable { get; set; }
        public int IdWaiter { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Waiter Waiter { get; set; }
        public virtual DiningTable DiningTable { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
