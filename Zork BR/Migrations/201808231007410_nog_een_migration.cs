namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nog_een_migration : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Enemies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Enemies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
