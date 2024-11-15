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
        public DateTime SalesDateTime { get; set; }
        public int SalesPiece { get; set; }
        //Fiyat Price
        public decimal SalesPrice { get; set; }
        //ToplamTutar=Total Amount
        public decimal SalesTotalAmount { get; set; }
        //Ürün
        //Cari
        //Personel
        public int ProductID { get; set; }
        public int CurrentID { get; set; }
        public int PersonnelID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}