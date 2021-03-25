using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Pos
{
    
    public class Gestion
    {

        private decimal _tasaCambioActual;
        private OOB.Deposito.Entidad.Ficha _depositoAsignado;
        private Producto.Lista.Gestion _gestionListar;
        private Producto.Buscar.Gestion _gestionBuscar;
        private Cliente.Gestion _gestionCliente;
        private Consultor.Gestion _gestionConsultor;


        public Decimal TasaCambioActual { get { return _tasaCambioActual; } }
        public string UsuarioActual { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }
        public string EquipoEstacion { get { return Sistema.EquipoEstacion; } }
        public string ClienteData { get { return _gestionCliente.ClienteData; } }


        public Gestion()
        {
            _gestionListar = new Producto.Lista.Gestion();
            _gestionBuscar = new Producto.Buscar.Gestion();
            _gestionBuscar.setGestionLista(_gestionListar);
            _gestionCliente = new Cliente.Gestion();
            _gestionConsultor = new Consultor.Gestion();
            _gestionConsultor.setGestionBuscar(_gestionBuscar);
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
            _tasaCambioActual= r01.Entidad;

            var r02 = Sistema.MyData.Deposito_GetFichaById(Sistema.ConfiguracionActual.idDeposito);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            _depositoAsignado = r02.Entidad;
            _gestionBuscar.setDepositoAsignado(_depositoAsignado);
            _gestionBuscar.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);
            _gestionConsultor.setTarifaPrecio(Sistema.ConfiguracionActual.idPrecioManejar);

            return rt;
        }

        public void ClienteBuscar()
        {
            _gestionCliente.Inicializa();
            _gestionCliente.Inicia();
        }

        public void Consultor()
        {
            _gestionConsultor.Inicializa();
            _gestionConsultor.setFactorCambio(_tasaCambioActual);
            _gestionConsultor.Inicia();
        }

    }

}