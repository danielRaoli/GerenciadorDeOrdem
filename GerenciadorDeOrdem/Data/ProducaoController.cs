using GerenciadorDeOrdem.Model;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;


namespace GerenciadorDeOrdem.Data
{
    internal class ProducaoController
    {
        public static ProducaoContext context = new ProducaoContext();

        public static void AddProducao()
        {
            var nomeProduto = AnsiConsole.Ask<string>("Digite o nome do produto: ");
            var dbProduct = context.Produtos.FirstOrDefault(p => p.Nome == nomeProduto);
            if (dbProduct == null)
            {
                Console.WriteLine("Produto informado não existe, tente novamente");
                nomeProduto = AnsiConsole.Ask<string>("Digite o nome do produto: ");
            }
            var dataTermino = AnsiConsole.Ask<DateTime>("Digite a data de término: ");
            context.Producoes.Add(new OrdemDeProducao { DataTermino = dataTermino, ProdutoId = dbProduct.Id, DataInicio = DateTime.Now });
            context.SaveChanges();
            
        }

        public static void ListarProducoes()
        {
            var producoes = context.Producoes.Include(p => p.Produto).ToList();
            foreach (var prod in producoes)
            {
                Console.WriteLine(prod);
            }
        }

        public static void ListarPorGrupo()
        {
            Console.WriteLine("Em andamento:\n ");
            var producoesAndamento = context.Producoes.Where(p => p.Status == StatusProducao.Producao);
            foreach (var prod in producoesAndamento)
            {
                Console.WriteLine(prod);
            }
            Console.WriteLine("Concluídas: ");
            var producoesConcluidas = context.Producoes.Where(p => p.Status == StatusProducao.Concluido);
            foreach (var prod in producoesConcluidas)
            {
                Console.WriteLine(prod);
            }

        }

        public static void AtualizarStatusProducao()
        {
            var producoesAtualizada = context.Producoes.ForEachAsync(p => p.Status = (p.DataTermino >= p.DataInicio) ? StatusProducao.Concluido : StatusProducao.Producao);
            context.SaveChanges();
            Console.WriteLine("As ordens foram atualizadas...");
        }
    }
}
