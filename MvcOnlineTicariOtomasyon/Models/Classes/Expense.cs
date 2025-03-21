﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Expense
    {
        //Expense=Gider
        [Key]
        public int ExpenseId { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDateTime { get; set; }
        public decimal ExpenseTotal { get; set; }
    }
}