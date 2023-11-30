using SimpleQueriesExecutor.Models.Enums;

namespace SimpleQueriesExecutor.DataAccess
{
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
