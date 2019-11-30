using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace citas.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        public ICollection<Horario> Horarios { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}