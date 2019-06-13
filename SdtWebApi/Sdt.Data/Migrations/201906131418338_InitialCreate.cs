namespace Sdt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        AutorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Beschreibung = c.String(),
                        Geburtsdatum = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.AutorId);
            
            CreateTable(
                "dbo.Spruch",
                c => new
                    {
                        SpruchId = c.Int(nullable: false, identity: true),
                        SpruchText = c.String(),
                        AutorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpruchId)
                .ForeignKey("dbo.Autor", t => t.AutorId, cascadeDelete: true)
                .Index(t => t.AutorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spruch", "AutorId", "dbo.Autor");
            DropIndex("dbo.Spruch", new[] { "AutorId" });
            DropTable("dbo.Spruch");
            DropTable("dbo.Autor");
        }
    }
}
