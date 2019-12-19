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
        public String DNI { get; set; }
        public String Pago { get; set; }
        public String Nombre { get; set; }
        public String Celular { get; set; }
        public String Correo { get; set; }
        public DateTime FechaInicioCita { get; set; }
        public DateTime FechaFinCita { get; set; }
        public int Duracion { get; set; }
        public int IdTipo { get; set; }
        [ForeignKey("IdTipo")]
        public virtual Tipo Tipos { get; set; }
        public String Comentarios { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}