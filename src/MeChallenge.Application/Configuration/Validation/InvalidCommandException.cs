namespace MeChallenge.Application.Configuration.Validation
{
    using FluentValidation.Results;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     Represents any errors from command model
    /// </summary>
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message, List<ValidationFailure> errors) : base(message)
        {
            Errors = errors;
        }

        public List<ValidationFailure> Errors { get; }
    }
}