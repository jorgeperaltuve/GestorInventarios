using GestorInventario.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Repositories
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Usuario> GetAll();
    }
}
