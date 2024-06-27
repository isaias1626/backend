using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ApiCrud.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> CriarUsuario([FromBody] UsuarioDTO usuario)
        {
            var usuarioEntidade = new UsuarioEntidade
            {
                Cidade = usuario.Cidade,
                Email = usuario.Email,
                Idade = usuario.Idade,
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone
            };

            _context.usuarioEntidades.Add(usuarioEntidade);
            _context.SaveChanges();
            return Ok(usuario);
        }

        [HttpGet]
        public ActionResult<List<UsuarioEntidade>> GetAll()
        {
            return _context.usuarioEntidades.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioEntidade> GetById(Guid id)
        {
            var usuario = _context.usuarioEntidades.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var usuario = _context.usuarioEntidades.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuarioEntidades.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UsuarioEntidade>> UpdateUsuarios(Guid id, [FromBody] UsuarioDTO usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            var user = await _context.usuarioEntidades.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Email = usuario.Email;
            user.Senha = usuario.Senha;
            user.Nome = usuario.Nome;
            user.Idade = usuario.Idade;
            user.Cidade = usuario.Cidade;
            user.Telefone = usuario.Telefone;

            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
