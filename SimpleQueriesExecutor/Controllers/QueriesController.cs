using Microsoft.AspNetCore.Mvc;
using SimpleQueriesExecutor.Logic;
using SimpleQueriesExecutor.Models.Requests;

namespace SimpleQueriesExecutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueriesController : ControllerBase
    {
        private readonly QueryQueueService _queryExecutor;

        public QueriesController()
        {
            _queryExecutor = new QueryQueueService();
        }


        [HttpPost]
        public async Task ExecuteQuery(ExecuteQueryRequest request)
        {
            await _queryExecutor.PutQueryToQueue(request);
        }
    }  
}
