namespace BankingUoW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        DateOfCreation = c.DateTime(nullable: false),
                        CurrencyType = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BankAccountId)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.BankId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        DateOfCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.BankAvilableCurrencyTypes",
                c => new
                    {
                        BankAvilableCurrencyTypeId = c.Int(nullable: false, identity: true),
                        BankId = c.Int(nullable: false),
                        CurrencyType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankAvilableCurrencyTypeId)
                .ForeignKey("dbo.Banks", t => t.BankId, cascadeDelete: true)
                .Index(t => t.BankId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        DateOfCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        TransferId = c.Int(nullable: false, identity: true),
                        BankAccountId = c.Int(nullable: false),
                        TargetBankAccountId = c.Int(nullable: false),
                        CurrencyType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransferStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransferId)
                .ForeignKey("dbo.BankAccounts", t => t.BankAccountId, cascadeDelete: true)
                .Index(t => t.BankAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "BankAccountId", "dbo.BankAccounts");
            DropForeignKey("dbo.BankAccounts", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.BankAvilableCurrencyTypes", "BankId", "dbo.Banks");
            DropForeignKey("dbo.BankAccounts", "BankId", "dbo.Banks");
            DropIndex("dbo.Transfers", new[] { "BankAccountId" });
            DropIndex("dbo.BankAvilableCurrencyTypes", new[] { "BankId" });
            DropIndex("dbo.BankAccounts", new[] { "ClientId" });
            DropIndex("dbo.BankAccounts", new[] { "BankId" });
            DropTable("dbo.Transfers");
            DropTable("dbo.Clients");
            DropTable("dbo.BankAvilableCurrencyTypes");
            DropTable("dbo.Banks");
            DropTable("dbo.BankAccounts");
        }
    }
}
