using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.ArticulosCompra
{
    
    public class Gestion
    {


        private string _autoProv;
        private OOB.LibCompra.Proveedor.Data.Ficha _proveedor;
        private BindingSource _bs;
        private Filtro _filtro;
        private List<data> _ldata;


        public string Proveedor { get { return _proveedor.RifNombrePrv; } }
        public BindingSource Source { get { return _bs; } }
        public DateTime Desde { get { return _filtro.desde; } }
        public DateTime Hasta { get { return _filtro.hasta; } }


        public Gestion()
        {
            _autoProv = "";
            _filtro = new Filtro();
            _ldata= new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _ldata;
        }


        public void Inicializa()
        {
            _autoProv = "";
            _proveedor = null;
            _filtro.Limpiar();
        }

        public void setProveedor(OOB.LibCompra.Proveedor.Data.Ficha Item)
        {
            _autoProv = Item.autoId;
        }


        CompraArticulosFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CompraArticulosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Proveedor_GetFicha(_autoProv);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _proveedor = r01.Entidad;
            _filtro.setProveedor(r01.Entidad.autoId);

            return rt;
        }

        public void setDesde(DateTime fecha)
        {
            _filtro.setDesde(fecha);
        }

        public void setHasta(DateTime fecha)
        {
            _filtro.setHasta(fecha);
        }

        public void Buscar()
        {
            if (_filtro.IsOk()) 
            {
                var filtroOOB = new OOB.LibCompra.Proveedor.Articulos.Filtro()
                {
                    desde = _filtro.desde,
                    hasta = _filtro.hasta,
                    autoProv = _filtro.autoProveedor,
                };
                var r01 = Sistema.MyData.Proveedor_ArticulosComprados_GetLista(filtroOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _ldata.Clear();
                foreach(var it in r01.Lista)
                {
                    var nr = new data(it);
                    _ldata.Add(nr);
                }
                _bs.CurrencyManager.Refresh();
            }
        }

        public void Limpiar()
        {
            _filtro.Limpiar();
            _filtro.setProveedor(_proveedor.autoId);
            _ldata.Clear();
            _bs.CurrencyManager.Refresh();
        }

    }

}