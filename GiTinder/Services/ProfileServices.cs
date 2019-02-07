using GiTinder.Data;
using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Services
{
    public class ProfileServices
    {
        private GiTinderContext _context;

        public ProfileServices()
        {
            GiTinderContext _context = new GiTinderContext();
        }

        public ProfileServices(GiTinderContext context)
        {
            _context = context;
        }
        public List<User> GetProfilesForUser(string username, int numberOfProfiles)
        {
            return (from Users in _context.Users
                    where Users.Username != username
                    select Users).OrderBy(x => Guid.NewGuid()).Take(numberOfProfiles).ToList();
        }
    }
}
