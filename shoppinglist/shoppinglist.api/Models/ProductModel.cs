using System.ComponentModel.DataAnnotations;

namespace shoppinglist.api.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity greater than 0 required")]
        public int Quantity { get; set; }
    }
}