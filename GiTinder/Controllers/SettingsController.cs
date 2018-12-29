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

namespace GiTinder.Controllers
{
    public class SettingsController : ControllerBase
    {
        private readonly GiTinderContext _context;

        public SettingsController(GiTinderContext context)
        {
            _context = context;
        }

        // GET: Settings
        [HttpGet("/settings")]
        public object GetSettings()
        {
            var settings = new Settings("Mock Filip", true, true, 160);
            
            System.Diagnostics.Debug.WriteLine("OK GETsettings!");
            return settings;
        }

        [HttpPost("/settings")]
        public IActionResult PostSettings([FromBody] Settings settings)
        {
            if(!ModelState.IsValid)
            {

                return BadRequest();
            }
            try
            {


                _context.Settings.Add(settings);
                
                System.Diagnostics.Debug.WriteLine("OK1 PostSettings!");

                _context.SaveChanges();
                
                System.Diagnostics.Debug.WriteLine("OK2 PostSettings!");
                return Ok(settings);
            }
            catch (Exception e)
            {
                
                System.Diagnostics.Debug.WriteLine("Error- PostSettingsException!");
                return StatusR
            }
        }
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