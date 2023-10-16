using GerenciadorDeOrdem.Model;
using Microsoft.EntityFrameworkCore;


namespace GerenciadorDeOrdem.Data
{
    internal  class ProducaoContext : DbContext
    {
       
        public DbSet<OrdemDeProducao> Producoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ordemproducao.db");
        }


    }
}
