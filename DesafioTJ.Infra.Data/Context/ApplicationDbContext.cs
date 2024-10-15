using Microsoft.EntityFrameworkCore;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Infra.Data.Mapping;

namespace DesafioTJ.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroAssunto> LivroAssunto { get; set; }
        public DbSet<LivroAutor> LivroAutor { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Assunto>(new AssuntoMap().Configure);
            modelBuilder.Entity<Autor>(new AutorMap().Configure);
            modelBuilder.Entity<Livro>(new LivroMap().Configure);
            modelBuilder.Entity<LivroAssunto>(new LivroAssuntoMap().Configure);
            modelBuilder.Entity<LivroAutor>(new LivroAutorMap().Configure);
        }
    }
}
