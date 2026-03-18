using FraudMonitoringSystem.Exceptions.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FraudMonitoringSystem.Aspects.Customer
{
    public class AccountExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case AccountAlreadyExistsException ex:
                    context.Result = new ConflictObjectResult(new { Error = ex.Message, Type = "AccountAlreadyExists" });
                    break;

                case AccountNotFoundException ex:
                    context.Result = new NotFoundObjectResult(new { Error = ex.Message, Type = "AccountNotFound" });
                    break;

                case AccountValidationException ex:
                    context.Result = new BadRequestObjectResult(new { Error = ex.Message, Type = "ValidationError" });
                    break;

                case AccountDatabaseException ex:
                    context.Result = new ObjectResult(new { Error = ex.Message, Type = "DatabaseError" }) { StatusCode = 500 };
                    break;

                case DuplicateAccountException ex:
                    context.Result = new ConflictObjectResult(new { Error = ex.Message, Type = "DuplicateAccount" });
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
