using System.Net;
using System.ComponentModel.DataAnnotations;
using RecipeCostControl.API.Extensions;

namespace RecipeCostControl.API.Middlewares
{
    internal sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await context.Response.SendErrorMessageAsync(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
#if DEBUG
                var message = ex.Message;
#else
                const message = "Internal Server Error";
#endif
                await context.Response.SendErrorMessageAsync(HttpStatusCode.InternalServerError, message);
            }
        }
    }

}
