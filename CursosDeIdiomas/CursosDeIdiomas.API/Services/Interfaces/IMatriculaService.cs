using CursosDeIdiomas.API.Models;

namespace CursosDeIdiomas.API.Services.Interfaces
{
    public interface IMatriculaService
    {
        Task<Matricula> AddMatricula(Matricula matricula);
        Task<IEnumerable<Matricula>> GetMatriculasByAlunoId(int alunoId); 
        Task<IEnumerable<Matricula>> GetAllMatriculas(); 
        Task DeleteMatricula(int id);
    }
}
