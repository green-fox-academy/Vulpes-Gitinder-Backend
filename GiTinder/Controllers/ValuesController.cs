using System;
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
    public ValuesController(GiTinderContex giTinderContex)
    {
            _giTinderContext = giTinderContex;


    }
           

         // private ActionResult<List<string>> list;
        private GiTinderContex _giTinderContext;

        //GET api/values/hello-world
        [HttpGet("hello-world")]
        public ActionResult<string> SayHello()
        {
            return "Hello, World!";
        }


        ////GET api/values/listusernames
        //[HttpGet("listusernames")]
        //public ActionResult<List<string>> ListUserNames()
        //{
        //    //ActionResult res = new ActionResult<<>>();


        //    List<string> list = new List<string>();
        //    User user1 = new User();
        //    User user2 = new User();
        //    user1.userName = "filip teply";
        //    user2.userName = "jonathan bonnin";

        //    GiTinderContext context = new GiTinderContext();
        //    context.Users.Add(user1);
        //    context.Users.Add(user2);
        //    context.SaveChanges();

        //    list.Add(item: user1.userName);
        //    list.Add(item: user2.userName);


        //    //list = list.AddAll(foreach(Setting setting : settings.UserName);

        //    return list;
        //}

       


        //[HttpPost]
        //public async Task<ActionResult<Settings>> PostSettings(Settings settings)
        //{  
        //    _giTinderContext.Settings.Add(settings);
        //    await _giTinderContext.SaveChangesAsync();
        //    return CreatedAtAction("GetSettings", settings);
        //   //ew { id = settings.Id },
        //}

        //// POST api/values/postusernames
        //[HttpPost]
        //public void PostUserName([FromBody] string UserName)
        //{

        //}

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
