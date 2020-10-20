using System;
using System.Collections.Generic;
using System.Text;
using RegistroDetalle.DAL;
using RegistroDetalle.Entidades;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace RegistroDetalle.BLL
{
    public class MorasBLL
    {
        public static int BuscarBuscar { get; internal set; }

        public static bool Guardar(Moras moras){
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if(contexto.Moras.Add(moras)!= null)
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

       private static bool Existe(int id)
        {
            bool existe;
            Contexto contexto = new Contexto();
            try{
                existe = contexto.Moras.Any(m => m.MoraId== id);
            }
            catch(Exception){
                throw;

            } finally{
                contexto.Dispose();
            }
            return existe;
        }
      
       public static bool Modificar(Moras moras){
            bool Modificado = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId = {moras.MoraId}");
                foreach(var anterior in moras.MorasDetalle)
                {
                    contexto.Entry(anterior).State =EntityState.Added;
                }
                contexto.Entry(moras).State = EntityState.Modified;
                Modificado = (contexto.SaveChanges()>0);
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Modificado;
        }

        public static bool Eliminar(int id){
            bool Eliminado = false;
            Contexto contexto = new Contexto();
            try{
                var moras = contexto.Moras.Find(id);
                contexto.Entry(moras).State = EntityState.Deleted;
                Eliminado = contexto.SaveChanges()>0;
            }

            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Moras Buscar(int id){
            Moras moras = new Moras();
            Contexto contexto = new Contexto();
            try{
                moras = contexto.Moras.Include(x => x.MorasDetalle).Where(p => p.MoraId  == id).SingleOrDefault();
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return moras;
        }

    public static List <Moras> GetList(Expression<Func<Moras, bool>> moras)
        {
            List<Moras> Lista = new List<Moras>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Moras.Where(moras).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
    }

    }
}