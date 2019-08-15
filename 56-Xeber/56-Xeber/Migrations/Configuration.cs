namespace _56_Xeber.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _56_Xeber.Areas.Admin.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<_56_Xeber.Areas.Admin.Models.XeberContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_56_Xeber.Areas.Admin.Models.XeberContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Users.AddOrUpdate(x => x.Id,
                new User { Id = 1, Name = "Ayaz", Login = "P210-Ayaz", Password = "ALaMVM2kdotUrXJ+agKHp5N1L71hB8uMQD9Iqc1L1mN4/MPa2XLJsMOUKPI+aLEy0g==", Status = true}
                );
            context.Categories.AddOrUpdate(x => x.Id,
                new Category { Id = 1, Name = "Siyasət" },
                new Category { Id = 2, Name = "İqtisadiyyat" },
                new Category { Id = 3, Name = "İdman" },
                new Category { Id = 4, Name = "Mədəniyyət" },
                new Category { Id = 5, Name = "Dünya" },
                new Category { Id = 6, Name = "Analitika" }
                );
        }
    }
}
