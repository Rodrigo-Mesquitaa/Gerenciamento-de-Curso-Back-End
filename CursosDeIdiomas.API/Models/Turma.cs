namespace CursosDeIdiomas.API.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
