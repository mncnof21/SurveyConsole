using SurveyConsole.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Responses
{
    public class HttpResponse
    {
        public int statuscode { get; set; }
        public String message { get; set; }
        public int? currPage { get; set; }
        public int? totalPage { get; set; }
        public int? totalData { get; set; }
        public object data { get; set; }
        public List<ValidationError> errors { get; set; }

        public HttpResponse()
        {
        }

        public HttpResponse(int statuscode, String message, object data)
        {
            this.statuscode = statuscode;
            this.message = message;
            this.data = data;
        }

        public HttpResponse(int statuscode, String message, object data, int currPage, int totalPage, int totalData)
        {
            this.statuscode = statuscode;
            this.message = message;
            this.currPage = currPage;
            this.totalPage = totalPage;
            this.totalData = totalData;
            this.data = data;
        }

        public HttpResponse(int statuscode, String message, object data, List<ValidationError> validationErrors)
        {
            this.statuscode = statuscode;
            this.message = message;
            this.data = data;
            this.errors = validationErrors;
        }
    }
}
