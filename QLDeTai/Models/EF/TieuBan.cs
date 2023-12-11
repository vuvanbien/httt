using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDeTai.Models.EF
{
    [Table("TieuBan")]
    public class TieuBan
    {
        public TieuBan()
        {

            this.DeTais = new HashSet<DeTai>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên Tiểu ban không để trống")]
        public string TenTieuBan { get; set;}
        [Required(ErrorMessage = "Tên Đ/c Trưởng Tiểu ban không để trống")]
        public string TruongTB { get; set; }
        [Required(ErrorMessage = "Tên Đ/c Phó Tiểu ban không để trống")]
        public string PhoTB { get; set; }
        public string UV1 { get; set; }
        public string UV2 { get; set; }
        public string UV3 { get; set; }
        [Required(ErrorMessage = "Ngày Thành lập không để trống")]
        public DateTime NgayTL { get; set; }
        public virtual ICollection<DeTai> DeTais { get; set; }
    }
}