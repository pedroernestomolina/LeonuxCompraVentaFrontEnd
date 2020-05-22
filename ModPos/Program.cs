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

                frm = new Identificacion.IdentificacionFrm();
                frm.UsuarioOk += frm_UsuarioOk;
                frm.SalidaOk += frm_SalidaOk;
                Application.Run(frm);

                //Sistema.MyBalanza = new Lib.BalanzaSoloPeso.BalanzaManual.Balanza();
                //Sistema.Usuario = new OOB.LibVenta.PosOffline.Usuario.Ficha() { Auto="0000000001", Codigo="CAJA1T1", Descripcion="CAJ. TURNO 1" , IsActivo=true};

                //var frm = new Facturacion.PosVenta();
                //if (frm.CargarData()) 
                //{
                //    Application.Run(frm);
                //}
            }
            else 
            {
                Helpers.Msg.Error(r01.Mensaje);
                Application.Exit();
            }
        }

        private static void frm_UsuarioOk(object sender, EventArgs e)
        {
            frm.Hide();
            var frmPos = new Form1();
            if (frmPos.CargarData()) 
            {
                frmPos.ShowDialog();
            }
            frm.Close();
        }

        private static void frm_SalidaOk(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }

}
