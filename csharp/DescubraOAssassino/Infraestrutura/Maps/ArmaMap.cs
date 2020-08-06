using System.Data.Entity.ModelConfiguration;
using Misterio.Dominio.Entidades;

namespace Misterio.Infraestrutura.Maps
{
    public class ArmaMap : EntityTypeConfiguration<Arma>
    {
        public ArmaMap()
        {
            this.ToTable("Armas");
            this.HasKey(k => k.Id);
            this.Property(p => p.Nome).IsRequired().HasColumnName("Nome");
        }

    }
}
