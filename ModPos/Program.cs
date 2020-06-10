using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos
{

    static class Program
    {

        static Identificacion.IdentificacionFrm frm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var r01 = Helpers.Utilitis.CargarXml();
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                Sistema.MyData2 = new DataProvPosOffLine.Data.DataProv(@Helpers.Utilitis._DataLocal);
                Sistema.MyData2.setServidorRemoto(@Helpers.Utilitis._Instancia, @Helpers.Utilitis._BaseDatos);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var _gestion = new Gestion();
                _gestion.Inicia();

            }
            else 
            {
                Helpers.Msg.Error(r01.Mensaje);
                Application.Exit();
            }
        }

    }

}
