namespace MeChallenge.API.Configuration.ProblemDetails
{
    using Application.Configuration.Validation;
    using FluentValidation;
    using Helpers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///     Represents errors on command model state <see cref="FluentValidation" />
    /// </summary>
    public class InvalidCommandRuleValidationExceptionProblemDetails : ProblemDetails
    {
        public InvalidCommandRuleValidationExceptionProblemDetails(InvalidCommandException exception)
        {
            Status = StatusCodes.Status400BadRequest;
            Type = nameof(InvalidCommandRuleValidationExceptionProblemDetails);
            Errors = exception.Errors.Select(x => new ProblemDetailsWrapErrors
            {
                Code = x.GetHashCode(),
                Type = Severity.Error.ToString(),
                Description = x.ErrorMessage,
                Title = x.PropertyName
            });
        }

        public IEnumerable<ProblemDetailsWrapErrors> Errors { get; }
        public new string Extensions { get; set; }
    }
}