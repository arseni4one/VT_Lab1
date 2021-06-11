using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VT_Lab1.Middleware;


namespace VT_Lab1.Middleware
{
    public static class appExtensions
    {
        public static IApplicationBuilder UseFileLogging(this
            IApplicationBuilder app)
             => app.UseMiddleware<LogMiddleware>();
    }
}
