using DataProvSistema.Infra;
using ServiceSistema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvSistema.Data
{
    
    public partial class DataProv: IData
    {

        public static IService MyData;


        public DataProv(string instancia, string bd, string usuario="root")
        {
            MyData = new ServiceSistema.MyService.Service(instancia, bd, usuario);
        }


        public OOB.ResultadoEntidad<DateTime> FechaServidor()
        {
            var result = new OOB.ResultadoEntidad<DateTime>();

            var r01 = MyData.FechaServidor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (DateTime)r01.Entidad;

            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibSistema.Empresa.Data.Ficha> Empresa_Datos()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibSistema.Empresa.Data.Ficha>();

            var r01 = MyData.Empresa_Datos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibSistema.Empresa.Data.Ficha()
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