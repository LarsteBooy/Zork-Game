namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sick_Of_Migrations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Players", "Kills");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Kills", c => c.Int(nullable: false));
        }
    }
}
