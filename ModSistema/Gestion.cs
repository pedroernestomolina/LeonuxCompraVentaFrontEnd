using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModSistema
{

    public class Gestion
    {


        private SucursalGrupo.Gestion _gestionSucGrupo;
        private Sucursal.Gestion _gestionSuc;
        private Deposito.Gestion _gestionDep;
        private Precio.Gestion _gestionPrecio;
        private UsuarioGrupo.Gestion _gestionUsuarioGrupo;
        private Usuario.Gestion _gestionUsuario;
        private SucursalDeposito.Gestion _gestionSucDep;
        private Servicio.Gestion _gestionServicio;
        private TasaDivisa.Gestion _gestionTasaDivisa;
        private Maestros.Gestion _gestionMaestro;
        private ReconversionMonetaria.Gestion _gestionRecMon;
        private DatosNegocio.Editar.Gestion _gestionDatosNegocio;
        private IGestion _gConfModulo;


        public string Host 
        {
            get 
            {
                return Sistema.Host; 
            }
        }

        public string Version 
        {
            get 
            {
                return "Ver. " + Application.ProductVersion; 
            }
        }

        public string Usuario
        {
            get
            {
                var rt = "";
                rt = Sistema.UsuarioP.codigo +
                    Environment.NewLine + Sistema.UsuarioP.nombre +
                    Environment.NewLine + Sistema.UsuarioP.grupo;
                return rt;
            }
        }


        public Gestion()
        {
            _gestionSucGrupo = new SucursalGrupo.Gestion();
            _gestionSuc = new Sucursal.Gestion();
            _gestionDep = new Deposito.Gestion();
            _gestionPrecio = new Precio.Gestion();
            _gestionUsuarioGrupo = new UsuarioGrupo.Gestion();
            _gestionUsuario = new Usuario.Gestion();
            _gestionSucDep = new SucursalDeposito.Gestion();
            _gestionServicio = new Servicio.Gestion();
            _gestionTasaDivisa = new TasaDivisa.Gestion();
            _gestionMaestro = new Maestros.Gestion();
            _gestionRecMon = new ReconversionMonetaria.Gestion();
            _gestionDatosNegocio = new DatosNegocio.Editar.Gestion();
            //
            _gConfModulo = new Configuracion.Modulo.Gestion();
        }


        public void Inicia() 
        {
            var frm = new Form1();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public void MaestroSucursalGrupo()
        {
            var r00 = Sistema.MyData.Permiso_ControlSucursalGrupo(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionSucGrupo.Inicia();
            }
        }

        public void MaestroSucursales()
        {
            var r00 = Sistema.MyData.Permiso_ControlSucursal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionSuc.Inicia();
            }
        }


        public  void MaestroDepositos()
        {
            var r00 = Sistema.MyData.Permiso_ControlDeposito(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionDep.Inicia();
            }
        }

        public void EtiquetarPrecios()
        {
            var r00 = Sistema.MyData.Permiso_EtiquetaParaPrecios(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionPrecio.Inicia();
            }
        }

        public void AsignarDepositoPrincipalASucursal()
        {
            var r00 = Sistema.MyData.Permiso_AsignarDepositoSucursal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionSucDep.Inicia();
            }
        }

        public void MaestroUsuariosGrupo()
        {
            var r00 = Sistema.MyData.Permiso_ControlUsuarioGrupo(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionUsuarioGrupo.Inicializa();
                _gestionUsuarioGrupo.Inicia();
            }
        }

        public void MaestroUsuarios()
        {
            var r00 = Sistema.MyData.Permiso_ControlUsuario(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionUsuario.Inicializa();
                _gestionUsuario.Inicia();
            }
        }

        public void InicializarBD()
        {
            var r00 = Sistema.MyData.Permiso_InicializarBD(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionServicio.IniciaBD();
            }
        }

        public void InicializarBD_Sucursal()
        {
            var r00 = Sistema.MyData.Permiso_InicializarBD_Sucursal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionServicio.IniciaBD_Sucursal();
            }
        }

        public void TasaRecepcionDivisaPos()
        {
            var r00 = Sistema.MyData.Permiso_AjustarTasaDivisaRecepcionPos(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var gestion = new TasaDivisa.Pos.Gestion();
                _gestionTasaDivisa.setGestion(gestion);
                _gestionTasaDivisa.Inicia();
            }
        }

        public void TasaDivisa()
        {
            var r00 = Sistema.MyData.Permiso_AjustarTasaDivisa(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var gestion = new TasaDivisa.Sist.Gestion();
                _gestionTasaDivisa.setGestion(gestion);
                _gestionTasaDivisa.Inicia();
            }
        }

        public void Vendedor()
        {
            var r00 = Sistema.MyData.Permiso_ControlVendedor(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _gestionVend = new Maestros.Vendedor.Gestion();
                _gestionMaestro.setGestion(_gestionVend);
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
       }

        public void Cobrador()
        {
            var r00 = Sistema.MyData.Permiso_ControlCobrador(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _gestionCob = new Maestros.Cobrador.Gestion();
                _gestionMaestro.setGestion(_gestionCob);
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
        }

        public void SeriesFiscal()
        {
            var r00 = Sistema.MyData.Permiso_ControlSerieFiscal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                var _gestionSF= new Maestros.SerieFiscal.Gestion();
                _gestionMaestro.setGestion(_gestionSF);
                _gestionMaestro.Inicializa();
                _gestionMaestro.Inicia();
            }
        }

        public void ReconversionMonetaria()
        {
            var r01 = Sistema.MyData.ReconversionMonetaria_GetCount();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            var cnt=r01.Entidad;
            if ( cnt>= 1) 
            {
                Helpers.Msg.Error("PROCESO DE RECONVERSION MONETARIA YA REALIZADO"+Environment.NewLine+"VERIFIQUE POR FAVOR...");
                return;
            }

            _gestionRecMon.Inicializa();
            _gestionRecMon.setFactorReconversion(1000000);
            _gestionRecMon.Inicia();
        }

        public void DatosDelNegocio()
        {
            var r00 = Sistema.MyData.Permiso_ControlSerieFiscal(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionDatosNegocio.Inicializa();
                _gestionDatosNegocio.Inicia();
            }
        }

        public void ConfiguracionModulo()
        {
            var r00 = Sistema.MyData.Permiso_ConfiguracionSistema(Sistema.UsuarioP.autoGrupo);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gConfModulo.Inicializa();
                _gConfModulo.Inicia();
            }
        }

    }

}