using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema.SucursalDeposito
{
    
    public class GestionAjustar
    {

        private List<OOB.LibSistema.Deposito.Ficha> lDeposito;
        private BindingSource bsDeposito;
        private OOB.LibSistema.Sucursal.Ficha ficha;


        public bool IsAjusteOk { get; set; }
        public string AutoDeposito { get; set; }
        public BindingSource DepositoSource { get { return bsDeposito; } }
        public string Sucursal 
        { 
            get 
            {
                var r = "";
                r +=ficha.codigo+Environment.NewLine;
                r +=ficha.nombre+Environment.NewLine;
                return r;
            } 
        }


        public GestionAjustar()
        {
            LimpiarEntradas();
            lDeposito= new List<OOB.LibSistema.Deposito.Ficha>();
            bsDeposito= new BindingSource();
            bsDeposito.DataSource = lDeposito;
            ficha = null;
        }

        private void LimpiarEntradas()
        {
            IsAjusteOk = false;
            AutoDeposito = "";
        }


        public void Inicia() 
        {
            LimpiarEntradas();
            if (CargarData())
            {
                var frm = new AsignarFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Sucursal_GetFicha(ficha.auto);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            ficha = r01.Entidad;
            AutoDeposito = r01.Entidad.autoDepositoPrincipal;

            var r02 = Sistema.MyData.Deposito_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            lDeposito.Clear();
            lDeposito.AddRange(r02.Lista.OrderBy(o=>o.nombre).ToList());

            return rt;
        }

        public void setFicha(OOB.LibSistema.Sucursal.Ficha it)
        {
            ficha = it;
        }

        public void Procesar()
        {
            IsAjusteOk = false;
            if (AutoDeposito.Trim() == "") 
            {
                Helpers.Msg.Error("Campo Deposito No Puede Estar Vacio");
                return;
            }

            var msg = MessageBox.Show("Guardar Ajuste ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                var fichaOOB = new OOB.LibSistema.Sucursal.AsignarDepositoPrincipal()
                {
                    auto = ficha.auto,
                    autoDepositoPrincipal = AutoDeposito,
                };
                var r01 = Sistema.MyData.Sucursal_AsignarDepositoPrincipal(fichaOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                IsAjusteOk = true;
            }
        }

    }

}