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
/*    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.Entity<Articulos>().HasData(new Articulos() { ArticuloId = 1, Descripcion = "Jabon", Precio = 150 });            
            modelBuilder.Entity<Articulos>().HasData(new Articulos() { ArticuloId = 2, Descripcion = "Habichuelas", Precio = 55 });            
            modelBuilder.Entity<Articulos>().HasData(new Articulos() { ArticuloId = 3, Descripcion = "Salami", Precio = 60 });
        }
    }
     
*/
 }   
}