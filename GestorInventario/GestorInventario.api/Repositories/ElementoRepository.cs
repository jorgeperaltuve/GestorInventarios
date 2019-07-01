using GestorInventario.api.Models;
using GestorInventario.model.Context;
using GestorInventario.model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Repositories
{
    public class ElementoRepository : RepositoryBase<Elemento>, IElementoRepository
    {
        #region Constructores
        public ElementoRepository(GestorInventariosContext DbContext) : base(DbContext)
        {

        }
        #endregion

        #region Métodos públicos asincronos.

        /// <summary>
        /// Crea elemento inventario.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public async Task<Elemento> CrearElementoInventarioAsync(Elemento elemento)
        {
            try
            { 
                return await AddEntityAsync(elemento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Saca elemento inventario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Elemento> SacarElementoInventarioAsync(object id)
        {
            try
            {
                var elemento = await GetEntityAsync(id);

                //Actualizamos solo el campo disponible.
                elemento.Disponible = false;
                return await UpdateEntityAsync(elemento);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Inserta o actualiza un elemento.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public async Task<Elemento> InsertOrUpdateAsync(Elemento elemento)
        {
            try
            {
                var entity = await GetEntityAsync(elemento.ElementoId);

                if (entity != null)
                {
                    return await UpdateEntityAsync(entity);
                }
                else
                {
                    return await AddEntityAsync(elemento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Obtiene un elemento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Elemento> GetbyIdAsync(object id)
        {
            try
            {
                var entity = await _DbContext.Elemento.FindAsync(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene todos los elementos disponibles
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Elemento>> ObtenerTodosAsync(bool disponible = true)
        {
            try
            {
                var result = await _DbContext.Elemento.Where(m => m.Disponible == disponible).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
