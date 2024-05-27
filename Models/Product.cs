using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name= "Urun Id")]
        public int ProductId { get; set; }
        [Display(Name= "Urun Adı")]
        [Required(ErrorMessage ="Gerekli bir alan")]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Display(Name= "Fiyat")]
        [Required]
        [Range(0,100000)]
        public decimal? Price { get; set; }
        [Display(Name= "Resim")]
        public string? Image { get; set; }
        public bool IsActive { get; set; }
        [Display(Name="Category")]
        [Required]
        public int? CategoryId { get; set; }
        
    }
}