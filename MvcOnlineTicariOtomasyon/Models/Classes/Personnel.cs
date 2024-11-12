using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Personnel
    {
        [Key]
        public int PersonnelId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonnelName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonnelSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string PersonnelImage { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public virtual Department Department { get; set; }


    }
}