namespace SupportMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedgroups : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "Person_Id", "dbo.People");
            DropIndex("dbo.Groups", new[] { "Person_Id" });
            DropTable("dbo.Groups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Image = c.String(),
                        Created = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Groups", "Person_Id");
            AddForeignKey("dbo.Groups", "Person_Id", "dbo.People", "Id");
        }
    }
}
