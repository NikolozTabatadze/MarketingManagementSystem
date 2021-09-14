using System;
using System.Collections.Generic;
using System.Text;

namespace MMS.Core
{
    public class HttpResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Dictionary<string, dynamic> Payload { get; set; }

        public HttpResult()
        {
            Payload = new Dictionary<string, dynamic>();
        }

        public static HttpResult Success(string message)
        {
            return new HttpResult() { IsSuccess = true, Message = message };
        }

        public static HttpResult Error(string message)
        {
            return new HttpResult() { IsSuccess = false, Message = message };
        }
    }
}
