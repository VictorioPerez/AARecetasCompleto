using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Domino
{
    internal class receta
    {
        public int recetaNro { get; set; }
        public string nombre { get; set; }
        public int tipoReceta { get; set; }
        public string nombreChef { get; set; }

        //Lista de detalles
       public List<detalleReceta> detalleRecetaList { get; set; }
       public receta()
        {
            detalleRecetaList = new List<detalleReceta>();
        } 
        public void agregarDetalle(detalleReceta detalleR)
        {
            detalleRecetaList.Add(detalleR);
        }
        public void quitarDetalle(int posicion)
        {
            detalleRecetaList.RemoveAt(posicion);
        }
    }
}
