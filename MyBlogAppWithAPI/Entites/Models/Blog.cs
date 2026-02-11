using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public Category Category { get; set; }
        public Author Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
