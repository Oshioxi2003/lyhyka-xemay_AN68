using System.Data.Entity;

namespace EF6_SQLite_Working_ConsoleApp
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyDbContext>());
        }

        public DbSet<Event> Events { get; set; }
    }
}