using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class Gestion
    {

        private IGestion _gestion;
        private GestionDocumento _gestionDoc;
        private GestionItem _gestionItem;


        //
        public string TituloDocumento { get { return _gestion.TituloDocumento; } }
        public bool SalidaOk { get { return _gestion.SalidaOk; } }
        //
        public string Proveedor { get { return _gestionDoc.Proveedor; } }
        public DateTime FechaEmision { get { return _gestionDoc.FechaEmision; } }
        public string DocumentoNro { get { return _gestionDoc.DocumentoNro; } }
        public string ControlNro { get { return _gestionDoc.ControlNro; } }
        public DateTime FechaVencimiento { get { return _gestionDoc.FechaVencimiento; } }
        public decimal FactorDivisa { get { return _gestionDoc.FactorDivisa; } }
        public string Deposito { get { return _gestionDoc.DepositoNombre; } }
        public string Sucursal { get { return _gestionDoc.SucursalNombre; } }
        public bool DatosDocumentoIsOk { get { return _gestionDoc.IsAceptarOk; } }
        //
        public BindingSource ItemSource { get { return _gestionItem.ItemSource; } }
        public decimal Total { get { return _gestionItem.TotalMonto; } }
        public decimal MontoIva { get { return _gestionItem.MontoIva; } }
        public decimal MontoDivisa { get { return _gestionItem.MontoDivisa; } }
        public int Items { get { return _gestionItem.TItems; } }
        //
        public GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get { return _gestion.MetodoBusquedaProducto; } }
        public string CadenaPrdBuscar { get { return _gestion.CadenaPrdBuscar; } set { _gestion.CadenaPrdBuscar = value; } }


        public Gestion()
        {
            _gestionDoc = new GestionDocumento();
            _gestionItem = new GestionItem();
        }


        public void setGestion(IGestion gestion) 
        {
            _gestion = gestion;
            _gestionDoc.setGestion(_gestion.GestionDoc);
            _gestionItem.setGestion(_gestion.GestionItem);
        }

        Formulario.DocumentoFrm frm;
        public void Inicia() 
        {
            _gestion.Inicializar();
            if (CargarData())
            {
                frm = new Formulario.DocumentoFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return _gestion.CargarData();
        }

        public void NuevoDocumento()
        {
            _gestionDoc.Inicia();
        }

        public void LimpiarItems()
        {
            _gestionItem.LimpiarItems();
        }

        public void EliminarItem()
        {
            _gestionItem.EliminarItem();
        }

        public void EditarItem()
        {
            _gestionItem.EditarItem();
        }

        public void BuscarProducto()
        {
            _gestion.BuscarProducto();
        }

        public void ActivarBusquedaProductoPorCodigo()
        {
            _gestion.ActivarBusquedaProductoPorCodigo();
        }

        public void ActivarBusquedaProductoPorNombre()
        {
            _gestion.ActivarBusquedaProductoPorNombre();
        }

        public void ActivarBusquedaProductoPorReferencia()
        {
            _gestion.ActivarBusquedaProductoPorReferencia();
        }

        public void Salir()
        {
            _gestion.Salir();
        }

        public void ProcesarGurdar()
        {
            _gestion.ProcesarGurdar();
        }

        public void LimpiarDocumento()
        {
            _gestion.LimpiarDocumento();
        }

    }

}