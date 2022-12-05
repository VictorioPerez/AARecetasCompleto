using RecetasSLN.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios
{
    internal abstract class abstractFactoryService
    {
        public abstract IServicio crearServicio();
    }
}
