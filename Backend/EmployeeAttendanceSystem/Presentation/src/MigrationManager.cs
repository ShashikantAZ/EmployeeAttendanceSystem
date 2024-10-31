using Microsoft.EntityFrameworkCore;
using SEA.Data.ContextConfig;
namespace ESA.API
{
    public class MigrationManager
    {
        private readonly SeaDbContext _context;
        private readonly IHostEnvironment _env;
        private readonly ILogger<MigrationManager> _logger;

        public MigrationManager(SeaDbContext context, IHostEnvironment env, ILogger<MigrationManager> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        public void ApplyMigrations()
        {
            if (_env.IsDevelopment())
            {
                try
                {
                    _context.Database.Migrate(); // Applies pending migrations
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while migrating the database.");
                    throw; // Re-throw the exception after logging it
                }
            }
        }
    }
}
