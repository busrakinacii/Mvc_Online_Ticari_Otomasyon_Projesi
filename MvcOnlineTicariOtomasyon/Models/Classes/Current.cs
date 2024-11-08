using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Current
    {
        //Current=CARi
        [Key]
        public int CurrentId { get; set; }
        public string CurrentName { get; set; }
        public string CurrentSurname { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentMail { get; set; }
    }
}