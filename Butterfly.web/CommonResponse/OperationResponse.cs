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
        public String Error { get; set; }

        public bool IsSuccess { get; set; }

        public HttpStatusCode Status { get; set; }
    }
}