namespace BlogSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMenuParentIdNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SystemMenus", "ParentId", c => c.Guid(true));
            AlterColumn("dbo.WebMenus", "ParentId", c => c.Guid(true));
        }

        public override void Down()
        {
            AlterColumn("dbo.SystemMenus", "ParentId", c => c.Guid(false));
            AlterColumn("dbo.WebMenus", "ParentId", c => c.Guid(false));
        }
    }
}
