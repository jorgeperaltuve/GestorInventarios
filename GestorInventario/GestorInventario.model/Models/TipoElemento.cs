using System;
using System.Collections.Generic;

namespace GestorInventario.model.Models
{
    public partial class TipoElemento
    {
        public TipoElemento()
        {
            Elemento = new HashSet<Elemento>();
        }

        public int TipoElementoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Elemento> Elemento { get; set; }
    }
}
