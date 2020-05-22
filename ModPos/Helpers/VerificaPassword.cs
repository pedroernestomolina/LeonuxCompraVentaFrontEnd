using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModPos.Helpers
{
    
    public class VerificaPassword
    {

        static public bool Verificar()
        {
            var rt = true;

            var frmSeguridad = new ClaveSeguridad.SeguridadFrm();
            frmSeguridad.ShowDialog();
            if (frmSeguridad.Clave != "")
            {
                //var r01 = Sistema.MyData.PosOffLine_ClaveSeguridad();
                //if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                //{
                //    Helpers.Msg.Error(r01.Mensaje);
                //    return false;
                //}
                //if (r01.Entidad.Trim().ToUpper()!=frmSeguridad.Clave)
                //{
                //    Helpers.Msg.Error("CLAVE INCORRECTA...");
                //    return false;
                //}
            }

            return rt;
        }

    }

}
