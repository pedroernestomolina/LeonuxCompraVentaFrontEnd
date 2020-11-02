using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibCompra.Empresa.Data.Ficha> Empresa_Datos()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Empresa.Data.Ficha>();

            var r01 = MyData.Empresa_Datos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Empresa.Data.Ficha()
            {
                CiRif = s.CiRif,
                DireccionFiscal = s.DireccionFiscal,
                Nombre = s.Nombre,
                Telefono = s.Telefono,
            };
            result.Entidad = nr;

            return result;
        }

    }

}