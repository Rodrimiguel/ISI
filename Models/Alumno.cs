using System.ComponentModel.DataAnnotations;

namespace Instituto1.Models;

public class Alumno
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    public string Name { get; set; }

    [Display(Name = "Apellido")]
    public string LastName { get; set; }

    [Display(Name = "DNI")]
    public string Dni { get; set; }

    [Display(Name = "Curso Seleccionado")]
    public string CursoSeleccionado { get; set; }

    public virtual List<Curso>? Cursos { get; set; }
}
