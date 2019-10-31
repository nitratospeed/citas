using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace citas.Models
{
    public class Tipo
    {
        [Key]
        public int IdTipo { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}