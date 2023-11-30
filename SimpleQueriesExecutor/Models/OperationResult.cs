namespace SimpleQueriesExecutor.Models
{
    public class OperationResult
    {
        public bool IsSuccessfull { get; set; }
        public string ErrorMessage { get; set; }

        public static OperationResult Successful => new() { IsSuccessfull = true };

        public OperationResult()
        {
            IsSuccessfull = true;
            ErrorMessage = string.Empty;
        }

        public OperationResult(string error)
        {
            IsSuccessfull = false;
            ErrorMessage = error;
        }
    }
}
