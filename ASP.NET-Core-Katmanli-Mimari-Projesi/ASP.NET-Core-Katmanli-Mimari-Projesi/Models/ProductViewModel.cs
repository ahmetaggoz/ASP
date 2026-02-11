using Entities.Dtos;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Models
{
    public class ProductViewModel
    {
        public class ProductListViewModel
        {
            public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
            public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
            public int? SelectedCategoryId { get; set; }
            public string SearchTerm { get; set; } = string.Empty;
            public int TotalCount { get; set; }
        }

        public class ProductCreateViewModel
        {
            public CreateProductDto Product { get; set; } = new CreateProductDto();
            public IEnumerable<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
            public string ReturnUrl { get; set; }
        }
    }
}
