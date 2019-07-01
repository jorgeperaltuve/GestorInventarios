using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestorInventario.model.Models
{
    public partial class Elemento
    {
        public int ElementoId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime FechaCaducidad { get; set; }

        [Required]
        public int TipoElementoId { get; set; }
        public bool Disponible { get; set; }

        public virtual TipoElemento TipoElemento { get; set; }
    }
}
