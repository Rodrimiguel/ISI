using Instituto1.Models;

namespace Instituto1.ViewModels;

public class AlumnoViewModel {

    public List<Alumno> Alumnos {get;set;} = new List<Alumno>();

    public string? NameFilter {get;set;}


}