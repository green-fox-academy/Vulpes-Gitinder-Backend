using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiTinder.Tests.Controllers
{
    class ErrorResponseBodyFactory
    {
        public static ErrorResponseBody CreateErrorResponseBody()
        {
            return new ErrorResponseBody("error", "Unauthorized request!");
        }
    }
}
