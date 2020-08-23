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
        public static void Throw()
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    }
}
