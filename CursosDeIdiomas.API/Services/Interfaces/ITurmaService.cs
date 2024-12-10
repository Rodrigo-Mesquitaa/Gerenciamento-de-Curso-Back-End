using CursosDeIdiomas.API.Models;

namespace CursosDeIdiomas.API.Services.Interfaces
{
    public interface ITurmaService
    {
        Task<Turma> AddTurma(Turma turma); 
        Task<Turma> GetTurmaById(int id);
        Task<IEnumerable<Turma>> GetAllTurmas(); 
        Task<Turma> UpdateTurma(Turma turma);
        Task DeleteTurma(int id);
    }
}
