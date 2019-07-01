using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Repositories
{
    public interface IRepository<T> where T: class
    {
        /// <summary>
        /// Obtiene entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetEntityAsync(object id);

        /// <summary>
        /// Agrega entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddEntityAsync(T entity);

        /// <summary>
        /// Actualiza entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> UpdateEntityAsync(T entity);
    }
}
