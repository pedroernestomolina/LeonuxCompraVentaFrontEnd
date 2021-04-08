using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Pos
{
    
    public class Gestion
    {

        public enum EnumModoFuncion { Facturacion = 1, NotaCredito };


        private decimal _tasaCambioActual;
        private OOB.Deposito.Entidad.Ficha _depositoAsignado;
        private EnumModoFuncion _modoFuncion;
        private bool _permitirBusquedaPorDescripcion;
        private Producto.Lista.Gestion _gestionListar;
        private Producto.Buscar.Gestion _gestionBuscar;
        private Cliente.Gestion _gestionCliente;
        private Consultor.Gestion _gestionConsultor;
        private Item.Gestion _gestionItem;
        private Devolucion.Gestion _gestionDevolucion;
        private Multiplicar.Gestion _gestionMultiplicar;


        public Decimal TasaCambioActual { get { return _tasaCambioActual; } }
        public string UsuarioActual { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }
        public string EquipoEstacion { get { return Sistema.EquipoEstacion; } }
        public string ClienteData { get { return _gestionCliente.ClienteData; } }
        public int CantItem { get { return _gestionItem.CantItem; } }
        public decimal TotalPeso { get { return _gestionItem.TotalPeso; } }
        public int CantRenglones { get { return _gestionItem.CantRenglones; } }
        public decimal Importe { get { return _gestionItem.Importe; } }
        public decimal ImporteDivisa { get { return _gestionItem.ImporteDivisa; } }
        public string ProductoNombre { get { return _gestionItem.Producto; } }
        public string ProductoTasaIva { get { return _gestionItem.PrdTasaIva; } }
        public decimal ProductoPrecioNeto { get { return _gestionItem.PrdPrecioNeto; } }
        public decimal ProductoIva { get { return _gestionItem.PrdIva; } }
        public decimal ProductoContenido { get { return _gestionItem.PrdContenido; } }

        public BindingSource ItemSource { get { return _gestionItem.ItemSource; } }
        public bool SalirIsOk 
        { 
            get 
            { 
                var rt=true;
                if (Importe > 0) { return false; }
                if (CantItem >0) { return false; }
                return rt;
            }
        }


        public Gestion()
        {
            _modoFuncion = EnumModoFuncion.Facturacion;
            _permitirBusquedaPorDescripcion = true;

            _gestionListar = new Producto.Lista.Gestion();
            _gestionBuscar = new Producto.Buscar.Gestion();
            _gestionBuscar.setGestionLista(_gestionListar);
            _gestionCliente = new Cliente.Gestion();
            _gestionConsultor = new Consultor.Gestion();
            _gestionConsultor.setGestionBuscar(_gestionBuscar);
            _gestionDevolucion = new Devolucion.Gestion();
            _gestionMultiplicar = new Multiplicar.Gestion();
            _gestionItem = new Item.Gestion();
            _gestionItem.Hnd_Item_Cambio += _gestionItem_Hnd_Item_Cambio;
            _gestionItem.setGestionMultiplicar(_gestionMultiplicar);
            _gestionItem.setGestionDevolucion(_gestionDevolucion);
        }


        private void _gestionItem_Hnd_Item_Cambio(object sender, EventArgs e)
        {
            if (frm != null) 
            {
                frm.ActualizarItem();
            }
        }

        public void Inicializa()
        {
            _tasaCambioActual = 0.0m;
        }

        PosFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new PosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_FactorDivisa();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Deposito_GetFichaById(Sistema.ConfiguracionActual.idDeposito);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var filtro = new OOB.Venta.Item.Lista.Filtro()
            {
                idOperador = Sistema.PosEnUso.id,
            };
            var r03 = Sistema.MyData.Venta_Item_GetLista(filtro);
            if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            _tasaCambioActual = r01.Entidad;
            _depositoAsignado = r02.Entidad;
            _gestionBuscar.setDepositoAsignado(_depositoAsignado);
            _gestionBuscar.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);
            _gestionConsultor.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);
            _gestionItem.Inicializar();
            _gestionItem.setDepositoAsignado(_depositoAsignado);
            _gestionItem.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);
            _gestionItem.setValidarExistencia(Sistema.ConfiguracionActual.ValidarExistencia_Activa);
            _gestionItem.setData(r03.ListaD, _tasaCambioActual);

            return rt;
        }

        public void ClienteBuscar()
        {
            _gestionCliente.Inicializa();
            _gestionCliente.Inicia();
            _gestionItem.setItemActualInicializar();
        }

        public void Consultor()
        {
            _gestionConsultor.Inicializa();
            _gestionConsultor.setFactorCambio(_tasaCambioActual);
            _gestionConsultor.Inicia();
            _gestionItem.setItemActualInicializar();
        }

        public void BuscarProducto(string cadena)
        {
            if (cadena == "") { return; }

            if (_modoFuncion == EnumModoFuncion.Facturacion)
            {
                _gestionBuscar.GestionListar.setCantidadVisible(true);
                _gestionBuscar.GestionListar.setPrecioVisible(true);
                _gestionBuscar.ActivarBusqueda(cadena, _permitirBusquedaPorDescripcion);
                if (_gestionBuscar.BusquedaIsOk)
                {
                    _gestionItem.Inicializar();
                    _gestionItem.RegistraItem(_gestionBuscar.AutoProducto);
                }
                else
                    _gestionItem.setItemActualInicializar();
            }

        }

        public void AnularVenta()
        {
            _gestionItem.Inicializar();
            _gestionItem.AnularVenta();
            if (_gestionItem.AnularVentaIsOk) 
            {
                _gestionCliente.Limpiar();
            }
            _gestionItem.setItemActualInicializar();
        }

        public void DevolucionItem()
        {
            _gestionItem.DevolucionItem();
       }

        public void IncrementarItem()
        {
            _gestionItem.Incrementar();
        }

        public void DecrementarItem()
        {
            _gestionItem.Decrementar();
        }

        public void Multiplicar()
        {
            _gestionItem.Multiplicar();
        }

    }

}