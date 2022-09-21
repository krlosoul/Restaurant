namespace Restaurant.Core.Dtos
{
    public class FoodDto
    {
        public int IdFood { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class CreateFoodDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class SalesFoodDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
