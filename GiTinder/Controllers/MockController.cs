﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Models;
using GiTinder.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiTinder.Controllers
{
    [Route("api/[controller]")]
    public class MockController : Controller
    {
        private MockLoginContext _loginItem;

        public MockController(MockLoginContext loginItem)
        {
            _loginItem = loginItem;
           // _loginItem.LoginItems.Add(new MockLoginItem {  });
            //_loginItem.SaveChanges();

           

        }


        [HttpPost("/login")]
        public IActionResult Res([FromBody]MockLoginItem item, MockResponse response, MockErrorMessage errorMessage)
        {

            if (item != null)
            {
                return new ObjectResult(response);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,errorMessage);
              

            }
        }
        

    }
}
