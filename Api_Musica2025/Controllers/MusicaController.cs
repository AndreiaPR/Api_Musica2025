using Api_Musica2025.Context;
using Api_Musica2025.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Musica2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicaController : ControllerBase
    {
        private readonly DataBase _context; // Alterado para usar o contexto correto  

        public MusicaController(DataBase context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Musica>>> GetTodas()
        {
            List<Musica> musicas = await _context.Musicas
                .Include(m => m.Artista)
                .Include(m => m.Genero)
                .ToListAsync();

            return Ok(musicas); // Adicionado retorno da lista de músicas  
        }
    }
}
