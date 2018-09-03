namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hoi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "InEquipState", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "InEquipState");
        }
    }
}
