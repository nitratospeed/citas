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
    public class medicoController : Controller
    {
        private readonly CitasContext _context;

        public medicoController(CitasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult getListaMedicos()
        {
            var medicos = _context.Medicos
            // .Include(x=>x.Horarios)
            .ToList();

            return Json(medicos);
        }
        
/*         public JsonResult postCita(Cita objCita)
        {
            try
            {
                objCita.FechaRegistro = DateTime.Now;
                _context.Citas.Add(objCita);
                _context.SaveChanges();

                return Json("1");     
            }
            catch (System.Exception)
            {        
                return Json("0");
            }
        } */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
