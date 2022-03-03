using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.MovimientoInv.AjusteInvCero
{
    
    public class Gestion: IMov
    {

        private FiltrosGen.IOpcion _gSucursal;
        private FiltrosGen.IOpcion _gConcepto;
        private FiltrosGen.IOpcion _gDepOrigen;
        private IItem _gItem;
        private string _autorizadoPor;
        private string _motivo;
        private DateTime _fechaSistema;


        public BindingSource SucursalSource { get { return _gSucursal.Source; } }
        public string SucursalGetID { get { return _gSucursal.GetId; } }
        public BindingSource ConceptoSource { get { return _gConcepto.Source; } }
        public string ConceptoGetID { get { return _gConcepto.GetId; } }
        public BindingSource DepOrigenSource { get { return _gDepOrigen.Source; } }
        public string DepOrigenGetID { get { return _gDepOrigen.GetId; } }
        public string AutoriazadoPor { get { return _autorizadoPor; } }
        public string Motivo { get { return _motivo; } }
        public DateTime FechaSistema { get { return _fechaSistema; } }
        public BindingSource ItemsSource { get { return _gItem.Source; } }
        public int CntItem { get { return _gItem.CntItem; } }
        public bool HablitarCambio { get { return CntItem==0; } }


        public Gestion(FiltrosGen.IOpcion sucursal, FiltrosGen.IOpcion concepto, FiltrosGen.IOpcion depOrigen, IItem item) 
        {
            _gSucursal = sucursal;
            _gConcepto = concepto;
            _gDepOrigen = depOrigen;
            _gItem = item;
        }


        public void Inicializa()
        {
            _autorizadoPor = "";
            _motivo = "";
            _gSucursal.Inicializa();
            _gConcepto.Inicializa();
            _gDepOrigen.Inicializa();
            _gItem.Inicializa();
        }

        private MvFrm frm;
        public void Inicia(GestionMov ctr)
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new MvFrm();
                    frm.setControlador(ctr);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Sucursal_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var lst = new List<ficha>();
            foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList()) 
            {
                lst.Add(new ficha(rg.auto, rg.codigo,rg.nombre));
            }
            _gSucursal.setData(lst);

            var r02 = Sistema.MyData.Concepto_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var lst2 = new List<ficha>();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList())
            {
                lst2.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
            }
            _gConcepto.setData(lst2);

            var r03 = Sistema.MyData.FechaServidor();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _fechaSistema = r03.Entidad.Date;

            return true;
        }

        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
            if (id.Trim() != "")
            {
                var r01 = Sistema.MyData.Deposito_GetListaBySucursal(_gSucursal.Item.codigo);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var lst = new List<ficha>();
                foreach (var rg in r01.Lista.OrderBy(o => o.nombre).ToList())
                {
                    lst.Add(new ficha(rg.auto, rg.codigo, rg.nombre));
                }
                _gDepOrigen.setData(lst);
            }
        }
        public void setConcepto(string id)
        {
            _gConcepto.setFicha(id);
        }
        public void setDepOrigen(string id)
        {
            _gDepOrigen.setFicha(id);
        }
        public void setAutorizado(string p)
        {
            _autorizadoPor = p;
        }
        public void setMotivo(string p)
        {
            _motivo = p;
        }

        public void Limpiar()
        {
            _autorizadoPor = "";
            _motivo = "";
            _gSucursal.Inicializa();
            _gConcepto.Inicializa();
            _gDepOrigen.Inicializa();
        }

        public void CapturarAplicarAjuste()
        {
            if (_gSucursal.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ SUCURSAL ] NO SELECCIONADA");
                return;
            }
            if (_gDepOrigen.Item == null)
            {
                Helpers.Msg.Alerta("CAMPO [ DEPOSITO ] NO SELECCIONADO");
                return;
            }
            CapturarInv();
        }

        private void CapturarInv()
        {
            var filtroOOB = new OOB.LibInventario.Movimiento.AjusteInvCero.Capture.Filtro()
            {
                idDeposito = _gDepOrigen.GetId,
            };
            var r01 =  Sistema.MyData.Producto_Movimiento_AjusteInventarioCero_Capture(filtroOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _gItem.setData(r01.Entidad.data.OrderBy(o=>o.nombrePrd).ToList());
        }

    }

}