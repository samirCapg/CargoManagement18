namespace CargoManagementDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedalltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        CargoId = c.Int(nullable: false, identity: true),
                        CargoName = c.String(nullable: false),
                        Place = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        CargoTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CargoId)
                .ForeignKey("dbo.CargoTypes", t => t.CargoTypeId, cascadeDelete: true)
                .Index(t => t.CargoTypeId);
            
            CreateTable(
                "dbo.CargoTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Weight = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        ExtraWeight = c.Double(nullable: false),
                        ExtraPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CargoOrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderId = c.String(nullable: false),
                        ReceiverName = c.String(nullable: false),
                        ReceiverEmail = c.String(),
                        ReceiverPhoneNo = c.String(),
                        IsAccepted = c.Boolean(nullable: false),
                        CargoStatusId = c.Int(nullable: false),
                        CustId = c.Int(nullable: false),
                        CargoTypeId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        CargoStatus_StatusId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CargoStatus", t => t.CargoStatus_StatusId)
                .ForeignKey("dbo.CargoTypes", t => t.CargoTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustId, cascadeDelete: true)
                .Index(t => t.CustId)
                .Index(t => t.CargoTypeId)
                .Index(t => t.CityId)
                .Index(t => t.CargoStatus_StatusId);
            
            CreateTable(
                "dbo.CargoStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 50),
                        Pincode = c.Int(nullable: false),
                        Country = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        CustName = c.String(),
                        CustAddress = c.String(),
                        CustPhNo = c.String(),
                        CustEmail = c.String(nullable: false),
                        CustPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        EmpName = c.String(),
                        EmpPhNo = c.String(),
                        EmpEmail = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsApproved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CargoOrderDetails", "CustId", "dbo.Customers");
            DropForeignKey("dbo.CargoOrderDetails", "CityId", "dbo.Cities");
            DropForeignKey("dbo.CargoOrderDetails", "CargoTypeId", "dbo.CargoTypes");
            DropForeignKey("dbo.CargoOrderDetails", "CargoStatus_StatusId", "dbo.CargoStatus");
            DropForeignKey("dbo.Cargoes", "CargoTypeId", "dbo.CargoTypes");
            DropIndex("dbo.CargoOrderDetails", new[] { "CargoStatus_StatusId" });
            DropIndex("dbo.CargoOrderDetails", new[] { "CityId" });
            DropIndex("dbo.CargoOrderDetails", new[] { "CargoTypeId" });
            DropIndex("dbo.CargoOrderDetails", new[] { "CustId" });
            DropIndex("dbo.Cargoes", new[] { "CargoTypeId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Cities");
            DropTable("dbo.CargoStatus");
            DropTable("dbo.CargoOrderDetails");
            DropTable("dbo.CargoTypes");
            DropTable("dbo.Cargoes");
            DropTable("dbo.Admins");
        }
    }
}
