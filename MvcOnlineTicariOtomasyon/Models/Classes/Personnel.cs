using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Personnel
    {
        [Key]
        public int PersonnelId { get; set; }
        public string PersonnelName { get; set; }
        public string PersonnelSurname { get; set; }
        public string PersonnelImage { get; set; }


    }
}