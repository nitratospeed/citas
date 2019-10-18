using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using citas.Models;
using Microsoft.EntityFrameworkCore;

namespace citas.Controllers
{
    public class citacontroller : Controller
    {
        private readonly CitasContext _context;

        public citacontroller(CitasContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["Medicos_Nombres_asc"] = String.IsNullOrEmpty(sortOrder) ? "Medicos_Nombres_desc" : "";
            ViewData["NombreCliente_asc"] = String.IsNullOrEmpty(sortOrder) ? "NombreCliente_desc" : "";
            ViewData["FechaCita_asc"] = sortOrder == "Date" ? "FechaCitaParam" : "FechaCita_desc";
            ViewData["Tipo_asc"] = String.IsNullOrEmpty(sortOrder) ? "Tipo_desc" : "";
            
            ViewData["CurrentFilter"] = searchString;
            
            var cita = from s in _context.Citas.Include(s => s.Medicos)
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                cita = cita.Where(s => s.NombreCliente.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "Medicos_Nombres_desc":
                    cita = cita.OrderByDescending(s => s.Medicos.Nombres);
                    break;
                case "Medicos_Nombres_asc":
                    cita = cita.OrderBy(s => s.Medicos.Nombres);
                    break;
                case "NombreCliente_desc":
                    cita = cita.OrderByDescending(s => s.NombreCliente);
                    break;
                case "NombreCliente_asc":
                    cita = cita.OrderBy(s => s.NombreCliente);
                    break;
                case "FechaCita_desc":
                    cita = cita.OrderByDescending(s => s.FechaCita);
                    break;
                case "FechaCita_asc":
                    cita = cita.OrderBy(s => s.FechaCita);
                    break;
                case "Tipo_desc":
                    cita = cita.OrderByDescending(s => s.Tipo);
                    break;
                case "Tipo_asc":
                    cita = cita.OrderBy(s => s.Tipo);
                    break;
                default:
                    cita = cita.OrderBy(s => s.FechaCita);
                    break;
            }
            return View(await cita.AsNoTracking().ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
