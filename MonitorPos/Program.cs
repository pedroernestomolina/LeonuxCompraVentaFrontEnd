using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MonitorPos
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var r01 = Sistema.MyData.TestBD_Local();
            //var r02 = Sistema.MyData.TestBD_Remoto();
            //var r03 = Sistema.MyData.TestBD_Nube();
            //Application.Run(new Form1());

            var r01 = Src.Helpers.Utilitis.CargarXml();
            if (r01.Result != OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Sistema.MyData = new ProvSqLitePosOffLine.Provider(Src.Helpers.Utilitis._DataLocal);
                Sistema.MyData.setServidorRemoto(Src.Helpers.Utilitis._Instancia, Src.Helpers.Utilitis._BaseDatos);

                var frm = new Src.Principal.PrincipalFrm();
                Application.Run(frm);
            }
            Application.Exit();
        }
    }

}