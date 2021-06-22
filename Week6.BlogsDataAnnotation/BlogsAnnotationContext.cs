using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.BlogsDataAnnotation.Models;

namespace Week6.BlogsDataAnnotation
{
    class BlogsAnnotationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Persona> People { get; set; }

        public BlogsAnnotationContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            optBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = BlogsAnnotation; Server = .\SQLEXPRESS");
        }

    }
}
