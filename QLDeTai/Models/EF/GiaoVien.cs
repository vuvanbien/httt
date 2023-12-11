using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDeTai.Models.EF
{
    [Table("GiaoVien")]
    public class GiaoVien
    {
        public GiaoVien()
        {
            
            this.DeTais = new HashSet<DeTai>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã cán bộ không để trống")]
        public string MaCB { get; set; }
        [Required(ErrorMessage = "Tên giáo viên không để trống")]
        public  string TenGV { get; set; }
        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Email không để trống")]
        public string Email { get; set; }
       
        public string HocHam { get; set; }
      
        public string ChucVu { get; set; }
     
        public string CapBac { get; set; }
     
        [Required(ErrorMessage = "Bộ môn không để trống")]
        public string BoMon { get; set; }
        public int IdDonVi { get; set; }
        public virtual ICollection<DeTai> DeTais { get; set; }

        [ForeignKey("IdDonVi")]
        public virtual DonViGV DonViGV { get; set; }
    }
}