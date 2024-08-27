using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace LINQComEFCore.Models
{
    class EstoqueContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=estoque.db");
            options.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
