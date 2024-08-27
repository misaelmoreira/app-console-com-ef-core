using LINQComEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace LINQComEFCore
{
    class Program
    {
        static EstoqueContext db = new EstoqueContext();

        static void Main(string[] args)
        {
            Console.WriteLine();
            MostrarPrecoProdutoMaisCaro();
            MostrarPrecoProdutoMaisBarato();
            MostrarPrecoMedioProdutos();
            MostrarQuantidadeDeProdutos();
            MostrarValorEstoqueDeProdutos();
            MostrarValorEstoquePorCategoria();
        }

        static void MostrarTodasAsCategorias()
        {
            Console.WriteLine("Categorias\n");
            var categorias = db.Categorias.ToList();
            foreach (var c in categorias)
            {
                Console.WriteLine($"{c.IdCategoria:D2} - {c.Nome}");
            }
        }

        static void MostrarTodosOsProdutos()
        {
            Console.WriteLine("Produtos\n");
            var produtos = db.Produtos.ToList();
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.IdProduto:D2} - {p.Nome}");
            }
        }

        static void MostrarCategoriaPorId(int id)
        {
            var c = db.Categorias.Single(x => x.IdCategoria == id);
            Console.WriteLine($"{c.IdCategoria:D2} - {c.Nome}");
        }

        static void MostrarProdutoPorId(int id)
        {
            var p = db.Produtos.Single(x => x.IdProduto == id);
            Console.WriteLine($"{p.IdProduto:D2} - {p.Nome}");
        }

        static void MostrarProdutosComNomeContendo(string palavra)
        {
            Console.WriteLine($"Produtos com nome contendo \"{palavra}\":\n");
            var produtos = db.Produtos.Where(x => x.Nome.Contains(palavra)).ToList();
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.IdProduto:D2} - {p.Nome}");
            }
        }

        static void MostrarProdutosComPrecoMenorQue(double valor)
        {
            Console.WriteLine($"Produtos com preço menor que {valor:C2}:\n");
            var produtos = db.Produtos.Where(x => x.Preco < valor).ToArray();
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.IdProduto:D2} - {p.Nome} ({p.Preco:C2})");
            }
        }

        static void MostrarProdutosContendoSomenteNome()
        {
            Console.WriteLine("Produtos contendo somente nome:\n");
            var produtos = db.Produtos.Select(x => new { Nome = x.Nome }).ToList();
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.Nome}");
            }
        }

        static void MostrarProdutosContendoSomenteNomeOrdenados()
        {
            Console.WriteLine("Produtos contendo somente nome:\n");
            var produtos = db.Produtos.Select(x => new { Nome = x.Nome }).
                OrderBy(x => x.Nome).ToList();
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.Nome}");
            }
        }

        static void MostrarProdutosSemRastrear()
        {
            var init = db.Categorias.ToList();

            Stopwatch timer = new Stopwatch();
            Console.WriteLine("Produtos sem rastreamento: ");
            timer.Start();
            var produtosNT = db.Produtos.AsNoTracking().ToList();
            timer.Stop();
            foreach (var p in produtosNT)
            {
                Console.WriteLine($"{p.IdProduto:D2} - {p.Nome}");
            }
            Console.WriteLine($"\nTempo decorrido: {timer.ElapsedMilliseconds} milissegundos.");

            Console.WriteLine();
            Console.WriteLine("Produtos com rastreamento: ");
            timer.Reset();
            timer.Start();
            var produtosWT = db.Produtos.ToList();
            timer.Stop();
            foreach (var p in produtosWT)
            {
                Console.WriteLine($"{p.IdProduto:D2} - {p.Nome}");
            }
            Console.WriteLine($"\nTempo decorrido: {timer.ElapsedMilliseconds} milissegundos.");
        }

        static void MostrarCategoriasComSeusProdutos()
        {
            Console.WriteLine("Categorias e seus produtos:\n");
            var categorias = db.Categorias.Include(x => x.Produtos).ToList();
            foreach (var c in categorias)
            {
                Console.WriteLine($"{c.IdCategoria:D2} - {c.Nome}");
                Console.WriteLine("-----------------");
                foreach (var p in c.Produtos)
                {
                    Console.WriteLine($"{p.IdProduto:D2} - {p.Nome}");
                }
                Console.WriteLine();
            }
        }

        static void MostrarNProdutosMaisCaros(int n)
        {
            Console.WriteLine($"Os {n} produtos mais caros");
            var produtos = db.Produtos.OrderByDescending(x => x.Preco).Take(n).ToList();
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.IdProduto:D2} - {p.Nome} ({p.Preco:C2})");
            }
        }

        static void MostrarPaginaDeProdutos(int nPagina, int qPagina)
        {
            Console.WriteLine($"Página {nPagina} de produtos:\n");
            var produtos = db.Produtos.Skip((nPagina-1) * qPagina).Take(qPagina).ToList();
            foreach (var p in produtos)
            {
                Console.WriteLine($"{p.IdProduto:D2} - {p.Nome} ({p.Preco:C2})");
            }
        }

        static void MostrarPrecoProdutoMaisCaro()
        {
            var preco = db.Produtos.Max(x => x.Preco);
            Console.WriteLine($"Preço do produto mais caro: {preco:C2}\n");
        }

        static void MostrarPrecoProdutoMaisBarato()
        {
            var preco = db.Produtos.Min(x => x.Preco);
            Console.WriteLine($"Preço do produto mais barato: {preco:C2}\n");
        }

        static void MostrarPrecoMedioProdutos()
        {
            var preco = db.Produtos.Average(x => x.Preco);
            Console.WriteLine($"Preço médio dos produtos: {preco:C2}\n");
        }

        static void MostrarQuantidadeDeProdutos()
        {
            var qtde = db.Produtos.Count();
            Console.WriteLine($"Quantidade produtos: {qtde:D2}\n");
        }

        static void MostrarValorEstoqueDeProdutos()
        {           
            var valor = db.Produtos.Sum(x => x.Preco * x.EstoqueAtual);
            Console.WriteLine($"Valor do estoque: {valor:C2}\n");
        }

        static void MostrarValorEstoquePorCategoria()
        {
            Console.WriteLine("Valor em estoque por categoria:\n");
            var grupos = db.Categorias.Include(x => x.Produtos)
                .Select(x => new { Categoria = x.Nome, 
                    Valor = x.Produtos.Sum(x => x.Preco * x.EstoqueAtual)});
            foreach (var g in grupos)
            {
                Console.WriteLine($"{g.Categoria} - {g.Valor:C2}");
            }
        }
    }
}
