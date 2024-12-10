using Microsoft.EntityFrameworkCore;
using CursosDeIdiomas.API.Models;

namespace CursosDeIdiomas.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de Aluno
            modelBuilder.Entity<Aluno>()
                .HasIndex(a => a.CPF)
                .IsUnique(); // Garantir que o CPF seja único

            // Configurações de Turma
            modelBuilder.Entity<Turma>()
                .HasMany(t => t.Matriculas)
                .WithOne(m => m.Turma)
                .HasForeignKey(m => m.TurmaId);

            // Configurações de Matricula
            modelBuilder.Entity<Matricula>()
                .HasKey(m => new { m.AlunoId, m.TurmaId }); // Chave composta para garantir que um aluno só pode estar matriculado uma vez em uma turma

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(m => m.AlunoId);
        }
    }
}