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

    }

}