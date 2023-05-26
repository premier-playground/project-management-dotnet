using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Repositories.Configuration
{
    public class SqlServerConfiguration: DbConfiguration
    {
        public SqlServerConfiguration()
        {
            // SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            // // SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb", "Server=localhost;Database=project_management;Trusted_Connection=True;"));
            // SetDefaultConnectionFactory(new SqlServerConfiguration());
        }
    }
}
