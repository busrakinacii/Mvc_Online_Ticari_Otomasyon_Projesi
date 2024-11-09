using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Current
    {
        //Current=CARi,Akım
        [Key]
        public int CurrentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CurrentMail { get; set; }

        public SalesTransaction SalesTransaction { get; set; }
    }
}