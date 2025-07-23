using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CategoryUpdateDto 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori adı boş bırakılamaz.")]
        public string CategoryName { get; set; }
    }
}
