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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult getListaMedicos()
        {
            try
            {
                var medicos = _context.Medicos.Select( m => new 
                {
                    id = m.IdMedico.ToString(),
                    title = m.Nombres,
                    eventcolor = "green"
                }).ToList();

                return Ok(medicos);        
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        public JsonResult getListaMedicosById(int medico)
        {       
            if (medico==0)
            {
                var medicosb = _context.Medicos.Select( m => new 
                {
                    id = m.IdMedico.ToString(),
                    title = m.Nombres,
                    eventcolor = "green"
                }).ToList();

                return Json(medicosb);              
            }   
              
            var medicos = _context.Medicos.Where(x=>x.IdMedico==medico).Select( m => new 
            {
                id = m.IdMedico.ToString(),
                title = m.Nombres,
                eventcolor = "green"
            }).ToList();

            return Json(medicos);
        }

        public JsonResult getCitaById(int IdCita)
        {
            var citas = _context.Citas.Find(IdCita);
            return Json(citas);
        }

        public JsonResult getListaCitas(string nombre, int medico)
        {
            if (nombre == null)
            {
                nombre = "";      
            }

            var citas = _context.Citas.Include(x=>x.Medicos).Include(x=>x.Tipos)
                        .Select( m => new 
                            {
                            id = m.IdCita.ToString(),
                            resourceId = m.IdMedico.ToString(),
                            start = m.FechaInicioCita,
                            end = m.FechaFinCita,
                            title = m.NombreCliente,
                            color = m.Tipos.Color,
                            }).ToList();

            if (nombre != "" && medico != 0)
            {
                var citasx = citas.Where(s => 
                        (s.title.ToLower().Contains(nombre.ToLower())) 
                        && (s.resourceId == medico.ToString()));   
                                    return Json(citasx);   
            }

            if (nombre != "" && medico == 0)
            {
                var citasx = citas.Where(s => s.title.ToLower().Contains(nombre.ToLower()));   
                            return Json(citasx);   
            }

            if (nombre == "" && medico != 0)
            {
                var citasx = citas.Where(s => (s.resourceId == medico.ToString()));      
                            return Json(citasx);
            }
            else  
            {
                return Json(citas);
            }
        }
        
        public JsonResult getListaTipos()
        {
            var tipos = _context.Tipos.Select( t => new 
            {
                id = t.IdTipo.ToString(),
                title = t.Descripcion
            }).ToList();

            return Json(tipos);
        }

        public JsonResult postCita(Cita objCita)
        {
            try
            {
                if (objCita.IdCita == 0){
                objCita.FechaRegistro = DateTime.Now;
                objCita.FechaFinCita = objCita.FechaInicioCita.AddMinutes(objCita.Duracion);
                _context.Citas.Add(objCita);
                _context.SaveChanges();

                return Json("1");  
                }
                else{
                    return Json("0");
                }
            }
            catch (System.Exception)
            {        
                return Json("0");
            }
        }

        public IActionResult updateCita(Cita objCita)
        {
            try
            {
                objCita.FechaFinCita = objCita.FechaInicioCita.AddMinutes(objCita.Duracion);
                _context.Update(objCita);
                _context.SaveChanges();
                return Json("1");  
            }
            catch (System.Exception)
            {
                return Json("0");  
            }
        }

        public IActionResult deleteCita(int idCita)
        {
            try
            {
                var cita = _context.Citas.Find(idCita);
                _context.Citas.Remove(cita);
                _context.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest(idCita);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
