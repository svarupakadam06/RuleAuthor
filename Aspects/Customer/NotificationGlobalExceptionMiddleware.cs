using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace FraudMonitoringSystem.Models.Customer
{
    public class NotificationGlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public NotificationGlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotificationBusinessException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
            }
            catch (NotificationNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(context, "An unexpected error occurred.", HttpStatusCode.InternalServerError);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                error = message,
                status = statusCode.ToString()
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
