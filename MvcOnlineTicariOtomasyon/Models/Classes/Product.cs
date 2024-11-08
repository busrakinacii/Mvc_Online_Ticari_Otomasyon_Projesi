using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //Brand=Marka
        public string ProductBrand { get; set; }
        public short ProductStock { get; set; }
        //Purchase Price=ALış Fiyat
        public decimal ProductPurchasePrice { get; set; }
        //Sale Price=Satış Fiyat
        public decimal ProductSalePrice { get; set; }
        public bool ProductStatus { get; set; }
        public string ProductImage { get; set; }
    }
}