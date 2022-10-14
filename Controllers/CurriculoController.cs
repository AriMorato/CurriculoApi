using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CurriculoApi.Data;
using CurriculoApi.Model;

namespace CurriculoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculoController : ControllerBase
    {
        private readonly DataContext _context;

        public CurriculoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Curriculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculo>>> GetCurriculo()
        {
            return await _context.Curriculo.ToListAsync();
        }

        // GET: api/Curriculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curriculo>> GetCurriculo(int id)
        {
            var curriculo = await _context.Curriculo.FindAsync(id);

            if (curriculo == null)
            {
                return NotFound();
            }

            return curriculo;
        }

        // PUT: api/Curriculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurriculo(int id, Curriculo curriculo)
        {
            if (id != curriculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(curriculo).State = EntityState.Modified;

            try
            {
               await _context.SaveChangesAsync();

                Historico hs = new Historico();
                hs.IdCurriculo = id;
                hs.Data = DateTime.Now;
                hs.Detalhes = "Atualização do Curriculo CPF: " + curriculo.Cpf;

                _context.Historico.Add(hs);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurriculoExists(id))
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

        // POST: api/Curriculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curriculo>> PostCurriculo(Curriculo curriculo)
        {
          
            _context.Curriculo.Add(curriculo);
            await _context.SaveChangesAsync();


            Historico hs = new Historico();
            hs.IdCurriculo = curriculo.Id;
            hs.Data = DateTime.Now;
            hs.Detalhes = "Novo Curriculo CPF: " + curriculo.Cpf;

            _context.Historico.Add(hs);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetCurriculo", new { id = curriculo.Id }, curriculo);
        }

        // DELETE: api/Curriculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurriculo(int id)
        {
            var curriculo = await _context.Curriculo.FindAsync(id);
            if (curriculo == null)
            {
                return NotFound();
            }
            curriculo.Ativo = false;
            //_context.Curriculo.Remove(curriculo)

            _context.Entry(curriculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            Historico hs = new Historico();
            hs.IdCurriculo = id;
            hs.Data = DateTime.Now;
            hs.Detalhes = "Exclusão(Inativo) do Curriculo CPF: " + curriculo.Cpf;

            _context.Historico.Add(hs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurriculoExists(int id)
        {
            return _context.Curriculo.Any(e => e.Id == id);
        }
    }
}
