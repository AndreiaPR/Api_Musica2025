using Microsoft.EntityFrameworkCore;
using Api_Musica2025.Models; // Certifique-se de que os models estão nesse namespace

namespace Api_Musica2025.Context
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        public DbSet<Musica> Musicas { get; set; }
        
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBase).Assembly);
        }
    }
}




