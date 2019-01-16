using GiTinder.Data;
using GiTinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Services
{
    public class MatchFactory
    {
        private GiTinderContext _context;

        public MatchFactory(GiTinderContext context)
        {
            _context = context;
        }

        public void CreateAndSaveMatch(string username_1, string username_2)
        {
            var newmatch = new Match(username_1, username_2);
            _context.Matches.Add(newmatch);
            _context.SaveChanges();
        }
    }
}
