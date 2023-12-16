using System.ComponentModel.DataAnnotations;

namespace Instituto1.Models;

public class Curso
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    public string Name { get; set; }

    [Display(Name = "Duración")]
    public string Duration { get; set; }

    [Display(Name = "Precio")]
    public double Price { get; set; }

    [Display(Name = "Créditos")]
    public int Credits { get; set; }

    public virtual List<Alumno>? Alumnos { get; set; }
}
