using Api_Musica2025.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api_Musica2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private static List<Genero> generos = new List<Genero>
        {
            new Genero { Id = 1, Nome = "MPB" },
            new Genero { Id = 2, Nome = "Funk" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Genero>> GetTodos() => Ok(generos);

        [HttpGet("{id}")]
        public ActionResult<Genero> GetPorId(int id)
        {
            var genero = generos.FirstOrDefault(g => g.Id == id);
            return genero == null ? NotFound() : Ok(genero);
        }

        [HttpPost]
        public ActionResult<Genero> Criar(Genero novoGenero)
        {
            novoGenero.Id = generos.Max(g => g.Id) + 1;
            generos.Add(novoGenero);
            return CreatedAtAction(nameof(GetPorId), new { id = novoGenero.Id }, novoGenero);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Genero generoAtualizado)
        {
            var genero = generos.FirstOrDefault(g => g.Id == id);
            if (genero == null) return NotFound();

            genero.Nome = generoAtualizado.Nome;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var genero = generos.FirstOrDefault(g => g.Id == id);
            if (genero == null) return NotFound();

            generos.Remove(genero);
            return NoContent();
        }
    }
}
