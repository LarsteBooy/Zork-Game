namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerStats", "MaximumItemsInInventory", c => c.Int(nullable: false));
            AddColumn("dbo.PlayerStats", "RenderMinimap", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerStats", "RenderMinimap");
            DropColumn("dbo.PlayerStats", "MaximumItemsInInventory");
        }
    }
}
