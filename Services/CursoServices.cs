using Instituto1.Data;
using Instituto1.Models;
using Microsoft.EntityFrameworkCore;


namespace Instituto1.Services;

public class CursoServices : ICursoServices
{   
    private readonly CursoContext _context;

     public CursoServices(CursoContext context)
    {
        _context = context;
    }
    public void Create(Curso obj)
    {
         _context.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var obj = GetById(id);
        
        if (obj != null){
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }

    public List<Curso> GetAll()
    {
        var query = GetQuery();
        return query.ToList();
    }

    public List<Curso> GetAll(string filter)
    {
        var query = GetQuery();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower())
                || x.Duration.ToLower().Contains(filter.ToLower()) 
                || x.Price.ToString().Contains(filter)
                || x.Price.ToString().Contains(filter) 
                || x.Credits.ToString().Contains(filter));              
        }

        return query.ToList();
    }

    public Curso? GetById(int id)
    {
        var Curso = GetQuery()
                .Include(x=> x.Alumnos)
                .FirstOrDefault(m => m.Id == id);

        return Curso;
    }

    public void Update(Curso obj)
    {
        _context.Update(obj);
        _context.SaveChanges();
    }
    private IQueryable<Curso> GetQuery()
    {
        return from curso in _context.Curso select curso;
    }
    
}