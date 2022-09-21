using Restaurant.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.UnitTest.Stubs
{
    public static class BillStub
    {
        public static readonly BillsWithDetailsDto billsWithDetailsDto = new BillsWithDetailsDto { IdBill = 1 };

        public static readonly IEnumerable<BillsWithDetailsDto> billsWithDetailsDtos = new List<BillsWithDetailsDto> { billsWithDetailsDto };

        public static readonly GetBillsWithDetailsDto getBillsWithDetailsDto = new GetBillsWithDetailsDto { IdCustomer = "1111111111" };

        public static readonly CreateBillDto createBillDto = new CreateBillDto { 
            IdCustomer = "1111111111" , 
            CreateBillDetailsDto = BillDetailStub.createBillsDetailsDto
        };
    }
}
