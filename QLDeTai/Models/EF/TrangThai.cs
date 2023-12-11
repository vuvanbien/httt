using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLDeTai.Models.EF
{
    [Table("TrangThai")]
    public class TrangThai
    {
        public TrangThai()
        {
            this.DeTais = new HashSet<DeTai>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenTrangThai { get; set; }
        public string MoTa {  get; set; }
        public virtual ICollection<DeTai> DeTais { get; set; }
    }
}