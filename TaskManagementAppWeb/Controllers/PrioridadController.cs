﻿using CapaDominio.Entities;
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

            ViewBag.errorMessage = "No se pudo agregar la prioridad";

            return View(prioridad);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Prioridad? prioridad = _context.Prioridades.FirstOrDefault(x => x.IdPrioridad == id);
            if (prioridad == null)
            {
                return NotFound();
            }

            return View(prioridad);
        }

        [HttpPost]
        public IActionResult Edit(Prioridad prioridad)
        {
            if (ModelState.IsValid)
            {
                _context.Prioridades.Update(prioridad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prioridad);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Prioridad? prioridad = _context.Prioridades.FirstOrDefault(x => x.IdPrioridad == id);
            if (prioridad == null)
            {
                return NotFound();
            }

            return View(prioridad);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(Prioridad prioridad)
        {
            if (prioridad != null)
            {
                // Verificar si el usuario está relacionada con alguna tarea
                bool hasRelatedTareas = _context.Tareas.Any(x => x.IdPrioridad == prioridad.IdPrioridad);
                if (hasRelatedTareas)
                {
                    // Agregar un mensaje de error y retornar a la vista de eliminación
                    ViewBag.errorMessage = "No se puede eliminar esta prioridad porque está relacionado con una o más tareas";
                    return View(prioridad);
                }

                _context.Prioridades.Remove(prioridad);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prioridad);
        }

        private bool PrioridadExists(int id)
        {
            return _context.Prioridades.Any(e => e.IdPrioridad == id);
        }

    }
}

