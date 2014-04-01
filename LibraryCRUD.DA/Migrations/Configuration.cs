using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using LibraryCRUD.BO.Enums;
using LibraryCRUD.BO.Entitites;

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
                new Publisher(){ Name = "Addison-Wesley", FoundationDate = DateTime.Parse("1942/01/01")},
                new Publisher(){ Name = "Bodleian Library, University of Oxford", FoundationDate = DateTime.Parse("1602/01/01")}
            };
            publishers.ForEach(p => context.Publishers.AddOrUpdate(ex => ex.Name, p));

            List<Author> authors = new List<Author>()
            {
                new Author(){ FullName = "Johnson Richard", DateBorn = DateTime.Parse("1733/01/01")},
                new Author(){ FullName = "Donald Knuth", DateBorn = DateTime.Parse("1938/10/01")}
            };
            authors.ForEach(a => context.Authors.AddOrUpdate(au => au.FullName, a));
            context.SaveChanges();

            List<Book> books = new List<Book>()
            {
                new Book(){ PublishDate = DateTime.Parse("1997-01-01"), Title = "The Art of Computer Programming", 
                    Publisher = publishers.ElementAt(0),
                    Rarity = BookStatusEnum.Common},
                new Book(){ PublishDate = DateTime.Parse("1994-01-01"), Title = "Concrete Mathematics", 
                    Publisher = publishers.ElementAt(0),
                    Rarity = BookStatusEnum.Common},
                new Book(){ PublishDate = DateTime.Parse("1992-01-01"), Title = "Literate Programming", 
                    Publisher = publishers.ElementAt(0),
                    Rarity = BookStatusEnum.Common},
                new Book(){ PublishDate = DateTime.Parse("1776-01-01"), Title = "Juvenile Sports and Pastimes", 
                    Publisher = publishers.SingleOrDefault(p => p.Name == "Bodleian Library, University of Oxford"),
                    Authors = new HashSet<Author>(){ context.Authors.SingleOrDefault(a => a.FullName == "Johnson Richard") },
                    Rarity = BookStatusEnum.Rare}
            };
            books.ForEach(b => context.Books.AddOrUpdate(ex => ex.Title, b));
            context.SaveChanges();


        }
    }
}
