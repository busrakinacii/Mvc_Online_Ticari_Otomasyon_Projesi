using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Expense
    {
        //Expense=Gider
        [Key]
        public int ExpenseId { get; set; }
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDateTime { get; set; }
        public decimal ExpenseTotal { get; set; }
    }
}