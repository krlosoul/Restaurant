namespace Restaurant.UnitTest.Stubs
{
    using Restaurant.Core.Dtos;
    using Restaurant.Core.Entities;
    using System.Collections.Generic;

    public static class FoodStub
    {
        public static Food food = new Food() { };

        public static IList<Food> foods = new List<Food> { food };

        public static CreateFoodDto createFoodDto = new CreateFoodDto { Name = "pruea" };

        public static FoodDto foodDto = new FoodDto { Name = "pruea" };

        public static SalesFoodDto salesFoodDto = new SalesFoodDto { Name = "prueba" };
    }
}
