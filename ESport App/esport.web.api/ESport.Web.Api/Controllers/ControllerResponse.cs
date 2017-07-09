using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESport.Web.Api.Controllers
{
    public class ControllerResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; internal set; }
    }
}