using Instituto1.Models;

namespace Instituto1.ViewModels;

public class AlumnoViewModel {

    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Dni { get; set; }
    public string CursoSeleccionado { get; set; }
    public virtual List<CursoViewModel>? Cursos { get;set; }
    public List<Alumno> Alumnos {get;set;} = new List<Alumno>();
    public List<int>? CursoIds { get;set; }
    public string NameFilter {get;set;}


}