using CapaDominio.Entities;
using CapaInfraestructura.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAppWeb.Controllers
{
    public class EstadoController : Controller
    {
        private readonly AppDbContext _context;

        public EstadoController (AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var listaEstados = await _context.Estados.ToListAsync();
            return View(listaEstados);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estado estado)
        {
            if (ModelState.IsValid)
            {
                _context.Estados.Add(estado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.errorMessage = "No se pudo agregar este estado";

            return View(estado);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Estado? estado = _context.Estados.FirstOrDefault(x => x.IdEstado == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [HttpPost]
        public IActionResult Edit(Estado estado)
        {
            if (ModelState.IsValid)
            {
                _context.Estados.Update(estado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Estado? estado = _context.Estados.FirstOrDefault(x => x.IdEstado == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Estado estados)
        {
            if (estados != null)
            {
                // Verificar si el estado está relacionada con alguna tarea
                bool hasRelatedTareas = _context.Tareas.Any(x => x.IdEstado == estados.IdEstado);
                if (hasRelatedTareas)
                {
                    // Agregar un mensaje de error y retornar a la vista de eliminación
                    ViewBag.errorMessage = "No se puede eliminar el estado porque está relacionada con una o más tareas";
                    return View(estados);
                }

                _context.Estados.Remove(estados);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estados);
        }

        private bool CategoriaExists(int id)
        {
            return _context.Estados.Any(e => e.IdEstado == id);
        }

    }
}
