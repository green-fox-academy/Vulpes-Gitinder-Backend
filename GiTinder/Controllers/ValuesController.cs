﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiTinder.Data;
using GiTinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiTinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase

    {
        private readonly GiTinderContext _context;

        public ValuesController(GiTinderContext context)
        {
            _context = context;
        }

        //GET api/values/hello-world
        [HttpGet("hello-world")]
        public ActionResult<string> SayHello()
        {
            System.Diagnostics.Debug.WriteLine("OK1 Hello!!!");
            Console.WriteLine("OK2 Hello!!!");
            return "Hello, World!";
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
