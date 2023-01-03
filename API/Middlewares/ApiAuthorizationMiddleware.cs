using Adapters.Context;
using Adapters.Services.Settings.Users;
using Domain.Extensions;
using DTO.Settings.Users;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace API.Middlewares
{
    public class ApiAuthorizationMiddleware : IMiddleware
    {
        private readonly IUserService _userService;
        private readonly ISessionContext _sessionContext;

        public ApiAuthorizationMiddleware(IUserService userService, ISessionContext sessionContext)
        {
            _userService = userService;
            _sessionContext = sessionContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (IsRouteAllowedToAnonymous(context))
            {
                await next(context);
                return;
            }

            var claims = GetRequiredClaims(context.User);

            if (string.IsNullOrWhiteSpace(claims.subjectId))
            {
                await ToContextResponse(context, HttpStatusCode.Forbidden, string.Empty);
                return;
            }

            var user = _userService.GetBySubjectIdAsync(claims.subjectId ?? string.Empty).Result;

            var expiredIn = claims.expiredIn != null ? long.Parse(claims.expiredIn) : 0;

            if (!string.IsNullOrEmpty(claims.subjectId))
            {
                SetFirebaseToContext(claims.subjectId, context.User.FindFirstValue(ClaimTypes.Email));
            }

            if (IsAuthenticated(context) && IsTokenExpired(user, expiredIn))
            {
                await ToContextResponse(context, HttpStatusCode.Unauthorized, "api-exception-expired-token");
                return;
            }

            if (IsAuthenticated(context) && user != null)
            {
                _sessionContext.SetToken(await context.GetTokenAsync("access_token"));

                await SetUserToContextAndContinue(context, next, user);
                return;
            }

            await ToContextResponse(context, HttpStatusCode.Forbidden, "api-exception-unauthorized");
        }

        private static bool IsRouteAllowedToAnonymous(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            return endpoint?.Metadata.GetMetadata<IAllowAnonymous>() is not null;
        }

        private static bool IsAuthenticated(HttpContext context)
        {
            return context.User.Identity?.IsAuthenticated ?? false;
        }

        private void SetFirebaseToContext(string? subjectId, string? email)
        {
            _sessionContext.SetFirebase(new(subjectId, email));
        }

        private async Task SetUserToContextAndContinue(
            HttpContext context,
            RequestDelegate next,
            CompactUserDTO? user)
        {
            if (user != null)
            {
                _sessionContext.SetUser(user);
            }

            await next(context);
        }

        private static bool IsTokenExpired(CompactUserDTO? user, long expiredIn)
        {
            return user != null
                   && expiredIn != 0
                   && IsTokenExpired(expiredIn.ToDateTime());
        }

        private static async Task ToContextResponse(
            HttpContext context,
            HttpStatusCode statusCode,
            string messageError = "")
        {
            context.Response.StatusCode = (int) statusCode;
            await context.Response.WriteAsync(messageError);
        }

        private static bool IsTokenExpired(DateTime dateTime)
        {
            return dateTime <= DateTime.Now.AddMinutes(-1);
        }

        private static (string? expiredIn, string? subjectId) GetRequiredClaims(ClaimsPrincipal user)
            => (user.FindFirst("exp")?.Value,
                user.FindFirst("user_id")?.Value);
    }
}