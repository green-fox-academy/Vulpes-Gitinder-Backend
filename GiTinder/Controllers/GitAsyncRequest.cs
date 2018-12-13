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
        [HttpGet("getUser")]
        public async Task<User> GetProductAsync()
        {
            HttpClient client = new HttpClient();
            User rawUser = null;
            HttpResponseMessage response = await client.GetAsync("https://api.github.com/repos/Riceqrisp/Career-pivot");
            if (response.IsSuccessStatusCode)
            {
                rawUser = await response.Content.ReadAsAsync<User>();
            }
            return rawUser;
        }
    }
}

