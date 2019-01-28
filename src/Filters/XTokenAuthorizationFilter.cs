
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayloadPost.Filters
{
    public sealed class XTokenAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _xToken;

        public XTokenAuthorizationFilter(string xToken)
        {
            this._xToken = xToken;
        }      

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            StringValues xTokenList;
            if (context.HttpContext.Request.Headers.TryGetValue("x-token", out xTokenList) == false)
            {
                throw new UnauthorizedAccessException("Request header has not a x-token.");
            }

            string xToken = xTokenList.Single();
            if (this._xToken != xToken)
            {
                throw new UnauthorizedAccessException("Invalid x-token.");
            }
        }
    }
}
