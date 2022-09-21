namespace Restaurant.UnitTest.Stubs
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using System.Collections.Generic;

    public static class DiningTableStub
    {
        public static readonly DiningTable diningTable = new DiningTable { };

        public static IList<DiningTable> diningTables = new List<DiningTable> { diningTable };

        public static CreateDiningTableDto createDiningTableDto = new CreateDiningTableDto { Name = "prueba" };

        public static DiningTableDto diningTableDto = new DiningTableDto { Name = "prueba" };
    }
}
