using System.Data.Entity.ModelConfiguration;
using Misterio.Dominio.Entidades;

namespace Misterio.Infraestrutura.Maps
{
    public class LocalMap : EntityTypeConfiguration<Local>
    {
        public LocalMap()
        {
            this.ToTable("Locais");
            this.HasKey(k => k.Id);
            this.Property(p => p.Nome).IsRequired().HasColumnName("Nome");
        }

    }
}
