using Autofac;

namespace Template.DAL.Autofac
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(DatabaseContext)).As(typeof(DatabaseContext)).InstancePerLifetimeScope();

        }

    }
}
