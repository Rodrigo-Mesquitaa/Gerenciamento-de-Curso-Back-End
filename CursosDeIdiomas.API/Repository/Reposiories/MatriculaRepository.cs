using CursosDeIdiomas.API.Data;
using CursosDeIdiomas.API.Models;
using CursosDeIdiomas.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CursosDeIdiomas.API.Repository.Reposiories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly ApplicationDbContext _context;

        public MatriculaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Matricula> AddMatricula(Matricula matricula)
        {
            if (await _context.Matriculas.AnyAsync(m => m.AlunoId == matricula.AlunoId && m.TurmaId == matricula.TurmaId))
                throw new Exception("Matrícula já existente para este aluno nesta turma.");

            var turma = await _context.Turmas.Include(t => t.Matriculas).FirstOrDefaultAsync(t => t.Id == matricula.TurmaId);
            if (turma != null && turma.Matriculas.Count >= 5)
                throw new Exception("Não é possível matricular mais de 5 alunos na mesma turma.");

            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<IEnumerable<Matricula>> GetMatriculasByAlunoId(int alunoId)
        {
            return await _context.Matriculas
                .Include(m => m.Turma)
                .Where(m => m.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Matricula>> GetAllMatriculas() => await _context.Matriculas.ToListAsync();

        public async Task DeleteMatricula(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula != null)
            {
                _context.Matriculas.Remove(matricula);
                await _context.SaveChangesAsync();
            }
        }
    }
}
