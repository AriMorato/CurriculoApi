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
    public class StatusCurriculoController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusCurriculoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StatusCurriculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusCurriculo>>> GetStatusCurriculo()
        {
            return await _context.StatusCurriculo.ToListAsync();
        }

        // GET: api/StatusCurriculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusCurriculo>> GetStatusCurriculo(int id)
        {
            var statusCurriculo = await _context.StatusCurriculo.FindAsync(id);

            if (statusCurriculo == null)
            {
                return NotFound();
            }

            return statusCurriculo;
        }

        // PUT: api/StatusCurriculo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusCurriculo(int id, StatusCurriculo statusCurriculo)
        {
            if (id != statusCurriculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(statusCurriculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusCurriculoExists(id))
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

        // POST: api/StatusCurriculo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusCurriculo>> PostStatusCurriculo(StatusCurriculo statusCurriculo)
        {
            _context.StatusCurriculo.Add(statusCurriculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusCurriculo", new { id = statusCurriculo.Id }, statusCurriculo);
        }

        // DELETE: api/StatusCurriculo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusCurriculo(int id)
        {
            var statusCurriculo = await _context.StatusCurriculo.FindAsync(id);
            if (statusCurriculo == null)
            {
                return NotFound();
            }

            _context.StatusCurriculo.Remove(statusCurriculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusCurriculoExists(int id)
        {
            return _context.StatusCurriculo.Any(e => e.Id == id);
        }
    }
}
