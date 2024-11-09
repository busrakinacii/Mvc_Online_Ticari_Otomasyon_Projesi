using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bill
    {
        //Bill=Fatura
        [Key]
        public int BillId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillOrderNumber { get; set; }
        public DateTime BillDatetime { get; set; }

        //Vergi Dairesi=Tax Office
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string BillTaxOffice { get; set; }

        public DateTime BillClock { get; set; }

        //Deliverer=Teslim Eden
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BillDeliverer { get; set; }


        //Teslim Alan=recipient
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BillRecipient { get; set; }


        public ICollection<BillPencil> BillPencils { get; set; }
    }
}