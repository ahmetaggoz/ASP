using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık gereklidir")]
        [StringLength(200, ErrorMessage = "Başlık en fazla 200 karakter olabilir")]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "İçerik gereklidir")]
        [Display(Name = "İçerik")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Yazar gereklidir")]
        [StringLength(100, ErrorMessage = "Yazar adı en fazla 100 karakter olabilir")]
        [Display(Name = "Yazar")]
        public string Author { get; set; } = string.Empty;

        [Display(Name = "Yayınlansın mı?")]
        public bool IsPublished { get; set; }

        public int ViewCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
