using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDeTai.Models.EF
{
    [Table("DeTai")]
    public class DeTai
    {
        public DeTai()
        {
            this.HocViens = new HashSet<HocVien>();         
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên đề tài không để trống")]
        public string TenDeTai { get; set; }
        [Required(ErrorMessage = "Nội dung đề tài không để trống")]
        public string NoiDung { get; set; }
        [Required(ErrorMessage = "Mục tiêu đề tài không để trống")]
        public string MucTieu { get; set; }
    
        public DateTime NgayDK { get; set; }
        public string NamHoc { get; set; }
        public DateTime NgayCapNhap { get; set; }
       
        public string GhiChu { get; set; }
        public decimal? Diem { get; set; }
        public bool? KetLuan { get; set; }
        public string KhenThuong { get; set; }

        public int? IdTrangThai { get; set; }
        [ForeignKey("IdTrangThai")]
        public virtual TrangThai TrangThai { get; set; }
        public int? IdTieuBan { get; set; }
        [ForeignKey("IdTieuBan")]
        public virtual TieuBan TieuBan { get; set; }
        public int? IdGiaoVien { get; set; }
        [ForeignKey("IdGiaoVien")]
        public virtual GiaoVien GiaoVien { get; set; }
        public virtual ICollection<HocVien> HocViens { get; set; }
       
    }
}