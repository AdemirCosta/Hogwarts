using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Core.Exceptions
{
    public static class BadRequestException
    {
        public static void Throw(string message = "")
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(message)
            };

            //throw new HttpResponseException(response);
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    }
}
