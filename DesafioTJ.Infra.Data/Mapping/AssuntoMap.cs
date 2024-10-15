using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Infra.Data.Mapping
{
    public class AssuntoMap : IEntityTypeConfiguration<Assunto>
    {
        public void Configure(EntityTypeBuilder<Assunto> builder) 
        {
            builder.ToTable("Assunto");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd()
                .HasColumnName("CodAs")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            
        }
    }
}
