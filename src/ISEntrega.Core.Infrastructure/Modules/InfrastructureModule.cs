﻿namespace ISEntrega.Core.Infrastructure.Modules
{
    using Autofac;
    using ISEntrega.Core.Infrastructure.Mappings;
    using ISEntrega.Core.Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;

    public class InfrastructureModule : Autofac.Module
    {
        public string SQLServerConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
                optionsBuilder.UseSqlServer(SQLServerConnectionString);
                optionsBuilder.EnableSensitiveDataLogging(true);

            builder.RegisterType<Context>()
              .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
              .InstancePerLifetimeScope();

            //
            // Register all Types in ISEntrega.Core.Infrastructure
            //
            builder.RegisterAssemblyTypes(typeof(ResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
