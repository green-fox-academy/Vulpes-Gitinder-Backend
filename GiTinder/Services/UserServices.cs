using GiTinder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            string token = "";
            string[] tokenChars = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
            Random random = new Random();

            do
            {
                for (int i = 0; i < 28; i++)
                {
                    token += tokenChars[random.Next(0, tokenChars.Length)];
                }
            }
            while (_context.Users.Any(e => e.UserToken == token));

            return token;
        }
    }
}
