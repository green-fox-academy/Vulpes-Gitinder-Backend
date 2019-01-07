using GiTinder.Data;
using GiTinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        //async method is used everytime something should take long time like for requesting for data await allows certain line to run independently.
        //if user doesn't exist in github then it shouldnt respond
        public async Task<User> GetUserAsync(string username)
        {
    
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Clear() to clear headers being sure that it should only have requested headers. Learning
            //Gihub API needs to track requests through header User Agent (https://developer.github.com/v3/#user-agent-required).
            client.DefaultRequestHeaders.Add("User-Agent", "GiTinderApp");
            User rawUser = null;

            HttpResponseMessage responseUser = await client.GetAsync("https://api.github.com/users/" + username);
            if (responseUser.IsSuccessStatusCode)
            {
                rawUser = await responseUser.Content.ReadAsAsync<User>();
                _context.Users.Add(rawUser);
                _context.SaveChanges();
            }
            return rawUser;
        }
    }
}



