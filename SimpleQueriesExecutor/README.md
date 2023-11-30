# QueryExecutorApi

TODO:

1. Separate query execution, validation for ora and sql server
2. Need logic to determine db type by connection string or something else
3. Add logging to QueryExecutor, QueryQueueService,  QueryValidator. Probably use serilog and configure console logging for the beggining.
4. Add JWT Auth
5. Write tests? Not sure how to mock ora queries but I think we should have a look on TestContainers https://github.com/testcontainers/testcontainers-dotnet to write component tests
6. Currently added query executed in QueryQueueService but not sure if queue here is needed. Leave it here for now but in future we should remove queue class and execute directly from endpoint and queue should be implemented
