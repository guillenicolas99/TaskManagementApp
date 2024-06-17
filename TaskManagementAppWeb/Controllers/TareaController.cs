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
            ViewData["IdEstado"] = new SelectList(_context.Estados, "IdEstado", "Nombre");
            ViewData["IdPrioridad"] = new SelectList(_context.Prioridades, "IdPrioridad", "Nombre");
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetTareas()
        {
            var tareas = await _context.Tareas
                .Include(t => t.Estado)
                .Include (t => t.Prioridad)
                .Include(t => t.Categoria)
                .Include(t => t.UsuarioPropietario)
                .Include(t => t.UsuarioAsignado)
                .Select(t => new
                {
                    t.IdTarea,
                    t.Title,
                    t.FechaCreacion,
                    t.FechaEstimadaEntrega,
                    Estado = t.Estado.Nombre,
                    Prioridad = t.Prioridad.Nombre,
                    Categoria = t.Categoria.Nombre,
                    Propietario = t.UsuarioPropietario.Nombre,
                    AsiggnadoA = t.UsuarioAsignado.Nombre
                }).ToListAsync();
            return Json(tareas);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tarea tarea = await _context.Tareas.FirstOrDefaultAsync(x => x.IdTarea == id);
            if (tarea == null)
            {
                return NotFound();
            }

            ViewData["Estados"] = new SelectList(_context.Estados, "IdEstado", "Nombre", tarea.IdEstado);
            ViewData["Prioridades"] = new SelectList(_context.Prioridades, "IdPrioridad", "Nombre", tarea.IdPrioridad);
            ViewData["Categorias"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre", tarea.IdCategoria);
            ViewData["Usuarios"] = new SelectList(_context.Usuarios, "IdUsuario", "Nombre", tarea.IdUsuarioAsignado);
            return View(tarea);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tareaDetails = await _context.Tareas
                .Include(t => t.Estado)
                .Include(t => t.Prioridad)
                .Include(t => t.Categoria)
                .Include(t => t.UsuarioPropietario)
                .Include(t => t.UsuarioAsignado)
                .Include(t => t.Comentarios)
                .ThenInclude(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdTarea == id);

            if (tareaDetails == null)
            {
                return NotFound();
            }

            return View(tareaDetails);
        }
    }
}
