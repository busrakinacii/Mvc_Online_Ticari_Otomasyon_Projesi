using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminUserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string AdminPassword { get; set; }

        //Yetkilendirme
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string AdminAuthorization { get; set; }

    }
}