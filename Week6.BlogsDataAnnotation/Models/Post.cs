using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6.BlogsDataAnnotation.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Text { get; set; }
        public DateTime Date { get; set; }

        //Chiave esterna verso il blog
        public String BlogURL { get; set; }

        //Navigation Property
        public Blog Blog { get; set; }
    }
}
