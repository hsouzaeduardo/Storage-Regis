using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SQLAzureDemo.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}