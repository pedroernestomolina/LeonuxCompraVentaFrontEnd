using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.Reportes.Movimientos
{

    public class Gestion
    {

        private BindingSource bs_Sucursal;
        private BindingSource bs_Deposito;
        private List<OOB.LibCajaBanco.Sucursal.Ficha> lSucursal;
        private List<OOB.LibCajaBanco.Deposito.Ficha> lDeposito;


        public BindingSource _bsSucursal { get { return bs_Sucursal; } }
        public BindingSource _bsDeposito { get { return bs_Deposito; } }


        public string autoSucursal { get; set; }
        public string autoDeposito { get; set; }
        public DateTime desdeFecha { get; set; }
        public DateTime hastaFecha { get; set; }
        public bool IsFiltroOk { get; set; }


        public Gestion()
        {
            Limpiar();
            lSucursal = new List<OOB.LibCajaBanco.Sucursal.Ficha>();
            bs_Sucursal = new BindingSource();
            bs_Sucursal.DataSource = lSucursal;

            lDeposito= new List<OOB.LibCajaBanco.Deposito.Ficha>();
            bs_Deposito= new BindingSource();
            bs_Deposito.DataSource = lDeposito;
        }


        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new FiltroFrm ();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            IsFiltroOk = false;
            autoSucursal = "";
            autoDeposito = "";
            desdeFecha = DateTime.Now.Date;
            hastaFecha = DateTime.Now.Date;
        }

        private bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            lSucursal.Clear();
            lSucursal.AddRange(rt1.Lista);

            var rt2 = Sistema.MyData.Deposito_GetLista ();
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return false;
            }
            lDeposito.Clear();
            lDeposito.AddRange(rt2.Lista);

            return rt;
        }

        public void Procesar()
        {
            IsFiltroOk = true;
        }

        public void LimpiarSucursal()
        {
            autoSucursal = "";
            autoDeposito = "";
        }

    }

}