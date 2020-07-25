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
        private List<OOB.LibCajaBanco.Sucursal.Ficha> lSucursal;


        public BindingSource _bsSucursal { get { return bs_Sucursal; } }
        public string autoSucursal { get; set; }
        public DateTime desdeFecha { get; set; }
        public DateTime hastaFecha { get; set; }
        public bool IsFiltroOk { get; set; }


        public Gestion()
        {
            Limpiar();
            lSucursal = new List<OOB.LibCajaBanco.Sucursal.Ficha>();
            bs_Sucursal = new BindingSource();
            bs_Sucursal.DataSource = lSucursal;
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

            return rt;
        }

        public void Procesar()
        {
            IsFiltroOk = true;
        }

        public void LimpiarSucursal()
        {
            autoSucursal = "";
        }

    }

}