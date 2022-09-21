namespace Restaurant.Core.Entities
{
    using System.Collections.Generic;

    public partial class Food
    {
        public Food()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int IdFood { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
