namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "InBattle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "InBattle", c => c.Boolean(nullable: false));
        }
    }
}
