using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HotelManagement.MiddleWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IBaseRepository<TaiKhoan> _taiKhoanRepo)
        {
            var path = httpContext.Request.Path;
            if (path.Value.StartsWith("/account/login") || path.Value.StartsWith("/account/forgot_password"))
            {
                return _next(httpContext);
            }
            else
            {
                if (httpContext.Session.GetString("account_info") == null)
                {
                    httpContext.Response.Redirect("/account/login");
                }
                else
                {
                    var acc = JsonConvert.DeserializeObject<Account>(httpContext.Session.GetString("account_info"));
                    var curAcc = _taiKhoanRepo.GetAll().ToList().SingleOrDefault(i => i.TaiKhoan1 == acc.tai_khoan);

                    if ( !(path.Value.StartsWith("/service/get_service_by_id")) && path.Value.StartsWith("/service") || path.Value.StartsWith("/account/register") || path.Value.StartsWith("/account/register") || path.Value.StartsWith("/roomtype") || path.Value.StartsWith("/account/index"))
                    {
                        if (!curAcc.ChucVu.Equals("Quản lý"))
                        {
                            httpContext.Response.Redirect("/Error/403");
                        }
                    }
                   
                    if (path.Value.StartsWith("/room") && !(path.Value.StartsWith("/roomtype")))
                    {
                        if (!curAcc.ChucVu.Equals("Lễ tân"))
                        {
                            httpContext.Response.Redirect("/Error/403");
                        }
                    }
                    if (path.Value.StartsWith("/receiption/index") || path.Value.StartsWith("/receiption/delete"))
                    {
                        if (!curAcc.ChucVu.Equals("Thu ngân"))
                        {
                            httpContext.Response.Redirect("/Error/403");
                        }
                    }
                }
                return _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
