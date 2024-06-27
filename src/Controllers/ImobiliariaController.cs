using System.Data.Entity;
using ApiCrud.Data;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImobiliariaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ImobiliariaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ImobiliariaDTO>> CriarImovel([FromBody] ImobiliariaDTO imobiliaria)
        {
            var imobiliariaEntidade = new ImobiliariaEntidade
            {
                Tipo = imobiliaria.Tipo,
                Preco = imobiliaria.Preco,
                Localizacao = imobiliaria.Localizacao,
                Link_detalhes = imobiliaria.Link_detalhes,
                Foto = imobiliaria.Foto,
                Descricao = imobiliaria.Descricao,
                Caracteristicas = imobiliaria.Caracteristicas,
                contatoCorretor = imobiliaria.contatoCorretor,
            };

            _context.imobiliariaEntidades.Add(imobiliariaEntidade);
            _context.SaveChanges();
            return Ok(imobiliaria);
        }

        [HttpGet]
        public ActionResult<List<ImobiliariaEntidade>> GetAll()
        {
            return _context.imobiliariaEntidades.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ImobiliariaEntidade> GetById(Guid id)
        {
            var imobiliaria = _context.imobiliariaEntidades.FirstOrDefault(u => u.Id == id);
            if (imobiliaria == null)
            {
                return NotFound();
            }
            return Ok(imobiliaria);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImobiliaria(Guid id)
        {
            var imobiliaria = _context.imobiliariaEntidades.FirstOrDefault(u => u.Id == id);
            if (imobiliaria == null)
            {
                return NotFound();
            }

            _context.imobiliariaEntidades.Remove(imobiliaria);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ImobiliariaEntidade>> UpdateImovel(Guid id, [FromBody] ImobiliariaDTO imobiliaria)
        {
            if (imobiliaria == null)
            {
                return BadRequest();
            }

            var imovel = await _context.imobiliariaEntidades.FindAsync(id);

            if (imovel == null)
            {
                return NotFound();
            }

            imovel.Tipo = imobiliaria.Tipo;
            imovel.Preco = imobiliaria.Preco;
            imovel.Localizacao = imobiliaria.Localizacao;
            imovel.Link_detalhes = imobiliaria.Link_detalhes;
            imovel.Foto = imobiliaria.Foto;
            imovel.Descricao = imobiliaria.Descricao;
            imovel.Caracteristicas = imobiliaria.Caracteristicas;
            imovel.contatoCorretor = imobiliaria.contatoCorretor;

            await _context.SaveChangesAsync();

            return Ok(imovel);
        }
    }
}