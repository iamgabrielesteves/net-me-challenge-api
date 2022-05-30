namespace MeChallenge.Infrastructure.Logs
{
    using Autofac;
    using MeChallenge.Domain.SeedWorks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;
    using Serilog;

    public class LogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new ConsoleLifetimeOptions {SuppressStatusMessages = true})
                .As<ConsoleLifetimeOptions>();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();

            builder.RegisterType<Logging>().As<ILogging>();

            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}