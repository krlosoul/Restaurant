namespace Restaurant.Core.Entities
{
    public partial class BillDetail
    {
        public int IdBillDetail { get; set; }
        public int IdBill { get; set; }
        public int IdFood { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Food Food { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
