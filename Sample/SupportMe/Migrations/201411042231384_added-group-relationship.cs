namespace SupportMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgrouprelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Person_Id", c => c.Guid());
            CreateIndex("dbo.Groups", "Person_Id");
            AddForeignKey("dbo.Groups", "Person_Id", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Person_Id", "dbo.People");
            DropIndex("dbo.Groups", new[] { "Person_Id" });
            DropColumn("dbo.Groups", "Person_Id");
        }
    }
}
