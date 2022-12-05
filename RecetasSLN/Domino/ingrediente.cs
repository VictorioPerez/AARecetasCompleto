using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Domino
{
    internal class ingrediente
    {
        public int ingredienteID { get; set; }
        public string ingredienteName { get; set; }
        public string unidad { get; set; }


        public ingrediente() { }
        public ingrediente(int ingredienteID, string ingredienteName, string unidad)
        {
            this.ingredienteID = ingredienteID;
            this.ingredienteName = ingredienteName;
            this.unidad = unidad;
        }

    }
}
