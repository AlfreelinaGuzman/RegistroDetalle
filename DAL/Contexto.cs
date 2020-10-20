using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RegistroDetalle.Entidades;


namespace RegistroDetalle.DAL{

    public class Contexto : DbContext{
        public DbSet<Moras> Moras { get; set; }
        public DbSet<Personas> Personas{ get; set;}
        public DbSet<Prestamo> Prestamo { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite(@"Data Source= DATA/Prestamo.db");
    }
    
 }   
}