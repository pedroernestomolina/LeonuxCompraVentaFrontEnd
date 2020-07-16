using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModInventario
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Sistema.MyData = new DataProvInventario.Data.DataProv();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var _gestionInv = new GestionInv();
            _gestionInv.Inicia();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}