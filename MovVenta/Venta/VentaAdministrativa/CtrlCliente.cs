using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovVenta.Venta.VentaAdministrativa
{

    public class CtrlCliente
    {

        public event EventHandler<OOB.LibVenta.Cliente.Ficha> ClienteOK;
        private OOB.LibVenta.Cliente.Ficha _ficha;


        public CtrlCliente()
        {
        }


        public OOB.LibVenta.Cliente.Ficha Ficha 
        {
            get 
            {
                return _ficha;
            }
        }

        public void Limpiar() 
        {
            _ficha = null;
            Notificar();
        }

        private Cliente.BuscarFrm.BuscarFrm frmCliente = null;
        public void Buscar() 
        {
            if (frmCliente == null)
            {
                frmCliente = new Cliente.BuscarFrm.BuscarFrm();
                frmCliente.ClienteOK += frm_ClienteOK;
            }
            if (frmCliente.CargarData())
            {
                frmCliente.ShowDialog();
            }
        }

        private void frm_ClienteOK(object sender, Cliente.Buscar.ClienteSelected e)
        {
            if (!e.IsActivo)
            {
                Helpers.Msg.Error("CLIENTE SELECCIONADO EN ESTADO INACTIVO");
                return;
            }

            frmCliente.Close();
            CargarCliente(e.AutoCliente);
        }

        private void CargarCliente(string p)
        {
            var r01 = Program.MyData.ClienteFicha(p);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _ficha = r01.Entidad;
            Notificar();
        }

        Cliente.AgregarEventual.AgregarEventualFrm frmAgregarClienteEventual = null;
        public void CrearClienteEventual()
        {
            if (frmAgregarClienteEventual == null)
            {
                frmAgregarClienteEventual = new Cliente.AgregarEventual.AgregarEventualFrm();
                frmAgregarClienteEventual.AgregarOk += frmAgregarClienteEventual_AgregarOk;
            }
            frmAgregarClienteEventual.ShowDialog();
        }

        private void frmAgregarClienteEventual_AgregarOk(object sender, string e)
        {
            frmAgregarClienteEventual.Close();
            CargarCliente(e);
        }

        private void Notificar() 
        {
            EventHandler<OOB.LibVenta.Cliente.Ficha> handler = ClienteOK;
            if (handler != null)
            {
                handler(this, _ficha);
            }
        }

    }

}