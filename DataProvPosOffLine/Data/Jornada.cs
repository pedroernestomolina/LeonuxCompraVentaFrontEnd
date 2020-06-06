using DataProvPosOffLine.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvPosOffLine.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<int> Jornada_Activa()
        {
            var rt = new OOB.ResultadoEntidad<int>();

            var r01 = MyData.Jornada_Activa();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            rt.Entidad = r01.Entidad;
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Jornada.Cargar.Ficha> Jornada_Cargar(int idJornada)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibVenta.PosOffline.Jornada.Cargar.Ficha>();

            var r01 = MyData.Jornada_Cargar(idJornada);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var c = r01.Entidad;
            var nr = new OOB.LibVenta.PosOffline.Jornada.Cargar.Ficha()
            {
                Id = c.Id,
                Estatus = (OOB.LibVenta.PosOffline.Jornada.Enumerado.EnumEstatus)c.Estatus,
                EstatusTransmicion = (OOB.LibVenta.PosOffline.Jornada.Enumerado.EnumEstatusTrasmicion)c.EstatusTransmicion,
                FechaApertura = c.FechaApertura,
                FechaCierre = c.FechaCierre,
                HoraApertura = c.HoraApertura,
                HoraCierre = c.HoraCierre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoId Jornada_Abrir(OOB.LibVenta.PosOffline.Jornada.Abrir.Ficha ficha)
        {
            var rt = new OOB.ResultadoId();

            var agregarDTO = new DtoLibPosOffLine.Jornada.Abrir.Ficha()
            {
                Fecha = ficha.Fecha.ToShortDateString(),
                Hora = ficha.Hora,
                Estatus = ficha.Estatus,
            };
            var r01 = MyData.Jornada_Abrir(agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Id = r01.Id;

            return rt;
        }

        public OOB.Resultado Jornada_Cerrar(OOB.LibVenta.PosOffline.Jornada.Cerrar.Ficha ficha)
        {
            var rt = new OOB.Resultado();

            var agregarDTO = new DtoLibPosOffLine.Jornada.Cerrar.Ficha()
            {
                IdJornada=ficha.IdJornada,
                Fecha = ficha.Fecha.ToShortDateString(),
                Hora = ficha.Hora,
                Estatus = ficha.Estatus,
            };
            var r01 = MyData.Jornada_Cerrar(agregarDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}