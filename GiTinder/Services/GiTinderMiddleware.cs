using GiTinder.Models;
using GiTinder.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
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
            if (!context.Request.Path.Value.Contains("/login"))
            {
                string Token = context.Request.Headers["X-Gitinder-token"];

                if (string.IsNullOrEmpty(Token) || !userServices.TokenExists(Token))
                {
                    ErrorResponseBody responseBody = new ErrorResponseBody("error", "Unauthorized request!");
                    Log.Information("New ErrorResponseBody: {@ErrorResponseBody} was created", responseBody);
                    context.Response.StatusCode = 403;
                    context.Response.WriteAsync(JsonConvert.SerializeObject(responseBody));
                    return;
                }
                else
                {
                    User currentUser = userServices.FindUserByUserToken(Token);
                    context.Items["user"] = currentUser;
                }
            }
            await _next(context);
        }
    }
}
