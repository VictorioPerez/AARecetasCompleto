using RecetasSLN.presentación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmConsultarRecetas());
        }

        /*
          1) Para qué sirven las interfaces?
          2) Para qué son las implementaciones?
          3) Qué tienen que ver el Dao y la Interfaz?
          3) Para qué es el HelperDao?
          4) Qué es el singleton?
          5) Posibles pasos para programar
        */
    }
}
