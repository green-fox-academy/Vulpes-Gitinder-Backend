using GiTinder.Data;
using System;
using System.Linq;

namespace GiTinder.Services
{
    public class UserServices
    {
        private readonly GiTinderContext _context;

        public UserServices(GiTinderContext context)
        {
            _context = context;
        }

        public string CreateGiTinderToken()
        {
            string token;

            do
            {
                token = Guid.NewGuid().ToString();
            }
            while (_context.Users.Where(e => e.UserToken == token).Count() > 0);

            return token;
        }
    }
}

