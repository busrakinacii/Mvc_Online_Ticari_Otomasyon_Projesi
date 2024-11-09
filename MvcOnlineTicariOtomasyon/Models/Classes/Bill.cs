using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Bill
    {
        //Bill=Fatura
        [Key]
        public int BillId { get; set; }
        public string BillSerialNumber { get; set; }
        public string BillOrderNumber { get; set; }
        public DateTime BillDatetime { get; set; }

        //Vergi Dairesi=Tax Office
        public string BillTaxOffice { get; set; }

        public DateTime BillClock { get; set; }
        //Deliverer=Teslim Eden
        public string BillDeliverer { get; set; }
        //Teslim Alan=recipient
        public string BillRecipient { get; set; }

    }
}