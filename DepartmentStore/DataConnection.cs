using DAL_DepartmentStore;
using Microsoft.EntityFrameworkCore;

namespace DepartmentStore
{
    public static class DataConnection
    {
        public static void ConnectDb(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();
            var connection = config.GetConnectionString("DbConnection");
            services.AddDbContext<DbClass>(content => content.UseSqlServer(connection));
        }
    }
}
