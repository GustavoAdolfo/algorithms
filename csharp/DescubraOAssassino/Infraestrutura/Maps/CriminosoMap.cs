using System.Data.Entity.ModelConfiguration;
using Misterio.Dominio.Entidades;

namespace Misterio.Infraestrutura.Maps
{
    public class CriminosoMap : EntityTypeConfiguration<Criminoso>
    {
        public CriminosoMap()
        {
            this.ToTable("Criminosos");
            this.HasKey(k => k.Id);
            this.Property(p => p.Nome).IsRequired().HasColumnName("Nome");
        }

    }
}
