namespace Sdt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PflichtfelderAutor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Autor", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Autor", "Beschreibung", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Autor", "Beschreibung", c => c.String());
            AlterColumn("dbo.Autor", "Name", c => c.String());
        }
    }
}
