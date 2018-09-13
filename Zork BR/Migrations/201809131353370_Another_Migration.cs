namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Another_Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerStats", "Kills", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerStats", "Kills");
        }
    }
}
