using Api_Musica2025.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api_Musica2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistaController : ControllerBase
    {
        private static List<Artista> artistas = new List<Artista>
        {
            new Artista { Id = 1, Nome = "Gilberto Gil", EstiloMusical = "MPB" },
            new Artista { Id = 2, Nome = "Ludmilla", EstiloMusical = "Funk" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Artista>> GetTodos() => Ok(artistas);

        [HttpGet("{id}")]
        public ActionResult<Artista> GetPorId(int id)
        {
            var artista = artistas.FirstOrDefault(a => a.Id == id);
            return artista == null ? NotFound() : Ok(artista);
        }

        [HttpPost]
        public ActionResult<Artista> Criar(Artista novoArtista)
        {
            novoArtista.Id = artistas.Max(a => a.Id) + 1;
            artistas.Add(novoArtista);
            return CreatedAtAction(nameof(GetPorId), new { id = novoArtista.Id }, novoArtista);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Artista artistaAtualizado)
        {
            var artista = artistas.FirstOrDefault(a => a.Id == id);
            if (artista == null) return NotFound();

            artista.Nome = artistaAtualizado.Nome;
            artista.EstiloMusical = artistaAtualizado.EstiloMusical;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var artista = artistas.FirstOrDefault(a => a.Id == id);
            if (artista == null) return NotFound();

            artistas.Remove(artista);
            return NoContent();
        }
    }
}
