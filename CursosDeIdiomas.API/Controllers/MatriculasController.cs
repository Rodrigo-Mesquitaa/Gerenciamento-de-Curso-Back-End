using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursosDeIdiomas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculasController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculasController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatricula([FromBody] Matricula matricula)
        {
            var result = await _matriculaService.AddMatricula(matricula);
            return CreatedAtAction(nameof(GetMatriculasByAlunoId), new { alunoId = matricula.AlunoId }, result);
        }

        [HttpGet("aluno/{alunoId}")]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculasByAlunoId(int alunoId)
        {
            return Ok(await _matriculaService.GetMatriculasByAlunoId(alunoId));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetAllMatriculas() => Ok(await _matriculaService.GetAllMatriculas());

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatricula(int id)
        {
            await _matriculaService.DeleteMatricula(id);
            return NoContent();
        }
    }
}
