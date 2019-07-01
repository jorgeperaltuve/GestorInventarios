using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Models.Dtos
{
    public class UsuarioDTO
    {
        [Required]
        public string NombreAcceso { get; set; }

        [Required]
        public string Clave { get; set; }
    }
}
