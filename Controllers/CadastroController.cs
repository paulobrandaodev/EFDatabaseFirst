using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDatabaseFirts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirts.Controllers
{
    // Definir Rota da API
    // Definir que é um Controller de API
    // Herdar ControllerBase
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        // Instanciar meu contexto que faz as chamadas do banco
        testeContext _context = new testeContext();      

         // GET: api/Cadastro/
        [HttpGet]
        public async Task<ActionResult<List<Cadastro>>> Get()
        {
            var cadastros = await _context.Cadastro.Include(e => e.Endereco).ToListAsync();

            if (cadastros == null)
            {
                return NotFound();
            }

            return cadastros;
        }

        // GET: api/Cadastro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cadastro>> Get(int id)
        {
            var cadastro = await _context.Cadastro.Include(e => e.Endereco).FirstOrDefaultAsync(e => e.IdCadastro == id);

            if (cadastro == null)
            {
                return NotFound();
            }

            return cadastro;
        }

        // PUT: api/Cadastro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Cadastro cadastro)
        {
            if (id != cadastro.IdCadastro)
            {
                return BadRequest();
            }

            _context.Entry(cadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var cadastro_valido = await _context.Cadastro.FindAsync(id);

                if (cadastro_valido == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Cadastro/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cadastro>> Delete(int id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }

            _context.Cadastro.Remove(cadastro);
            await _context.SaveChangesAsync();

            return cadastro;
        }


    }
}