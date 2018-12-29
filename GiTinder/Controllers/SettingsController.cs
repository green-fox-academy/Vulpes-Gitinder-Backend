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
    public class SettingsController : Controller
    {
        private GiTinderContext _context;

        public SettingsController(GiTinderContext context)
        {
            _context = context;
        }

        // GET: Settings
        [HttpGet("/settings")]
        public object GetSettings()
        {
            var settings = new Settings("Mock Filip", true, true, 160);
            return settings;
        }

        [HttpPost("/settings")]
        public void PostSettings([FromBody] Settings settings)
        {

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

            _context.Settings.Add(settings);

            _context.SaveChanges();
        }
    }
}
