using ModVentaAdm.Data.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModVentaAdm.Data.Prov
{
    
    public partial class DataPrv : IData
    {

        public OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Entidad.Ficha> Sistema_Empresa_GetFicha()
        {
            var result = new OOB.Resultado.FichaEntidad<OOB.Sistema.Empresa.Entidad.Ficha>();

            var r01 = MyData.Sistema_Empresa_GetFicha();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Resultado.Enumerados.EnumResult.isError;
                return result;
            }
            var s = r01.Entidad;
            result.Entidad = new OOB.Sistema.Empresa.Entidad.Ficha()
            {
                CiRif = s.CiRif,
                Direccion = s.Direccion,
                Nombre = s.Nombre,
                Telefono = s.Telefono,
            };

            return result;
        }

    }

}