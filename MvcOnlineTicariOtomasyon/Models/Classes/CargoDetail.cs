using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Comment { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Personnel { get; set; }
        //Buyer=Alıcı
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Buyer { get; set; }
        public DateTime Datetime { get; set; }
    }
}