using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = String.Empty;
        public string Departman { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
    }
}
