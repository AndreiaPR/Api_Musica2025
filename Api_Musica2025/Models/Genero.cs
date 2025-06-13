using System.Text.Json.Serialization;

namespace Api_Musica2025.Models
{
    public class Genero
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

       
        [JsonIgnore] public ICollection<Musica> Musicas { get; set; }
    }
}
