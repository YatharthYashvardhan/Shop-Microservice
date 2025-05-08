using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartService.Model
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public ICollection<int> ProductId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime ExpectedDeliveryDate { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }



    }
}
