using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Infra.Data.Mapping
{
    public class LivroAssuntoMap : IEntityTypeConfiguration<LivroAssunto>
    {
        public void Configure(EntityTypeBuilder<LivroAssunto> builder) 
        {
            builder.ToTable("Livro_Assunto");
            builder.HasKey(x => x.Codigo_Livro);
            builder.Property(x => x.Codigo_Livro)
                .HasColumnName("Livro_Codl")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.Codigo_Assunto)
                .HasColumnName("Assunto_codAs")
                .HasColumnType("VARCHAR")
                .HasColumnType("Int")
                .IsRequired();
            
        }
    }
}
