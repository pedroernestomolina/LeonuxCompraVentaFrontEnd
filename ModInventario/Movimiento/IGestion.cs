using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModInventario.Movimiento
{
    
    public interface IGestion
    {


        bool IsCerrarOk { get; }
        string TipoMovimiento { get; }
        decimal MontoMovimiento { get; }
        string ItemsMovimiento { get; }
        bool Habilitar_DepDestino { get; }
        bool VisualizarColumnaTipoMovimiento { get; }
        System.Windows.Forms.BindingSource ConceptoSource { get;  }
        System.Windows.Forms.BindingSource SucursalSource { get; }
        System.Windows.Forms.BindingSource DepOrigenSource { get; }
        System.Windows.Forms.BindingSource DepDestinoSource { get; }
        System.Windows.Forms.BindingSource DetalleSouce { get; }
        string IdSucursal { get; set; }
        string IdConcepto { get; set; }
        string IdDepOrigen { get; set; }
        string IdDepDestino { get; set; }
        string AutorizadoPor { get; set; }
        string Motivo { get; set; }
        DateTime FechaMov { get; set; }
        OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda MetodoBusqueda { get; set; }
        string CadenaBusqueda { get; set; }
        enumerados.enumTipoMovimiento EnumTipoMovimiento { get; }


        void Inicia();
        bool CargarData();
        void Limpiar();
        bool LimpiarVistaIsOk();
        void BuscarProducto();
        void EliminarItem();
        void EditarItem();
        void Procesar();
        bool AbandonarDocumento();

    }

}