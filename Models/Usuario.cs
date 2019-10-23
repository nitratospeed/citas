using System;
using System.ComponentModel.DataAnnotations;

namespace citas.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Dni { get; set; }

        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}