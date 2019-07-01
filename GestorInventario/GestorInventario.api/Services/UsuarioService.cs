using GestorInventario.api.Repositories;
using GestorInventario.model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventario.api.Services
{
    public class UsuarioService : IUsuarioService
    {

        #region Propiedades privadas
        private readonly IUsuarioRepository _usuarioRepo;
        #endregion

        #region Constructores
        public UsuarioService(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
        #endregion

        #region Métodos públicos asincronos.
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                var usuarios = _usuarioRepo.GetAll();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario UsuarioEsValido(string NombreAcceso, string Clave)
        {
            var usuarios = _usuarioRepo.GetAll();

            var usuario = usuarios.Where(m => m.NombreAcceso == NombreAcceso && m.Clave == getHash(Clave)).FirstOrDefault();

            return usuario;
        }

        private static string getHash(string text)
        {
            // SHA512 is disposable by inheritance.  
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }


        #endregion
    }
}
