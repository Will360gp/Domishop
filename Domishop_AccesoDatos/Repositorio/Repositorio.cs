using Domishop__AccesoDatos.Data;
using Domishop_AccesoDatos.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domishop_AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {


        private readonly ApplicationDbContext _db;
        internal DbSet<T>? dbSet;

        public Repositorio(ApplicationDbContext db)
        {
                _db = db;
            this.dbSet = _db.Set<T>();
        }








        // Metdos Implementados de la interface de IRepositorio________________________
        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad); // insert into Table
        }

        public async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id); // select * from (Solo con id) trabaja este metodo
        }



        /// <summary>
        /// /////
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="incluirPropiedades"></param>
        /// <param name="isTracking"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>


        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>>? filtro = null,
            string? incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T>? query = dbSet;
            if (filtro != null)
                query = query.Where(filtro); // selet * from where

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "Categoria y Marca"
                }
            }

            // este metodo va sin el Orde By y no retorna el listado sino un solo producto

            if (!isTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();


        }






        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T>? query = dbSet;
            if(filtro!=null)
                query= query.Where(filtro); // selet * from where

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp); // ejemplo "Categoria y Marca"
                }
            }

            if(orderBy!=null)
                query = orderBy(query);

            if(!isTracking)
                query=query?.AsNoTracking(); // nulable

            return await query.ToListAsync();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------







        public void Remover(T entidad)
        {
            dbSet?.Remove(entidad);// nulable
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbSet?.RemoveRange(entidad);
        }
    }
}
