namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelan3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HuongDan", "DeTai_Id", "dbo.DeTai");
            DropForeignKey("dbo.HuongDan", "GiaoVien_Id", "dbo.GiaoVien");
            DropIndex("dbo.HuongDan", new[] { "DeTai_Id" });
            DropIndex("dbo.HuongDan", new[] { "GiaoVien_Id" });
            DropTable("dbo.HuongDan");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HuongDan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGV = c.Int(nullable: false),
                        IdDeTai = c.Int(nullable: false),
                        DeTai_Id = c.Int(),
                        GiaoVien_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.HuongDan", "GiaoVien_Id");
            CreateIndex("dbo.HuongDan", "DeTai_Id");
            AddForeignKey("dbo.HuongDan", "GiaoVien_Id", "dbo.GiaoVien", "Id");
            AddForeignKey("dbo.HuongDan", "DeTai_Id", "dbo.DeTai", "Id");
        }
    }
}
