using CursosDeIdiomas.API.Models;

namespace CursosDeIdiomas.API.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<Aluno> AddAluno(Aluno aluno);
        Task<Aluno> GetAlunoById(int id); 
        Task<IEnumerable<Aluno>> GetAllAlunos(); 
        Task<Aluno> UpdateAluno(Aluno aluno);
        Task DeleteAluno(int id);
    }
}
