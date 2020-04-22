using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFFApi.Extensions
{
    public static class ExtensionMethods
    {
        // Extension method to check if user is admin. Not entirely used so far. 
        public static bool IsAdmin(this HttpContext httpContext)
        {
            if(httpContext.User == null)
            {
                return false;
            }

            if(httpContext.User.Claims.Single(x => x.Type == "UserRole").Value == null)
            {
                return false;
            }

            return httpContext.User.Claims.Single(x => x.Type == "UserRole").Value == "Admin";
        }
    }
}
