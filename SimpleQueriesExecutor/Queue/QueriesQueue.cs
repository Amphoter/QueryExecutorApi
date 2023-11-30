using SimpleQueriesExecutor.Models.Enums;

namespace SimpleQueriesExecutor.Queue
{
    public static class QueriesQueue
    {
        public static List<QueryToExecture> Queries { get; set; }
    }

    public class QueryToExecture
    {
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
        public DatabaseType DbType { get; set; }
        public string Query { get; set; }
        public QueryStatus Status { get; set; }
    }

    public enum QueryStatus
    {
        Pending,
        Success,
        Failed
    }
}
