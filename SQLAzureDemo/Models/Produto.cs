using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLAzureDemo.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInclusao { get; set; }
    }
}