namespace Restaurant.UnitTest.Stubs
{
    using Restaurant.Core.Dtos;
    using System.Collections.Generic;

    public static class BillDetailStub
    {
        public static readonly CreateBillDetailDto createBillDetailDto = new CreateBillDetailDto { IdBill = 1, IdFood = 1, Price = 100, Quantity = 1 };

        public static List<CreateBillDetailDto> createBillDetailsDto = new List<CreateBillDetailDto>() { createBillDetailDto };

        public static readonly CreateBillDetailsDto createBillsDetailsDto = new CreateBillDetailsDto { CreateBillDetailDto = createBillDetailsDto };
    }
}
