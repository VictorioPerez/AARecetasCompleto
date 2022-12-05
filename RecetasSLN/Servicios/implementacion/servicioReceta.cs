using RecetasSLN.Datos.Implementacion;
using RecetasSLN.Datos.Interfaz;
using RecetasSLN.Domino;
using RecetasSLN.Servicios.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.implementacion
{
    internal class servicioReceta : IServicio
    {
        private IRecetaDao dao;
        public servicioReceta ()
        {
            dao = new recetaDao();
        }
        public bool guardarAlta(receta recetas)
        {
            return dao.crear(recetas);
        }

        public List<ingrediente> obtenerNombre()
        {
            return dao.ToGetNombre();
        }

        public int proximoID()
        {
            return dao.obtenerProximoID();
        }
    }
}
