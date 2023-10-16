using GerenciadorDeOrdem.Model;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeOrdem.Data
{
    internal class ProdutoControlle
    {
        public static ProducaoContext context = new ProducaoContext();

        public static void AddProduto()
        {

            var nomeProduto = AnsiConsole.Ask<string>("Digite o nome do produto");
           
            var dbProduct = context.Produtos.FirstOrDefault(p=> p.Nome == nomeProduto);
            if(dbProduct != null)
            {
                throw new ApplicationException("O nome do produto já existe");
            }

            context.Add(new Produto { Nome = nomeProduto});
            context.SaveChanges();

        }
    }
}
