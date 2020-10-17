using System;
using System.Collections.Generic;
using System.Text;
using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace RegistroDetalle.BLL{

    public class PrestamoBLL{

///-------------------------GUARDAR------------------------------------------
        public static bool Guardar(Prestamo prestamo){
           if(!Existe(prestamo.PrestamoID))
                return Insertar(prestamo);
           else
                return Modificar(prestamo);
        }
        
///-------------------------INSERTAR-----------------------------------------
        private static bool Insertar(Prestamo prestamo){

             bool paso = false;
             Contexto contexto = new Contexto();

            try{
                contexto.Prestamo.Add(prestamo);
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return paso;

        }

////-------------------------------MODIFICAR------------------------------
        private static bool Modificar(Prestamo prestamo){

            bool paso = false;
            Contexto contexto = new Contexto();

            try{
   
                contexto.Entry(prestamo).State= EntityState.Modified;
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

//----------------------------------ELIMINAR-----------------------------------------
        public static bool Eliminar(int id){
            
            bool paso = false;
            Contexto contexto = new Contexto();

            try{
        
                var prestamo = contexto.Prestamo.Find(id);

                if(prestamo != null){
                    contexto.Prestamo.Remove(prestamo);
                    paso = contexto.SaveChanges() >0;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

//-------------------------------------BUSCAR--------------------------------------
        public static Prestamo Buscar(int id){

            Contexto contexto = new Contexto();
            Prestamo prestamo = new Prestamo();

            try{
                prestamo =contexto.Prestamo.Find(id);

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return prestamo;

        }

//--------------------------------EXISTE--------------------------------------------
        public static bool Existe(int id){

            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Prestamo.Any(e => e.PrestamoID ==id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return encontrado;
        }

////-----------------------------List-------------------------------------------
        public static List<Prestamo> GetList(Expression<Func<Prestamo, bool>> criterio){
            
            List<Prestamo> lista = new List<Prestamo>();
            Contexto contexto = new Contexto();

            try{
                
                lista = contexto.Prestamo.Where(criterio).ToList();

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return lista;
        }
    }
}