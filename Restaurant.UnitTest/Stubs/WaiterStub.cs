namespace Restaurant.UnitTest.Stubs
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using System.Collections.Generic;

    public static class WaiterStub
    {
        public static readonly Waiter waiter = new Waiter { };

        public static IList<Waiter> waiters = new List<Waiter> { waiter };

        public static readonly CreateWaiterDto createWaiterDto = new CreateWaiterDto { FirstName = "prueba" };

        public static readonly WaiterDto waiterDto = new WaiterDto { FirstName = "prueba" };

        public static readonly WaiterSalesDto waiterSalesDto = new WaiterSalesDto { FirstName = "prueba" };

        public static IList<WaiterSalesDto> WaiterSalesDto = new List<WaiterSalesDto> { waiterSalesDto };
    }
}
