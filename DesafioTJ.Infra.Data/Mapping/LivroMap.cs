using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Infra.Data.Mapping
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder) 
        {
            builder.ToTable("Livro");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo)
                .ValueGeneratedOnAdd()
                .HasColumnName("Codl")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Editora)
                .HasColumnName("Editora")
                .HasColumnType("VARCHAR")
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(x => x.Edicao)
                .HasColumnName("Edicao")
                .HasColumnType("Int")
                .IsRequired();
            builder.Property(x => x.AnoPublicacao)
                .HasColumnName("AnoPublicacao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(4)
                .IsRequired();

        }
    }
}
