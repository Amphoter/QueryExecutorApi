using Dapper;
using Oracle.ManagedDataAccess.Client;
using SimpleQueriesExecutor.Constants;
using SimpleQueriesExecutor.Models;
using SimpleQueriesExecutor.Queue;

namespace SimpleQueriesExecutor.Logic
{
    //TODO add logic to separate ora and sql server execution. Make it soft to easily add new db types.
    public class QueryExecutor
    {
        private const int _commandTimeout = 10;
        private readonly ILogger<QueryExecutor> _logger;

        public QueryExecutor()
        {
            
        }

        public async Task<OperationResult> ExecuteQuery(QueryToExecture query)
        {          
            try
            {
                using var connection = new OracleConnection(query.ConnectionString);
                await connection.OpenAsync();

                try 
                {
                    var affectedRows = await connection.ExecuteAsync(query.Query, commandTimeout: _commandTimeout);

                    await  connection.CloseAsync();
                    return OperationResult.Successful;
                }
                catch (Exception ex)
                {
                    await connection.CloseAsync();
                    return new OperationResult(ex.Message);
                }
            }
            catch(Exception ex)
            {
                return new OperationResult(ex.Message);
            }          
        }
    }
}
