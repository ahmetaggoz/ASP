using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Kategori adý boþ býrakýlamaz.")]
        public String? CategoryName { get; set; } = String.Empty;

        // Collection navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}