using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace citas.Models
{
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }
        public int IdMedico { get; set; }
        public int Sede { get; set; }
        public String Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}