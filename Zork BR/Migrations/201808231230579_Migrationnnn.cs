namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationnnn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "InBattle", c => c.Boolean(nullable: false));
            AddColumn("dbo.Players", "Kills", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Kills");
            DropColumn("dbo.Players", "InBattle");
        }
    }
}
