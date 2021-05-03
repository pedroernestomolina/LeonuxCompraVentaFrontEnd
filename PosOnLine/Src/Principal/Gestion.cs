using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PosOnLine.Src.Principal
{
    
    public class Gestion
    {


        private Pos.Gestion _gestionPos;
        private PassWord.Gestion _gestionPassW;
        private AdministradorDoc.Principal.Gestion _gestionDoc;
        private Anular.Gestion _gestionAnular;
        private Cierre.Gestion _gestionCierre;
        private Configuracion.Gestion _gestionCnf;


        public string BD_Ruta { get { return Sistema.Instancia; } }
        public string BD_Nombre { get { return Sistema.BaseDatos; } }
        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string JornadaActiva { get { return Sistema.PosEnUso.IsEnUso ? "ACTIVA" + Environment.NewLine + Sistema.PosEnUso.fechaApertura.ToShortDateString() + ", " + Sistema.PosEnUso.horaApertura : ""; } }
        public string OperadorActivo { get { return Sistema.PosEnUso.codUsuario + Environment.NewLine + Sistema.PosEnUso.nomUsuario; } }
        public string UsuarioActual { get { return Sistema.Usuario.codigo + Environment.NewLine + Sistema.Usuario.nombre; } }
        public string EquipoId { get { return Sistema.IdEquipo; } }
        public bool ConfiguracionIsOk { get { return Sistema.ConfiguracionActual.Estatus_Activa; } }
        public string SucursalId 
        { 
            get 
            {
                var rt = "";
                if (Sistema.Sucursal != null) 
                {
                    rt = Sistema.Sucursal.codigo+Environment.NewLine +Sistema.Sucursal.nombre;
                }
                return rt;
            }
        }


        public Gestion()
        {
            _gestionCnf = new Configuracion.Gestion();
            _gestionCierre = new Cierre.Gestion();
            _gestionAnular = new Anular.Gestion();
            _gestionDoc = new AdministradorDoc.Principal.Gestion();
            _gestionDoc.setGestionAnular(_gestionAnular);
            _gestionPassW = new PassWord.Gestion();
            _gestionPos = new Pos.Gestion();
            _gestionPos.setGestionPassW(_gestionPassW);
            Helpers.PassWord.setGestion(_gestionPassW);
        }


        public void Inicializa()
        {
        }

        PrincipalFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                frm = new PrincipalFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Jornada_EnUso_GetByIdEquipo(Sistema.IdEquipo);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            Sistema.PosEnUso = r01.Entidad;

            var r02 = Sistema.MyData.Configuracion_Pos_GetFicha();
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            Sistema.ConfiguracionActual = r02.Entidad;

            if (r02.Entidad.idSucursal != "")
            {
                var r03 = Sistema.MyData.Sucursal_GetFichaById(r02.Entidad.idSucursal);
                if (r03.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r03.Mensaje);
                    return false;
                }
                Sistema.Sucursal = r03.Entidad;
            }

            return rt;
        }

        public void AbrirPos()
        {
            if (Sistema.PosEnUso.IsEnUso)
            {
                if (Sistema.PosEnUso.idUsuario != Sistema.Usuario.id)
                {
                    Helpers.Msg.Error("USUARIO ACTUAL NO PUEDE ABRIR POS" + Environment.NewLine + "EXISTE UNA JORNADA ABIERTA DE OTRO OPERADOR");
                    return;
                }
            }
            else 
            {
                if (Sistema.Sucursal == null) 
                {
                    Helpers.Msg.Error("CONFIGURACION SISTEMA NO HA SIDO REALIZADA, VERIFIQUE");
                    return;
                }
                AbrirJornada();
            }

            if (Sistema.PosEnUso.IsEnUso) 
            {
                frm.setVisibilidad(false);
                _gestionPos.Inicializa();
                _gestionPos.Inicia();
                frm.setVisibilidad(true);
            }
        }

        private void AbrirJornada()
        {
            var ficha = new OOB.Pos.Abrir.Ficha(Sistema.Sucursal, Sistema.IdEquipo, Sistema.Usuario);
            var r01 = Sistema.MyData.Jornada_Abrir(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            var r02 = Sistema.MyData.Jornada_EnUso_GetById(r01.Id);
            if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return;
            }
            Sistema.PosEnUso = r02.Entidad;
        }

        public void AdmDocumentos()
        {
            if (Sistema.PosEnUso.IsEnUso)
            {
                _gestionDoc.Inicializa();
                _gestionDoc.Inicia();
                if (_gestionDoc.NotaCreditoIsOk)
                {
                    _gestionPos.Inicializa();
                    _gestionPos.setNotaCredito(_gestionDoc.DocAplicaNotaCredito);
                    _gestionPos.Inicia();
                }
            }
            else
            {
                Helpers.Msg.Error("NO EXISTE UNA JORNADA ABIERTA");
                return;
            }
        }

        public void CerrarPos()
        {
            if (Sistema.PosEnUso.IsEnUso)
            {
                _gestionCierre.Inicializa();
                _gestionCierre.Inicia();
            }
            else 
            {
                Helpers.Msg.Error("NO EXISTE UNA JORNADA ABIERTA");
                return;
            }
        }

        public void Test_BD()
        {
            var r01 = Sistema.MyData.Test();
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }

            Helpers.Msg.Alerta("BASE DE DATOS CONECTADA CON EXITO !!!");
        }

        public void ConfiguracionSistema()
        {
            if (Sistema.Usuario.IsInvitado)
            {
                _gestionCnf.Inicializa();
                _gestionCnf.Inicia();
                if (_gestionCnf.ConfiguracionIsOk)
                {
                    var r01 = Sistema.MyData.Configuracion_Pos_GetFicha();
                    if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    var r02 = Sistema.MyData.Sucursal_GetFichaById(r01.Entidad.idSucursal);
                    if (r02.Result == OOB.Resultado.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    Sistema.ConfiguracionActual = r01.Entidad;
                    Sistema.Sucursal = r02.Entidad;
                }
            }
        }

    }

}