using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class ReturnImageLoad
    {
        public object data { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }

        public ReturnImageLoad(object data, string message, int statusCode)
        {
            this.data = data;
            this.message = message;
            this.statusCode = statusCode;
        }
    }
}