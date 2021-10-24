using Microsoft.Extensions.Configuration;

namespace Api.Repositories
{
    public abstract class CoreRepository
    {
        public string ConnectionString { get; }

        public CoreRepository(IConfiguration configuration)
        {
            string ConnectionString = configuration.GetConnectionString("SimplyProjects");
        }
    }
}