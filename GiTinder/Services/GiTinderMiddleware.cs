using GiTinder.Models;
using GiTinder.Models.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GiTinder.Services
{
    public class GiTinderMiddleware 
    {
        private readonly RequestDelegate _next;
        

        public GiTinderMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, UserServices userServices)
        {
            if (context.Request.Path.Value.Contains("/login"))
            {
                //if login
                // Todo: Our logic that we need to put in when the request is coming in
                Debug.Write("Hello");

                //check header if not login
                //How do I check which endpoint will be called?


                //IEnumerable<string> values;
                //if (context.Response.Headers.TryGetValue("X-GiTinder-Token", out values).isGUID ? :D)
                string Token = context.Request.Headers["X-Gitinder-token"];

                if (string.IsNullOrEmpty(Token) || Token == "tokenFailed")
                {
                    // header not ok => respond 403
                    context.Response.StatusCode = 403;
                }
                else
                {


                    User currentUser = userServices.FindUserByUserToken(Token);
                    Debug.Write(currentUser.Username);
                    //Session.SetString("username", currentUser.Username);
                    context.Items["user"] = currentUser;

                    await _next(context);
                    // Todo: Our logic that we need to put in when the response is going back
                }
            }
        }
    }
}
