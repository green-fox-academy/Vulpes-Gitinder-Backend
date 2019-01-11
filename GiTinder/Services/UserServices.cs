using GiTinder.Data;
using GiTinder.Models;
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

        public virtual string CreateGiTinderToken()
        {
            string token;

            do
            {
                token = Guid.NewGuid().ToString();
            }
            while (_context.Users.Where(e => e.UserToken == token).Count() > 0);

            return token;
        }

        public virtual bool UserExists(string username)
        {
            return _context.Users.Where(e => e.Username == username).Count() > 0;
        }

        public virtual void UpdateToken(string username)
        {
            _context.Find<User>(username).UserToken = CreateGiTinderToken();
            _context.SaveChanges();
        }

        public virtual void CreateNewUser(string username)
        {
            var newProfile = new User(username)
            {
                UserToken = CreateGiTinderToken()
            };
            _context.Users.Add(newProfile);
            _context.SaveChanges();
        }

        public virtual void UpdateUser(string username)
        {
            if (UserExists(username))
            {
                UpdateToken(username);
            }
            else
            {
                CreateNewUser(username);
            }
        }

        public virtual string GetTokenOf(string username)
        {
            return _context.Find<User>(username).UserToken;
        }
    }
}

