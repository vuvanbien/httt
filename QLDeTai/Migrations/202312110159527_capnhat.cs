namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhat : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeTai", "IdGiaoVien", "dbo.GiaoVien");
            DropForeignKey("dbo.DeTai", "IdTieuBan", "dbo.TieuBan");
            DropForeignKey("dbo.DeTai", "IdTrangThai", "dbo.TrangThai");
            DropIndex("dbo.DeTai", new[] { "IdTrangThai" });
            DropIndex("dbo.DeTai", new[] { "IdTieuBan" });
            DropIndex("dbo.DeTai", new[] { "IdGiaoVien" });
            AlterColumn("dbo.DeTai", "Diem", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.DeTai", "KetLuan", c => c.Boolean());
            AlterColumn("dbo.DeTai", "IdTrangThai", c => c.Int());
            AlterColumn("dbo.DeTai", "IdTieuBan", c => c.Int());
            AlterColumn("dbo.DeTai", "IdGiaoVien", c => c.Int());
            CreateIndex("dbo.DeTai", "IdTrangThai");
            CreateIndex("dbo.DeTai", "IdTieuBan");
            CreateIndex("dbo.DeTai", "IdGiaoVien");
            AddForeignKey("dbo.DeTai", "IdGiaoVien", "dbo.GiaoVien", "Id");
            AddForeignKey("dbo.DeTai", "IdTieuBan", "dbo.TieuBan", "Id");
            AddForeignKey("dbo.DeTai", "IdTrangThai", "dbo.TrangThai", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeTai", "IdTrangThai", "dbo.TrangThai");
            DropForeignKey("dbo.DeTai", "IdTieuBan", "dbo.TieuBan");
            DropForeignKey("dbo.DeTai", "IdGiaoVien", "dbo.GiaoVien");
            DropIndex("dbo.DeTai", new[] { "IdGiaoVien" });
            DropIndex("dbo.DeTai", new[] { "IdTieuBan" });
            DropIndex("dbo.DeTai", new[] { "IdTrangThai" });
            AlterColumn("dbo.DeTai", "IdGiaoVien", c => c.Int(nullable: false));
            AlterColumn("dbo.DeTai", "IdTieuBan", c => c.Int(nullable: false));
            AlterColumn("dbo.DeTai", "IdTrangThai", c => c.Int(nullable: false));
            AlterColumn("dbo.DeTai", "KetLuan", c => c.Boolean(nullable: false));
            AlterColumn("dbo.DeTai", "Diem", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.DeTai", "IdGiaoVien");
            CreateIndex("dbo.DeTai", "IdTieuBan");
            CreateIndex("dbo.DeTai", "IdTrangThai");
            AddForeignKey("dbo.DeTai", "IdTrangThai", "dbo.TrangThai", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeTai", "IdTieuBan", "dbo.TieuBan", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DeTai", "IdGiaoVien", "dbo.GiaoVien", "Id", cascadeDelete: true);
        }
    }
}
