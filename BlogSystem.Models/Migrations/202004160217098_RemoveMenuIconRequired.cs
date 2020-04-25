namespace BlogSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMenuIconRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SystemMenus", "Icon", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("dbo.WebMenus", "Icon", c => c.String(maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WebMenus", "Icon", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.SystemMenus", "Icon", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
    }
}
