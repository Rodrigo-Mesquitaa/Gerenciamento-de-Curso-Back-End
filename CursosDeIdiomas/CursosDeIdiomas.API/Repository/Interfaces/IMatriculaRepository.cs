using CursosDeIdiomas.API.Models;

namespace CursosDeIdiomas.API.Repository.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Matricula> AddMatricula(Matricula matricula);
        Task<IEnumerable<Matricula>> GetMatriculasByAlunoId(int alunoId);
        Task<IEnumerable<Matricula>> GetAllMatriculas();
        Task DeleteMatricula(int id);
    }
}
