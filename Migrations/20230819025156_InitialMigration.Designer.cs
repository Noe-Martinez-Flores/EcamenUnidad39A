﻿// <auto-generated />
using System;
using ExamenUnidad3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamenUnidad3.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230819025156_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExamenUnidad3.Models.Citas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAtencion")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaReservada")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MotivoVisita")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreVeterinario")
                        .HasColumnType("longtext");

                    b.Property<string>("Observaciones")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cita");
                });
#pragma warning restore 612, 618
        }
    }
}
