using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDeTai.Models.EF
{
    [Table("DonViHV")]
    public class DonViHV
    {
        public DonViHV()
        {
            this.HocViens = new HashSet<HocVien>();           
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
       
        [Required(ErrorMessage = "Tiểu đoàn không để trống")]
        public int TieuDoan {  get; set; }
        public string MoTa { get; set; }

        public virtual ICollection<HocVien> HocViens { get; set; }

    }
}