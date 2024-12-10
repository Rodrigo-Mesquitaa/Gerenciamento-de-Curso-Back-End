using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursosDeIdiomas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAluno([FromBody] Aluno aluno)
        {
            var result = await _alunoService.AddAluno(aluno);
            return CreatedAtAction(nameof(GetAluno), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _alunoService.GetAlunoById(id);
            if (aluno == null) return NotFound();
            return aluno;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAllAlunos() => Ok(await _alunoService.GetAllAlunos());

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, [FromBody] Aluno aluno)
        {
            if (id != aluno.Id) return BadRequest();
            await _alunoService.UpdateAluno(aluno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            await _alunoService.DeleteAluno(id);
            return NoContent();
        }
    }
}
