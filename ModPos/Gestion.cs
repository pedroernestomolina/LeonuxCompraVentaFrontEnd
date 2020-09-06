using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos
{

    public class Gestion
    {

        public void Inicia()
        {
            Identificacion();
            if (Sistema.Usuario != null)
            {
                Pos();
            }
        }

        private void Pos()
        {
            var _sistema = new Sistema_();
            if (_sistema.CargarData())
            {
                _sistema.Arranca();
            }
        }

        public void Identificacion()
        {
            var frm = new Identificacion.IdentificacionFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }

        public bool VerificarUsuario(string codigo, string clave)
        {
            var rt = false;

            if (codigo == "ADMINISTRADOR" && clave == "ADMIN") 
            {
                Sistema.Usuario = new OOB.LibVenta.PosOffline.Usuario.Ficha();
                Sistema.Usuario.setInvitado();
                return true;
            }

            var ficha = new OOB.LibVenta.PosOffline.Usuario.BuscarCargar()
            {
                Codigo = codigo,
                PassWord = clave,
            };
            var r01 = Sistema.MyData2.Usuario_Cargar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            rt = true;
            Sistema.Usuario = r01.Entidad;

            return rt;
        }

    }

}