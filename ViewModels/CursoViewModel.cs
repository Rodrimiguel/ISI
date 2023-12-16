using Instituto1.Models;

namespace  Instituto1.ViewModels;

public class CursoViewModel {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Duration { get; set; }
    public double Price { get; set; }
    public int Credits { get; set; }
    public List<Curso> Cursos { get; set; } = new List<Curso>();
    public string? NameFilter { get; set; }

}