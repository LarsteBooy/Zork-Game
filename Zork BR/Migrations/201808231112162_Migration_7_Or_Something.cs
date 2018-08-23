namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_7_Or_Something : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Weapons", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Weapons", "Strength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weapons", "Strength", c => c.Int(nullable: false));
            DropColumn("dbo.Weapons", "Discriminator");
        }
    }
}
