using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace citas.Models
{
    public class CitasContext : DbContext
    {
        public CitasContext (DbContextOptions<CitasContext> options)
            : base(options)
        {
        }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}