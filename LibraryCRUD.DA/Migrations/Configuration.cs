using LibraryCRUD.BO.Entitites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace LibraryCRUD.DA.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LibraryCRUD.DA.LibraryCRUDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryCRUD.DA.LibraryCRUDContext context)
        {
            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher(){ Name = "Addison-Wesley", FoundationDate = DateTime.Parse("1942/01/01")}
            };
            publishers.ForEach(p => context.Publishers.AddOrUpdate(ex => ex.Name, p));

            List<Book> books = new List<Book>()
            {
                new Book(){ PublishDate = DateTime.Parse("1997-01-01"), Title = "The Art of Computer Programming", Publisher = publishers.ElementAt(0)},
                new Book(){ PublishDate = DateTime.Parse("1994-01-01"), Title = "Concrete Mathematics", Publisher = publishers.ElementAt(0)},
                new Book(){ PublishDate = DateTime.Parse("1992-01-01"), Title = "Literate Programming", Publisher = publishers.ElementAt(0)}
            };
            books.ForEach(b => context.Books.AddOrUpdate(ex => ex.Title, b));
            context.SaveChanges();


        }
    }
}
