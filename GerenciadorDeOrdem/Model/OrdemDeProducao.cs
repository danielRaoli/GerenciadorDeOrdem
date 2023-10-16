
using System.ComponentModel.DataAnnotations;


namespace GerenciadorDeOrdem.Model
{
    internal class OrdemDeProducao
    {
        [Key]
        public int Id { get; set; }


        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public StatusProducao Status
        {
            get; set;

        }


        public override string ToString()
        {
            return $"{Produto}\n Data de início: {DataInicio.ToShortDateString()} - Data de conclusão: {DataTermino.ToShortDateString()}\n" +
                $"Status: {Status.ToString()}";
        }

    }
}
