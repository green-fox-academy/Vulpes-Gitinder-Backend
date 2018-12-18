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
        [HttpGet("username")]

        //async method is used everytime something should take long time like for requesting for data await allows certain line to run independently.
        //if user doesn't exist in github then it shouldnt respond
        public async Task<User> GetUserAsync()
        {
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Clear() to clear headers being sure that it should only have requested headers. Learning
            //
            //Gihub API needs to track requests through header User Agent (https://developer.github.com/v3/#user-agent-required).
            client.DefaultRequestHeaders.Add("User-Agent", "frog");
            User rawUser = null;
            Object json = null;
            HttpResponseMessage response = await client.GetAsync("https://api.github.com/users/Riceqrisp");
            if (response.IsSuccessStatusCode)
            {
                rawUser = await response.Content.ReadAsAsync<User>();
                json = await response.Content.ReadAsAsync<Object>();
            }
            return rawUser;
        }
    }
}

