namespace Restaurant.Core.Entities
{
    using System.Collections.Generic;

    public partial class DiningTable
    {
        public DiningTable()
        {
            Bills = new HashSet<Bill>();
        }

        public int IdDiningTable { get; set; }
        public string Name { get; set; }
        public string Reserved { get; set; }
        public int Chairs { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
