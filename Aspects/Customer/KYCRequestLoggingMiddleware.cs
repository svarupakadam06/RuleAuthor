namespace FraudMonitoringSystem.Aspects.Customer
{
    public class KYCRequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public KYCRequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Only log requests hitting the KYC API endpoints
            if (context.Request.Path.StartsWithSegments("/api/KYCProfiles"))
            {
                Console.WriteLine($"[KYC LOG] {DateTime.Now}: {context.Request.Method} {context.Request.Path}");
            }

            await _next(context);
        }
    }

    public static class KYCRequestLoggingExtensions
    {
        public static IApplicationBuilder UseKYCRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<KYCRequestLoggingMiddleware>();
        }
    }
}

