using Microsoft.EntityFrameworkCore;
using CursosDeIdiomas.API.Models;

namespace CursosDeIdiomas.API.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Verifica se o banco já foi populado
                if (context.Alunos.Any() || context.Turmas.Any() || context.Matriculas.Any())
                {
                    return; // O banco de dados já foi populado.
                }

                // Adicionar alunos
                var aluno1 = new Aluno { Nome = "João Silva", CPF = "12345678901" };
                var aluno2 = new Aluno { Nome = "Maria Oliveira", CPF = "09876543210" };

                context.Alunos.AddRange(aluno1, aluno2);

                // Adicionar turmas
                var turma1 = new Turma { Nome = "Inglês Básico" };
                var turma2 = new Turma { Nome = "Espanhol Intermediário" };

                context.Turmas.AddRange(turma1, turma2);

                // Salvar as alterações
                context.SaveChanges();

                // Adicionar matrículas
                context.Matriculas.AddRange(
                    new Matricula { AlunoId = aluno1.Id, TurmaId = turma1.Id },
                    new Matricula { AlunoId = aluno2.Id, TurmaId = turma2.Id }
                );

                context.SaveChanges();
            }
        }
    }
}