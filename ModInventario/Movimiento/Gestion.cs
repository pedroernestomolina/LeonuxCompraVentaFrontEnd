using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModInventario.Movimiento
{

    public class Gestion
    {


        private IGestion miGestion;


        public enumerados.enumTipoMovimiento EnumTipoMovimiento { get { return miGestion.EnumTipoMovimiento; } }
        public bool IsCerrarOk { get { return miGestion.IsCerrarOk; } }
        public string TipoMovimiento { get { return miGestion.TipoMovimiento; } }
        public decimal MontoMovimiento { get { return miGestion.MontoMovimiento; } }
        public string ItemsMovimiento { get { return miGestion.ItemsMovimiento; } }
        public bool Habilitar_DepDestino { get { return miGestion.Habilitar_DepDestino; } }
        public bool VisualizarColumnaTipoMovimiento { get { return miGestion.VisualizarColumnaTipoMovimiento; } }
        public BindingSource ConceptoSource { get { return miGestion.ConceptoSource; } }
        public BindingSource SucursalSource { get { return miGestion.SucursalSource; } }
        public BindingSource DepOrigenSource { get { return miGestion.DepOrigenSource; } }
        public BindingSource DepDestinoSource { get { return miGestion.DepDestinoSource; } }
        public BindingSource DetalleSource { get { return miGestion.DetalleSouce; } }
        public string IdSucursal { get { return miGestion.IdSucursal; } set { miGestion.IdSucursal = value; } }
        public string IdConcepto { get { return miGestion.IdConcepto; } set { miGestion.IdConcepto = value; } }
        public string IdDepOrigen { get { return miGestion.IdDepOrigen; } set { miGestion.IdDepOrigen = value; } }
        public string IdDepDestino { get { return miGestion.IdDepDestino; } set { miGestion.IdDepDestino = value; } }
        public string AutorizadoPor { get { return miGestion.AutorizadoPor; } set { miGestion.AutorizadoPor = value; }  }
        public string Motivo { get { return miGestion.Motivo ; } set { miGestion.Motivo = value; } }
        public DateTime FechaMov { get { return miGestion.FechaMov; } set { miGestion.FechaMov = value; } }
        public OOB.LibInventario.Producto.Enumerados.EnumMetodoBusqueda MetodoBusqueda { get { return miGestion.MetodoBusqueda; } set { miGestion.MetodoBusqueda = value; } }
        public string CadenaBusqueda { get { return miGestion.CadenaBusqueda; } set { miGestion.CadenaBusqueda = value; } }


        public Gestion()
        {
        }


        public void setGestion(IGestion gestion) 
        {
            miGestion = gestion;
        }

        MvFrm frm;
        public void Inicia() 
        {
            miGestion.Inicia();
            Limpiar();
            if (CargarData())
            {
                if (frm == null) 
                {
                }
                frm = new MvFrm();
                frm.setControlador(this);
                frm.Show();
            }
        }

        private bool CargarData()
        {
            return miGestion.CargarData();
        }

        private void Limpiar()
        {
            miGestion.Limpiar();
        }

        public bool LimpiarVistaIsOk()
        {
            return miGestion.LimpiarVistaIsOk();
        }

        public void BuscarProducto()
        {
            miGestion.BuscarProducto();
        }

        public void EliminarItem()
        {
            miGestion.EliminarItem();
        }

        public void EditarItem()
        {
            miGestion.EditarItem();
        }

        public void Procesar()
        {
            miGestion.Procesar();
        }

        public bool AbandonarDocumento()
        {
            return miGestion.AbandonarDocumento();
        }

    }

}
