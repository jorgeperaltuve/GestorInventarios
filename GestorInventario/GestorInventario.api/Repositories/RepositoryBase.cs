using GestorInventario.api.Models;
using GestorInventario.model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Propiedades
        protected GestorInventariosContext _DbContext;
        #endregion

        #region Constructores
        public RepositoryBase(GestorInventariosContext DbContext)
        {
            _DbContext = DbContext;
        }
        #endregion


        #region Métodos públicos asincronos
        /// <summary>
        /// Obtiene una entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetEntityAsync(object id)
        {
            try
            {
                var entity = await _DbContext.FindAsync<TEntity>(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Agrega una entidad
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            try
            {
                var result = await _DbContext.AddAsync(entity);
                await _DbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            try
            {
                _DbContext.Update(entity);
                await _DbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}
