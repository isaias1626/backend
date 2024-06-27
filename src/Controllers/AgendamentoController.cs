using ApiCrud.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AgendamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<AgendamentoDTO>> CriarAgendamento([FromBody] AgendamentoDTO usuario)
        {
            var agendamentoEntidade = new AgendamentoEntidade
            {
                Data = usuario.Data,
                Hora = usuario.Hora,
            };

            _context.agendamentoEntidades.Add(agendamentoEntidade);
            _context.SaveChanges();
            return Ok(usuario);
        }

        [HttpGet]
        public ActionResult<List<AgendamentoEntidade>> GetAll()
        {
            return _context.agendamentoEntidades.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<AgendamentoEntidade> GetById(Guid id)
        {
            var usuario = _context.agendamentoEntidades.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(Guid id)
        {
            var usuario = _context.agendamentoEntidades.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.agendamentoEntidades.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<AgendamentoEntidade>> UpdateAgendamento(Guid id, [FromBody] AgendamentoDTO usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            var user = await _context.agendamentoEntidades.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Data = usuario.Data;
            user.Hora = usuario.Hora;

            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
