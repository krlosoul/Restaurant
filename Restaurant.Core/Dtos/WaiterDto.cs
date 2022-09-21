namespace Restaurant.Core.Dtos
{
    using System;

    public class WaiterDto
    {
        public int IdWaiter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public DateTime? AdmissionDate { get; set; }
    }

    public class CreateWaiterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public DateTime? AdmissionDate { get; set; }
    }

    public class WaiterSalesDto
    {
        public decimal Sales { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
