using Apress.Recipes.WebApi.Models;

namespace Apress.Recipes.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Apress.Recipes.WebApi.Models.PlayersAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Apress.Recipes.WebApi.Models.PlayersAppContext";
        }

        protected override void Seed(Apress.Recipes.WebApi.Models.PlayersAppContext context)
        {
            context.Players.AddOrUpdate(
                new Player
                {
                    Id = 1,
                    Name = "Filip",
                    Team = "Whales",
                },
                new Player
                {
                    Id = 2,
                    Name = "Felix",
                    Team = "Whales",
                },
                new Player
                {
                    Id = 3,
                    Name = "Luiz",
                    Team = "Dolphins",
                },
                new Player
                {
                    Id = 4,
                    Name = "Terry",
                    Team = "Dolphins",
                }
                );
        }
    }
}
