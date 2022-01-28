namespace VectorViewer.Model.OperationResult
{
    public class OperationResult
    {
        public OperationResult(string description) : this()
        {
            Success = false;
            Description = description;
        }

        public OperationResult()
        {
            Success = true;
            Description = string.Empty;
        }

        public bool Success { get; }

        public string Description { get; }
    }
}