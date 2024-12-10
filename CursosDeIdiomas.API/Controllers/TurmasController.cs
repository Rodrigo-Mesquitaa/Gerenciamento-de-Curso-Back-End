using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursosDeIdiomas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmasController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurma([FromBody] Turma turma)
        {
            var result = await _turmaService.AddTurma(turma);
            return CreatedAtAction(nameof(GetTurma), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            var turma = await _turmaService.GetTurmaById(id);
            if (turma == null) return NotFound();
            return turma;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetAllTurmas() => Ok(await _turmaService.GetAllTurmas());

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTurma(int id, [FromBody] Turma turma)
        {
            if (id != turma.Id) return BadRequest();
            await _turmaService.UpdateTurma(turma);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            await _turmaService.DeleteTurma(id);
            return NoContent();
        }
    }
}
