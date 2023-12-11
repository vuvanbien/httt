namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelan1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HocVien", "DaiDoi", c => c.String(nullable: false));
            DropColumn("dbo.DonViHV", "DaiDoi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonViHV", "DaiDoi", c => c.Int(nullable: false));
            DropColumn("dbo.HocVien", "DaiDoi");
        }
    }
}
