using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDeTai.Models.EF
{
    [Table("DonViGV")]
    public class DonViGV
    {
        public DonViGV()
        {

            this.GiaoViens = new HashSet<GiaoVien>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên Khoa/Viện không để trống")]
        public string KhoaVien { get; set; }
        public virtual ICollection<GiaoVien> GiaoViens { get; set; }
    }
}