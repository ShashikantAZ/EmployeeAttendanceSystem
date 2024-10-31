using Microsoft.EntityFrameworkCore;
using SEA.Core.Models;
using SEA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEA.Data.ContextConfig
{
    public class SeaDbContext : DbContext
    {
        public SeaDbContext(DbContextOptions<SeaDbContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities here
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyEntity()); // Applying the Company configuration

            // Optionally, apply configurations for other entities
            // modelBuilder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
