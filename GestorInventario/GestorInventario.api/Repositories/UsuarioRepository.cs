using GestorInventario.api.Models;
using GestorInventario.model.Context;
using GestorInventario.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {

        #region Constructores
        public UsuarioRepository(GestorInventariosContext DbContext) : base(DbContext)
        {

        }
        #endregion

        #region Métodos públicos.
       
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                var result = _DbContext.Usuario.ToList();
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
