namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Yet_Another_Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerStats", "EnemiesRemaining", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerStats", "EnemiesRemaining");
        }
    }
}
