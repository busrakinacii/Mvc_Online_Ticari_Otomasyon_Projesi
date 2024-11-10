using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }


        //Brand=Marka
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ProductBrand { get; set; }
        public short ProductStock { get; set; }
        //Purchase Price=ALış Fiyat
        public decimal ProductPurchasePrice { get; set; }
        //Sale Price=Satış Fiyat
        public decimal ProductSalePrice { get; set; }
        public bool ProductStatus { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string ProductImage { get; set; }
        public Category Category { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}