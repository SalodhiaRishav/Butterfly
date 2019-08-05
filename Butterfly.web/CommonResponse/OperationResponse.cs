using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Butterfly.web.CommonResponse
{
    using System.Net;
    public class OperationResponse<T>
    {
        public String Message { get; set; }
        public T Data { get; set; }
        public List<String> Error { get; set; }

        public bool Success { get; set; }

        public HttpStatusCode Status { get; set; }

        public void OnSuccess(T data, string message)
        {
            this.Message = message;
            this.Data = data;
            this.Status = HttpStatusCode.OK;
            this.Error.Add("No error");
            this.Success = true;
        }

        public void OnError(string message, List<String> error)
        {
            this.Message = message;
            this.Status = HttpStatusCode.Forbidden;
            this.Error = error; ;
            this.Success = false;
        }

        public void OnException(string message)
        {
            this.Message = message;
            this.Status = HttpStatusCode.InternalServerError;
            this.Error.Add("Internal Server Error");
            this.Success = false;
        }
    }
}