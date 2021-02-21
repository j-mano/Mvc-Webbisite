using Autofac;
using Joachim_Johnson_ConsidAplication.Models;
using Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext;
using System.Linq;
using System.Reflection;
using static Joachim_Johnson_ConsidAplication.Aplication;

namespace Joachim_Johnson_ConsidAplication.Interfaces
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IAplication>();
            builder.RegisterType<CordinatesModells>().As<ICordinatesModells>();
            builder.RegisterType<Create>().As<ICreate>(); 
            builder.RegisterType<LoadCompanies>().As<ILoadCompanies>();


            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DataLayer)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}