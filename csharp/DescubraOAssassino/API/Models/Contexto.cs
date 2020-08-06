using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aplicacao.Models
{
    public class Contexto : DbContext
    {
        public DbSet<MisterioModel> Misterio { get; set; }

        static Contexto()
        {
            Database.SetInitializer<Contexto>(null);
        }

        public Contexto(string conexao) : base(conexao) //base(ConfigurationManager.ConnectionStrings[conexao].ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MisterioMap());
        }
    }
}