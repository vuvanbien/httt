namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updadtelan5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HocVien", "DeTai_Id", "dbo.DeTai");
            DropForeignKey("dbo.HocVien", "DonViHV_id", "dbo.DonViHV");
            DropIndex("dbo.HocVien", new[] { "DeTai_Id" });
            DropIndex("dbo.HocVien", new[] { "DonViHV_id" });
            DropColumn("dbo.HocVien", "IdDeTai");
            DropColumn("dbo.HocVien", "IdDonVi");
            RenameColumn(table: "dbo.HocVien", name: "DeTai_Id", newName: "IdDeTai");
            RenameColumn(table: "dbo.HocVien", name: "DonViHV_id", newName: "IdDonVi");
            AlterColumn("dbo.HocVien", "IdDeTai", c => c.Int(nullable: false));
            AlterColumn("dbo.HocVien", "IdDonVi", c => c.Int(nullable: false));
            CreateIndex("dbo.HocVien", "IdDonVi");
            CreateIndex("dbo.HocVien", "IdDeTai");
            AddForeignKey("dbo.HocVien", "IdDeTai", "dbo.DeTai", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HocVien", "IdDonVi", "dbo.DonViHV", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HocVien", "IdDonVi", "dbo.DonViHV");
            DropForeignKey("dbo.HocVien", "IdDeTai", "dbo.DeTai");
            DropIndex("dbo.HocVien", new[] { "IdDeTai" });
            DropIndex("dbo.HocVien", new[] { "IdDonVi" });
            AlterColumn("dbo.HocVien", "IdDonVi", c => c.Int());
            AlterColumn("dbo.HocVien", "IdDeTai", c => c.Int());
            RenameColumn(table: "dbo.HocVien", name: "IdDonVi", newName: "DonViHV_id");
            RenameColumn(table: "dbo.HocVien", name: "IdDeTai", newName: "DeTai_Id");
            AddColumn("dbo.HocVien", "IdDonVi", c => c.Int(nullable: false));
            AddColumn("dbo.HocVien", "IdDeTai", c => c.Int(nullable: false));
            CreateIndex("dbo.HocVien", "DonViHV_id");
            CreateIndex("dbo.HocVien", "DeTai_Id");
            AddForeignKey("dbo.HocVien", "DonViHV_id", "dbo.DonViHV", "id");
            AddForeignKey("dbo.HocVien", "DeTai_Id", "dbo.DeTai", "Id");
        }
    }
}
