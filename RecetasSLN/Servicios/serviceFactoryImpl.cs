using RecetasSLN.Servicios.implementacion;
using RecetasSLN.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios
{
    internal class serviceFactoryImpl : abstractFactoryService
    {
        public override IServicio crearServicio()
        {
            return new servicioReceta();
        }
    }
}
