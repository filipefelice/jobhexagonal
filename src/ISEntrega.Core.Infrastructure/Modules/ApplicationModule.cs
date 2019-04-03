namespace ISEntrega.Core.Infrastructure.Modules
{
    using Autofac;
    using ISEntrega.Core.Application;

    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in ISEntrega.Core.Application
            //
            builder.RegisterAssemblyTypes(typeof(IResultConverter).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
