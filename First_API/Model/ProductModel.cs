namespace First_API.Model
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public bool Deleted { get; set; }

        public string? ImagePath { get; set; }

        public string Category { get; set; }
    }
}
