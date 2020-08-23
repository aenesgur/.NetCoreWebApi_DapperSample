using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperSample.BLL.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
