using CalidadT2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CalidadT2.Services
{
    public interface ICookieAuthService
    {
        void SetHttpContext(HttpContext httpContext);
        public void SetSessionContext(Usuario usuariodb);
        public void Login(ClaimsPrincipal claim);
        public Claim GetClaim();
        public void LogOut();
    }

    public class CookieAuthService : ICookieAuthService
    {
        private HttpContext httpContext;

        public void SetHttpContext(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }
        public void SetSessionContext(Usuario usuariodb)
        {
            httpContext.Session.SetString("LoggedUser", usuariodb.Nombres);
        }
        public void Login(ClaimsPrincipal claim)
        {
            httpContext.SignInAsync(claim);

        }
        public Claim GetClaim()
        {
            var claim = httpContext.User.Claims.FirstOrDefault();
            return claim;
        }
        public void LogOut()
        {
            httpContext.SignOutAsync();
        }
    }
}
