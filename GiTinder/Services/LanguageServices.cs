using GiTinder.Data;
using System.Collections.Generic;
using System.Linq;

namespace GiTinder.Services
{
    public class LanguageServices
    {
        private GiTinderContext _context;

        public LanguageServices(GiTinderContext context)
        {
            _context = context;
        }

        public List<string> GetLanguageNamesListFromLanguageDb()
        {
            return _context.Languages.Select(sl => sl.LanguageName).ToList();
        }
    }
}
