using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProviderVenta.Data
{

    public partial class DataProvider : DataProviderVenta.Infra.IData
    {

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Usuario.Ficha> PosOffLine_Usuario(string usuCodigo, string usuClave)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Usuario.Ficha>();

            if (usuCodigo == "INVITADO" && usuClave == "")
            {
                var nr = new OOB.LibVenta.PosOffline.Usuario.Ficha()
                {
                    Auto = "",
                    AutoGrupo = "",
                    Codigo = "INVITADO",
                    Descripcion = "INVITADO",
                    CodigoGrupo = "",
                    DescripcionGrupo = "",
                    IsActivo = true,
                    IsInvitado=true,
                };
                rt.Entidad = nr;
            }
            else
            {
                if (usuCodigo == "CAJA1T1" && usuClave == "123")
                {
                    var nr = new OOB.LibVenta.PosOffline.Usuario.Ficha()
                    {
                        Auto = "0000000021",
                        AutoGrupo = "0000000004",
                        Codigo = "CAJA1T1",
                        Descripcion = "CAJA1T1",
                        CodigoGrupo = "",
                        DescripcionGrupo = "OPERADOR",
                        IsActivo = true,
                    };
                    rt.Entidad = nr;
                }
                else 
                {
                    rt.Mensaje = "USUARIO NO IDENTIFICADO";
                    rt.Result= OOB.Enumerados.EnumResult.isError;
                }
            }

            return rt;
        }

    }

}