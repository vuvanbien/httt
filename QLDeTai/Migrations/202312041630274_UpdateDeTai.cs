namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDeTai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeTai", "TruongNhom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeTai", "TruongNhom");
        }
    }
}
