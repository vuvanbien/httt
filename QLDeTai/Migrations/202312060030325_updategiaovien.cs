namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updategiaovien : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GiaoVien", "DonViGV_Id", "dbo.DonViGV");
            DropIndex("dbo.GiaoVien", new[] { "DonViGV_Id" });
            DropColumn("dbo.GiaoVien", "IdDonVi");
            RenameColumn(table: "dbo.GiaoVien", name: "DonViGV_Id", newName: "IdDonVi");
            AlterColumn("dbo.GiaoVien", "IdDonVi", c => c.Int(nullable: false));
            CreateIndex("dbo.GiaoVien", "IdDonVi");
            AddForeignKey("dbo.GiaoVien", "IdDonVi", "dbo.DonViGV", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiaoVien", "IdDonVi", "dbo.DonViGV");
            DropIndex("dbo.GiaoVien", new[] { "IdDonVi" });
            AlterColumn("dbo.GiaoVien", "IdDonVi", c => c.Int());
            RenameColumn(table: "dbo.GiaoVien", name: "IdDonVi", newName: "DonViGV_Id");
            AddColumn("dbo.GiaoVien", "IdDonVi", c => c.Int(nullable: false));
            CreateIndex("dbo.GiaoVien", "DonViGV_Id");
            AddForeignKey("dbo.GiaoVien", "DonViGV_Id", "dbo.DonViGV", "Id");
        }
    }
}
