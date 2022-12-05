using RecetasSLN.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Interfaz
{
    internal interface IRecetaDao
    {
        int obtenerProximoID();
        List<ingrediente> ToGetNombre();
        bool crear(receta Recetas);
    }
}
