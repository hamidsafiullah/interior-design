using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using InteriorDesign.Utils;

namespace InteriorDesign.Filters
{
    public class TokenAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IAuthService _authService;

        public TokenAuthorizationAttribute(IAuthService authService)
        {
            _authService = authService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Extract the token from the request header
            string token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token) || !_authService.IsTokenValid(token))
            {
                // Token is missing, invalid, or expired, return an unauthorized response
                context.Result = new UnauthorizedResult();
            }
        }
    }

}
