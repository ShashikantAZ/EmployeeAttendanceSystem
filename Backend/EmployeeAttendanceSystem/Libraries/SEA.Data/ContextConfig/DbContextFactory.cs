using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace SEA.Data.ContextConfig
{
    public class DbContextFactory
    {
        private readonly DatabaseOptions _databaseOptions;
        public bool flag = false;

        public DbContextFactory(DatabaseOptions databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        public SeaDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SeaDbContext>();
            optionsBuilder
                 .EnableDetailedErrors(_databaseOptions.EnableDetailedErrors)          // Set detailed errors
                 .EnableSensitiveDataLogging(_databaseOptions.EnableSesnsitiveDataLogging) // Set sensitive data logging
                 .UseSqlServer(_databaseOptions.ConnectionString, sqlOptions =>
                 {
                     sqlOptions.EnableRetryOnFailure(
                         _databaseOptions.MaxRetryCount);        // Set max retry count
                     sqlOptions.CommandTimeout(
                         _databaseOptions.CommandTimeout);       // Set command timeout
                 }); // Or any other DB provider

            return new SeaDbContext(optionsBuilder.Options);
        }
    }
}
