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
    public class homeController : Controller
    {
        private readonly CitasContext _context;

        public homeController(CitasContext context)
        {
            _context = context;
        }
        public JsonResult getListaMedicos()
        {
            var medicos = _context.Medicos.Select( m => new 
                        {
                            id = m.IdMedico.ToString(),
                            title = m.Nombres,
                            eventcolor = "green"
                        }).ToList();
            return Json(medicos);
        }

        public JsonResult getListaCitas()
        {
            var citas = _context.Citas.Include(x=>x.Medicos).Where(x => x.FechaCita.Date.Month == DateTime.Now.Date.Month).Select( m => new 
                        {
                            id = m.IdCita.ToString(),
                            resourceId = m.IdMedico.ToString(),
                            start = m.FechaCita,
                            end = m.FechaCita.AddMinutes(m.Duracion),
                            title = m.NombreCliente,
                            color = m.Medicos.Color,
                        }).ToList();
            return Json(citas);
        }

        public JsonResult getCitaById(int IdCita)
        {
            var citas = _context.Citas.Find(IdCita);
            return Json(citas);
        }

        public IActionResult Index()
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
