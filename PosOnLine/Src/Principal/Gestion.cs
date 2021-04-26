using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Src.Principal
{
    
    public class Gestion
    {


        private Pos.Gestion _gestionPos;
        private PassWord.Gestion _gestionPassW;
        private AdministradorDoc.Principal.Gestion _gestionDoc;
        private Anular.Gestion _gestionAnular;
        private Cierre.Gestion _gestionCierre;


        public Gestion()
        {
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
        }

        public void CerrarPos()
        {
            _gestionCierre.Inicializa();
            _gestionCierre.Inicia();
        }

    }

}