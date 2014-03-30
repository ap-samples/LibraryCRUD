namespace LibraryCRUD.DA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryCRUD.DA.LibraryCRUDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryCRUD.DA.LibraryCRUDContext context)
        {

        }
    }
}
