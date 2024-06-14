using CapaDominio.Entities;
using CapaInfraestructura.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskManagementAppWeb.Controllers
{
    public class PrioridadController : Controller
    {
        private readonly AppDbContext _context;

        public PrioridadController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var listaPrioridades = await _context.Prioridades.ToListAsync();
            return View(listaPrioridades);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Prioridad prioridad)
        {
            if (ModelState.IsValid)
            {
                _context.Prioridades.Add(prioridad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.errorMessage = "No se pudo agregar categoría";

            return View(prioridad);
        }
    }
}
