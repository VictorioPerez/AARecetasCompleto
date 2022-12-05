using RecetasSLN.Datos.Interfaz;
using RecetasSLN.Domino;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Datos.Implementacion
{
    internal class recetaDao : IRecetaDao
    {
        public bool crear(receta Recetas)
        {

            return helperDao.obtenerInstancia().CrearMaestroDetalleReceta("SP_INSERTAR_RECETA", "SP_INSERTAR_DETALLES",Recetas);
        }

        public int obtenerProximoID()
        {
            return helperDao.obtenerInstancia().proximoID("SP_Proximo_ID", "@next");
        }

        //METODO PARA OBTENER LOS DATOS PARA EL COMBOBOX
        public List<ingrediente> ToGetNombre()
        {
            List<ingrediente> listaIngrediente = new List<ingrediente>();
            DataTable tabla = helperDao.obtenerInstancia().combo("SP_CONSULTAR_INGREDIENTES");
            foreach (DataRow dr in tabla.Rows)
            {
                //Ingreso las columnas de SQL en el dr[]
                ingrediente ingrediente = new ingrediente();
                ingrediente.ingredienteID = Convert.ToInt32(dr["id_ingrediente"]);
                ingrediente.ingredienteName = (string)dr["n_ingrediente"];
                ingrediente.unidad = (string)dr["unidad_medida"];
                listaIngrediente.Add(ingrediente);
            }
            return listaIngrediente;
        }
    }
}
