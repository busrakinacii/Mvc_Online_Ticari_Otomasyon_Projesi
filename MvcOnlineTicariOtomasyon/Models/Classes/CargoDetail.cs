using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class CargoDetail
    {
        public int CargoDetailID { get; set; }
        public string Comment { get; set; }
        public string TrackingCode { get; set; }
        public string Personnel { get; set; }
        //Buyer=Alıcı
        public string Buyer { get; set; }
        public DateTime Datetime { get; set; }
    }
}