using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CreateOrderItemDto
    {
        [Required(ErrorMessage = "Ürün seçimi zorunludur")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Miktar belirtilmelidir")]
        [Range(1, int.MaxValue, ErrorMessage = "Miktar 1'den büyük olmalıdır")]
        public int Quantity { get; set; }
    }
}
