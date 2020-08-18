using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace testDapper
{
    public class MyDbcontext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => builder.AddConsole());
        
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Test.db;")
                          .UseLoggerFactory(MyLoggerFactory)
                          .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

    }
}