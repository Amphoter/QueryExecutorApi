using Dapper;
using Oracle.ManagedDataAccess.Client;
using SimpleQueriesExecutor.Constants;
using SimpleQueriesExecutor.DataAccess;
using SimpleQueriesExecutor.Models;
using SimpleQueriesExecutor.Models.Requests;

namespace SimpleQueriesExecutor.Logic
{
    public class QueryValidator
    {
        private const int _commandTimeout = 10;
        private readonly ILogger<QueryValidator> _logger;

        public QueryValidator()
        {

        }

        public async Task<OperationResult> ValidateQuery(ExecuteQueryRequest request, DbConnections connect)
        {
            try
            {
                using var connection = new OracleConnection(connect.ConnectionString);
                await connection.OpenAsync();

                try
                {
                    var validateQuery = OraFunctions.ValidateQuery(request.Query);
                    
                    var affectedRows = await connection.ExecuteAsync(validateQuery, commandTimeout: _commandTimeout);

                    await connection.CloseAsync();
                    return OperationResult.Successful;
                }
                catch (Exception ex)
                {
                    await connection.CloseAsync();
                    return new OperationResult(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return new OperationResult(ex.Message);
            }
        }
    }
}
