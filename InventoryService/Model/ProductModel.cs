using System.ComponentModel.DataAnnotations;

namespace InventoryService.Model
{
    public class ProductModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        [Range(0, Double.MaxValue, ErrorMessage = "Size must be a positive number.")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, Double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        public string? Design { get; set; }
    }
}
