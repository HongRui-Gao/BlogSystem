namespace BlogSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminsProperty_Images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Images", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Images");
        }
    }
}
