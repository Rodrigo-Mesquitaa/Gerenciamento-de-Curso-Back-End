using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Repository.Interfaces;
using CursosDeIdiomas.API.Services.Interfaces;

namespace CursosDeIdiomas.API.Services.Servicies
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {
            return await _alunoRepository.AddAluno(aluno);
        }

        public async Task<Aluno> GetAlunoById(int id) => await _alunoRepository.GetAlunoById(id);

        public async Task<IEnumerable<Aluno>> GetAllAlunos() => await _alunoRepository.GetAllAlunos();

        public async Task<Aluno> UpdateAluno(Aluno aluno) => await _alunoRepository.UpdateAluno(aluno);

        public async Task DeleteAluno(int id) => await _alunoRepository.DeleteAluno(id);
    }
}
