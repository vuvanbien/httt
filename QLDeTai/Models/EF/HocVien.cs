using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDeTai.Models.EF
{
    [Table("HocVien")]
    public class HocVien
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã học viên không để trống")]
        [StringLength(50)]
        public string MaHV {  get; set; }
        [Required(ErrorMessage = "Tên học viên không để trống")]
        public bool TruongNhom { get; set; }
        public string TenHV { get; set; }
        [Required(ErrorMessage = "Khoá học viên không để trống")]

        public int Khoa { get; set; }
        [Required(ErrorMessage = "Lớp học viên không để trống")]
        public string Lop { get; set; }
        [Required(ErrorMessage = "Đại đội học viên không để trống")]
        public string DaiDoi { get; set; }

        public bool GioiTinh { get; set; }
        [Required(ErrorMessage = "Điểm trung bình năm học vừa rồi của học viên không để trống")]
        public decimal DiemTBC { get; set; }
        public int IdDonVi { get; set; }
        public int IdDeTai { get; set; }
        [ForeignKey("IdDonVi")]
        public virtual DonViHV DonViHV { get; set; }
        [ForeignKey("IdDeTai")]
        public virtual DeTai DeTai { get; set; }

    }
}