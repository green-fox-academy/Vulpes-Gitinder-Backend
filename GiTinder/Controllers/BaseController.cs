using GiTinder.Models;
using GiTinder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
        public User GetCurrentUser()
        {
            return HttpContext.Items["user"] as User;
        }
    }

}
