namespace QLDeTai.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatDBDT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeTai",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenDeTai = c.String(nullable: false),
                        NoiDung = c.String(nullable: false),
                        MucTieu = c.String(nullable: false),
                        NgayDK = c.DateTime(nullable: false),
                        NamHoc = c.String(),
                        NgayCapNhap = c.DateTime(nullable: false),
                        GhiChu = c.String(),
                        Diem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KetLuan = c.Boolean(nullable: false),
                        KhenThuong = c.String(),
                        IdTrangThai = c.Int(nullable: false),
                        IdTieuBan = c.Int(nullable: false),
                        TieuBan_Id = c.Int(),
                        TrangThai_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TieuBan", t => t.TieuBan_Id)
                .ForeignKey("dbo.TrangThai", t => t.TrangThai_Id)
                .Index(t => t.TieuBan_Id)
                .Index(t => t.TrangThai_Id);
            
            CreateTable(
                "dbo.HocVien",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaHV = c.String(nullable: false, maxLength: 50),
                        TenHV = c.String(nullable: false),
                        Khoa = c.Int(nullable: false),
                        Lop = c.String(nullable: false),
                        GioiTinh = c.Boolean(nullable: false),
                        DiemTBC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdDonVi = c.Int(nullable: false),
                        IdDeTai = c.Int(nullable: false),
                        DeTai_Id = c.Int(),
                        DonViHV_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeTai", t => t.DeTai_Id)
                .ForeignKey("dbo.DonViHV", t => t.DonViHV_id)
                .Index(t => t.DeTai_Id)
                .Index(t => t.DonViHV_id);
            
            CreateTable(
                "dbo.DonViHV",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DaiDoi = c.Int(nullable: false),
                        TieuDoan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeTai", t => t.DeTai_Id)
                .ForeignKey("dbo.GiaoVien", t => t.GiaoVien_Id)
                .Index(t => t.DeTai_Id)
                .Index(t => t.GiaoVien_Id);
            
            CreateTable(
                "dbo.GiaoVien",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaCB = c.String(nullable: false),
                        TenGV = c.String(nullable: false),
                        SDT = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        HocHam = c.String(),
                        ChucVu = c.String(),
                        CapBac = c.String(),
                        BoMon = c.String(nullable: false),
                        IdDonVi = c.Int(nullable: false),
                        DonViGV_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DonViGV", t => t.DonViGV_Id)
                .Index(t => t.DonViGV_Id);
            
            CreateTable(
                "dbo.DonViGV",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KhoaVien = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TieuBan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenTieuBan = c.String(nullable: false),
                        TruongTB = c.String(nullable: false),
                        PhoTB = c.String(nullable: false),
                        UV1 = c.String(),
                        UV2 = c.String(),
                        UV3 = c.String(),
                        NgayTL = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrangThai",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenTrangThai = c.String(),
                        MoTa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.DeTai", "TrangThai_Id", "dbo.TrangThai");
            DropForeignKey("dbo.DeTai", "TieuBan_Id", "dbo.TieuBan");
            DropForeignKey("dbo.HuongDan", "GiaoVien_Id", "dbo.GiaoVien");
            DropForeignKey("dbo.GiaoVien", "DonViGV_Id", "dbo.DonViGV");
            DropForeignKey("dbo.HuongDan", "DeTai_Id", "dbo.DeTai");
            DropForeignKey("dbo.HocVien", "DonViHV_id", "dbo.DonViHV");
            DropForeignKey("dbo.HocVien", "DeTai_Id", "dbo.DeTai");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.GiaoVien", new[] { "DonViGV_Id" });
            DropIndex("dbo.HuongDan", new[] { "GiaoVien_Id" });
            DropIndex("dbo.HuongDan", new[] { "DeTai_Id" });
            DropIndex("dbo.HocVien", new[] { "DonViHV_id" });
            DropIndex("dbo.HocVien", new[] { "DeTai_Id" });
            DropIndex("dbo.DeTai", new[] { "TrangThai_Id" });
            DropIndex("dbo.DeTai", new[] { "TieuBan_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TrangThai");
            DropTable("dbo.TieuBan");
            DropTable("dbo.DonViGV");
            DropTable("dbo.GiaoVien");
            DropTable("dbo.HuongDan");
            DropTable("dbo.DonViHV");
            DropTable("dbo.HocVien");
            DropTable("dbo.DeTai");
        }
    }
}
