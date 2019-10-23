﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using citas.Models;

namespace citas.Migrations
{
    [DbContext(typeof(CitasContext))]
    partial class CitasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("citas.Models.Cita", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comentarios");

                    b.Property<string>("CorreoCliente");

                    b.Property<int>("Duracion");

                    b.Property<DateTime>("FechaCita");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<int>("IdMedico");

                    b.Property<string>("Movil");

                    b.Property<string>("NombreCliente");

                    b.Property<string>("Tipo");

                    b.HasKey("IdCita");

                    b.HasIndex("IdMedico");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("citas.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular");

                    b.Property<string>("Color");

                    b.Property<string>("Correo");

                    b.Property<string>("Direccion");

                    b.Property<string>("Especialidad");

                    b.Property<DateTime>("FechaNac");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<TimeSpan>("HorarioFin");

                    b.Property<TimeSpan>("HorarioInicio");

                    b.Property<string>("Nombres");

                    b.HasKey("IdMedico");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("citas.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contrasena");

                    b.Property<string>("Dni");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<string>("Nombres");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("citas.Models.Cita", b =>
                {
                    b.HasOne("citas.Models.Medico", "Medicos")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
