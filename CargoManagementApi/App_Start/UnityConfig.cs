using CargoManagementApi.Repositories.AdminRepository;
using CargoManagementApi.Repositories.EmployeeRepository.CargoManagementApi.Repositories.EmployeeRepository;
using CargoManagementApi.Repositories.EmployeeRepository;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using CargoManagementApi.Repositories.CustomerRepository;
using CargoManagementApi.Repositories.CitiesRepository;
using CargoManagementApi.Repositories;
using CargoManagementApi.Repositories.ProductsRepository;
using CargoManagementApi.Repositories.CargoStatusesRepository;
using CargoManagementApi.Repositories.CargoOrderDetailsRepository;

namespace CargoManagementApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //RegisterComponents Depenencies
            container.RegisterType<IAdminRepository, AdminRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEmployeeRepository, EmployeeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerRepository, CustomerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICityRepository, CityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICargoRepository, CargoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICargoTypeRepository, CargoTypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICargoStatusRepository, CargoStatusRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICargoOrderDetailRepository, CargoOrderDetailRepository>(new HierarchicalLifetimeManager());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);


        }
    }
}