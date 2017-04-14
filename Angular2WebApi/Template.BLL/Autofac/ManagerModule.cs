using System;
using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Template.BLL.Autofac
{
    public class ManagerModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name))
                      .Where(t => t.Name.EndsWith("Manager"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();
        }

    }
}
