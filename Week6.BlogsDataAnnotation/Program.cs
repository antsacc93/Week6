using System;
using System.Linq;
using Week6.BlogsDataAnnotation.Models;

namespace Week6.BlogsDataAnnotation
{
    //Creare un'applicazione che consente di gestire Persone e relativi autovoeicoli
    //Ogni persona è caratterizzata da 
    //    Nome, Cognome, codice fiscale (chiave primaria), data di nascita
    //Le automobili sono caratterizzate da:
    //    Targa (chiave primaria), numero posti, marca, data immatricolazione
    // Realizzare il database con Entity Framework e data annotation

    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new BlogsAnnotationContext())
            {
                //metodo che crea il database se non esiste, altrimenti lo richiama con 
                //la stringa di connessione
                ctx.Database.EnsureCreated();

                //Inserimento Blog
                //Blog blog = new Blog()
                //{
                //    URL = "www.myblog.it",
                //    Author = "Antonia",
                //    Name = "Blog di Antonia",

                //};

                //Blog blog = new Blog()
                //{
                //    URL = "www.blondesalad.com",
                //    Author = "Chiara Ferragni",
                //    Name = "The blonde salade"
                //};


                //ctx.Blogs.Add(blog);
                //ctx.SaveChanges();

                var blogFerragni = ctx.Blogs.Where(b => b.Author.Contains("Ferragni"));

                foreach(var item in ctx.Blogs)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("In particolare il blog di Ferragni è: ");
                foreach(var blogF in blogFerragni)
                {
                    Console.WriteLine(blogF);
                }

                var selectedBlog = ctx.Blogs.Find("www.blondesalad.com");
                var post = AddPost(selectedBlog);
                ctx.Posts.Add(post);
                ctx.SaveChanges();
            }
        }

        private static Post AddPost(Blog selectedBlog)
        {
            Post newPost = new Post()
            {
                Text = "New Post in blog",
                Date = DateTime.Today,
                Blog = selectedBlog,
                
            };
            return newPost;
        }
    }
}
