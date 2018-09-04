namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deleted_Consumable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Weapons", newName: "Items");
            AddColumn("dbo.Items", "HealthRegain", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "HealthRegain");
            RenameTable(name: "dbo.Items", newName: "Weapons");
        }
    }
}
