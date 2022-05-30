namespace MeChallenge.API.Configuration.ProblemDetails.Helpers
{
    using Application.Configuration.Validation;
    using Infrastructure.Logs;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Text.Json;

    /// <summary>
    ///     Filters any exception from the application
    /// </summary>
    public class ProblemDetailsFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;
            switch (exception)
            {
                case NotFoundException notFoundException:
                    Log.Warning(notFoundException);
                    break;
                case InvalidCommandException commandException:
                    Log.Error(commandException.Errors);
                    break;
                case JsonException jsonException:
                    Log.Error(jsonException);
                    break;
                default:
                    Log.Error(exception);
                    break;
            }
        }
    }
}