namespace Restaurant.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DecRestaurantId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Reviewes", new[] { "RestaurantInfo_Id1" });
            DropColumn("dbo.Reviewes", "RestaurantInfo_Id");
            RenameColumn(table: "dbo.Reviewes", name: "RestaurantInfo_Id1", newName: "RestaurantInfo_Id");
            AlterColumn("dbo.Reviewes", "RestaurantInfo_Id", c => c.Int());
            CreateIndex("dbo.Reviewes", "RestaurantInfo_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reviewes", new[] { "RestaurantInfo_Id" });
            AlterColumn("dbo.Reviewes", "RestaurantInfo_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reviewes", name: "RestaurantInfo_Id", newName: "RestaurantInfo_Id1");
            AddColumn("dbo.Reviewes", "RestaurantInfo_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviewes", "RestaurantInfo_Id1");
        }
    }
}
