namespace Mee.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mee.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Mee.Models.ApplicationDbContext";
        }

        protected override void Seed(Mee.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            /*context.Preferences.AddOrUpdate(
               new Models.Preference { Preferences = "Pinics" },
               new Models.Preference { Preferences = "Walks" },
               new Models.Preference { Preferences = "Restaurants" },
               new Models.Preference { Preferences = "Movies" },
               new Models.Preference { Preferences = "Staying in" },
               new Models.Preference { Preferences = "Horse Carriages or Horse Back Riding" },
               new Models.Preference { Preferences = "Aracde" },
               new Models.Preference { Preferences = "Bars" },
               new Models.Preference { Preferences = "Bowling" },
               new Models.Preference { Preferences = "Art" },
               new Models.Preference { Preferences = "Cooking" },
               new Models.Preference { Preferences = "Mini Golf" },
               new Models.Preference { Preferences = "Events (Concerts, Comedy Shows, etc)" },
               new Models.Preference { Preferences = "Get Away (Sybaris, Spas, etc)" },
               new Models.Preference { Preferences = "Boat Cruise" },
               new Models.Preference { Preferences = "Amusement Parks/Carnivals/Festivals" },
               new Models.Preference { Preferences = "Have a Budget? Let us know : " },
               new Models.Preference { Preferences = "Please let us know you prefer distance for traveling:" });*/

        }
    }
}
