﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroDetalle.DAL;

namespace RegistroDetalle.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("RegistroDetalle.Entidades.Moras", b =>
                {
                    b.Property<int>("MoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("MoraId");

                    b.ToTable("Moras");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.MorasDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoraId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MoraId");

                    b.ToTable("MorasDetalle");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.Personas", b =>
                {
                    b.Property<int>("PersonaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonaID");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.Prestamo", b =>
                {
                    b.Property<int>("PrestamoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Concepto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<float>("Mora")
                        .HasColumnType("REAL");

                    b.Property<int>("PersonaID")
                        .HasColumnType("INTEGER");

                    b.HasKey("PrestamoID");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("RegistroDetalle.Entidades.MorasDetalle", b =>
                {
                    b.HasOne("RegistroDetalle.Entidades.Moras", null)
                        .WithMany("MorasDetalle")
                        .HasForeignKey("MoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
