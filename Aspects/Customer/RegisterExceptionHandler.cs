using FraudMonitoringSystem.Exceptions;
using FraudMonitoringSystem.Exceptions.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FraudMonitoringSystem.Aspects.Customer
{
    /// <summary>
    /// Exception filter for handling registration-related exceptions.
    /// </summary>
    public class RegisterExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case RegisterUserAlreadyExistsException ex:
                    context.Result = new ConflictObjectResult(new
                    {
                        Error = ex.Message,
                        Type = "RegisterUserAlreadyExists"
                    });
                    break;

                case RegisterUserNotFoundException ex:
                    context.Result = new NotFoundObjectResult(new
                    {
                        Error = ex.Message,
                        Type = "RegisterUserNotFound"
                    });
                    break;

                case RegisterValidationException ex:
                    context.Result = new BadRequestObjectResult(new
                    {
                        Error = ex.Message,
                        Type = "RegisterValidationError"
                    });
                    break;

                case RegisterDatabaseException ex:
                    context.Result = new ObjectResult(new
                    {
                        Error = ex.Message,
                        Type = "RegisterDatabaseError"
                    })
                    { StatusCode = 500 };
                    break;

                case RegisterDuplicateRecordException ex:
                    context.Result = new ConflictObjectResult(new
                    {
                        Error = ex.Message,
                        Type = "RegisterDuplicateRecord"
                    });
                    break;

                default:
                    context.Result = new ObjectResult(new
                    {
                        Message = context.Exception.Message,
                        ExceptionType = context.Exception.GetType().Name,
                        Timestamp = DateTime.UtcNow
                    })
                    { StatusCode = 500 };
                    break;
            }

            context.ExceptionHandled = true;
        }
    }
}
