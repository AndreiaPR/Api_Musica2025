using System.Text.Json.Serialization;

namespace Api_Musica2025.Models
{
    public class Artista
    {
        public int Id { get; set; }

        public string Nome { get; set; } 

        public string EstiloMusical { get; set; } 

        [JsonIgnore] public ICollection<Musica> Musicas { get; set; }
    }
}