namespace Restaurant.Core.Dtos
{
    public class DiningTableDto
    {
        public int IdDiningTable { get; set; }
        public string Name { get; set; }
        public string Reserved { get; set; }
        public int Chairs { get; set; }
    }

    public class CreateDiningTableDto
    {
        public string Name { get; set; }
        public string Reserved { get; set; }
        public int Chairs { get; set; }
    }
}
