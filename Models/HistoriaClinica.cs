using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace citas.Models
{
    public class HistoriaClinica
    {
        [Key]
        public int IdHistoriaClinica { get; set; } 
        public String DNI { get; set; }
        public String Nombre { get; set; }
        public String Celular { get; set; }
        public String Correo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}