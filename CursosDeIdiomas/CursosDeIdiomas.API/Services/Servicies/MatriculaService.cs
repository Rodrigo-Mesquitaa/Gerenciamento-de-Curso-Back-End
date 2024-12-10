using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Repository.Interfaces;
using CursosDeIdiomas.API.Services.Interfaces;

namespace CursosDeIdiomas.API.Services.Servicies
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<Matricula> AddMatricula(Matricula matricula) => await _matriculaRepository.AddMatricula(matricula);

        public async Task<IEnumerable<Matricula>> GetMatriculasByAlunoId(int alunoId) => await _matriculaRepository.GetMatriculasByAlunoId(alunoId);

        public async Task<IEnumerable<Matricula>> GetAllMatriculas() => await _matriculaRepository.GetAllMatriculas();

        public async Task DeleteMatricula(int id) => await _matriculaRepository.DeleteMatricula(id);
    }
}
