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
    public class PersonasBLL
    {
     
        //------------------------------Insertar----------------------------------
        private static bool Insertar (Personas personas){
            bool Paso = false;
            Contexto contexto= new Contexto();

            try
            {
                
               contexto.Personas.Add(personas);
                Paso=contexto.SaveChanges()>0;

            }catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
          return Paso;
        }
        

//-------------------------Buscar-------------------------------
    public  static  Personas  Buscar(int id){
        Contexto contexto=new Contexto();
        Personas personas;
        try{
            personas= contexto.Personas.Find(id);
        }
        catch (Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
          return personas;
        }


        //-------------------------Modificar----------------------------
        private static bool Modificar(Personas personas)
        {
            bool Paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                Paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

                return Paso;
        }
        //----------------------- --Existe-----------------------------------
        public  static bool Existe(int id){
        Contexto contexto=new Contexto();
        bool encontrado = false;
        try{
            encontrado= contexto.Personas.Any(e => e.PersonaID == id);
            //encontrado= Encontrado;
        }
        catch (Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
          return encontrado;
        }

        //------------------------Eliminar----------------------------------
        public static bool Eliminar(int id){
            bool Paso = false;
            Contexto contexto = new Contexto();
            try{
                var personas = contexto.Personas.Find(id);
            if(personas != null){
            contexto.Personas.Remove(personas);
            Paso= contexto.SaveChanges()>0;
            }   
        }
        catch(Exception){
         throw;
        }finally
        {
            contexto.Dispose();
        }
        return Paso;
    }


        ///-------------------------Lista-------------------------------
        public static List<Personas> GetList(Expression<Func<Personas, bool>> personas) 
        {
            List<Personas> Lista = new List<Personas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Personas.Where(personas).ToList();
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

///-------------------GUARDAR-----------------
        public static bool Guardar (Personas personas){
            if (!Existe(personas.PersonaID))
                return Insertar(personas);
            else
            {
                return Modificar(personas);
            }
        }
    }

  }