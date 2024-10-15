using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Infra.Data.Mapping
{
    public class LivroAutorMap : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder) 
        {
            builder.ToTable("Livro_Autor");
            builder.HasKey(x => x.Codigo_Livro);
            builder.Property(x => x.Codigo_Livro)
                .ValueGeneratedOnAdd()
                .HasColumnName("Livro_Codl")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.Codigo_Autor)
                .HasColumnName("Codigo_Autor")
                .HasColumnType("VARCHAR")
                .HasColumnType("Int")
                .IsRequired();
            
        }
    }
}
