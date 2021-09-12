using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class ErrorResponseModel
    {

        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Error Errors { get; set; }

        public class Error
        {
            public List<string> ProjectName { get; set; }
        }

    }
}
