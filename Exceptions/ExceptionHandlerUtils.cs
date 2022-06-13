using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using SurveyConsole.Libs;

namespace SurveyConsole.Exceptions
{
    public class ExceptionHandlerUtils
    {
        public static ActionResult JsonOutput(Controller ctrl, HttpContext context, int statusCode, String msg)
        {
            context.Response.StatusCode = statusCode;
            var exception = new
            {
                reason = msg
            };

            return ctrl.Content(Encrypt.EncryptRJ256(JsonConvert.SerializeObject(new
            {
                statuscode = statusCode,
                message = msg
            })), "application/json");
        }
    }
}
