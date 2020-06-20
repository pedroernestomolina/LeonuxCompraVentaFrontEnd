using DataProvPosOffLine.InfraEstructura;
using ServicePosOffLine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{

    public partial class DataProv: IData
    {
        
        public static IService MyData;

        
        public DataProv(string pathDB) 
        {
            MyData = new ServicePosOffLine.MyService.Service(pathDB);
        }

        public void setServidorRemoto(string instancia, string basedatos)
        {
            MyData.setServidorRemoto(instancia, basedatos);
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

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Sistema.InformacionBD.Ficha> InformacionBD()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Sistema.InformacionBD.Ficha>();

            var r01 = MyData.InformacionBD();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var nr = new OOB.LibVenta.PosOffline.Sistema.InformacionBD.Ficha()
            {
                LocalBD = r01.Entidad.BD_Local,
                RemotoBD = r01.Entidad.BD_Remota,
            };
            result.Entidad = nr;

            return result;
        }

        public OOB.Resultado Inicializar_BdLocal()
        {
            var result = new OOB.Resultado();

            var r01 = MyData.Inicializar_BdLocal ();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            return result;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Empresa.Ficha> Empresa_Datos()
        {
            var result = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Empresa.Ficha>();

            var r01 = MyData.Empresa_Datos();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            var nr = new OOB.LibVenta.PosOffline.Empresa.Ficha()
            {
                Auto = r01.Entidad.Auto,
                CiRif = r01.Entidad.CiRif,
                Nombre = r01.Entidad.Nombre,
                DireccionFiscal = r01.Entidad.DireccionFiscal,
                Telefono = r01.Entidad.Telefono,
            };
            result.Entidad = nr;

            return result;
        }

    }

}