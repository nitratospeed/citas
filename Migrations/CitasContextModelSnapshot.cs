﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("citas.Models.Cita", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comentarios");

                    b.Property<string>("CorreoCliente");

                    b.Property<int>("Duracion");

                    b.Property<DateTime>("FechaFinCita");

                    b.Property<DateTime>("FechaInicioCita");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<int>("IdMedico");

                    b.Property<int>("IdTipo");

                    b.Property<string>("Movil");

                    b.Property<string>("NombreCliente");

                    b.HasKey("IdCita");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdTipo");

                    b.ToTable("Citas");
                });

            modelBuilder.Entity("citas.Models.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Dia");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<TimeSpan>("HoraFin");

                    b.Property<TimeSpan>("HoraInicio");

                    b.Property<int>("IdMedico");

                    b.Property<int>("Sede");

                    b.HasKey("IdHorario");

                    b.HasIndex("IdMedico");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("citas.Models.Medico", b =>
                {
                    b.Property<int>("IdMedico")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular");

                    b.Property<string>("Correo");

                    b.Property<string>("Direccion");

                    b.Property<string>("Especialidad");

                    b.Property<DateTime>("FechaNac");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<string>("Nombres");

                    b.HasKey("IdMedico");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("citas.Models.Tipo", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaRegistro");

                    b.HasKey("IdTipo");

                    b.ToTable("Tipos");
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

                    b.HasOne("citas.Models.Tipo", "Tipos")
                        .WithMany()
                        .HasForeignKey("IdTipo")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("citas.Models.Horario", b =>
                {
                    b.HasOne("citas.Models.Medico")
                        .WithMany("Horarios")
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
