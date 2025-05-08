using System.ComponentModel.DataAnnotations;

namespace ProductService.Model
{
    public class ProductModel
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }

        public string? Design { get; set; }
    }
}
