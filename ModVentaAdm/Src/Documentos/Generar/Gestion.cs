using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModVentaAdm.Src.Documentos.Generar
{
    
    public class Gestion
    {


        private IDocGestion _docGestion;
        private DatosDocumento.Gestion _datosDocGestion;
        private Cliente.Visualizar.Gestion _visualCliente;
        private Cliente.Documentos.Gestion _visualClienteDoc;
        private Cliente.Articulos.Gestion _visualClienteArticulos;
        private Items.Gestion _items;


        public string TipoDocumento { get { return _docGestion.TipoDocumento; } }
        public bool AbandonarDocIsOk { get { return _docGestion.AbandonarDocIsOk; } }
        public string Monto { get { return "Bs "+_items.MontoTotal.ToString("n2"); } }
        public string MontoDivisa { get { return "$ " + _items.MontoTotalDivisa.ToString("n2"); } }
        public string MontoNeto { get { return "Bs "+_items.MontoNeto.ToString("n2"); } }
        public string MontoIva { get { return "Bs "+_items.MontoIva.ToString("n2"); } }
        public string RifCliente { get { return _datosDocGestion.ClienteRif; } }
        public string CodigoCliente { get { return _datosDocGestion.ClienteCodigo; } }
        public string Cliente { get { return _datosDocGestion.ClienteRazonSocialDireccion; } }
        public BindingSource ItemsSource { get { return _items.ItemsSource; } }
        

        public Gestion() 
        {
            _items = new Items.Gestion();
            _datosDocGestion = new DatosDocumento.Gestion();
            _visualCliente = new Cliente.Visualizar.Gestion();
            _visualClienteDoc = new Cliente.Documentos.Gestion();
            _visualClienteArticulos = new Cliente.Articulos.Gestion();
        }


        public void Inicializa() 
        {
            _datosDocGestion.Inicializa();
            _docGestion.Inicializa();
            _items.Inicializa();
        }

        private DocGenerarFrm _frm;
        public void Inicia() 
        {
            if (_docGestion.CargarData()) 
            {
                _items.setDivisa(_docGestion.TasaDivisa);

                if (_frm == null) 
                {
                    _frm = new DocGenerarFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }

        public void setDocGestion(IDocGestion doc)
        {
            _docGestion = doc;
        }

        public void AbandonarDoc()
        {
            _docGestion.AbandonarDoc();
        }

        public void NuevoDocumento()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                return;
            }
            _datosDocGestion.Inicializa();
            _datosDocGestion.setHabilitarDeposito(!_items.HayItemsEnBandeja);
            _datosDocGestion.setHabilitarDatosDoc(_docGestion.HabilitarDatosDoc);
            _datosDocGestion.Inicia();
        }

        public void EditarDatosDocumento()
        {
            if (!_datosDocGestion.AceptarDatosIsOK)
            {
                return;
            }
            _datosDocGestion.setHabilitarDeposito(!_items.HayItemsEnBandeja);
            _datosDocGestion.Inicia();
        }

        public void LimpiarDatosDocumento()
        {
            if (_items.HayItemsEnBandeja)
            {
                Helpers.Msg.Error("DATOS DEL DOCUMENTO EN CUESTION NO PUEDEN SER LIMPIADOS");
                return;
            }

            var msg = "Estas Seguro De Limpiar Datos de Encabezado Del Documento ?";
            var r = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r== DialogResult.Yes)
            {
                _datosDocGestion.Limpiar();
            }
        }

        public void VisualizarCliente()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                _visualCliente.Inicializa();
                _visualCliente.setFicha(_datosDocGestion.EntidadCliente);
                _visualCliente.Inicia();
            }
        }

        public void VisualizarClenteDoc()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                var fecha = DateTime.Now.Date;
                var filtroOOB = new OOB.Maestro.Cliente.Documento.Filtro()
                {
                    desde = fecha.AddDays(-120),
                    hasta = fecha,
                    autoCliente = _datosDocGestion.EntidadCliente.id,
                };
                var r01 = Sistema.MyData.Cliente_Documentos_GetLista(filtroOOB);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                _visualClienteDoc.Inicializa();
                _visualClienteDoc.setCliente(_datosDocGestion.EntidadCliente);
                _visualClienteDoc.setLista(r01.ListaD);
                _visualClienteDoc.Inicia();
            }
        }

        public void VisualizarClienteArticulos()
        {
            if (_datosDocGestion.AceptarDatosIsOK)
            {
                var fecha = DateTime.Now.Date;
                var filtroOOB = new OOB.Maestro.Cliente.Articulos.Filtro()
                {
                    desde = fecha.AddDays(-120),
                    hasta = fecha,
                    autoCliente = _datosDocGestion.EntidadCliente.id,
                };
                var r01 = Sistema.MyData.Cliente_ArticulosVenta_GetLista(filtroOOB);
                if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _visualClienteArticulos.Inicializa();
                _visualClienteArticulos.setCliente(_datosDocGestion.EntidadCliente);
                _visualClienteArticulos.setLista(r01.ListaD);
                _visualClienteArticulos.Inicia();
            }
        }

        public void AgregarItem()
        {
            if (!_datosDocGestion.AceptarDatosIsOK) 
            {
                Helpers.Msg.Alerta("DEBES PRIMERO HACER CLICK EN NUEVO DOCUMENTO");
                return;
            }
            _items.AgregarItem();
        }

        public void LimpiarItems()
        {
            _items.LimpiarItems();
        }

        public void EliminarItem()
        {
            _items.EliminarItem();
        }

    }

}