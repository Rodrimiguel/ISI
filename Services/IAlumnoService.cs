using Instituto1.Models;

namespace Instituto1.Services;

public interface IAlumnoServices
{
    void Create (Alumno obj);
    List<Alumno> GetAll();
    List<Alumno> GetAll(string filter);
    void Update (Alumno obj);
    void Delete (Alumno obj);
    Alumno? GetById(int id);
}