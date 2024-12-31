using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingID { get; set; }

        //Trancking Code =takip Kodu
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }//1234123AB

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Comment { get; set; }
        public DateTime Datetime { get; set; }
    }
}