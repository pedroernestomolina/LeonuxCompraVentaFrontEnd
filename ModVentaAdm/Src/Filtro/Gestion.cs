using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Filtro
{
    
    public class Gestion
    {

        private data _data;
        private List<OOB.Sucursal.Entidad.Ficha> _lSucursal;
        private BindingSource _bsSucursal;
        private List<OOB.Sistema.TipoDocumento.Entidad.Ficha> _lTipoDoc;
        private BindingSource _bsTipoDoc;


        public data Data { get { return _data; } }
        public BindingSource SucursalSource { get { return _bsSucursal; } }
        public BindingSource TipoDocSource { get { return _bsTipoDoc; } }


        public Gestion()
        {
            _data= new data();

            _lSucursal = new List<OOB.Sucursal.Entidad.Ficha>();
            _bsSucursal = new BindingSource();
            _bsSucursal.DataSource = _lSucursal;

            _lTipoDoc = new List<OOB.Sistema.TipoDocumento.Entidad.Ficha>();
            _bsTipoDoc = new BindingSource();
            _bsTipoDoc.DataSource = _lTipoDoc;
        }


        public void Inicia()
        {
        }

        public void Inicializar()
        {
            LimpiarFiltros();
        }

        public void setFechaDesde(DateTime fecha)
        {
            _data.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _data.setFechaHasta(fecha);
        }

        public bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result ==  OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            _lSucursal.Clear();
            _lSucursal.AddRange(rt1.ListaD.OrderBy(o => o.nombre).ToList());
            _bsSucursal.CurrencyManager.Refresh();

            _lTipoDoc.Clear();
            _lTipoDoc.Add(new OOB.Sistema.TipoDocumento.Entidad.Ficha("1", "Factura", "01"));
            _lTipoDoc.Add(new OOB.Sistema.TipoDocumento.Entidad.Ficha("2", "Nota Debito","02"));
            _lTipoDoc.Add(new OOB.Sistema.TipoDocumento.Entidad.Ficha("3", "Nota Credito","03"));
            _lTipoDoc.Add(new OOB.Sistema.TipoDocumento.Entidad.Ficha("4", "Nota Entrega","04"));
            _lTipoDoc.Add(new OOB.Sistema.TipoDocumento.Entidad.Ficha("5", "Presupuesto", "05"));
            _lTipoDoc.Add(new OOB.Sistema.TipoDocumento.Entidad.Ficha("6", "Pedido", "06"));
            _bsTipoDoc.CurrencyManager.Refresh();

            return rt;
        }

        public void setSucursal(string autoId)
        {
            _data.setSucursal(_lSucursal.FirstOrDefault(f => f.auto == autoId));
        }

        public void setTipoDoc(string id)
        {
            _data.setTipoDoc(_lTipoDoc.FirstOrDefault(f => f.id == id));
        }

        public void LimpiarFiltros()
        {
            _data.Inicializar();
        }

        public OOB.Resultado.FichaEntidad<OOB.Documento.Lista.Filtro> Filtro()
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Documento.Lista.Filtro>();

            var filt = new OOB.Documento.Lista.Filtro();
            if (_data.FechaIsOk())
            {
                filt.desde = _data.Desde.Date;
                filt.hasta = _data.Hasta.Date;
            }
            else
            {
                result.Mensaje = "Fechas Incorrectas, Verifique Por Favor";
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result; ;
            }
            if (_data.Sucursal != null)
            {
                filt.codSucursal = _data.Sucursal.codigo;
            }
            if (_data.TipoDocumento != null)
            {
                filt.codTipoDocumento= _data.TipoDocumento.codigo;
            }
            result.Entidad = filt;

            return result;
        }

    }

}