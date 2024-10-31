using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace SEA.Data.ContextConfig
{
    public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
    {
        private readonly IConfiguration _configuration;

        public DatabaseOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(DatabaseOptions options)
        {
            _configuration.GetSection("DatabaseOptions").Bind(options);
        }
    }
}
