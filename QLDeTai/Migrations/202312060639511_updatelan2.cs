namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelan2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeTai", "TieuBan_Id", "dbo.TieuBan");
            DropForeignKey("dbo.DeTai", "TrangThai_Id", "dbo.TrangThai");
            DropIndex("dbo.DeTai", new[] { "TieuBan_Id" });
            DropIndex("dbo.DeTai", new[] { "TrangThai_Id" });
            DropColumn("dbo.DeTai", "IdTieuBan");
            DropColumn("dbo.DeTai", "IdTrangThai");
            RenameColumn(table: "dbo.DeTai", name: "TieuBan_Id", newName: "IdTieuBan");
            RenameColumn(table: "dbo.DeTai", name: "TrangThai_Id", newName: "IdTrangThai");
            AddColumn("dbo.DeTai", "IdGiaoVien", c => c.Int(nullable: false));
            AddColumn("dbo.HocVien", "TruongNhom", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DeTai", "IdTieuBan", c => c.Int(nullable: false));
            AlterColumn("dbo.DeTai", "IdTrangThai", c => c.Int(nullable: false));
            AlterColumn("dbo.HocVien", "TenHV", c => c.String());
            CreateIndex("dbo.DeTai", "IdTrangThai");
            CreateIndex("dbo.DeTai", "IdTieuBan");
            CreateIndex("dbo.DeTai", "IdGiaoVien");
            AddForeignKey("dbo.DeTai", "IdGiaoVien", "dbo.GiaoVien", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeTai", "IdTieuBan", "dbo.TieuBan", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeTai", "IdTrangThai", "dbo.TrangThai", "Id", cascadeDelete: true);
            DropColumn("dbo.DeTai", "TruongNhom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeTai", "TruongNhom", c => c.String());
            DropForeignKey("dbo.DeTai", "IdTrangThai", "dbo.TrangThai");
            DropForeignKey("dbo.DeTai", "IdTieuBan", "dbo.TieuBan");
            DropForeignKey("dbo.DeTai", "IdGiaoVien", "dbo.GiaoVien");
            DropIndex("dbo.DeTai", new[] { "IdGiaoVien" });
            DropIndex("dbo.DeTai", new[] { "IdTieuBan" });
            DropIndex("dbo.DeTai", new[] { "IdTrangThai" });
            AlterColumn("dbo.HocVien", "TenHV", c => c.String(nullable: false));
            AlterColumn("dbo.DeTai", "IdTrangThai", c => c.Int());
            AlterColumn("dbo.DeTai", "IdTieuBan", c => c.Int());
            DropColumn("dbo.HocVien", "TruongNhom");
            DropColumn("dbo.DeTai", "IdGiaoVien");
            RenameColumn(table: "dbo.DeTai", name: "IdTrangThai", newName: "TrangThai_Id");
            RenameColumn(table: "dbo.DeTai", name: "IdTieuBan", newName: "TieuBan_Id");
            AddColumn("dbo.DeTai", "IdTrangThai", c => c.Int(nullable: false));
            AddColumn("dbo.DeTai", "IdTieuBan", c => c.Int(nullable: false));
            CreateIndex("dbo.DeTai", "TrangThai_Id");
            CreateIndex("dbo.DeTai", "TieuBan_Id");
            AddForeignKey("dbo.DeTai", "TrangThai_Id", "dbo.TrangThai", "Id");
            AddForeignKey("dbo.DeTai", "TieuBan_Id", "dbo.TieuBan", "Id");
        }
    }
}
