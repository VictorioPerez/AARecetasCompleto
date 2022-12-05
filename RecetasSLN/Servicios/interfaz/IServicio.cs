using RecetasSLN.Domino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.interfaz
{
    internal interface IServicio
    {
        int proximoID();
        //LISTA QUE QUIERO Q APAREZCA EN EL CBO 
        List<ingrediente> obtenerNombre();

        //Guardar el alta del ejercicio
        bool guardarAlta(receta recetas);
    }
}
