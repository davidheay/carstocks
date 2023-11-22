using Microsoft.AspNetCore.Authorization;

namespace carstocks.utils;

public class SameDealerHandler : AuthorizationHandler<SameDealerRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameDealerRequirement requirement)
    {
        if (context.Resource is DefaultHttpContext mvcContext)
        {
            if (mvcContext.GetRouteData().Values.TryGetValue("dealerId", out var dealerIdFromPath))
            {
                var dealerIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == "dealerId");

                if (dealerIdClaim != null && dealerIdFromPath.ToString() == dealerIdClaim.Value)
                {
                    context.Succeed(requirement);
                }
            }
        }

        return Task.CompletedTask;
    }
}
