using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModPos.Operador.Cierre
{
    
    public class CtrCierre
    {

        public CtrCierre()
        {
        }


        public void Cierre() 
        {
            var r00 = Sistema.MyData2.Pendiente_HayCuentasporProcesar();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (r00.Entidad)
            {
                Helpers.Msg.Error("HAY CUENTAS PENDIENTES POR PROCESAR, VERIFIQUE POR FAVOR");
                return;
            }

            var r01 = Sistema.MyData2.Operador_Movimiento(Sistema.MyOperador.Id);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var frm = new CierreFrm();
            frm.setControlador(this);
            frm.setOperador(Sistema.MyOperador);
            frm.setMovimientos(r01.Entidad);
            frm.ShowDialog();

            var msg = MessageBox.Show("Estas Seguro De Cerrar Este Operador ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            //var ficha = new OOB.LibVenta.PosOffline.Operador.Cerrar.Ficha()
            //{
            //    IdOperador = Sistema.MyOperador.Id,
            //    Estatus = "C",
            //    Fecha = DateTime.Now,
            //    Hora = DateTime.Now.ToShortTimeString(),
            //};
            //var r01 = Sistema.MyData2.Operador_Cerrar(ficha);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}
            //Sistema.MyOperador = null;
            //Helpers.Msg.Alerta("OPERADOR CERRRADO EXITOSAMENTE !!!!!");
        }

    }

}