using System;
using System.Data.Entity;
using System.Linq;
using System.Xml;
using CargoManagementDataAccess.Entity.Models;

namespace CargoManagementDataAccess.Entity.Context
{
    public class CargoManagementDbContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CargoManagementDataAccess.Entity.Context.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public CargoManagementDbContext()
            : base("name=cargoDbConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<CargoOrderDetail> CargoOrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<CargoType> CargoTypes { get; set; }


        public DbSet<City> Cities { get; set; }

        public DbSet<CargoStatus> cargoStatuses { get; set; }

        //public DbSet<CargoOrderInfo> CargoOrderInfos { get; set; }  


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}