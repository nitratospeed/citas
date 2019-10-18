using System;
using System.ComponentModel.DataAnnotations;

namespace citas.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        public string Nombres { get; set; }
        public string Especialidad { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}