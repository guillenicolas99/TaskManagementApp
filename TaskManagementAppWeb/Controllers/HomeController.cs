using CapaInfraestructura.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TaskManagementAppWeb.Models;

namespace TaskManagementAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.categorias = _context.Categorias.Count();
            ViewBag.estados = _context.Estados.Count();
            ViewBag.tareas = _context.Tareas.Count();
            ViewBag.usuarios = _context.Usuarios.Count();
            ViewBag.prioridades = _context.Prioridades.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
