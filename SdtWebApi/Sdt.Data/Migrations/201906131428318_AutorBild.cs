namespace Sdt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutorBild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autor", "Photo", c => c.Binary());
            AddColumn("dbo.Autor", "PhotoMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Autor", "PhotoMimeType");
            DropColumn("dbo.Autor", "Photo");
        }
    }
}
