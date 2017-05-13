namespace SQLAzureDemo.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SQLAzureDemo.Models.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SQLAzureDemo.Models.Contexto context)
        {
            var products = new List<Produto>()
            {
                new Produto() { DataInclusao = DateTime.Now, Descricao ="Produto" },
                new Produto() { DataInclusao = DateTime.Now.AddDays(5), Descricao ="ProdutoA" },
                new Produto() { DataInclusao = DateTime.Now.AddDays(10), Descricao ="ProdutoB" },
            };

            products.ForEach(x => context.Produtos.AddOrUpdate(x));
            context.SaveChanges();
        }
    }
}
