namespace BlogSystem.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogSystem.Models.BlogSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogSystem.Models.BlogSystemContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddOrUpdate(new Roles[]
                {
                    new Roles(){Title = "超级管理员"},
                    new Roles(){Title = "普通管理员"}
                });

                context.SaveChanges();
            }
        }
    }
}
