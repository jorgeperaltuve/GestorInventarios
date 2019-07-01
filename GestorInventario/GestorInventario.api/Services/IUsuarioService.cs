using GestorInventario.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Services
{
    public interface IUsuarioService
    {
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Usuario> GetAll();

        /// <summary>
        /// Valida Usuario.
        /// </summary>
        /// <param name="NombreAcceso"></param>
        /// <param name="Clave"></param>
        /// <returns></returns>
        Usuario UsuarioEsValido(string NombreAcceso, string Clave);
    }
}
