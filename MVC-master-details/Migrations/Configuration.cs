namespace test111.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using test111.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<test111.Models.aaaFahad11Entities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(test111.Models.aaaFahad11Entities context)
        {
            var categories = new List<Category>
            {
                new Category{CategoryName="Premium"},
                new Category{CategoryName="Regular"},
                new Category{CategoryName="Guest"}
            };
            categories.ForEach(m => context.Categories.AddOrUpdate(c => c.CategoryName, m));
            context.SaveChanges();
        }
    }
}
