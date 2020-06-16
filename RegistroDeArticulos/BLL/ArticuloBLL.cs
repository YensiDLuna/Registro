using Microsoft.EntityFrameworkCore;
using RegistroDeArticulos.DAL;
using RegistroDeArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroDeArticulos.BLL
{
public  class ArticuloBLL
	{
        public static bool Guardar(Articulo articulo)
        {
            if (!Existe(articulo.articuloId)) 
                return Insertar(articulo);
            else
                return Modificar(articulo);
        }

        private static bool Insertar(Articulo articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Articulo.Add(articulo);
                paso = contexto.SaveChanges() > 0;
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

        private static bool Modificar(Articulo articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(articulo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

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


        public static Articulo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulo articulo;


            try
            {
                articulo = contexto.Articulo.Find(id);
            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }
            return articulo;
        }

        public static List<Articulo> GetList(Expression<Func<Articulo, bool>> criterio)
        {

            List<Articulo> lista = new List<Articulo>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Articulo.Where(criterio).ToList();

            }

            catch (Exception)
            {
                throw;
            }

            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Articulo.Any(e => e.articuloId == id);
            }

            catch (Exception)
            {
                throw;

            }

            finally
            {

                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                
                var vehiculos = contexto.Articulo.Find(id);

                if (vehiculos != null)
                {
                    contexto.Articulo.Remove(vehiculos);
                    paso = contexto.SaveChanges() > 0;

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

    }
}
