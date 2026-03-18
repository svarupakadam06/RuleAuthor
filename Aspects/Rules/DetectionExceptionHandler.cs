using FraudMonitoringSystem.Exceptions.Rules;
using System.Net;
using System.Text.Json;

namespace FraudMonitoringSystem.Aspects.Rules
{
    public class DetectionExceptionHandler
    {
        private readonly RequestDelegate _next;

        public DetectionExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DetectionValidationException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (DetectionNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            var response = new
            {
                error = exception.Message,
                type = exception.GetType().Name,
                timestamp = DateTime.UtcNow
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}