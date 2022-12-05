using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Domino
{
    internal class detalleReceta
    {
        public detalleReceta(ingrediente ingredientes, int cantidad)
        {
            this.ingredientes = ingredientes;
            this.cantidad = cantidad;
        }

        public ingrediente ingredientes { get; set; }
        public int cantidad { get; set; }
    }
}
