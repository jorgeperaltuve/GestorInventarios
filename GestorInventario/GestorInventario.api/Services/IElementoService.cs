using GestorInventario.api.Models;
using GestorInventario.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Services
{
    public interface IElementoService
    {
        /// <summary>
        /// Obtiene un elemento por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Elemento> GetbyIdAsync(object id);

        /// <summary>
        /// Obtiene todos los elementos por defecto disponibles
        /// </summary>
        /// <param name="disponible"></param>
        /// <returns></returns>
        Task<IEnumerable<Elemento>> ObtenerTodosAsync(bool disponible = true);

        /// <summary>
        /// Crea elemento inventario.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        Task<Elemento> CrearElementoInventarioAsync(Elemento elemento);

        /// <summary>
        /// Saca elemento inventario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Elemento> SacarElementoInventarioAsync(object id);
    }
}
