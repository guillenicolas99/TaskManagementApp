using CapaDominio.Entities;
using CapaInfraestructura.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAppWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var listaCategorias = await _context.Categorias.ToListAsync();
            return View(listaCategorias);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if(ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.errorMessage = "No se pudo agregar categoría";

            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Categoria? categoria = _context.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Categoria? categoria = _context.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Categoria categoria)
        {
            if (categoria != null)
            {
                // Verificar si la categoría está relacionada con alguna tarea
                bool hasRelatedTareas = _context.Tareas.Any(x => x.IdCategoria == categoria.IdCategoria);
                if (hasRelatedTareas)
                {
                    // Agregar un mensaje de error y retornar a la vista de eliminación
                    ViewBag.errorMessage = "No se puede eliminar la categoría porque está relacionada con una o más tareas";
                    return View(categoria);
                }

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.IdCategoria == id);
        }

    }
}
