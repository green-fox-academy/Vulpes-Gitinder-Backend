using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GiTinder.Data;
using GiTinder.Models;
using System.Collections;
using Microsoft.Extensions.Logging;

namespace GiTinder.Controllers
{
    public class SettingsController : Controller
    {
        //private ILogger<SettingsController> _logger;

        //public SettingsController(ILogger<SettingsController> logger)
        //{
        //    _logger = logger;
        //}

        private GiTinderContext _context;

        public SettingsController(GiTinderContext context)
        {
            _context = context;
        }

        // GET: Settings
        [HttpGet("/settings/{username}")]
        public object GetSettings(string username)
        {
            GeneralApiResponseBody responseBody;

            if (Request.Headers["X-Gitinder-Token"] == "")
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }
            else
            {
                var settings = _context.Settings.Where(s => s.UserName == username).FirstOrDefault();
                // var settings = new Settings("Mock Filip", true, true, 160);
                //_logger.LogInformation("Mock Settings was created!" );
                return settings;
            }
        }

        [HttpPut("/settings/{username}")]
        //[ValidateAntiForgeryToken]
        public object PutSettings([FromBody]Settings settings, string username)
        {
            var set = _context.Settings.Where(s => s.UserName == username).FirstOrDefault();
            GeneralApiResponseBody responseBody;

            if (Request.Headers["X-Gitinder-Token"] == "")
            {
                responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                return StatusCode(403, responseBody);
            }

            if (settings == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (set != null)
            //{
                _context.Settings.Update(settings);
                _context.SaveChanges();
                responseBody = new OKResponseBody("ok", "success");
                return StatusCode(200, responseBody);
            //}
            
            //if (set == null)
            //{
            //_context.Settings.Add(settings);
            //_context.SaveChanges();
            //responseBody = new OKResponseBody("ok", "success");
            //return StatusCode(200, responseBody);
            //}                   
        }

        [HttpPost("/settings")]
        //[ValidateAntiForgeryToken]
        public object PostSettings([FromBody]Settings settings)
        {
            GeneralApiResponseBody responseBody;

            //if (Request.Headers["X-Gitinder-Token"] == "")
            //{
            //    Response.StatusCode = 403;
            //    responseBody = new ErrorResponseBody("error", "Unauthorized request!");
            //    return responseBody;
            //}

            if (Request.Headers["X-Gitinder-Token"] == "")
            {

                responseBody = new ErrorResponseBody("error", "Unauthorized request!");

                return StatusCode(403, responseBody);
            }

            else if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Settings.Add(settings);
            _context.SaveChanges();
            return NoContent();
        }


        //[HttpPost("/settings")]
        //public IActionResult PostSettings([FromBody] Settings settings)
        //{
        //    if(!ModelState.IsValid)
        //    {

        //        return BadRequest();
        //    }
        //    try
        //    {


        //        _context.Settings.Add(settings);

        //        System.Diagnostics.Debug.WriteLine("OK1 PostSettings!");

        //        _context.SaveChanges();

        //        System.Diagnostics.Debug.WriteLine("OK2 PostSettings!");
        //        return Ok(settings);
        //    }
        //    catch (Exception e)
        //    {

        //        System.Diagnostics.Debug.WriteLine("Error- PostSettingsException!");
        //        return StatusR
        //    }
        //}
    }
}


//using (var context = new SchoolContext())
//{
//    var std = new Student()
//    {
//        FirstName = "Bill",
//        LastName = "Gates"
//    };
//    context.Students.Add(std);

//    // or
//    // context.Add<Student>(std);

//    context.SaveChanges();
//}

//_context.Settings.Add(settings);

//_context.SaveChanges();