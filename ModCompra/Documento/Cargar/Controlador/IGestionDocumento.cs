using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestionDocumento
    {

        string CadenaBuscar { get; set; }
        string DocumentoNro { get; set; }
        string ControlNro { get; set; }
        string OrdenCompraNro { get; set; }
        int DiasCredito { get; set; }
        decimal FactorDivisa { get; set; }
        DateTime FechaEmision { get; set; }
        string Notas { get; set; }
        string IdSucursal { get; set; }
        string IdDeposito { get; set; }
        string MesRelacion { get; }
        string AnoRelacion { get; }
        DateTime FechaVencimiento { get; }
        string RifProveedor { get; }
        string RazonSocialProveedor { get; }
        string DireccionProveedor { get; }
        System.Windows.Forms.BindingSource SucursalSource { get; }
        System.Windows.Forms.BindingSource DepositoSource { get; }
        Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda PreferenciaBusquedaProveedor { get; }
        bool IsAceptarOk { get; }
        bool ProveedorIsOk { get; set; }
        bool LimpiarDatosIsOk { get; set; }


        bool CargarData();
        void Aceptar();
        void setMetodoBusqueda(Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda metodo);
        void BuscarProveedor();
        void LimpiarDatos();

    }

}