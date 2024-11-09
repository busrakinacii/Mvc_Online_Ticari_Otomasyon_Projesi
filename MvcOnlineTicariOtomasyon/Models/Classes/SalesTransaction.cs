using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SalesTransaction
    {
        //Sales Transaction = Satış İşlemi

        [Key]
        public int SalesTransactionId { get; set; }
        //Ürün
        //Cari
        //Personel
        public DateTime SalesDateTime { get; set; }
        public int SalesPiece { get; set; }
        //Fiyat Price
        public decimal SalesPrice { get; set; }
        //ToplamTutar=Total Amount
        public decimal SalesTotalAmount { get; set; }
    }
}