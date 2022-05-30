namespace MeChallenge.Infrastructure.Domain
{
    using Autofac;
    using Microsoft.Extensions.Configuration;

    public class DomainModule : Module
    {
        private readonly IConfiguration _configuration;

        public DomainModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}