namespace Restaurant.Core.Dtos
{
    using System;
    using System.Collections.Generic;

    public class CreateBillDto
    {
        public string IdCustomer { get; set; }
        public int IdDiningTable { get; set; }
        public int IdWaiter { get; set; }
        public DateTime CreationDate { get; set; }
        public CreateBillDetailsDto CreateBillDetailsDto { get; set; }
    }

    public class GetBillsWithDetailsDto : DateRangeDto
    {
        public int? IdBill { get; set; }
        public string IdCustomer { get; set; }
        public int? IdDiningTable { get; set; }
        public int? IdWaiter { get; set; }
        public int? IdFood { get; set; }
    }

    public class BillsWithDetailsDto
    {
        public int IdBill { get; set; }
        public DateTime CreationDate { get; set; }
        public string Customer { get; set; }
        public string Waiter { get; set; }
        public string DiningTable { get; set; }
        public decimal Price { get; set; }
        public List<BillDetailsDto> BillDetailsDto { get; set; }
    }
}