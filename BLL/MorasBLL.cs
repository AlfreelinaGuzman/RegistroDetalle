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

        public static bool Guardar(Moras mora)
        {
            if (!Existe(mora.MoraId))
                return Insertar(mora);
            else
                return Modificar(mora);
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
        private static bool Insertar(Moras mora)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Moras.Add(mora);
                paso = contexto.SaveChanges() > 0;

                List<MorasDetalle> detalle = mora.MorasDetalle;
                foreach (MorasDetalle det in detalle)
                {
                    Prestamo prestamo = PrestamoBLL.Buscar(det.PrestamoId);
                    if (prestamo != null)
                    {
                        prestamo.Mora += Convert.ToSingle(det.Valor);
                        PrestamoBLL.Guardar(prestamo);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
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