namespace Restaurant.Core.Dtos
{
    public class CustomerDto
    {
        public string IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class GetCustomerDto : DateRangeDto
    {
        public decimal Spent { get; set; }
    }

    public class CustomerSpendDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Spent { get; set; }
    }
}