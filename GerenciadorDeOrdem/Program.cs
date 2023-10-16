using GerenciadorDeOrdem.Data;
using Spectre.Console;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        var aplicacaoRunStatus = true;

        while (aplicacaoRunStatus)
        {
            var options = AnsiConsole.Prompt(new SelectionPrompt<MenuOptions>()
         .Title("O que deseja fazer ?").AddChoices(
                MenuOptions.AddProduto,
                MenuOptions.AddProducao,
                MenuOptions.listarProducoes,
                MenuOptions.ListarPorGrupo,
                MenuOptions.AtualizarProducoes,
                MenuOptions.Quit
            ));

            switch (options)
            {
                case MenuOptions.AddProduto:
                    ProdutoControlle.AddProduto();
                    break;
                case MenuOptions.AddProducao:
                    ProducaoController.AddProducao();
                    break;
                case MenuOptions.listarProducoes:
                    ProducaoController.ListarProducoes();
                    break;
                case MenuOptions.ListarPorGrupo:
                    ProducaoController.ListarPorGrupo();
                    break;
                case MenuOptions.AtualizarProducoes:
                    ProducaoController.AtualizarStatusProducao();
                    break;
                case MenuOptions.Quit:
                    aplicacaoRunStatus = false;
                    break;

            }
        }
    }

    enum MenuOptions
    {
        AddProduto,
        AddProducao,
        listarProducoes,
        ListarPorGrupo,
        AtualizarProducoes,
        Quit
    }
}
