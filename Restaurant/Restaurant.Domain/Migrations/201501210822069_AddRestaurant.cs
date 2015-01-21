namespace Restaurant.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestaurant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviewes", "RestaurantInfo_Id", "dbo.RestaurantInfoes");
            DropIndex("dbo.Reviewes", new[] { "RestaurantInfo_Id" });
            AddColumn("dbo.Reviewes", "RestaurantInfo_Id1", c => c.Int());
            AlterColumn("dbo.Reviewes", "RestaurantInfo_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviewes", "RestaurantInfo_Id1");
            AddForeignKey("dbo.Reviewes", "RestaurantInfo_Id1", "dbo.RestaurantInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviewes", "RestaurantInfo_Id1", "dbo.RestaurantInfoes");
            DropIndex("dbo.Reviewes", new[] { "RestaurantInfo_Id1" });
            AlterColumn("dbo.Reviewes", "RestaurantInfo_Id", c => c.Int());
            DropColumn("dbo.Reviewes", "RestaurantInfo_Id1");
            CreateIndex("dbo.Reviewes", "RestaurantInfo_Id");
            AddForeignKey("dbo.Reviewes", "RestaurantInfo_Id", "dbo.RestaurantInfoes", "Id");
        }
    }
}
