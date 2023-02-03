using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RusMProject.WebAPI
{
    public class ResponseGenerator
    {
        public static IActionResult CreateResponse(HttpStatusCode httpStatusCode,object text)
        {
            var response = new ObjectResult(text);
            response.StatusCode = (int)httpStatusCode;

            return response;
        }
    }
}
