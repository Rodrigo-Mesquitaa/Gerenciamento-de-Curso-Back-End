using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Repository.Interfaces;
using CursosDeIdiomas.API.Services.Interfaces;

namespace CursosDeIdiomas.API.Services.Servicies
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<Turma> AddTurma(Turma turma) => await _turmaRepository.AddTurma(turma);

        public async Task<Turma> GetTurmaById(int id) => await _turmaRepository.GetTurmaById(id);

        public async Task<IEnumerable<Turma>> GetAllTurmas() => await _turmaRepository.GetAllTurmas();

        public async Task<Turma> UpdateTurma(Turma turma) => await _turmaRepository.UpdateTurma(turma);

        public async Task DeleteTurma(int id) => await _turmaRepository.DeleteTurma(id);
    }
}
