using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Infra.Data.Mapping
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder) 
        {
            builder.ToTable("Autor");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd()
                .HasColumnName("CodAu")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            
        }
    }
}
