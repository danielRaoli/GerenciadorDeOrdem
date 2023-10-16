
using System.ComponentModel.DataAnnotations;


namespace GerenciadorDeOrdem.Model
{
    internal class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }


        public override string ToString()
        {
            return "Produto: "+ Nome;
        }
    }


}
