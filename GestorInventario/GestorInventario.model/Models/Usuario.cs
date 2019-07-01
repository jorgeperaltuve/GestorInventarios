using System;
using System.Collections.Generic;

namespace GestorInventario.model.Models
{
    public partial class Usuario
    {
        public int UsuarioId { get; set; }
        public string NombreAcceso { get; set; }
        public string Clave { get; set; }
    }
}
