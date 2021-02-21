using Autofac;
using Joachim_Johnson_ConsidAplication.Controllers.DataAcess.StoreContext;
using Joachim_Johnson_ConsidAplication.Controllers.Functions.StoreContext;
using Joachim_Johnson_ConsidAplication.Models;
using Joachim_Johnson_ConsidAplication.Servises.Functions.CompanyContext;
using Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext;
using Joachim_Johnson_ConsidAplication.Servises.Functions.StoreContext.Interfaces;
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

            // Company related services
            builder.RegisterType<Create>().As<ICreate>(); 
            builder.RegisterType<LoadCompanies>().As<ILoadCompanies>();
            builder.RegisterType<LoadSpecifikCompany>().As<ILoacSpecifikCompany>(); 
            builder.RegisterType<DeleteCompany>().As<IDeleteCompany>();

            // Store related
            builder.RegisterType<EditStore>().As<IEditStore>();
            builder.RegisterType<CreateStore>().As<ICreateStore>();
            builder.RegisterType<LoadStores>().As<IloadStores>();
            builder.RegisterType<LoadSpecificStore>().As<ILoadSpecifikStore>();


            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DataLayer)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}