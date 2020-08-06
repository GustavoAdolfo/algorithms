using System.Configuration;
using System.Data.Entity;
using Misterio.Dominio.Entidades;
using Misterio.Infraestrutura.Maps;

namespace Misterio.Infraestrutura
{
    public sealed class Contexto : DbContext
    {
        static Contexto()
        {
            Database.SetInitializer<Contexto>(null);
        }

        public Contexto(string conexao) : base(conexao)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CriminosoMap());
            modelBuilder.Configurations.Add(new ArmaMap());
            modelBuilder.Configurations.Add(new LocalMap());
        }

        public DbSet<Criminoso> Criminoso { get; set; }
        public DbSet<Arma> Arma { get; set; }
        public DbSet<Local> Local { get; set; }
    }
}
