using SimpleQueriesExecutor.DataAccess;
using SimpleQueriesExecutor.Models.Requests;
using SimpleQueriesExecutor.Queue;

namespace SimpleQueriesExecutor.Logic
{
    public class QueryQueueService
    {
        private readonly QueryValidator _validator;
        private readonly ILogger<QueryQueueService> _logger;

        public QueryQueueService()
        {
            _validator =  new QueryValidator();
        }

        public async Task PutQueryToQueue(ExecuteQueryRequest request)
        {
            var connect = DataContext.DbConntections.FirstOrDefault(x => x.DbName == request.DbName);

            if(connect is null)
            {
                throw new Exception();
            }

            var validationResult = await _validator.ValidateQuery(request, connect);

            if (!validationResult.IsSuccessfull)
            {
                throw new Exception(validationResult.ErrorMessage);
            }

            //QueriesQueue.Queries.Add(new QueryToExecture
            //{
            //    DbName = request.DbName,
            //    ConnectionString = connect.ConnectionString,
            //    Status = QueryStatus.Pending,
            //    Query = request.Query
            //});

            var executeSerice = new QueryExecutor();

            var result = await executeSerice.ExecuteQuery(new QueryToExecture
            {
                DbName = request.DbName,
                ConnectionString = connect.ConnectionString,
                DbType = connect.DbType,
                Status = QueryStatus.Pending,
                Query = request.Query
            });
        }
    }
}
