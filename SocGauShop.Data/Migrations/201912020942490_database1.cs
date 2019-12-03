namespace SocGauShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ProductCategories", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Posts", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PostCategories", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductCategories", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
