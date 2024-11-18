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
        [StringLength(30, ErrorMessage = "En Fazla 30 Karakter yazabilirsiniz.")]
        public string CurrentName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "50 Karakterden Fazla Olamaz.")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail Adresi Geçerli Değildir.")]
        public string CurrentMail { get; set; }

        public bool CurrentStatus { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}