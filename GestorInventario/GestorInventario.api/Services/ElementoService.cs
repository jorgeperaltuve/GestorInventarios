using GestorInventario.api.Models;
using GestorInventario.api.Repositories;
using GestorInventario.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Services
{
    public class ElementoService : IElementoService
    {
        #region Propiedades privadas
        private readonly IElementoRepository _elementoRepo;
        #endregion

        #region Constructores
        public ElementoService(IElementoRepository elementoRepo)
        {
            _elementoRepo = elementoRepo;
        }
        #endregion

        #region Métodos públicos asincronos.
        /// <summary>
        /// Obtiene un elemento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Elemento> GetbyIdAsync(object id)
        {
            try
            {
                var elemento = await _elementoRepo.GetbyIdAsync(id);
                return elemento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Crea elemento inventario.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public async Task<Elemento> CrearElementoInventarioAsync(Elemento elemento)
        {
            return await _elementoRepo.CrearElementoInventarioAsync(elemento);
        }

        /// <summary>
        /// Saca elemento inventario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Elemento> SacarElementoInventarioAsync(object id)
        {
            return await _elementoRepo.SacarElementoInventarioAsync(id);
        }

        /// <summary>
        /// Obtiene todos los elementos disponibles.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Elemento>> ObtenerTodosAsync(bool disponible = true)
        {
            try
            {
                var elementos = await _elementoRepo.ObtenerTodosAsync(disponible);
                return elementos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
