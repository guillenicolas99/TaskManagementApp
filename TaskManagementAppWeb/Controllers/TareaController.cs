using CapaDominio.Entities;
using CapaInfraestructura.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TaskManagementAppWeb.Controllers
{
    public class TareaController : Controller
    {
        private readonly AppDbContext _context;

        public TareaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index ()
        {
            var tareas = _context.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Prioridad)
                .Include(t => t.Categoria)
                .Include(t => t.UsuarioPropietario)
                .Include(t => t.UsuarioAsignado);
            
            return View(await tareas.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Nombre");
            ViewData["IdPrioridad"] = new SelectList(_context.Prioridades, "IdPrioridad", "Nombre");
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Description,FechaEstimadaEntrega,IdEstado,IdPrioridad,IdCategoria,IdUsuarioAsignado")] Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.FechaCreacion = DateTime.Now;
                tarea.IdUsuarioPropietario = 1;

                _context.Tareas.Add(tarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.errorMessage = "No se pudo crear la tarea";
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Nombre", tarea.IdEstado);
            ViewData["IdPrioridad"] = new SelectList(_context.Prioridades, "IdPrioridad", "Nombre", tarea.IdPrioridad);
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre", tarea.IdCategoria);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", tarea.IdUsuarioAsignado);
            return View(tarea);
        }
    }
}
