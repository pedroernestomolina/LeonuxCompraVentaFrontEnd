using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PosOnLine.Helpers
{

    public class PassWord
    {

        private static Src.PassWord.Gestion _gestion;
        private static string _clave;


        public PassWord()
        {
            _clave = "";
        }


        static public void setGestion(Src.PassWord.Gestion gestion)
        {
            _gestion = gestion;
        }

        static public void setClave(string clave) 
        {
            _clave = clave;
        }

        public static bool PassWIsOk(string funcion)
        {
            var rt = true;

            if (funcion == "") 
            {
                Helpers.Sonido.ClvaeAcceso();
                _gestion.Inicializa();
                _gestion.Inicia();
                if (_gestion.Clave != Sistema.CLAVE_ADMINISTRADOR)
                {
                    Helpers.Msg.Error("CLAVE INCORRECTA");
                    return false;
                }
                return true;
            }

            var ficha = new OOB.Permiso.Buscar.Ficha() { IdGrupoUsuario = Sistema.Usuario.idGrupo, CodigoFuncion = funcion };
            var r01 = Sistema.MyData.Permiso_Pos(ficha);
            if (r01.Result == OOB.Resultado.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            if (r01.Entidad.permisoHabilitado)
            {
                if (r01.Entidad.requiereClave)
                {
                    Helpers.Sonido.ClvaeAcceso();
                    _gestion.Inicializa();
                    _gestion.Inicia();
                    if (_gestion.Clave != _clave.Trim().ToUpper())
                    {
                        Helpers.Msg.Error("CLAVE INCORRECTA");
                        return false;
                    }
                }
            }
            else
            {
                Helpers.Msg.Error("PERMISO HO HABILITADO");
                rt = false;
            }

            return rt;
        }

    }

}