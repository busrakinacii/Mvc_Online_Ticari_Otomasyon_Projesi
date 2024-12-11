using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;


namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillPencil> BillPencils { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<SalesTransaction> SalesTransactions { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ToDoList> toDoLists { get; set; }

    }
}