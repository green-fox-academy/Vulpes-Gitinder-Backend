using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiTinder.Services
{
    public class User
    {
        static Object CreateUserFromGitApi (String username)
        {
            
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-agent", "GiTinderApp");
                

            }
        }
    }
}
