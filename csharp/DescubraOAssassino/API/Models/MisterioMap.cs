using System.Data.Entity.ModelConfiguration;

namespace Aplicacao.Models
{
    public class MisterioMap : EntityTypeConfiguration<MisterioModel>
    {
        public MisterioMap()
        {
            this.HasKey(p => p.IdMisterio);

            this.ToTable("misterio");
            this.Property(p => p.IdMisterio).HasColumnName("IdMisterio");
            this.Property(p => p.IdLocal).HasColumnName("IdLocal");
            this.Property(p => p.IdArma).HasColumnName("IdArma");
            this.Property(p => p.IdSuspeito).HasColumnName("IdSuspeito");
        }
    }
}