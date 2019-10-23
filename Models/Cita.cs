using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace citas.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }
        public int IdMedico { get; set; }
        
        [ForeignKey("IdMedico")]
        public virtual Medico Medicos { get; set; }
        [Display(Name = "Fecha de Cita")]
        public DateTime FechaCita { get; set; }
        [Display(Name = "Cliente")]
        public String NombreCliente { get; set; }
        [Display(Name = "Correo Cliente")]
        public String Movil { get; set; }
        public String CorreoCliente { get; set; }
        [Display(Name = "Duración")]
        public int Duracion { get; set; }
        public String Tipo { get; set; }
        public String Comentarios { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}