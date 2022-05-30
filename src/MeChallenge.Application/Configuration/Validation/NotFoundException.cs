namespace MeChallenge.Application.Configuration.Validation
{
    using System;

    /// <summary>
    ///     Represents when Mongo Db not found any result
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string details) : base(details)
        {
            Details = details;
        }

        public string Details { get; }
    }
}