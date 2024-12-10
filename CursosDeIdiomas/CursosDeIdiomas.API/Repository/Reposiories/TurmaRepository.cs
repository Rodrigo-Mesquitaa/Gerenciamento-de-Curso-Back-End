using CursosDeIdiomas.API.Data;
using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CursosDeIdiomas.API.Repository.Reposiories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly ApplicationDbContext _context;

        public TurmaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Turma> AddTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma> GetTurmaById(int id) => await _context.Turmas.FindAsync(id);

        public async Task<IEnumerable<Turma>> GetAllTurmas() => await _context.Turmas.ToListAsync();

        public async Task<Turma> UpdateTurma(Turma turma)
        {
            _context.Turmas.Update(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task DeleteTurma(int id)
        {
            var turma = await GetTurmaById(id);
            if (turma != null && !turma.Matriculas.Any())
            {
                _context.Turmas.Remove(turma);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Turma não pode ser excluída, pois possui alunos matriculados.");
            }
        }
    }
}
