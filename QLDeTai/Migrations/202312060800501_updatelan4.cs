namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelan4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonViHV", "MoTa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonViHV", "MoTa");
        }
    }
}
