namespace Zork_BR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I_Hate_Migrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Strength = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Players", "SelectedWeapon_Id", c => c.Int());
            CreateIndex("dbo.Players", "SelectedWeapon_Id");
            AddForeignKey("dbo.Players", "SelectedWeapon_Id", "dbo.Weapons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "SelectedWeapon_Id", "dbo.Weapons");
            DropIndex("dbo.Players", new[] { "SelectedWeapon_Id" });
            DropColumn("dbo.Players", "SelectedWeapon_Id");
            DropTable("dbo.Weapons");
        }
    }
}
