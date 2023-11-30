using SimpleQueriesExecutor.Models.Enums;

namespace SimpleQueriesExecutor.DataAccess
{
    public class DbConnections
    {
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
        public DatabaseType DbType { get; set; }
    }
}
