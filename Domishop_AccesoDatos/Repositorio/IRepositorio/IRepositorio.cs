using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domishop_AccesoDatos.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task<T> Obtener(int id);// Aqui se le coloca el tsk para que sean metodos asincronos
        Task<IEnumerable<T>> ObtenerTodos( // Aqui se le coloca el tsk para que sean metodos asincronos
            Expression<Func<T, bool>>? filtro = null, 
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null, 
            string? incluirPropiedades = null, 
            bool isTracking = true
            );

        Task<T> ObtenerPrimero( // Aqui se le coloca el tsk para que sean metodos asincronos
            Expression<Func<T, bool>>? filtro = null, 
            string? incluirPropiedades = null,
            bool isTracking = true
            );


        Task Agregar(T entidad);// Aqui se le coloca el tsk para que sean metodos asincronos
        void Remover(T entidad);// Estos metodos no pueden ser asincronos por que son para remover registros
        void RemoverRango(IEnumerable<T> entidad);// Estos metodos no pueden ser asincronos por que son para remover registros




    }
}
