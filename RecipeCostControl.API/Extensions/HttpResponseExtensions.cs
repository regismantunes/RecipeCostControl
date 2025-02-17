using RecipeCostControl.Data.Dto;
using System.Net;
using System.Text.Json;

namespace RecipeCostControl.API.Extensions
{
    internal static class HttpResponseExtensions
    {
        public static async Task SendErrorMessageAsync(this HttpResponse response, HttpStatusCode httpStatus, string message)
        {
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatus;

            var responseDto = new ErrorMessageDto(message);
            await response.WriteAsync(JsonSerializer.Serialize(responseDto));
        }
    }
}
