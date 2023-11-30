namespace SimpleQueriesExecutor.Models.Requests
{
    public class ExecuteQueryRequest
    {
        public string DbName { get; set; }
        public string Schema { get; set; }
        public string Query { get; set; }
    }
}
