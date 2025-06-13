namespace Api_Musica2025.Models
{
    public class Musica
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;

        // Chaves estrangeiras
        public int ArtistaId { get; set; }

        public Artista Artista { get; set; }

        public int GeneroId { get; set; }

        public Genero Genero { get; set; }
    }
}
