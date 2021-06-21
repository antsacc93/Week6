using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.BlogsDataAnnotation.Models
{
    public class Blog
    {
        // Chiave primaria di default BlogID
        //public int ID { get; set; }
        [Key]
        [MaxLength(20), MinLength(10)]
        public String URL { get; set; }
        public String Name { get; set; }
        [Required]
        public String Author { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

        public override string ToString()
        {
            return $"{Name} - {Author} - Follow on: {URL}";
        }
    }
}
