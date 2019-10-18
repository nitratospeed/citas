using System;
using System.ComponentModel.DataAnnotations;

namespace citas.Models
{
    public class Cita
    {
        [Key]
        public int IdCita { get; set; }
        public int IdMedico { get; set; }    
        public DateTime FechaCita { get; set; }
        public String NombreCliente { get; set; }
        public String CorreoCliente { get; set; }
        public int Duracion { get; set; }
        public String Tipo { get; set; }
        public String Comentarios { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}