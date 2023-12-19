using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Instituto1.Data;
using Instituto1.Models;
using Instituto1.ViewModels;
using Instituto1.Services;

namespace Instituto1.Controllers
{
    public class AlumnoController : Controller
    {
        private IAlumnoServices _alumnoServices;  
        private ICursoServices _cursoServices;

        public AlumnoController(IAlumnoServices estudianteService, ICursoServices cursoService)
        {
            _alumnoServices = estudianteService;
            _cursoServices = cursoService;
        }

        // GET: Alumno
        public IActionResult Index(string nameFilter)
        {
            var model = new AlumnoViewModel();
            model.Alumnos = _alumnoServices.GetAll(nameFilter);
            return View(model);
        }

        // GET: Alumno/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = _alumnoServices.GetById(id.Value);
            if (alumno == null)
            {
                return NotFound();
            }
            var model = new Alumno();
            model.Name = alumno.Name;
            model.LastName = alumno.LastName;
            model.Dni = alumno.Dni;
            model.CursoSeleccionado = alumno.CursoSeleccionado;

            return View(alumno);
        }

        // GET: Alumno/Create
        public IActionResult Create()
        {   
            var cursosList  = _cursoServices.GetAll();
            ViewData["Cursos"] = new SelectList(cursosList, "Id", "Name");
            return View();
        }

        // POST: Alumno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,LastName,Dni,CursoSeleccionado")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _alumnoServices.Create(alumno);
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        // GET: Alumno/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = _alumnoServices.GetById(id.Value);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        // POST: Alumno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,LastName,Dni,CursoSeleccionado")] Alumno alumno)
        {
              if (id != alumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _alumnoServices.Update(alumno);
                return RedirectToAction(nameof(Index));
            }
            
            return View(alumno);
        }

        // GET: Alumno/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = _alumnoServices.GetById(id.Value);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var estudiante = _alumnoServices.GetById(id);
            if (estudiante != null)
            {
                _alumnoServices.Delete(estudiante);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
          return _alumnoServices.GetById(id) != null;
        }
    }
}
