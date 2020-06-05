using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.ClaveSeguridad
{
    
    public class Seguridad
    {


        public bool SolicitarClave() 
        {
            var rt = false;

            Helpers.Sonido.ClvaeAcceso();
            var frm = new SeguridadFrm();
            frm.ShowDialog();
            var clv=frm.Clave.Trim().ToUpper();
            if (clv != "")
            {
                var r01 = Sistema.MyData2.Configuracion_ClavePos();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return rt; ;
                }

                if (clv == r01.Entidad.Clave.Trim().ToUpper())
                {
                    rt = true;
                }
                else 
                {
                    Helpers.Msg.Error("CLAVE INCORRECTA !!!");
                }
            }
            else 
            {
                Helpers.Msg.Error("CLAVE INCORRECTA !!!");
            }

            return rt;
        }

    }

}