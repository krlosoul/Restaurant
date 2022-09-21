namespace Restaurant.UnitTest.Stubs
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using System.Collections.Generic;

    public static class CustomerStub
    {
        public static readonly Customer customer = new Customer { };

        public static IList<Customer> customers = new List<Customer> { customer };

        public static CustomerDto customerDto = new CustomerDto { IdCustomer = "1111111111" };

        public static GetCustomerDto getCustomerDto = new GetCustomerDto { };

        public static CustomerSpendDto customerSpendDto = new CustomerSpendDto { };

        public static IList<CustomerSpendDto> customerSpendsDto = new List<CustomerSpendDto> { customerSpendDto };
    }
}
