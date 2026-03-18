using FraudMonitoringSystem.Exceptions;
using FraudMonitoringSystem.Exceptions.Admin;
using System.Net;
using System.Text.Json;

namespace FraudMonitoringSystem.Aspects.Admin
{
    public class GlobalExceptionHandler

    {

        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)

        {

            _next = next;

        }

        public async Task Invoke(HttpContext context)

        {

            try

            {

                await _next(context);

            }

            catch (InvalidRoleException ex)

            {

                await HandleException(context, HttpStatusCode.BadRequest, ex.Message);

            }

            catch (RoleNotFoundException ex)

            {

                await HandleException(context, HttpStatusCode.NotFound, ex.Message);

            }

            catch (Exceptions.RoleAlreadyExistsException ex)

            {

                await HandleException(context, HttpStatusCode.Conflict, ex.Message);

            }

            catch (Exception)

            {

                await HandleException(context, HttpStatusCode.InternalServerError, "Internal Server Error");

            }

        }

        private static async Task HandleException(HttpContext context, HttpStatusCode statusCode, string message)

        {

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new

            {

                status = (int)statusCode,

                error = message

            });

            await context.Response.WriteAsync(result);

        }

    }

}