namespace Butterfly.CaseManagement.Contracts.Utils
{
    using System.Collections.Generic;

    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public string ResponseCode { get; set; }
    }
}
