using GiTinder.Data;
using GiTinder.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiTinder.Controllers
{
    [Route("test")]
    [ApiController]
    public class GitAsyncRequest
    {
        private readonly GiTinderContext _context;

        public UsersController(GiTinderContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]

        //async method is used everytime something should take long time like for requesting for data await allows certain line to run independently.
        //if user doesn't exist in github then it shouldnt respond
        public async Task<User> GetUserAsync(User user, string username)
        {
            //User test1 = new User;
            //User.getuser by id pass it to the 
            _context.
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Clear() to clear headers being sure that it should only have requested headers.
            client.DefaultRequestHeaders.Add("User-Agent", "frog");
            User rawUser = null;
            HttpResponseMessage response = await client.GetAsync("https://api.github.com/repos/"+ /*username*/ + "/Career-pivot");
            if (response.IsSuccessStatusCode)
            {
                rawUser = await response.Content.ReadAsAsync<User>();
            }
            return rawUser;
        }
    }
}

