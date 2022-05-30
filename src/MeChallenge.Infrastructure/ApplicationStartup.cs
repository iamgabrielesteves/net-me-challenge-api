namespace MeChallenge.Infrastructure
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Autofac.Extras.CommonServiceLocator;
    using CommonServiceLocator;
    using Database;
    using Domain;
    using InProc;
    using Logs;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class ApplicationStartup
    {
        public static IServiceProvider Initialize(
            IServiceCollection services,
            IConfiguration configuration)
        {
            IServiceProvider serviceProvider = CreateAutofacServiceProvider(services, configuration);
            return serviceProvider;
        }

        private static IServiceProvider CreateAutofacServiceProvider(
            IServiceCollection services,
            IConfiguration configuration)
        {
            ContainerBuilder container = new();

            container.Populate(services);

            container.RegisterModule(new DatabaseModule(configuration.GetConnectionString("Default")));
            container.RegisterModule(new InProcModule(configuration));
            container.RegisterModule(new DomainModule(configuration));
            container.RegisterModule(new LogModule());

            IContainer buildContainer = container.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));
            AutofacServiceProvider serviceProvider = new(buildContainer);
            return serviceProvider;
        }
    }
}