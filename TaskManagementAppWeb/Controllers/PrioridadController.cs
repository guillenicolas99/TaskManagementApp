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

        public IActionResult Create()
        {
            return View();
        }
    }
}
