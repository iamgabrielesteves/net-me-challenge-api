namespace MeChallenge.Infrastructure.Database
{
    using Application.Configuration.Data;
    using Autofac;
    using Domain;
    using Domain.Orders;
    using Domain.Products;
    using MeChallenge.Domain.AggregatesModels.Order;
    using MeChallenge.Domain.AggregatesModels.Product;
    using MeChallenge.Domain.SeedWorks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
    using SeedWork;

    public class DatabaseModule : Module
    {
        private readonly string _databaseConnectionString;

        public DatabaseModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConnectionsFactory>()
                .As<IConnectionFactory>()
                .WithParameter("databaseConnectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder
                .Register(_ =>
                {
                    DbContextOptionsBuilder<MeChallengeContext> dbContextOptionsBuilder = new();
                    dbContextOptionsBuilder.UseNpgsql(_databaseConnectionString);
                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new MeChallengeContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}