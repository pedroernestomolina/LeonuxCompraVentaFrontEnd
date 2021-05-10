using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.AdministradorDoc.Lista
{
    
    public class Gestion
    {


        private List<data> _l;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private data _docAplicarNotaCredito;
        private data _docAplicaParaAnulacion;

        public string TotItems { get { return _bs.Count.ToString().Trim(); } }
        public data DocAplicarNotaCredito { get { return _docAplicarNotaCredito; } }
        public data DocAplicaParaAulacion { get { return _docAplicaParaAnulacion; } }
        public BindingSource Source { get { return _bs; } }


        public Gestion()
        {
            _docAplicarNotaCredito = null;
            _docAplicaParaAnulacion = null;
            _l= new List<data>();
            _bl = new BindingList<data>(_l);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
        }


        public void Inicializa() 
        {
            _docAplicarNotaCredito = null;
            _docAplicaParaAnulacion = null;
        }

        public void BajarItem()
        {
            _bs.Position += 1;
        }

        public void SubirItem()
        {
            _bs.Position -= 1;
        }

        public void setData(List<OOB.Documento.Lista.Ficha> list)
        {
            _bl.Clear();
            foreach (var it in list.OrderByDescending(o=>o.FechaEmision).ThenByDescending(o=>o.Id).ToList()) 
            {
                _bl.Add(new data(it));
            }
        }

        public bool AplicaParaNotaCredito()
        {
            var rt = false;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                if (it.DocTipo == data.enumTipoDoc.Factura)
                {
                    if (!it.IsAnulado)
                    {
                        _docAplicarNotaCredito = it;
                        return true;
                    }
                    else 
                    {
                        Helpers.Msg.Error("A DOCUMENTO ANULADO NO SE PUEDE APLICAR NOTA DE CREDITO");
                    }
                }
                else 
                {
                    Helpers.Msg.Error("NO SE PUEDE APLICAR NOTA DE CREDITO A ESTE TIPO DE DOCUMENTO");
                }
            }

            return rt;
        }

        public bool AplicaParaAnular()
        {
            var rt = false;
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                if (!it.IsAnulado)
                {
                    _docAplicaParaAnulacion = it;
                    return true;
                }
                else 
                {
                    Helpers.Msg.Error("Documento Se Encuentra Ya Anulado");
                    return false;
                }
            }

            return rt;
        }

        public void setAnularDoc()
        {
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                it.setAnularDoc();
            }
            _bs.CurrencyManager.Refresh();
        }

        public void ImprimirDocumento()
        {
            if (_bs.Current != null)
            {
                var it = (data)_bs.Current;
                var xr1 = Sistema.MyData.Documento_GetById(it.idDocumento);
                if (xr1.Result == OOB.Resultado.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(xr1.Mensaje);
                    return;
                }

                var xdata = new Helpers.Imprimir.data();
                xdata.negocio = new Helpers.Imprimir.data.Negocio()
                {
                    Nombre = Sistema.DatosEmpresa.Nombre,
                    CiRif = Sistema.DatosEmpresa.CiRif,
                    Direccion = Sistema.DatosEmpresa.Direccion,
                    Telefonos = Sistema.DatosEmpresa.Telefono,
                };
                var docNombre = "";
                switch (xr1.Entidad.Tipo.Trim().ToUpper())
                {
                    case "01":
                        docNombre = "FACTURA";
                        break;
                    case "02":
                        docNombre = "NOTA DE DEBITO";
                        break;
                    case "03":
                        docNombre = "NOTA DE CREDITO";
                        break;
                    case "04":
                        docNombre = "NOTA DE ENTREGA";
                        break;
                }
                xdata.encabezado = new Helpers.Imprimir.data.Encabezado()
                {
                    CiRifCli = xr1.Entidad.CiRif,
                    DireccionCli = xr1.Entidad.DirFiscal,
                    DocumentoCondicionPago = xr1.Entidad.CondicionPago,
                    DocumentoControl = xr1.Entidad.Control,
                    DocumentoDiasCredito = xr1.Entidad.Dias,
                    DocumentoFecha = xr1.Entidad.Fecha,
                    DocumentoFechaVencimiento = xr1.Entidad.FechaVencimiento,
                    DocumentoNombre = docNombre,
                    DocumentoNro = xr1.Entidad.DocumentoNro,
                    DocumentoSerie = xr1.Entidad.Serie,
                    DocumentoAplica = xr1.Entidad.Aplica,
                    NombreCli = xr1.Entidad.RazonSocial,
                    FactorCambio=xr1.Entidad.FactorCambio,
                    SubTotal=xr1.Entidad.SubTotalNeto,
                    Descuento=xr1.Entidad.Descuento,
                    Total=xr1.Entidad.Total,
                    TotalDivisa=xr1.Entidad.MontoDivisa,
                };
                xdata.item = new List<Helpers.Imprimir.data.Item>();
                foreach (var rg in xr1.Entidad.items)
                {
                    var nr = new Helpers.Imprimir.data.Item()
                    {
                        NombrePrd = rg.Nombre,
                        CodigoPrd = rg.Codigo,
                        Cantidad = rg.Cantidad,
                        Contenido = rg.ContenidoEmpaque,
                        DepositoCodigo = rg.CodigoDeposito,
                        DepositoDesc = rg.Deposito,
                        Empaque = rg.Empaque,
                        Importe = rg.TotalNeto,
                        ImporteDivisa = rg.TotalNeto,
                        Precio = rg.PrecioItem,
                        PrecioDivisa = rg.PrecioItem,
                        TotalUnd=rg.CantidadUnd,
                    };
                    xdata.item.Add(nr);
                }

                switch (it.DocTipo)
                { 
                    case data.enumTipoDoc.Factura:
                        Sistema.ImprimirFactura.setData(xdata);
                        Sistema.ImprimirFactura.ImprimirCopiaDoc();
                        break;

                    case data.enumTipoDoc.NotaCredito:
                        Sistema.ImprimirNotaCredito.setData(xdata);
                        Sistema.ImprimirNotaCredito.ImprimirCopiaDoc();
                        break;

                    case data.enumTipoDoc.NotaEntrega:
                        Sistema.ImprimirNotaCredito.setData(xdata);
                        Sistema.ImprimirNotaCredito.ImprimirCopiaDoc();
                        break;
                }
            }
        }

    }

}