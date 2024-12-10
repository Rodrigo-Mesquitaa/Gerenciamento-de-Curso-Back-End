using CursosDeIdiomas.API.Data;
using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CursosDeIdiomas.API.Repository.Reposiories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _context;

        public AlunoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {
            if (await _context.Alunos.AnyAsync(a => a.CPF == aluno.CPF))
                throw new Exception("Aluno já cadastrado.");

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> GetAlunoById(int id) => await _context.Alunos.FindAsync(id);

        public async Task<IEnumerable<Aluno>> GetAllAlunos() => await _context.Alunos.ToListAsync();

        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }

        public async Task DeleteAluno(int id)
        {
            var aluno = await GetAlunoById(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }
    }
}
