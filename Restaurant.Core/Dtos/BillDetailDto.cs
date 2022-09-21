namespace Restaurant.Core.Dtos
{
    using System.Collections.Generic;

    public class BillDetailsDto
    {
        public string Food { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateBillDetailDto
    {
        public int IdBill { get; set; }
        public int IdFood { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public class CreateBillDetailsDto
    {
        public List<CreateBillDetailDto> CreateBillDetailDto { get; set; }
    }
}
