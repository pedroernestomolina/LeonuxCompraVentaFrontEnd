using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Sistema.MyData = new DataProvCajaBanco.Data.DataProv("localhost","pita");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var r01 = Sistema.MyData.Usuario_Principal();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                Application.Exit();
            }
            else
            {
                Sistema.UsuarioP = r01.Entidad;
                var _gestion = new Gestion();
                _gestion.Inicia();
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}