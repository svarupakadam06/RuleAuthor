using FraudMonitoringSystem.Exceptions.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FraudMonitoringSystem.Aspects.Customer
{
    public class ExceptionHandlers : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {

                case UserAlreadyExistsException ex:
                    context.Result = new ConflictObjectResult(new { Error = ex.Message, Type = "UserAlreadyExists" });
                    break;
                case UserNotFoundException ex:
                    context.Result = new NotFoundObjectResult(new { Error = ex.Message, Type = "NotFoundError" });
                    break;

                case ValidationException ex:
                    context.Result = new BadRequestObjectResult(new { Error = ex.Message, Type = "ValidationError" });
                    break;

                case DatabaseException ex:
                    context.Result = new ObjectResult(new { Error = ex.Message, Type = "DatabaseError" }) { StatusCode = 500 };
                    break;

                case DuplicateRecordException ex:
                    context.Result = new ConflictObjectResult(new { Error = ex.Message, Type = "DuplicateError" });
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
