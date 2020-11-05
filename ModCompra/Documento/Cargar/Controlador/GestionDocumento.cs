using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class GestionDocumento
    {

        private IGestionDocumento _gestion;


        public string DocumentoNro { get { return _gestion.DocumentoNro; } set { _gestion.DocumentoNro = value; } }
        public DateTime FechaEmision { get { return _gestion.FechaEmision; } set { _gestion.FechaEmision = value; } }
        public string ControlNro { get { return _gestion.ControlNro; } set { _gestion.ControlNro = value; } }
        public int DiasCredito { get { return _gestion.DiasCredito; } set { _gestion.DiasCredito = value; } }
        public string OrdenCompraNro { get { return _gestion.OrdenCompraNro; } set { _gestion.OrdenCompraNro = value; } }
        public decimal FactorDivisa { get { return _gestion.FactorDivisa; } set { _gestion.FactorDivisa = value; } }
        public string Notas { get { return _gestion.Notas; } set { _gestion.Notas = value; } }
        public string IdSucursal { get { return _gestion.IdSucursal; } set { _gestion.IdSucursal = value; } }
        public string IdDeposito { get { return _gestion.IdDeposito; } set { _gestion.IdDeposito = value; } } 
        public string MesRelacion { get { return _gestion.MesRelacion; } }
        public string AnoRelacion { get { return _gestion.AnoRelacion; } }
        public string RifProveedor { get { return _gestion.RifProveedor; } }
        public string RazonSocialProveedor { get { return _gestion.RazonSocialProveedor; } }
        public string DireccionProveedor { get { return _gestion.DireccionProveedor; } } 
        public DateTime FechaVencimiento { get { return _gestion.FechaVencimiento; } }
        public BindingSource SucursalSource { get { return _gestion.SucursalSource; } }
        public BindingSource DepositoSource { get { return _gestion.DepositoSource; } }
        public Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda PreferenciaBusquedaProveedor { get { return _gestion.PreferenciaBusquedaProveedor; } }
        public bool IsAceptarOk { get { return _gestion.IsAceptarOk; } }


        Formulario.DatosDocumentoFrm frm;
        public void Inicia()
        {
            if (_gestion.CargarData())
            {
                if (frm == null)
                {
                    frm = new Formulario.DatosDocumentoFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setGestion(IGestionDocumento gestion) 
        {
            _gestion = gestion;
        }

        public void Aceptar()
        {
            _gestion.Aceptar();
        }

    }

}