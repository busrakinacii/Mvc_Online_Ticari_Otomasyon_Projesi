using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class BillPencil
    {
        [Key]
        public int BillPencilId { get; set; }

        //Explanation=Açıklama
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string BillPencilExplanation { get; set; }
        // amount=Miktar
        public int BillPencilAmount { get; set; }
        //Birim Fiyat=unit Price
        public decimal BillPencilUnitPrice { get; set; }
        public decimal BillPencilTotal { get; set; }
        public int BillId { get; set; }
        public virtual Bill Bill { get; set; }
    }
}