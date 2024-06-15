using CapaDominio.Entities;
using CapaInfraestructura.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var listaUsuarios = await _context.Usuarios.ToListAsync();
            return View(listaUsuarios);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.errorMessage = "No se pudo agregar el usuario";

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Usuario? usuario = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Usuario? usuario = _context.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Usuario usuario)
        {
            if (usuario != null)
            {
                // Verificar si el usuario está relacionada con alguna tarea
                bool hasRelatedTareas = _context.Tareas.Any(x => x.IdUsuarioPropietario == usuario.IdUsuario);
                if (hasRelatedTareas)
                {
                    // Agregar un mensaje de error y retornar a la vista de eliminación
                    ViewBag.errorMessage = "No se puede eliminar el usuario porque está relacionado con una o más tareas";
                    return View(usuario);
                }

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }

    }
}