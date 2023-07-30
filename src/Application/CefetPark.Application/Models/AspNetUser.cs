using CefetPark.Domain.Interfaces.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CefetPark.Application.Models
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


        public string ObterRoleDoUsuario()
        {
            return _accessor.HttpContext.User.ObterRoleDoUsuario();
        }

        public int ObterUsuarioId()
        {
            return _accessor.HttpContext.User.ObterUsuarioId();
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static int ObterUsuarioId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("Id");
            if(claim == null) throw new Exception("Id não Encontrado no Token");

            return int.Parse(claim?.Value);
        }

        public static string ObterRoleDoUsuario(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var roles = principal.FindFirst(ClaimTypes.Role);
            if (roles == null) throw new Exception("Role não encontrada no Token");


            return roles?.Value;
        }
    }
}
