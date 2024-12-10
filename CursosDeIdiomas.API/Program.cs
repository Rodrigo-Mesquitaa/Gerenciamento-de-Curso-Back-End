using Microsoft.EntityFrameworkCore;
using CursosDeIdiomas.API.Data;
using CursosDeIdiomas.API.Repository.Interfaces;
using CursosDeIdiomas.API.Services.Interfaces;
using CursosDeIdiomas.API.Repository.Reposiories;
using CursosDeIdiomas.API.Services.Servicies;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adicionar serviços ao contêiner.
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("CursosDeIdiomasDB"));

        builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
        builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
        builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
        builder.Services.AddScoped<IAlunoService, AlunoService>();
        builder.Services.AddScoped<ITurmaService, TurmaService>();
        builder.Services.AddScoped<IMatriculaService, MatriculaService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        // Configuração do Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Cursos de Idiomas API", Version = "v1" });
        });

        var app = builder.Build();

        // Configurar o pipeline de requisições.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cursos de Idiomas API v1");
            c.RoutePrefix = string.Empty; // Faz com que o Swagger UI esteja acessível na raiz da aplicação
        });

        app.MapControllers();

        app.Run();
    }
}