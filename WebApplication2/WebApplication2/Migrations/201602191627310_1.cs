namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id_location = c.Int(nullable: false, identity: true),
                        date_deb = c.DateTime(nullable: false),
                        date_fin = c.DateTime(nullable: false),
                        Voiture = c.Int(nullable: false),
                        User = c.Int(nullable: false),
                        exist = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_location);
            
            AddColumn("dbo.Voitures", "Prix_parJour", c => c.Int(nullable: false));
            DropColumn("dbo.Voitures", "Prix");
            DropTable("dbo.Prixes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Prixes",
                c => new
                    {
                        Id_prix = c.Int(nullable: false, identity: true),
                        date_deb = c.DateTime(nullable: false),
                        date_fin = c.DateTime(nullable: false),
                        Prix_parJour = c.Int(nullable: false),
                        User = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_prix);
            
            AddColumn("dbo.Voitures", "Prix", c => c.Int(nullable: false));
            DropColumn("dbo.Voitures", "Prix_parJour");
            DropTable("dbo.Locations");
        }
    }
}
