using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Babai.Authorization
{
    public class GoodManRequirement : IAuthorizationRequirement 
    {
    }

    public class GoodManRequirementHandler : AuthorizationHandler<GoodManRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GoodManRequirement requirement)
        {
            if (context.User.HasClaim("goodMan", "true")) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }


}
