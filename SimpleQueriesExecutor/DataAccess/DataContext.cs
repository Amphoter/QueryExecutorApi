using SimpleQueriesExecutor.Models.Enums;

namespace SimpleQueriesExecutor.DataAccess
{
    //TODO Need logic to determine db type by connection string or something else
    public static class DataContext
    {
        public static DbConnections[] DbConntections = new DbConnections[] 
        {
            new DbConnections
            {
                DbName = "STK1R",
                ConnectionString = "",
                DbType = DatabaseType.Oracle
            }
        };
    }
}
