using Instituto1.Data;
using Instituto1.Models;
using Microsoft.EntityFrameworkCore;

namespace Instituto1.Services;

public class AlumnoServices : IAlumnoServices
{
    private readonly CursoContext _context;

    public AlumnoServices(CursoContext context)
    {
        _context = context;
    }
    public void Create(Alumno obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(Alumno obj)
    {
        _context.Remove(obj);
        _context.SaveChanges();
    }

    public List<Alumno> GetAll()
    {
        return _context.Alumno.Include(x => x.Cursos).ToList();
    }
    
    public List<Alumno> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower())
                || x.LastName.ToLower().Contains(filter.ToLower()) 
                || x.Dni.ToString().Contains(filter));
        }

        return query.ToList();
    }

    public Alumno? GetById(int id)
    {
        var estudiante = _context.Alumno
                .Include(r => r.Cursos)
                .FirstOrDefault(m => m.Id == id);

        return estudiante;
    }

    public void Update(Alumno obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }

    private IQueryable<Alumno> GetQuery()
    {
        return from alumno in _context.Alumno select alumno;
    }
}

