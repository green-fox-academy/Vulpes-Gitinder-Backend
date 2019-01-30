﻿using GiTinder.Data;
using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Services
{
    public class ProfileService
    {
        private GiTinderContext _context;
        //public IQueryable<User> RandomProfiles { get; set; }
        public ProfileService(GiTinderContext context)
        {
            _context = context;
        }
        //public void Returns20Profiles(GiTinderContext context, User username)
        //{
        //    var random20 = _context.Users.OfType<DataRow>().Shuffle(new Random()).Take(20);

        //}
        public List<User> ReturnNProfilesRandomly(string username, int numberOfProfiles)
        {
            //assigning found user to exclude from database
            //var foundUser = _context.Users.Where(u => u.Username == username).FirstOrDefault();

            return (from Users in _context.Users
                    where Users.Username != username
                    select Users).OrderBy(x => Guid.NewGuid()).Take(numberOfProfiles).ToList(); 
        }
        public void testOnReturn()
        {
            var test = ReturnNProfilesRandomly("two",25);
            
            string combindedTest= string.Join(";",test);

            Debug.Write(combindedTest);
        }
    }
}
